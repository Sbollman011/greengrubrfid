namespace UHFAPP
{
    partial class ReceiveEPC
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
            this.lvEPC = new System.Windows.Forms.ListView();
            this.columnHeaderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRssi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderANT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnScanEPC = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lto = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbIP = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvEPC
            // 
            this.lvEPC.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvEPC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderID,
            this.columnHeaderEPC,
            this.columnHeaderTID,
            this.columnHeaderRssi,
            this.columnHeaderCount,
            this.columnHeaderANT});
            this.lvEPC.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvEPC.FullRowSelect = true;
            this.lvEPC.Location = new System.Drawing.Point(-1, 43);
            this.lvEPC.Name = "lvEPC";
            this.lvEPC.Size = new System.Drawing.Size(1286, 438);
            this.lvEPC.TabIndex = 3;
            this.lvEPC.UseCompatibleStateImageBehavior = false;
            this.lvEPC.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderID
            // 
            this.columnHeaderID.Text = "ID";
            this.columnHeaderID.Width = 77;
            // 
            // columnHeaderEPC
            // 
            this.columnHeaderEPC.Text = "EPC";
            this.columnHeaderEPC.Width = 700;
            // 
            // columnHeaderTID
            // 
            this.columnHeaderTID.Text = "TID";
            this.columnHeaderTID.Width = 280;
            // 
            // columnHeaderRssi
            // 
            this.columnHeaderRssi.Text = "Rssi";
            this.columnHeaderRssi.Width = 90;
            // 
            // columnHeaderCount
            // 
            this.columnHeaderCount.Text = "Count";
            this.columnHeaderCount.Width = 80;
            // 
            // columnHeaderANT
            // 
            this.columnHeaderANT.Text = "ANT";
            this.columnHeaderANT.Width = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(844, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Destination IP:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(340, 503);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(23, 24);
            this.lblTotal.TabIndex = 29;
            this.lblTotal.Text = "0";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(701, 503);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 48);
            this.button1.TabIndex = 30;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTime.ForeColor = System.Drawing.Color.Black;
            this.lblTime.Location = new System.Drawing.Point(340, 541);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(23, 24);
            this.lblTime.TabIndex = 28;
            this.lblTime.Text = "0";
            // 
            // btnScanEPC
            // 
            this.btnScanEPC.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnScanEPC.Location = new System.Drawing.Point(444, 503);
            this.btnScanEPC.Name = "btnScanEPC";
            this.btnScanEPC.Size = new System.Drawing.Size(125, 48);
            this.btnScanEPC.TabIndex = 25;
            this.btnScanEPC.Text = "Start";
            this.btnScanEPC.UseVisualStyleBackColor = true;
            this.btnScanEPC.Click += new System.EventHandler(this.btnScanEPC_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(259, 546);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 19);
            this.label2.TabIndex = 27;
            this.label2.Text = "Time:";
            // 
            // lto
            // 
            this.lto.AutoSize = true;
            this.lto.BackColor = System.Drawing.Color.Transparent;
            this.lto.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lto.ForeColor = System.Drawing.Color.Black;
            this.lto.Location = new System.Drawing.Point(259, 503);
            this.lto.Name = "lto";
            this.lto.Size = new System.Drawing.Size(75, 19);
            this.lto.TabIndex = 26;
            this.lto.Text = "Total:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(978, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 26);
            this.textBox1.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 32;
            this.label3.Text = "IP:";
            // 
            // cmbIP
            // 
            this.cmbIP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbIP.FormattingEnabled = true;
            this.cmbIP.Location = new System.Drawing.Point(41, 11);
            this.cmbIP.Name = "cmbIP";
            this.cmbIP.Size = new System.Drawing.Size(245, 24);
            this.cmbIP.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(315, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 34;
            this.label4.Text = "Port:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(362, 11);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(60, 26);
            this.textBox2.TabIndex = 35;
            this.textBox2.Text = "8888";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // ReceiveEPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1280, 591);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnScanEPC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvEPC);
            this.Name = "ReceiveEPC";
            this.Text = "ReceiveEPC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReceiveEPC_FormClosing);
            this.Load += new System.EventHandler(this.ReceiveEPC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvEPC;
        private System.Windows.Forms.ColumnHeader columnHeaderID;
        private System.Windows.Forms.ColumnHeader columnHeaderEPC;
        private System.Windows.Forms.ColumnHeader columnHeaderTID;
        private System.Windows.Forms.ColumnHeader columnHeaderRssi;
        private System.Windows.Forms.ColumnHeader columnHeaderCount;
        private System.Windows.Forms.ColumnHeader columnHeaderANT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnScanEPC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lto;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
    }
}