using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using Microsoft.Win32;
using Shortcut;
using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Net.Http;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MicMute
{
    public partial class MainForm : Form
    {
        const string DEFAULT_RECORDING_DEVICE = "Default recording device";
        public CoreAudioController AudioController = new CoreAudioController();
        private readonly HotkeyBinder hotkeyBinder = new HotkeyBinder();
        private readonly RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\MicMute");
        
        // toggle
        private readonly string registryKeyName = "Hotkey";
        private Hotkey hotkey;

        // mute
        private readonly string registryKeyMute = "HotkeyMute";
        private Hotkey muteHotkey;

        // unmute
        private readonly string registryKeyUnmute = "HotkeyUnmute";
        private Hotkey unMuteHotkey;

        private readonly string registryDeviceId = "DeviceId";
        private readonly string registryDeviceName = "DeviceName";
        private readonly string registryOverlayX = "OverlayX";
        private readonly string registryOverlayY = "OverlayY";
        
        // Webhook 设置
        private readonly string registryWebhookEnabled = "WebhookEnabled";
        private readonly string registryWebhookHost = "WebhookHost";
        private readonly string registryWebhookPort = "WebhookPort";
        private readonly string registryWebhookPath = "WebhookPath";
        private readonly string registryWebhookToken = "WebhookToken";
        private readonly string registryWebhookMutedMessage = "WebhookMutedMessage";
        private readonly string registryWebhookUnmutedMessage = "WebhookUnmutedMessage";

        private string selectedDeviceId;
        private string selectedDeviceName;
        private MicSelectorForm micSelectorForm;
        private MuteOverlayForm muteOverlayForm;


        enum MicStatus
        {
            Initial, On, Off, Error
        }
        private MicStatus currentStatus;

        private bool myVisible; 
        public bool MyVisible
        {
            get { return myVisible; }
            set { myVisible = value; Visible = value; }
        }

        public MainForm()
        {
            InitializeComponent();
            
            // 启动时立即隐藏主窗口
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Opacity = 0;
            
            muteOverlayForm = new MuteOverlayForm();
        }

        private void OnNextDevice(DeviceChangedArgs next)
        {
            UpdateSelectedDevice();
        }

        private void MyHide()
        {
            // 先隐藏窗口，避免闪现
            this.Opacity = 0;
            this.WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            Location = new Point(-10000, -10000);
            MyVisible = false;
        }

        private void MyShow()
        {
            MyVisible = true;
            ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.Opacity = 1;
            CenterToScreen();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 确保窗口完全隐藏
            MyHide();
            selectedDeviceId = (string)registryKey.GetValue(registryDeviceId) ?? "";
            selectedDeviceName = (string)registryKey.GetValue(registryDeviceName) ?? DEFAULT_RECORDING_DEVICE;

            UpdateSelectedDevice();
            AudioController.AudioDeviceChanged.Subscribe(OnNextDevice);
            
            // toggle
            var hotkeyValue = registryKey.GetValue(registryKeyName);
            if (hotkeyValue != null)
            {
                var converter = new Shortcut.Forms.HotkeyConverter();
                hotkey = (Hotkey)converter.ConvertFromString(hotkeyValue.ToString());
                if (!hotkeyBinder.IsHotkeyAlreadyBound(hotkey)) hotkeyBinder.Bind(hotkey).To(ToggleMicStatus);
            }

            // mute 
            hotkeyValue = registryKey.GetValue(registryKeyMute);
            if (hotkeyValue != null)
            {
                var converter = new Shortcut.Forms.HotkeyConverter();
                muteHotkey = (Hotkey)converter.ConvertFromString(hotkeyValue.ToString());
                if (!hotkeyBinder.IsHotkeyAlreadyBound(muteHotkey)) hotkeyBinder.Bind(muteHotkey).To(MuteMicStatus);
            }

            // unmute 
            hotkeyValue = registryKey.GetValue(registryKeyUnmute);
            if (hotkeyValue != null)
            {
                var converter = new Shortcut.Forms.HotkeyConverter();
                unMuteHotkey = (Hotkey)converter.ConvertFromString(hotkeyValue.ToString());
                if (!hotkeyBinder.IsHotkeyAlreadyBound(unMuteHotkey)) hotkeyBinder.Bind(unMuteHotkey).To(UnMuteMicStatus);
            }

            //AudioController.AudioDeviceChanged.Subscribe(x =>
            //{
            //    Debug.WriteLine("{0} - {1}", x.Device.Name, x.ChangedType.ToString());
            //});
        }

        private void OnMuteChanged(DeviceMuteChangedArgs next)
        {
            UpdateStatus(next.Device);
        }

        IDisposable muteChangedSubscription;
        public void UpdateDevice(IDevice device)
        {
            muteChangedSubscription?.Dispose();
            muteChangedSubscription = device?.MuteChanged.Subscribe(OnMuteChanged);
            UpdateStatus(device);
        }
        public IDevice getSelectedDevice()
        {
            return selectedDeviceId == "" ? AudioController.DefaultCaptureDevice : AudioController.GetDevice(new Guid(selectedDeviceId), DeviceState.Active);
        }

        public void UpdateSelectedDevice()
        {
            UpdateDevice(getSelectedDevice());
        }

        Icon iconOff = Properties.Resources.off;
        Icon iconOn = Properties.Resources.on;
        Icon iconError = Properties.Resources.error;

        public void PlaySound(string relativePath)
        {
            string path = Path.Combine(Application.StartupPath, relativePath);
            if (File.Exists(path))
            {
                SoundPlayer simpleSound = new SoundPlayer(path);
                simpleSound.Play();
            }
        }

        public void UpdateStatus(IDevice device)
        {
            MicStatus newStatus = (device != null) ? (device.IsMuted ? MicStatus.Off : MicStatus.On) : MicStatus.Error;
            bool playSound = currentStatus != MicStatus.Initial && currentStatus != newStatus;
            currentStatus = newStatus;
            switch (currentStatus)
            {
                case MicStatus.On:
                    UpdateIcon(iconOn, device.FullName);
                    if (playSound) PlaySound("on.wav");
                    if (playSound) muteOverlayForm.ShowUnmuted();
                    if (playSound) SendWebhook(false); // 非静音
                    break;
                case MicStatus.Off:
                    UpdateIcon(iconOff, device.FullName);
                    if (playSound) PlaySound("off.wav");
                    if (playSound) muteOverlayForm.ShowMuted();
                    if (playSound) SendWebhook(true); // 静音
                    break;
                case MicStatus.Error:
                    UpdateIcon(iconError, "< No device >");
                    if (playSound) PlaySound("error.wav");
                    break;
            }
        }
        
        private async void SendWebhook(bool isMuted)
        {
            try
            {
                // 检查是否启用 Webhook
                var enabled = registryKey.GetValue(registryWebhookEnabled);
                if (enabled == null || enabled.ToString() != "1")
                {
                    return;
                }
                
                // 读取 Webhook 配置
                var host = registryKey.GetValue(registryWebhookHost)?.ToString() ?? "localhost";
                var port = registryKey.GetValue(registryWebhookPort)?.ToString() ?? "8765";
                var path = registryKey.GetValue(registryWebhookPath)?.ToString() ?? "/webhook";
                var token = registryKey.GetValue(registryWebhookToken)?.ToString() ?? "";
                var message = isMuted 
                    ? (registryKey.GetValue(registryWebhookMutedMessage)?.ToString() ?? "{\"message\": \"麦克风已静音\"}")
                    : (registryKey.GetValue(registryWebhookUnmutedMessage)?.ToString() ?? "{\"message\": \"麦克风已开启\"}");
                
                // 构建 URL
                string url = $"http://{host}:{port}{path}";
                
                // 发送 HTTP 请求
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(5);
                    
                    var request = new HttpRequestMessage(HttpMethod.Post, url);
                    request.Content = new StringContent(message, Encoding.UTF8, "application/json");
                    
                    // 添加 Authorization header
                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        request.Headers.Add("Authorization", $"Bearer {token}");
                    }
                    
                    await client.SendAsync(request);
                }
            }
            catch
            {
                // 忽略 Webhook 错误，不影响主功能
            }
        }
        private void UpdateIcon(Icon icon, string tooltipText)
        {
            this.icon.Icon = icon;
            this.icon.Text = tooltipText.Substring(0, Math.Min(tooltipText.Length, 63));
        }

        public async void ToggleMicStatus()
        {
            await getSelectedDevice()?.ToggleMuteAsync();
        }

        public async void MuteMicStatus()
        {
            await getSelectedDevice()?.SetMuteAsync(true);
        }

        public async void UnMuteMicStatus()
        {
            await getSelectedDevice()?.SetMuteAsync(false);
        }

        private void Icon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToggleMicStatus();
            }
        }

        private void HotkeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // toggle
            if (hotkey != null)
            {
                hotkeyTextBox.Hotkey = hotkey;
                if (hotkeyBinder.IsHotkeyAlreadyBound(hotkey)) hotkeyBinder.Unbind(hotkey);
            }

            // mute
            if (muteHotkey != null)
            {
                muteTextBox.Hotkey = muteHotkey;
                if (hotkeyBinder.IsHotkeyAlreadyBound(muteHotkey)) hotkeyBinder.Unbind(muteHotkey);
            }

            // unmute
            if (unMuteHotkey != null)
            {
                unmuteTextBox.Hotkey = unMuteHotkey;
                if (hotkeyBinder.IsHotkeyAlreadyBound(unMuteHotkey)) hotkeyBinder.Unbind(unMuteHotkey);
            }

            // 加载悬浮窗位置
            LoadOverlayPosition();

            MyShow();
        }

        private void LoadOverlayPosition()
        {
            var x = registryKey.GetValue(registryOverlayX);
            var y = registryKey.GetValue(registryOverlayY);

            if (x != null && y != null)
            {
                overlayXTextBox.Text = x.ToString();
                overlayYTextBox.Text = y.ToString();
            }
            else
            {
                // 默认位置：屏幕右上角
                int defaultX = Screen.PrimaryScreen.WorkingArea.Width - 270;
                int defaultY = 20;
                overlayXTextBox.Text = defaultX.ToString();
                overlayYTextBox.Text = defaultY.ToString();
            }
            
            // 加载颜色设置
            overlayBgColorTextBox.Text = muteOverlayForm.GetBackgroundColor();
            overlayMutedColorTextBox.Text = muteOverlayForm.GetMutedTextColor();
            overlayUnmutedColorTextBox.Text = muteOverlayForm.GetUnmutedTextColor();
            
            // 加载 Webhook 设置
            LoadWebhookSettings();
        }
        
        private void LoadWebhookSettings()
        {
            webhookEnabledCheckBox.Checked = registryKey.GetValue(registryWebhookEnabled)?.ToString() == "1";
            webhookHostTextBox.Text = registryKey.GetValue(registryWebhookHost)?.ToString() ?? "localhost";
            webhookPortTextBox.Text = registryKey.GetValue(registryWebhookPort)?.ToString() ?? "8765";
            webhookPathTextBox.Text = registryKey.GetValue(registryWebhookPath)?.ToString() ?? "/webhook";
            webhookTokenTextBox.Text = registryKey.GetValue(registryWebhookToken)?.ToString() ?? "";
            webhookMutedMessageTextBox.Text = registryKey.GetValue(registryWebhookMutedMessage)?.ToString() ?? "{\"message\": \"麦克风已静音\"}";
            webhookUnmutedMessageTextBox.Text = registryKey.GetValue(registryWebhookUnmutedMessage)?.ToString() ?? "{\"message\": \"麦克风已开启\"}";
        }
        
        private void SaveWebhookSettings()
        {
            registryKey.SetValue(registryWebhookEnabled, webhookEnabledCheckBox.Checked ? "1" : "0");
            registryKey.SetValue(registryWebhookHost, webhookHostTextBox.Text);
            registryKey.SetValue(registryWebhookPort, webhookPortTextBox.Text);
            registryKey.SetValue(registryWebhookPath, webhookPathTextBox.Text);
            registryKey.SetValue(registryWebhookToken, webhookTokenTextBox.Text);
            registryKey.SetValue(registryWebhookMutedMessage, webhookMutedMessageTextBox.Text);
            registryKey.SetValue(registryWebhookUnmutedMessage, webhookUnmutedMessageTextBox.Text);
        }

        private void OverlayPreviewButton_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(overlayXTextBox.Text);
                int y = int.Parse(overlayYTextBox.Text);
                
                // 应用颜色设置（临时）
                muteOverlayForm.SaveColors(
                    overlayBgColorTextBox.Text,
                    overlayMutedColorTextBox.Text,
                    overlayUnmutedColorTextBox.Text
                );
                
                muteOverlayForm.Location = new Point(x, y);
                muteOverlayForm.ShowPreview();
            }
            catch
            {
                MessageBox.Show("请输入有效的坐标数值和颜色代码（如 #F0F0F0）", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OverlaySaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(overlayXTextBox.Text);
                int y = int.Parse(overlayYTextBox.Text);
                
                // 保存位置
                muteOverlayForm.SavePosition(new Point(x, y));
                
                // 保存颜色
                muteOverlayForm.SaveColors(
                    overlayBgColorTextBox.Text,
                    overlayMutedColorTextBox.Text,
                    overlayUnmutedColorTextBox.Text
                );
                
                MessageBox.Show("悬浮窗设置已保存", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("请输入有效的坐标数值和颜色代码（如 #F0F0F0）", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void OverlayHideButton_Click(object sender, EventArgs e)
        {
            muteOverlayForm.HideOverlay();
        }
        
        private void OverlayBottomCenterButton_Click(object sender, EventArgs e)
        {
            // 计算底部居中位置
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int overlayWidth = 250; // 悬浮窗宽度
            int overlayHeight = 80; // 悬浮窗高度
            
            int x = (screenWidth - overlayWidth) / 2;
            int y = screenHeight - overlayHeight - 50; // 距离底部50像素
            
            overlayXTextBox.Text = x.ToString();
            overlayYTextBox.Text = y.ToString();
            
            // 自动预览
            OverlayPreviewButton_Click(sender, e);
        }
        
        private void OverlayTopCenterButton_Click(object sender, EventArgs e)
        {
            // 计算顶部居中位置
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int overlayWidth = 250; // 悬浮窗宽度
            
            int x = (screenWidth - overlayWidth) / 2;
            int y = 20; // 距离顶部20像素
            
            overlayXTextBox.Text = x.ToString();
            overlayYTextBox.Text = y.ToString();
            
            // 自动预览
            OverlayPreviewButton_Click(sender, e);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MyVisible)
            {
                MyHide();
                e.Cancel = true;

                hotkey = hotkeyTextBox.Hotkey;

                if (hotkey == null)
                {
                    registryKey.DeleteValue(registryKeyName, false);
                }
                else
                {
                    if (!hotkeyBinder.IsHotkeyAlreadyBound(hotkey))
                    {
                        registryKey.SetValue(registryKeyName, hotkey);
                        if (!hotkeyBinder.IsHotkeyAlreadyBound(hotkey)) hotkeyBinder.Bind(hotkey).To(ToggleMicStatus);
                    }
                }

                muteHotkey = muteTextBox.Hotkey;

                if (muteHotkey == null)
                {
                    registryKey.DeleteValue(registryKeyMute, false);
                }
                else
                {
                    if (!hotkeyBinder.IsHotkeyAlreadyBound(muteHotkey))
                    {
                        registryKey.SetValue(registryKeyMute, muteHotkey);
                        if (!hotkeyBinder.IsHotkeyAlreadyBound(muteHotkey)) hotkeyBinder.Bind(muteHotkey).To(MuteMicStatus);
                    }
                }


                unMuteHotkey = unmuteTextBox.Hotkey;

                if (unMuteHotkey == null)
                {
                    registryKey.DeleteValue(registryKeyUnmute, false);
                }
                else
                {
                    if (!hotkeyBinder.IsHotkeyAlreadyBound(unMuteHotkey))
                    {
                        registryKey.SetValue(registryKeyUnmute, unMuteHotkey);
                        if (!hotkeyBinder.IsHotkeyAlreadyBound(unMuteHotkey)) hotkeyBinder.Bind(unMuteHotkey).To(UnMuteMicStatus);
                    }
                }
                
                // 保存 Webhook 设置
                SaveWebhookSettings();

            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            hotkeyTextBox.Hotkey = null;
            hotkeyTextBox.Text = "None";
        }
        private void muteReset_Click(object sender, EventArgs e)
        {
            muteTextBox.Hotkey = null;
            muteTextBox.Text = "None";
        }

        private void unmuteReset_Click(object sender, EventArgs e)
        {
            unmuteTextBox.Hotkey = null;
            unmuteTextBox.Text = "None";
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            micSelectorForm = new MicSelectorForm();
            ComboBox comboBox = micSelectorForm.cbMics;
            comboBox.Items.Clear();

            bool registryExists = false;

            ComboboxItem defaultItem = new ComboboxItem();
            defaultItem.Text = DEFAULT_RECORDING_DEVICE;
            defaultItem.deviceId = "";
            comboBox.Items.Add(defaultItem);

            if (selectedDeviceId == "")
            {
                registryExists = true;
                comboBox.SelectedIndex = comboBox.Items.Count - 1;
            }

            foreach (CoreAudioDevice device in AudioController.GetCaptureDevices())
            {
                if (device.State == DeviceState.Active)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = device.FullName;
                    item.deviceId = device.Id.ToString();
                    comboBox.Items.Add(item);

                    if (item.deviceId == selectedDeviceId)
                    {
                        registryExists = true;
                        comboBox.SelectedIndex = comboBox.Items.Count - 1;
                    }
                }
            }

            if (!registryExists) {
                ComboboxItem item = new ComboboxItem();
                item.Text = "(unavailable) " + registryDeviceName.ToString();
                item.deviceId = selectedDeviceId.ToString();
                comboBox.Items.Add(item);
                comboBox.SelectedIndex = comboBox.Items.Count - 1;
            }
            DialogResult result = micSelectorForm.ShowDialog();
            Console.WriteLine(result);
            ComboboxItem selectedItem = (ComboboxItem)comboBox.SelectedItem;

            registryKey.SetValue(registryDeviceId, selectedItem.deviceId);
            registryKey.SetValue(registryDeviceName, selectedItem.Text);
            selectedDeviceName = selectedItem.Text;
            selectedDeviceId = selectedItem.deviceId;

            micSelectorForm.Dispose();

            UpdateSelectedDevice();
        }
    }
}
