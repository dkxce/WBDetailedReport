namespace WBDetailedReport
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.maxEdit = new System.Windows.Forms.NumericUpDown();
            this.maxTT = new System.Windows.Forms.Label();
            this.stopBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.logEdit = new System.Windows.Forms.TextBox();
            this.delayEdit = new System.Windows.Forms.NumericUpDown();
            this.daysEdit = new System.Windows.Forms.NumericUpDown();
            this.tillEdit = new System.Windows.Forms.DateTimePicker();
            this.fromEdit = new System.Windows.Forms.DateTimePicker();
            this.tokenEdit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.fileBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.mrgBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tInfo = new System.Windows.Forms.TextBox();
            this.bLoad = new System.Windows.Forms.Button();
            this.fMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysEdit)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(967, 519);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bLoad);
            this.tabPage1.Controls.Add(this.maxEdit);
            this.tabPage1.Controls.Add(this.maxTT);
            this.tabPage1.Controls.Add(this.stopBtn);
            this.tabPage1.Controls.Add(this.startBtn);
            this.tabPage1.Controls.Add(this.logEdit);
            this.tabPage1.Controls.Add(this.delayEdit);
            this.tabPage1.Controls.Add(this.daysEdit);
            this.tabPage1.Controls.Add(this.tillEdit);
            this.tabPage1.Controls.Add(this.fromEdit);
            this.tabPage1.Controls.Add(this.tokenEdit);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(959, 490);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Скачать";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // maxEdit
            // 
            this.maxEdit.Location = new System.Drawing.Point(493, 45);
            this.maxEdit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.maxEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxEdit.Name = "maxEdit";
            this.maxEdit.Size = new System.Drawing.Size(88, 22);
            this.maxEdit.TabIndex = 14;
            this.maxEdit.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // maxTT
            // 
            this.maxTT.AutoSize = true;
            this.maxTT.Location = new System.Drawing.Point(386, 48);
            this.maxTT.Name = "maxTT";
            this.maxTT.Size = new System.Drawing.Size(101, 16);
            this.maxTT.TabIndex = 13;
            this.maxTT.Text = "Макс записей:";
            // 
            // stopBtn
            // 
            this.stopBtn.Enabled = false;
            this.stopBtn.Location = new System.Drawing.Point(864, 44);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(75, 23);
            this.stopBtn.TabIndex = 12;
            this.stopBtn.Text = "СТОП";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(864, 15);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 11;
            this.startBtn.Text = "СТАРТ";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // logEdit
            // 
            this.logEdit.Location = new System.Drawing.Point(20, 84);
            this.logEdit.Multiline = true;
            this.logEdit.Name = "logEdit";
            this.logEdit.ReadOnly = true;
            this.logEdit.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logEdit.Size = new System.Drawing.Size(919, 385);
            this.logEdit.TabIndex = 10;
            // 
            // delayEdit
            // 
            this.delayEdit.Location = new System.Drawing.Point(317, 45);
            this.delayEdit.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.delayEdit.Minimum = new decimal(new int[] {
            61,
            0,
            0,
            0});
            this.delayEdit.Name = "delayEdit";
            this.delayEdit.Size = new System.Drawing.Size(63, 22);
            this.delayEdit.TabIndex = 9;
            this.delayEdit.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // daysEdit
            // 
            this.daysEdit.Location = new System.Drawing.Point(112, 45);
            this.daysEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.daysEdit.Name = "daysEdit";
            this.daysEdit.Size = new System.Drawing.Size(52, 22);
            this.daysEdit.TabIndex = 8;
            this.daysEdit.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // tillEdit
            // 
            this.tillEdit.Location = new System.Drawing.Point(666, 44);
            this.tillEdit.Name = "tillEdit";
            this.tillEdit.Size = new System.Drawing.Size(179, 22);
            this.tillEdit.TabIndex = 7;
            this.tillEdit.Value = new System.DateTime(2025, 3, 31, 0, 0, 0, 0);
            // 
            // fromEdit
            // 
            this.fromEdit.Location = new System.Drawing.Point(666, 16);
            this.fromEdit.Name = "fromEdit";
            this.fromEdit.Size = new System.Drawing.Size(179, 22);
            this.fromEdit.TabIndex = 6;
            this.fromEdit.Value = new System.DateTime(2025, 3, 1, 0, 0, 0, 0);
            // 
            // tokenEdit
            // 
            this.tokenEdit.Location = new System.Drawing.Point(112, 16);
            this.tokenEdit.Name = "tokenEdit";
            this.tokenEdit.PasswordChar = '*';
            this.tokenEdit.ReadOnly = true;
            this.tokenEdit.Size = new System.Drawing.Size(375, 22);
            this.tokenEdit.TabIndex = 5;
            this.tokenEdit.Enter += new System.EventHandler(this.tokenEdit_Enter);
            this.tokenEdit.Leave += new System.EventHandler(this.tokenEdit_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Таймаут в секундах:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Шаг в днях:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(597, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Дата по:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(598, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Дата от:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "API Token:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.fileBox);
            this.tabPage2.Controls.Add(this.statusStrip1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(959, 490);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Склеить в CSV";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // fileBox
            // 
            this.fileBox.ContextMenuStrip = this.contextMenuStrip1;
            this.fileBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileBox.FormattingEnabled = true;
            this.fileBox.ItemHeight = 16;
            this.fileBox.Location = new System.Drawing.Point(3, 3);
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(953, 458);
            this.fileBox.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clsBtn,
            this.mrgBtn});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 52);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // clsBtn
            // 
            this.clsBtn.Name = "clsBtn";
            this.clsBtn.Size = new System.Drawing.Size(142, 24);
            this.clsBtn.Text = "Очистить";
            this.clsBtn.Click += new System.EventHandler(this.clsToolStripMenuItem_Click);
            // 
            // mrgBtn
            // 
            this.mrgBtn.Name = "mrgBtn";
            this.mrgBtn.Size = new System.Drawing.Size(142, 24);
            this.mrgBtn.Text = "Склеить";
            this.mrgBtn.Click += new System.EventHandler(this.mrgBtn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusText});
            this.statusStrip1.Location = new System.Drawing.Point(3, 461);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(953, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(55, 20);
            this.toolStripStatusLabel1.Text = "Статус:";
            // 
            // statusText
            // 
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(27, 20);
            this.statusText.Text = "---";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(861, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tInfo);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(959, 490);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Информация о токене";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tInfo
            // 
            this.tInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tInfo.Font = new System.Drawing.Font("Monoid", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tInfo.Location = new System.Drawing.Point(3, 3);
            this.tInfo.Multiline = true;
            this.tInfo.Name = "tInfo";
            this.tInfo.ReadOnly = true;
            this.tInfo.Size = new System.Drawing.Size(953, 484);
            this.tInfo.TabIndex = 0;
            // 
            // bLoad
            // 
            this.bLoad.Location = new System.Drawing.Point(493, 16);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(88, 23);
            this.bLoad.TabIndex = 15;
            this.bLoad.Text = "Выбрать ...";
            this.bLoad.UseVisualStyleBackColor = true;
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // fMenu
            // 
            this.fMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.fMenu.Name = "fMenu";
            this.fMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 519);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "WBDetailedReport";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysEdit)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DateTimePicker fromEdit;
        private System.Windows.Forms.TextBox tokenEdit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox logEdit;
        private System.Windows.Forms.NumericUpDown delayEdit;
        private System.Windows.Forms.NumericUpDown daysEdit;
        private System.Windows.Forms.DateTimePicker tillEdit;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown maxEdit;
        private System.Windows.Forms.Label maxTT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clsBtn;
        private System.Windows.Forms.ToolStripMenuItem mrgBtn;
        private System.Windows.Forms.ListBox fileBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox tInfo;
        private System.Windows.Forms.Button bLoad;
        private System.Windows.Forms.ContextMenuStrip fMenu;
    }
}

