namespace UHFAPP
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemScanEPC = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemReadWriteTag = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killLockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uHFVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemReceiveEPC = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.combCommunicationMode = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblPortName = new System.Windows.Forms.ToolStripLabel();
            this.cmbComPort = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblPort = new System.Windows.Forms.Label();
            this.ipControl1 = new WindowsFormsControlLibrary1.IPControl();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemScanEPC,
            this.MenuItemReadWriteTag,
            this.configToolStripMenuItem,
            this.killLockToolStripMenuItem,
            this.uHFVersionToolStripMenuItem,
            this.toolStripMenuItem1,
            this.MenuItemReceiveEPC,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1290, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "ScanEPC";
            this.menuStrip1.ItemAdded += new System.Windows.Forms.ToolStripItemEventHandler(this.menuStrip1_ItemAdded);
            // 
            // MenuItemScanEPC
            // 
            this.MenuItemScanEPC.Name = "MenuItemScanEPC";
            this.MenuItemScanEPC.Size = new System.Drawing.Size(66, 20);
            this.MenuItemScanEPC.Text = "ReadEPC";
            this.MenuItemScanEPC.Click += new System.EventHandler(this.MenuItemScanEPC_Click);
            // 
            // MenuItemReadWriteTag
            // 
            this.MenuItemReadWriteTag.Name = "MenuItemReadWriteTag";
            this.MenuItemReadWriteTag.Size = new System.Drawing.Size(91, 20);
            this.MenuItemReadWriteTag.Text = "ReadWriteTag";
            this.MenuItemReadWriteTag.Click += new System.EventHandler(this.MenuItemReadWriteTag_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configToolStripMenuItem.Text = "Configuration";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // killLockToolStripMenuItem
            // 
            this.killLockToolStripMenuItem.Name = "killLockToolStripMenuItem";
            this.killLockToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.killLockToolStripMenuItem.Text = "Kill-Lock";
            this.killLockToolStripMenuItem.Click += new System.EventHandler(this.killLockToolStripMenuItem_Click);
            // 
            // uHFVersionToolStripMenuItem
            // 
            this.uHFVersionToolStripMenuItem.Name = "uHFVersionToolStripMenuItem";
            this.uHFVersionToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.uHFVersionToolStripMenuItem.Text = "UHF Info";
            this.uHFVersionToolStripMenuItem.Click += new System.EventHandler(this.uHFVersionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(85, 20);
            this.toolStripMenuItem1.Text = "Temperature";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // MenuItemReceiveEPC
            // 
            this.MenuItemReceiveEPC.Name = "MenuItemReceiveEPC";
            this.MenuItemReceiveEPC.Size = new System.Drawing.Size(108, 20);
            this.MenuItemReceiveEPC.Text = "UDP-ReceiveEPC";
            this.MenuItemReceiveEPC.Click += new System.EventHandler(this.receiveEPCToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Visible = false;
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.combCommunicationMode,
            this.toolStripLabel2,
            this.toolStripSeparator1,
            this.lblPortName,
            this.cmbComPort,
            this.toolStripOpen,
            this.toolStripLabel1,
            this.toolStripLabel5,
            this.toolStripLabel3,
            this.toolStripComboBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1290, 37);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "Open";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(38, 34);
            this.toolStripLabel4.Text = "Mode";
            // 
            // combCommunicationMode
            // 
            this.combCommunicationMode.Items.AddRange(new object[] {
            "串口",
            "网络"});
            this.combCommunicationMode.Name = "combCommunicationMode";
            this.combCommunicationMode.Size = new System.Drawing.Size(121, 37);
            this.combCommunicationMode.TextChanged += new System.EventHandler(this.toolStripComboBox2_TextChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(61, 34);
            this.toolStripLabel2.Text = "                  ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // lblPortName
            // 
            this.lblPortName.Name = "lblPortName";
            this.lblPortName.Size = new System.Drawing.Size(35, 34);
            this.lblPortName.Text = "COM";
            // 
            // cmbComPort
            // 
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(121, 37);
            // 
            // toolStripOpen
            // 
            this.toolStripOpen.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.toolStripOpen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStripOpen.BackgroundImage")));
            this.toolStripOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripOpen.Checked = true;
            this.toolStripOpen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripOpen.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOpen.Image")));
            this.toolStripOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOpen.Name = "toolStripOpen";
            this.toolStripOpen.Size = new System.Drawing.Size(60, 34);
            this.toolStripOpen.Text = "  Open  ";
            this.toolStripOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripOpen.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(61, 34);
            this.toolStripLabel1.Text = "                  ";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(61, 34);
            this.toolStripLabel5.Text = "                  ";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(59, 34);
            this.toolStripLabel3.Text = "Language";
            this.toolStripLabel3.Visible = false;
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 37);
            this.toolStripComboBox1.Visible = false;
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            this.toolStripComboBox1.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 739);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1290, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.lblPort);
            this.panel1.Controls.Add(this.ipControl1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPort);
            this.panel1.Location = new System.Drawing.Point(200, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 37);
            this.panel1.TabIndex = 6;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.Control;
            this.btnConnect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConnect.BackgroundImage")));
            this.btnConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnConnect.ForeColor = System.Drawing.Color.Black;
            this.btnConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect.Location = new System.Drawing.Point(346, 1);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(60, 34);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "  Open  ";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPort.Location = new System.Drawing.Point(247, 7);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(40, 16);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Port";
            // 
            // ipControl1
            // 
            this.ipControl1.BackColor = System.Drawing.SystemColors.Control;
            this.ipControl1.IpData = new string[] {
        "",
        "",
        "",
        ""};
            this.ipControl1.Location = new System.Drawing.Point(35, 0);
            this.ipControl1.Name = "ipControl1";
            this.ipControl1.Size = new System.Drawing.Size(198, 37);
            this.ipControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP";
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPort.Location = new System.Drawing.Point(293, 3);
            this.txtPort.MaxLength = 6;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(47, 26);
            this.txtPort.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1290, 761);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "GAO216002Demo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemScanEPC;
        private System.Windows.Forms.ToolStripMenuItem MenuItemReadWriteTag;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblPortName;
        private System.Windows.Forms.ToolStripComboBox cmbComPort;
        private System.Windows.Forms.ToolStripButton toolStripOpen;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem uHFVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem killLockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox combCommunicationMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private WindowsFormsControlLibrary1.IPControl ipControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ToolStripMenuItem MenuItemReceiveEPC;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;

    }
}

