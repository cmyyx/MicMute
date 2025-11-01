namespace MicMute
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.iconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.hotkeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hotkeyTextBox = new Shortcut.Forms.HotkeyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.muteTextBox = new Shortcut.Forms.HotkeyTextBox();
            this.muteReset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.unmuteReset = new System.Windows.Forms.Button();
            this.unmuteTextBox = new Shortcut.Forms.HotkeyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.overlayXTextBox = new System.Windows.Forms.TextBox();
            this.overlayYTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.overlayBgColorTextBox = new System.Windows.Forms.TextBox();
            this.overlayMutedColorTextBox = new System.Windows.Forms.TextBox();
            this.overlayUnmutedColorTextBox = new System.Windows.Forms.TextBox();
            this.overlayPreviewButton = new System.Windows.Forms.Button();
            this.overlaySaveButton = new System.Windows.Forms.Button();
            this.overlayHideButton = new System.Windows.Forms.Button();
            this.overlayBottomCenterButton = new System.Windows.Forms.Button();
            this.overlayTopCenterButton = new System.Windows.Forms.Button();
            this.webhookGroupBox = new System.Windows.Forms.GroupBox();
            this.webhookEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.webhookHostTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.webhookPortTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.webhookPathTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.webhookTokenTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.webhookMutedMessageTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.webhookUnmutedMessageTextBox = new System.Windows.Forms.TextBox();
            this.webhookGroupBox.SuspendLayout();
            this.iconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // icon
            // 
            this.icon.ContextMenuStrip = this.iconContextMenu;
            this.icon.Text = "<Initializing>";
            this.icon.Visible = true;
            this.icon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseClick);
            // 
            // iconContextMenu
            // 
            this.iconContextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.iconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.hotkeyToolStripMenuItem,
            this.toolStripMenuItem1});
            this.iconContextMenu.Name = "iconContextMenu";
            this.iconContextMenu.Size = new System.Drawing.Size(200, 118);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(199, 38);
            this.toolStripMenuItem2.Text = "Select mic";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // hotkeyToolStripMenuItem
            // 
            this.hotkeyToolStripMenuItem.Name = "hotkeyToolStripMenuItem";
            this.hotkeyToolStripMenuItem.Size = new System.Drawing.Size(199, 38);
            this.hotkeyToolStripMenuItem.Text = "Hotkey";
            this.hotkeyToolStripMenuItem.Click += new System.EventHandler(this.HotkeyToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(199, 38);
            this.toolStripMenuItem1.Text = "Exit";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // hotkeyTextBox
            // 
            this.hotkeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hotkeyTextBox.Hotkey = null;
            this.hotkeyTextBox.Location = new System.Drawing.Point(24, 78);
            this.hotkeyTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.hotkeyTextBox.Name = "hotkeyTextBox";
            this.hotkeyTextBox.Size = new System.Drawing.Size(494, 44);
            this.hotkeyTextBox.TabIndex = 1;
            this.hotkeyTextBox.Text = "None";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(26, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(647, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Register toggle hotkey (auto saved on close)";
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReset.Location = new System.Drawing.Point(530, 75);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(6);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(154, 50);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(26, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(631, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "Register mute hotkey (auto saved on close)";
            // 
            // muteTextBox
            // 
            this.muteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.muteTextBox.Hotkey = null;
            this.muteTextBox.Location = new System.Drawing.Point(24, 201);
            this.muteTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.muteTextBox.Name = "muteTextBox";
            this.muteTextBox.Size = new System.Drawing.Size(494, 44);
            this.muteTextBox.TabIndex = 5;
            this.muteTextBox.Text = "None";
            // 
            // muteReset
            // 
            this.muteReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.muteReset.Location = new System.Drawing.Point(530, 201);
            this.muteReset.Margin = new System.Windows.Forms.Padding(6);
            this.muteReset.Name = "muteReset";
            this.muteReset.Size = new System.Drawing.Size(154, 50);
            this.muteReset.TabIndex = 6;
            this.muteReset.Text = "reset";
            this.muteReset.UseVisualStyleBackColor = true;
            this.muteReset.Click += new System.EventHandler(this.muteReset_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(26, 267);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(667, 37);
            this.label3.TabIndex = 7;
            this.label3.Text = "Register unmute hotkey (auto saved on close)";
            // 
            // unmuteReset
            // 
            this.unmuteReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.unmuteReset.Location = new System.Drawing.Point(530, 310);
            this.unmuteReset.Margin = new System.Windows.Forms.Padding(6);
            this.unmuteReset.Name = "unmuteReset";
            this.unmuteReset.Size = new System.Drawing.Size(154, 50);
            this.unmuteReset.TabIndex = 9;
            this.unmuteReset.Text = "reset";
            this.unmuteReset.UseVisualStyleBackColor = true;
            this.unmuteReset.Click += new System.EventHandler(this.unmuteReset_Click);
            // 
            // unmuteTextBox
            // 
            this.unmuteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.unmuteTextBox.Hotkey = null;
            this.unmuteTextBox.Location = new System.Drawing.Point(24, 310);
            this.unmuteTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.unmuteTextBox.Name = "unmuteTextBox";
            this.unmuteTextBox.Size = new System.Drawing.Size(494, 44);
            this.unmuteTextBox.TabIndex = 8;
            this.unmuteTextBox.Text = "None";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(26, 386);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(389, 37);
            this.label4.TabIndex = 10;
            this.label4.Text = "悬浮窗设置";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(28, 430);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 31);
            this.label5.TabIndex = 17;
            this.label5.Text = "位置 X:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(28, 480);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 31);
            this.label6.TabIndex = 18;
            this.label6.Text = "位置 Y:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(28, 530);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 31);
            this.label7.TabIndex = 19;
            this.label7.Text = "背景色:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(28, 580);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(158, 31);
            this.label8.TabIndex = 20;
            this.label8.Text = "静音文字色:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(28, 630);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(182, 31);
            this.label9.TabIndex = 21;
            this.label9.Text = "非静音文字色:";
            // 
            // overlayBgColorTextBox
            // 
            this.overlayBgColorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.overlayBgColorTextBox.Location = new System.Drawing.Point(220, 527);
            this.overlayBgColorTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.overlayBgColorTextBox.Name = "overlayBgColorTextBox";
            this.overlayBgColorTextBox.Size = new System.Drawing.Size(150, 38);
            this.overlayBgColorTextBox.TabIndex = 22;
            this.overlayBgColorTextBox.Text = "#F0F0F0";
            // 
            // overlayMutedColorTextBox
            // 
            this.overlayMutedColorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.overlayMutedColorTextBox.Location = new System.Drawing.Point(220, 577);
            this.overlayMutedColorTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.overlayMutedColorTextBox.Name = "overlayMutedColorTextBox";
            this.overlayMutedColorTextBox.Size = new System.Drawing.Size(150, 38);
            this.overlayMutedColorTextBox.TabIndex = 23;
            this.overlayMutedColorTextBox.Text = "#FF4500";
            // 
            // overlayUnmutedColorTextBox
            // 
            this.overlayUnmutedColorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.overlayUnmutedColorTextBox.Location = new System.Drawing.Point(220, 627);
            this.overlayUnmutedColorTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.overlayUnmutedColorTextBox.Name = "overlayUnmutedColorTextBox";
            this.overlayUnmutedColorTextBox.Size = new System.Drawing.Size(150, 38);
            this.overlayUnmutedColorTextBox.TabIndex = 24;
            this.overlayUnmutedColorTextBox.Text = "#00C800";
            // 
            // overlayXTextBox
            // 
            this.overlayXTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.overlayXTextBox.Location = new System.Drawing.Point(220, 427);
            this.overlayXTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.overlayXTextBox.Name = "overlayXTextBox";
            this.overlayXTextBox.Size = new System.Drawing.Size(150, 38);
            this.overlayXTextBox.TabIndex = 12;
            this.overlayXTextBox.Text = "0";
            // 
            // overlayYTextBox
            // 
            this.overlayYTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.overlayYTextBox.Location = new System.Drawing.Point(220, 477);
            this.overlayYTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.overlayYTextBox.Name = "overlayYTextBox";
            this.overlayYTextBox.Size = new System.Drawing.Size(150, 38);
            this.overlayYTextBox.TabIndex = 14;
            this.overlayYTextBox.Text = "0";
            // 
            // overlayPreviewButton
            // 
            this.overlayPreviewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.overlayPreviewButton.Location = new System.Drawing.Point(400, 527);
            this.overlayPreviewButton.Margin = new System.Windows.Forms.Padding(6);
            this.overlayPreviewButton.Name = "overlayPreviewButton";
            this.overlayPreviewButton.Size = new System.Drawing.Size(130, 70);
            this.overlayPreviewButton.TabIndex = 15;
            this.overlayPreviewButton.Text = "预览";
            this.overlayPreviewButton.UseVisualStyleBackColor = true;
            this.overlayPreviewButton.Click += new System.EventHandler(this.OverlayPreviewButton_Click);
            // 
            // overlaySaveButton
            // 
            this.overlaySaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.overlaySaveButton.Location = new System.Drawing.Point(554, 527);
            this.overlaySaveButton.Margin = new System.Windows.Forms.Padding(6);
            this.overlaySaveButton.Name = "overlaySaveButton";
            this.overlaySaveButton.Size = new System.Drawing.Size(130, 70);
            this.overlaySaveButton.TabIndex = 16;
            this.overlaySaveButton.Text = "保存";
            this.overlaySaveButton.UseVisualStyleBackColor = true;
            this.overlaySaveButton.Click += new System.EventHandler(this.OverlaySaveButton_Click);
            // 
            // overlayHideButton
            // 
            this.overlayHideButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.overlayHideButton.Location = new System.Drawing.Point(554, 427);
            this.overlayHideButton.Margin = new System.Windows.Forms.Padding(6);
            this.overlayHideButton.Name = "overlayHideButton";
            this.overlayHideButton.Size = new System.Drawing.Size(130, 45);
            this.overlayHideButton.TabIndex = 25;
            this.overlayHideButton.Text = "隐藏";
            this.overlayHideButton.UseVisualStyleBackColor = true;
            this.overlayHideButton.Click += new System.EventHandler(this.OverlayHideButton_Click);
            // 
            // overlayBottomCenterButton
            // 
            this.overlayBottomCenterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.overlayBottomCenterButton.Location = new System.Drawing.Point(400, 427);
            this.overlayBottomCenterButton.Margin = new System.Windows.Forms.Padding(6);
            this.overlayBottomCenterButton.Name = "overlayBottomCenterButton";
            this.overlayBottomCenterButton.Size = new System.Drawing.Size(70, 45);
            this.overlayBottomCenterButton.TabIndex = 26;
            this.overlayBottomCenterButton.Text = "底部";
            this.overlayBottomCenterButton.UseVisualStyleBackColor = true;
            this.overlayBottomCenterButton.Click += new System.EventHandler(this.OverlayBottomCenterButton_Click);
            // 
            // overlayTopCenterButton
            // 
            this.overlayTopCenterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.overlayTopCenterButton.Location = new System.Drawing.Point(480, 427);
            this.overlayTopCenterButton.Margin = new System.Windows.Forms.Padding(6);
            this.overlayTopCenterButton.Name = "overlayTopCenterButton";
            this.overlayTopCenterButton.Size = new System.Drawing.Size(70, 45);
            this.overlayTopCenterButton.TabIndex = 27;
            this.overlayTopCenterButton.Text = "顶部";
            this.overlayTopCenterButton.UseVisualStyleBackColor = true;
            this.overlayTopCenterButton.Click += new System.EventHandler(this.OverlayTopCenterButton_Click);
            // 
            // 
            // webhookGroupBox
            // 
            this.webhookGroupBox.Controls.Add(this.webhookEnabledCheckBox);
            this.webhookGroupBox.Controls.Add(this.label10);
            this.webhookGroupBox.Controls.Add(this.webhookHostTextBox);
            this.webhookGroupBox.Controls.Add(this.label11);
            this.webhookGroupBox.Controls.Add(this.webhookPortTextBox);
            this.webhookGroupBox.Controls.Add(this.label12);
            this.webhookGroupBox.Controls.Add(this.webhookPathTextBox);
            this.webhookGroupBox.Controls.Add(this.label13);
            this.webhookGroupBox.Controls.Add(this.webhookTokenTextBox);
            this.webhookGroupBox.Controls.Add(this.label14);
            this.webhookGroupBox.Controls.Add(this.webhookMutedMessageTextBox);
            this.webhookGroupBox.Controls.Add(this.label15);
            this.webhookGroupBox.Controls.Add(this.webhookUnmutedMessageTextBox);
            this.webhookGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.webhookGroupBox.Location = new System.Drawing.Point(26, 690);
            this.webhookGroupBox.Name = "webhookGroupBox";
            this.webhookGroupBox.Size = new System.Drawing.Size(658, 380);
            this.webhookGroupBox.TabIndex = 28;
            this.webhookGroupBox.TabStop = false;
            this.webhookGroupBox.Text = "Webhook 设置";
            // 
            // webhookEnabledCheckBox
            // 
            this.webhookEnabledCheckBox.AutoSize = true;
            this.webhookEnabledCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.webhookEnabledCheckBox.Location = new System.Drawing.Point(15, 35);
            this.webhookEnabledCheckBox.Name = "webhookEnabledCheckBox";
            this.webhookEnabledCheckBox.Size = new System.Drawing.Size(180, 35);
            this.webhookEnabledCheckBox.TabIndex = 0;
            this.webhookEnabledCheckBox.Text = "启用 Webhook";
            this.webhookEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(10, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 29);
            this.label10.TabIndex = 1;
            this.label10.Text = "主机/IP:";
            // 
            // webhookHostTextBox
            // 
            this.webhookHostTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.webhookHostTextBox.Location = new System.Drawing.Point(120, 72);
            this.webhookHostTextBox.Name = "webhookHostTextBox";
            this.webhookHostTextBox.Size = new System.Drawing.Size(200, 35);
            this.webhookHostTextBox.TabIndex = 2;
            this.webhookHostTextBox.Text = "localhost";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(340, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 29);
            this.label11.TabIndex = 3;
            this.label11.Text = "端口:";
            // 
            // webhookPortTextBox
            // 
            this.webhookPortTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.webhookPortTextBox.Location = new System.Drawing.Point(420, 72);
            this.webhookPortTextBox.Name = "webhookPortTextBox";
            this.webhookPortTextBox.Size = new System.Drawing.Size(100, 35);
            this.webhookPortTextBox.TabIndex = 4;
            this.webhookPortTextBox.Text = "8765";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(10, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 29);
            this.label12.TabIndex = 5;
            this.label12.Text = "路径:";
            // 
            // webhookPathTextBox
            // 
            this.webhookPathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.webhookPathTextBox.Location = new System.Drawing.Point(120, 117);
            this.webhookPathTextBox.Name = "webhookPathTextBox";
            this.webhookPathTextBox.Size = new System.Drawing.Size(400, 35);
            this.webhookPathTextBox.TabIndex = 6;
            this.webhookPathTextBox.Text = "/webhook";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(10, 165);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 29);
            this.label13.TabIndex = 7;
            this.label13.Text = "Token:";
            // 
            // webhookTokenTextBox
            // 
            this.webhookTokenTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.webhookTokenTextBox.Location = new System.Drawing.Point(120, 162);
            this.webhookTokenTextBox.Name = "webhookTokenTextBox";
            this.webhookTokenTextBox.Size = new System.Drawing.Size(400, 35);
            this.webhookTokenTextBox.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(10, 210);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(154, 29);
            this.label14.TabIndex = 9;
            this.label14.Text = "静音消息体:";
            // 
            // webhookMutedMessageTextBox
            // 
            this.webhookMutedMessageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.webhookMutedMessageTextBox.Location = new System.Drawing.Point(15, 245);
            this.webhookMutedMessageTextBox.Multiline = true;
            this.webhookMutedMessageTextBox.Name = "webhookMutedMessageTextBox";
            this.webhookMutedMessageTextBox.Size = new System.Drawing.Size(620, 50);
            this.webhookMutedMessageTextBox.TabIndex = 10;
            this.webhookMutedMessageTextBox.Text = "{\"message\": \"麦克风已静音\"}";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(10, 305);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(178, 29);
            this.label15.TabIndex = 11;
            this.label15.Text = "非静音消息体:";
            // 
            // webhookUnmutedMessageTextBox
            // 
            this.webhookUnmutedMessageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.webhookUnmutedMessageTextBox.Location = new System.Drawing.Point(15, 340);
            this.webhookUnmutedMessageTextBox.Multiline = true;
            this.webhookUnmutedMessageTextBox.Name = "webhookUnmutedMessageTextBox";
            this.webhookUnmutedMessageTextBox.Size = new System.Drawing.Size(620, 50);
            this.webhookUnmutedMessageTextBox.TabIndex = 12;
            this.webhookUnmutedMessageTextBox.Text = "{\"message\": \"麦克风已开启\"}";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 1090);
            this.Controls.Add(this.webhookGroupBox);
            this.Controls.Add(this.overlayTopCenterButton);
            this.Controls.Add(this.overlayBottomCenterButton);
            this.Controls.Add(this.overlayHideButton);
            this.Controls.Add(this.overlayUnmutedColorTextBox);
            this.Controls.Add(this.overlayMutedColorTextBox);
            this.Controls.Add(this.overlayBgColorTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.overlaySaveButton);
            this.Controls.Add(this.overlayPreviewButton);
            this.Controls.Add(this.overlayYTextBox);
            this.Controls.Add(this.overlayXTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.unmuteReset);
            this.Controls.Add(this.unmuteTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.muteReset);
            this.Controls.Add(this.muteTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hotkeyTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.Text = "MicMute";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.iconContextMenu.ResumeLayout(false);
            this.webhookGroupBox.ResumeLayout(false);
            this.webhookGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon icon;
        private System.Windows.Forms.ContextMenuStrip iconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private Shortcut.Forms.HotkeyTextBox hotkeyTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem hotkeyToolStripMenuItem;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Label label2;
        private Shortcut.Forms.HotkeyTextBox muteTextBox;
        private System.Windows.Forms.Button muteReset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button unmuteReset;
        private Shortcut.Forms.HotkeyTextBox unmuteTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox overlayXTextBox;
        private System.Windows.Forms.TextBox overlayYTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox overlayBgColorTextBox;
        private System.Windows.Forms.TextBox overlayMutedColorTextBox;
        private System.Windows.Forms.TextBox overlayUnmutedColorTextBox;
        private System.Windows.Forms.Button overlayPreviewButton;
        private System.Windows.Forms.Button overlaySaveButton;
        private System.Windows.Forms.Button overlayHideButton;
        private System.Windows.Forms.Button overlayBottomCenterButton;
        private System.Windows.Forms.Button overlayTopCenterButton;
        private System.Windows.Forms.GroupBox webhookGroupBox;
        private System.Windows.Forms.CheckBox webhookEnabledCheckBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox webhookHostTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox webhookPortTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox webhookPathTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox webhookTokenTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox webhookMutedMessageTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox webhookUnmutedMessageTextBox;
    }
}

