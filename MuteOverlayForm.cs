using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MicMute
{
    public partial class MuteOverlayForm : Form
    {
        private readonly RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\MicMute");
        private readonly string registryOverlayX = "OverlayX";
        private readonly string registryOverlayY = "OverlayY";
        private Timer autoHideTimer;
        private Label statusLabel;
        private PictureBox iconBox;

        public MuteOverlayForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadPosition();
        }

        private void InitializeCustomComponents()
        {
            // 窗体设置 - 不可点击穿透
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Size = new Size(250, 80);
            this.Opacity = 0.9;

            // 设置窗口样式为透明穿透（不可点击）
            int initialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);

            // 图标
            iconBox = new PictureBox
            {
                Size = new Size(48, 48),
                Location = new Point(15, 16),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.Controls.Add(iconBox);

            // 状态标签
            statusLabel = new Label
            {
                AutoSize = false,
                Size = new Size(170, 60),
                Location = new Point(70, 10),
                Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent
            };
            this.Controls.Add(statusLabel);

            // 自动隐藏计时器
            autoHideTimer = new Timer();
            autoHideTimer.Interval = 3000; // 3秒
            autoHideTimer.Tick += AutoHideTimer_Tick;
        }

        // Windows API 用于设置窗口穿透
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public void LoadPosition()
        {
            try
            {
                var x = registryKey.GetValue(registryOverlayX);
                var y = registryKey.GetValue(registryOverlayY);

                if (x != null && y != null)
                {
                    this.Location = new Point((int)x, (int)y);
                }
                else
                {
                    // 默认位置：屏幕右上角
                    this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 20, 20);
                }
            }
            catch
            {
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 20, 20);
            }
        }

        public void SavePosition(Point position)
        {
            this.Location = position;
            registryKey.SetValue(registryOverlayX, position.X);
            registryKey.SetValue(registryOverlayY, position.Y);
        }

        public void ShowMuted()
        {
            autoHideTimer.Stop();
            statusLabel.Text = "麦克风已静音";
            statusLabel.ForeColor = Color.FromArgb(255, 100, 100);
            
            try
            {
                iconBox.Image = Properties.Resources.microphone_off;
            }
            catch
            {
                // 如果图标资源不存在，使用默认图标
            }

            if (!this.Visible)
            {
                this.Show();
            }
        }

        public void ShowUnmuted()
        {
            statusLabel.Text = "麦克风已开启";
            statusLabel.ForeColor = Color.FromArgb(100, 255, 100);
            
            try
            {
                iconBox.Image = Properties.Resources.microphone_black_shape;
            }
            catch
            {
                // 如果图标资源不存在，使用默认图标
            }

            this.Show();
            autoHideTimer.Stop();
            autoHideTimer.Start();
        }

        public void ShowPreview()
        {
            statusLabel.Text = "悬浮窗预览";
            statusLabel.ForeColor = Color.FromArgb(100, 200, 255);
            
            try
            {
                iconBox.Image = Properties.Resources.microphone_black_shape;
            }
            catch
            {
                // 如果图标资源不存在，使用默认图标
            }

            this.Show();
        }

        private void AutoHideTimer_Tick(object sender, EventArgs e)
        {
            autoHideTimer.Stop();
            this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            base.OnFormClosing(e);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // WS_EX_TRANSPARENT = 0x20, WS_EX_LAYERED = 0x80000
                cp.ExStyle |= 0x80000 | 0x20;
                return cp;
            }
        }
    }
}
