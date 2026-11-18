
namespace _485扫描
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.portComboBox = new System.Windows.Forms.ComboBox();
            this.baudRateComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.regInput = new System.Windows.Forms.NumericUpDown();
            this.timeInput = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.staetTxt = new System.Windows.Forms.RichTextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tcpPortNum = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.networkTextBox = new System.Windows.Forms.TextBox();
            this.networkButton = new System.Windows.Forms.Button();
            this.agreementComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.logLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.regInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeInput)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcpPortNum)).BeginInit();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.BackColor = System.Drawing.Color.Aqua;
            this.openButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.openButton.Location = new System.Drawing.Point(330, 30);
            this.openButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(138, 36);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "打开";
            this.openButton.UseVisualStyleBackColor = false;
            this.openButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(37, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "端口：";
            // 
            // portComboBox
            // 
            this.portComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portComboBox.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.portComboBox.FormattingEnabled = true;
            this.portComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.portComboBox.Location = new System.Drawing.Point(133, 15);
            this.portComboBox.Name = "portComboBox";
            this.portComboBox.Size = new System.Drawing.Size(140, 27);
            this.portComboBox.Sorted = true;
            this.portComboBox.TabIndex = 2;
            this.portComboBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.portComboBox_MouseDown);
            // 
            // baudRateComboBox
            // 
            this.baudRateComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "4800",
            "9600",
            "19200",
            "115200"});
            this.baudRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudRateComboBox.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baudRateComboBox.FormattingEnabled = true;
            this.baudRateComboBox.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "56000",
            "115200"});
            this.baudRateComboBox.Location = new System.Drawing.Point(133, 50);
            this.baudRateComboBox.Name = "baudRateComboBox";
            this.baudRateComboBox.Size = new System.Drawing.Size(140, 27);
            this.baudRateComboBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(17, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "波特率：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(27, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "输入寄存器ID：0-65535";
            // 
            // regInput
            // 
            this.regInput.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regInput.Location = new System.Drawing.Point(27, 178);
            this.regInput.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.regInput.Name = "regInput";
            this.regInput.Size = new System.Drawing.Size(205, 29);
            this.regInput.TabIndex = 6;
            // 
            // timeInput
            // 
            this.timeInput.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timeInput.Location = new System.Drawing.Point(335, 177);
            this.timeInput.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.timeInput.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.timeInput.Name = "timeInput";
            this.timeInput.Size = new System.Drawing.Size(192, 29);
            this.timeInput.TabIndex = 8;
            this.timeInput.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(337, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "延时时间：30-2000";
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.Aqua;
            this.stopButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stopButton.Location = new System.Drawing.Point(199, 220);
            this.stopButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(138, 36);
            this.stopButton.TabIndex = 9;
            this.stopButton.Text = "停止";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Aqua;
            this.startButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startButton.Location = new System.Drawing.Point(15, 220);
            this.startButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(138, 36);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "开始";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.Aqua;
            this.clearButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clearButton.Location = new System.Drawing.Point(382, 220);
            this.clearButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(138, 36);
            this.clearButton.TabIndex = 10;
            this.clearButton.Text = "清除数据";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // staetTxt
            // 
            this.staetTxt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.staetTxt.Location = new System.Drawing.Point(12, 291);
            this.staetTxt.Name = "staetTxt";
            this.staetTxt.ReadOnly = true;
            this.staetTxt.Size = new System.Drawing.Size(524, 188);
            this.staetTxt.TabIndex = 12;
            this.staetTxt.Text = "";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(22, 269);
            this.label5.MinimumSize = new System.Drawing.Size(20, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 19);
            this.label5.TabIndex = 13;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(1, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(552, 129);
            this.tabControl.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.openButton);
            this.tabPage1.Controls.Add(this.portComboBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.baudRateComboBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(544, 96);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "串口";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tcpPortNum);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.networkTextBox);
            this.tabPage2.Controls.Add(this.networkButton);
            this.tabPage2.Controls.Add(this.agreementComboBox);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(544, 96);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "网口";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tcpPortNum
            // 
            this.tcpPortNum.Location = new System.Drawing.Point(385, 54);
            this.tcpPortNum.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.tcpPortNum.Name = "tcpPortNum";
            this.tcpPortNum.Size = new System.Drawing.Size(120, 29);
            this.tcpPortNum.TabIndex = 11;
            this.tcpPortNum.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(303, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 19);
            this.label8.TabIndex = 10;
            this.label8.Text = "端口：";
            // 
            // networkTextBox
            // 
            this.networkTextBox.Location = new System.Drawing.Point(114, 56);
            this.networkTextBox.Name = "networkTextBox";
            this.networkTextBox.Size = new System.Drawing.Size(178, 29);
            this.networkTextBox.TabIndex = 9;
            // 
            // networkButton
            // 
            this.networkButton.BackColor = System.Drawing.Color.Aqua;
            this.networkButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.networkButton.Location = new System.Drawing.Point(377, 9);
            this.networkButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.networkButton.Name = "networkButton";
            this.networkButton.Size = new System.Drawing.Size(138, 36);
            this.networkButton.TabIndex = 5;
            this.networkButton.Text = "连接";
            this.networkButton.UseVisualStyleBackColor = false;
            this.networkButton.Click += new System.EventHandler(this.networkButton_Click);
            // 
            // agreementComboBox
            // 
            this.agreementComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.agreementComboBox.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.agreementComboBox.FormattingEnabled = true;
            this.agreementComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.agreementComboBox.Items.AddRange(new object[] {
            "TCP Client",
            "TCP Server"});
            this.agreementComboBox.Location = new System.Drawing.Point(114, 12);
            this.agreementComboBox.Name = "agreementComboBox";
            this.agreementComboBox.Size = new System.Drawing.Size(178, 27);
            this.agreementComboBox.Sorted = true;
            this.agreementComboBox.TabIndex = 7;
            this.agreementComboBox.SelectedIndexChanged += new System.EventHandler(this.agreementComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(12, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "协议类型：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(12, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "网络地址：";
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.BackColor = System.Drawing.Color.Transparent;
            this.logLabel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.logLabel.Location = new System.Drawing.Point(201, 269);
            this.logLabel.MinimumSize = new System.Drawing.Size(20, 19);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(20, 19);
            this.logLabel.TabIndex = 15;
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(554, 489);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.staetTxt);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.timeInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.regInput);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(570, 528);
            this.MinimumSize = new System.Drawing.Size(570, 528);
            this.Name = "Form1";
            this.Text = "485扫描器";
            ((System.ComponentModel.ISupportInitialize)(this.regInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeInput)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcpPortNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox portComboBox;
        private System.Windows.Forms.ComboBox baudRateComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown regInput;
        private System.Windows.Forms.NumericUpDown timeInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.RichTextBox staetTxt;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button networkButton;
        private System.Windows.Forms.ComboBox agreementComboBox;
        private System.Windows.Forms.NumericUpDown tcpPortNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox networkTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.Timer timer1;
    }
}

