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
        private readonly string registryOverlayBgColor = "OverlayBgColor";
        private readonly string registryOverlayMutedTextColor = "OverlayMutedTextColor";
        private readonly string registryOverlayUnmutedTextColor = "OverlayUnmutedTextColor";
        private Timer previewTimer;
        private Timer topMostTimer;
        private Label statusLabel;
        private PictureBox iconBox;
        
        // 默认颜色
        private Color backgroundColor = Color.FromArgb(240, 240, 240); // #F0F0F0
        private Color mutedTextColor = Color.FromArgb(255, 69, 0); // 橘红色
        private Color unmutedTextColor = Color.FromArgb(0, 200, 0); // 绿色

        public MuteOverlayForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadPosition();
        }

        private void InitializeCustomComponents()
        {
            // 加载自定义颜色
            LoadColors();
            
            // 窗体设置 - 不可点击穿透
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.BackColor = backgroundColor;
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
                ForeColor = mutedTextColor,
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent
            };
            this.Controls.Add(statusLabel);

            // 预览自动隐藏计时器
            previewTimer = new Timer();
            previewTimer.Interval = 5000; // 5秒
            previewTimer.Tick += PreviewTimer_Tick;

            // TopMost 保持计时器
            topMostTimer = new Timer();
            topMostTimer.Interval = 1000; // 每秒检查一次
            topMostTimer.Tick += TopMostTimer_Tick;
        }
        
        private void LoadColors()
        {
            try
            {
                // 加载背景颜色
                var bgColor = registryKey.GetValue(registryOverlayBgColor);
                if (bgColor != null)
                {
                    backgroundColor = ColorTranslator.FromHtml(bgColor.ToString());
                }
                
                // 加载静音文字颜色
                var mutedColor = registryKey.GetValue(registryOverlayMutedTextColor);
                if (mutedColor != null)
                {
                    mutedTextColor = ColorTranslator.FromHtml(mutedColor.ToString());
                }
                
                // 加载非静音文字颜色
                var unmutedColor = registryKey.GetValue(registryOverlayUnmutedTextColor);
                if (unmutedColor != null)
                {
                    unmutedTextColor = ColorTranslator.FromHtml(unmutedColor.ToString());
                }
            }
            catch
            {
                // 使用默认颜色
            }
        }
        
        public void SaveColors(string bgColor, string mutedColor, string unmutedColor)
        {
            try
            {
                backgroundColor = ColorTranslator.FromHtml(bgColor);
                mutedTextColor = ColorTranslator.FromHtml(mutedColor);
                unmutedTextColor = ColorTranslator.FromHtml(unmutedColor);
                
                registryKey.SetValue(registryOverlayBgColor, bgColor);
                registryKey.SetValue(registryOverlayMutedTextColor, mutedColor);
                registryKey.SetValue(registryOverlayUnmutedTextColor, unmutedColor);
                
                this.BackColor = backgroundColor;
            }
            catch
            {
                // 忽略错误
            }
        }
        
        public string GetBackgroundColor()
        {
            return ColorTranslator.ToHtml(backgroundColor);
        }
        
        public string GetMutedTextColor()
        {
            return ColorTranslator.ToHtml(mutedTextColor);
        }
        
        public string GetUnmutedTextColor()
        {
            return ColorTranslator.ToHtml(unmutedTextColor);
        }

        // Windows API 用于设置窗口穿透
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        // Windows API 用于强制置顶
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_SHOWWINDOW = 0x0040;

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
            previewTimer.Stop();
            statusLabel.Text = "麦克风已静音";
            statusLabel.ForeColor = mutedTextColor;

            // 使用托盘图标（橘红色）
            try
            {
                iconBox.Image = Properties.Resources.off.ToBitmap();
            }
            catch
            {
                // 如果图标资源不存在，使用默认图标
            }

            if (!this.Visible)
            {
                this.Show();
                // 立即强制置顶
                ForceTopMost();
            }

            // 启动置顶检查计时器
            topMostTimer.Start();
        }

        public void ShowUnmuted()
        {
            // 非静音时直接隐藏悬浮窗，不显示任何内容
            previewTimer.Stop();
            topMostTimer.Stop(); // 停止置顶检查计时器
            this.Hide();
        }

        public void ShowPreview()
        {
            statusLabel.Text = "悬浮窗预览";
            statusLabel.ForeColor = Color.FromArgb(100, 150, 200);

            try
            {
                iconBox.Image = Properties.Resources.on.ToBitmap();
            }
            catch
            {
                // 如果图标资源不存在，使用默认图标
            }

            this.Show();
            // 立即强制置顶
            ForceTopMost();

            previewTimer.Stop();
            previewTimer.Start();

            // 预览时也启动置顶检查计时器
            topMostTimer.Start();
        }
        
        public void HideOverlay()
        {
            previewTimer.Stop();
            topMostTimer.Stop(); // 停止置顶检查计时器
            this.Hide();
        }
        
        private void PreviewTimer_Tick(object sender, EventArgs e)
        {
            previewTimer.Stop();
            topMostTimer.Stop(); // 停止置顶检查计时器
            this.Hide();
        }

        private void TopMostTimer_Tick(object sender, EventArgs e)
        {
            // 只有在窗口可见时才强制置顶
            if (this.Visible && !this.IsDisposed)
            {
                ForceTopMost();
            }
        }

        private void ForceTopMost()
        {
            try
            {
                // 使用 SetWindowPos 强制置顶
                SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);

                // 确保 TopMost 属性也是 true
                if (!this.TopMost)
                {
                    this.TopMost = true;
                }
            }
            catch
            {
                // 忽略错误，继续运行
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                previewTimer.Stop();
                topMostTimer.Stop(); // 停止置顶检查计时器
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
