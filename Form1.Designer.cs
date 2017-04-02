namespace WindowsFormsApplication1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_Connect = new System.Windows.Forms.Button();
            this.listBox_EPC = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_NumberOfTag = new System.Windows.Forms.TextBox();
            this.Button_Save = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Button_WriteData = new System.Windows.Forms.Button();
            this.Button_ReadData = new System.Windows.Forms.Button();
            this.textBox_NewData = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_DataLength = new System.Windows.Forms.TextBox();
            this.textBox_DataOffset = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_AccessPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_Temperature = new System.Windows.Forms.TextBox();
            this.Button_Set = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_Humidity = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_Distance = new System.Windows.Forms.TextBox();
            this.textBox_Angle = new System.Windows.Forms.TextBox();
            this.textBox_PowerLevel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.number = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.Button_Read = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.listBox_Metadata = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(281, 18);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.MaxLength = 3;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(44, 63);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(788, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bluetooth Virtual Com Port Number:";
            // 
            // Button_Connect
            // 
            this.Button_Connect.Location = new System.Drawing.Point(332, 18);
            this.Button_Connect.Name = "Button_Connect";
            this.Button_Connect.Size = new System.Drawing.Size(108, 25);
            this.Button_Connect.TabIndex = 2;
            this.Button_Connect.Text = "Connect";
            this.Button_Connect.UseVisualStyleBackColor = true;
            this.Button_Connect.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox_EPC
            // 
            this.listBox_EPC.FormattingEnabled = true;
            this.listBox_EPC.ItemHeight = 55;
            this.listBox_EPC.Location = new System.Drawing.Point(469, 18);
            this.listBox_EPC.Name = "listBox_EPC";
            this.listBox_EPC.Size = new System.Drawing.Size(677, 224);
            this.listBox_EPC.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_NumberOfTag);
            this.groupBox1.Controls.Add(this.Button_Save);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.Button_Read);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(11, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 595);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "246008 Operations";
            // 
            // textBox_NumberOfTag
            // 
            this.textBox_NumberOfTag.Location = new System.Drawing.Point(103, 37);
            this.textBox_NumberOfTag.Name = "textBox_NumberOfTag";
            this.textBox_NumberOfTag.Size = new System.Drawing.Size(44, 63);
            this.textBox_NumberOfTag.TabIndex = 30;
            this.textBox_NumberOfTag.Text = "3";
            // 
            // Button_Save
            // 
            this.Button_Save.Location = new System.Drawing.Point(319, 30);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(137, 38);
            this.Button_Save.TabIndex = 20;
            this.Button_Save.Text = "Save";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Button_WriteData);
            this.groupBox3.Controls.Add(this.Button_ReadData);
            this.groupBox3.Controls.Add(this.textBox_NewData);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBox_DataLength);
            this.groupBox3.Controls.Add(this.textBox_DataOffset);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox_AccessPassword);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(8, 335);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(436, 254);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tag Advanced Operations";
            // 
            // Button_WriteData
            // 
            this.Button_WriteData.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_WriteData.Location = new System.Drawing.Point(272, 206);
            this.Button_WriteData.Name = "Button_WriteData";
            this.Button_WriteData.Size = new System.Drawing.Size(147, 38);
            this.Button_WriteData.TabIndex = 28;
            this.Button_WriteData.Text = "Write";
            this.Button_WriteData.UseVisualStyleBackColor = true;
            this.Button_WriteData.Click += new System.EventHandler(this.button7_Click);
            // 
            // Button_ReadData
            // 
            this.Button_ReadData.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_ReadData.Location = new System.Drawing.Point(6, 206);
            this.Button_ReadData.Name = "Button_ReadData";
            this.Button_ReadData.Size = new System.Drawing.Size(147, 38);
            this.Button_ReadData.TabIndex = 27;
            this.Button_ReadData.Text = "Read";
            this.Button_ReadData.UseVisualStyleBackColor = true;
            this.Button_ReadData.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox_NewData
            // 
            this.textBox_NewData.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_NewData.Location = new System.Drawing.Point(232, 169);
            this.textBox_NewData.MaxLength = 30;
            this.textBox_NewData.Name = "textBox_NewData";
            this.textBox_NewData.Size = new System.Drawing.Size(187, 63);
            this.textBox_NewData.TabIndex = 26;
            this.textBox_NewData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox7_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(533, 55);
            this.label9.TabIndex = 25;
            this.label9.Text = "New Data to be Written:";
            // 
            // textBox_DataLength
            // 
            this.textBox_DataLength.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DataLength.Location = new System.Drawing.Point(232, 133);
            this.textBox_DataLength.MaxLength = 3;
            this.textBox_DataLength.Name = "textBox_DataLength";
            this.textBox_DataLength.Size = new System.Drawing.Size(187, 63);
            this.textBox_DataLength.TabIndex = 24;
            this.textBox_DataLength.Text = "6";
            this.textBox_DataLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
            // 
            // textBox_DataOffset
            // 
            this.textBox_DataOffset.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DataOffset.Location = new System.Drawing.Point(232, 97);
            this.textBox_DataOffset.MaxLength = 3;
            this.textBox_DataOffset.Name = "textBox_DataOffset";
            this.textBox_DataOffset.Size = new System.Drawing.Size(187, 63);
            this.textBox_DataOffset.TabIndex = 23;
            this.textBox_DataOffset.Text = "2";
            this.textBox_DataOffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(536, 55);
            this.label8.TabIndex = 22;
            this.label8.Text = "Data Length (in Words):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(514, 55);
            this.label6.TabIndex = 21;
            this.label6.Text = "Data Offset (in Words):";
            // 
            // textBox_AccessPassword
            // 
            this.textBox_AccessPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_AccessPassword.Location = new System.Drawing.Point(232, 61);
            this.textBox_AccessPassword.MaxLength = 8;
            this.textBox_AccessPassword.Name = "textBox_AccessPassword";
            this.textBox_AccessPassword.Size = new System.Drawing.Size(187, 63);
            this.textBox_AccessPassword.TabIndex = 20;
            this.textBox_AccessPassword.Text = "00000000";
            this.textBox_AccessPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(415, 55);
            this.label5.TabIndex = 19;
            this.label5.Text = "Access Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(663, 55);
            this.label4.TabIndex = 18;
            this.label4.Text = "Select Memory to Read/Write:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Reserved Memory",
            "EPC Memory",
            "TID Memory",
            "User Memory"});
            this.comboBox1.Location = new System.Drawing.Point(232, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(187, 63);
            this.comboBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_Temperature);
            this.groupBox2.Controls.Add(this.Button_Set);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textBox_Humidity);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textBox_Distance);
            this.groupBox2.Controls.Add(this.textBox_Angle);
            this.groupBox2.Controls.Add(this.textBox_PowerLevel);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(8, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 127);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reader Settings";
            // 
            // textBox_Temperature
            // 
            this.textBox_Temperature.Location = new System.Drawing.Point(380, 27);
            this.textBox_Temperature.Name = "textBox_Temperature";
            this.textBox_Temperature.Size = new System.Drawing.Size(44, 63);
            this.textBox_Temperature.TabIndex = 28;
            this.textBox_Temperature.Text = "0";
            // 
            // Button_Set
            // 
            this.Button_Set.Location = new System.Drawing.Point(198, 25);
            this.Button_Set.Name = "Button_Set";
            this.Button_Set.Size = new System.Drawing.Size(50, 30);
            this.Button_Set.TabIndex = 5;
            this.Button_Set.Text = "Set";
            this.Button_Set.UseVisualStyleBackColor = true;
            this.Button_Set.Click += new System.EventHandler(this.button3_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(269, 55);
            this.label10.TabIndex = 22;
            this.label10.Text = "Distance(ft)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 55);
            this.label2.TabIndex = 3;
            this.label2.Text = "Power Level:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(160, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(198, 55);
            this.label11.TabIndex = 27;
            this.label11.Text = "Angle(°)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(256, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(374, 55);
            this.label13.TabIndex = 29;
            this.label13.Text = "Temperature(°F)";
            // 
            // textBox_Humidity
            // 
            this.textBox_Humidity.Location = new System.Drawing.Point(380, 74);
            this.textBox_Humidity.Name = "textBox_Humidity";
            this.textBox_Humidity.Size = new System.Drawing.Size(44, 63);
            this.textBox_Humidity.TabIndex = 25;
            this.textBox_Humidity.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(283, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(284, 55);
            this.label12.TabIndex = 23;
            this.label12.Text = "Humidity(%)";
            // 
            // textBox_Distance
            // 
            this.textBox_Distance.Location = new System.Drawing.Point(107, 74);
            this.textBox_Distance.Name = "textBox_Distance";
            this.textBox_Distance.Size = new System.Drawing.Size(44, 63);
            this.textBox_Distance.TabIndex = 21;
            this.textBox_Distance.Text = "0";
            // 
            // textBox_Angle
            // 
            this.textBox_Angle.Location = new System.Drawing.Point(231, 74);
            this.textBox_Angle.Name = "textBox_Angle";
            this.textBox_Angle.Size = new System.Drawing.Size(44, 63);
            this.textBox_Angle.TabIndex = 26;
            this.textBox_Angle.Text = "0";
            // 
            // textBox_PowerLevel
            // 
            this.textBox_PowerLevel.Location = new System.Drawing.Point(108, 27);
            this.textBox_PowerLevel.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_PowerLevel.MaxLength = 2;
            this.textBox_PowerLevel.Name = "textBox_PowerLevel";
            this.textBox_PowerLevel.Size = new System.Drawing.Size(44, 63);
            this.textBox_PowerLevel.TabIndex = 2;
            this.textBox_PowerLevel.Text = "30";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 55);
            this.label3.TabIndex = 4;
            this.label3.Text = "dBm";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.number);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(8, 226);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(436, 103);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tag EPC Encoding";
            // 
            // number
            // 
            this.number.AutoSize = true;
            this.number.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number.ForeColor = System.Drawing.Color.DimGray;
            this.number.Location = new System.Drawing.Point(402, 25);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(51, 55);
            this.number.TabIndex = 42;
            this.number.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(421, 55);
            this.label7.TabIndex = 17;
            this.label7.Text = "New EPC number:";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(162, 22);
            this.textBox3.MaxLength = 30;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(233, 63);
            this.textBox3.TabIndex = 16;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(145, 59);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(147, 38);
            this.button5.TabIndex = 15;
            this.button5.Text = "Write";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Button_Read
            // 
            this.Button_Read.Location = new System.Drawing.Point(160, 30);
            this.Button_Read.Name = "Button_Read";
            this.Button_Read.Size = new System.Drawing.Size(137, 38);
            this.Button_Read.TabIndex = 0;
            this.Button_Read.Text = "Tag Inventory";
            this.Button_Read.UseVisualStyleBackColor = true;
            this.Button_Read.Click += new System.EventHandler(this.button2_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(274, 55);
            this.label14.TabIndex = 30;
            this.label14.Text = "#(Tag) / sec";
            // 
            // listBox_Metadata
            // 
            this.listBox_Metadata.FormattingEnabled = true;
            this.listBox_Metadata.ItemHeight = 55;
            this.listBox_Metadata.Location = new System.Drawing.Point(469, 336);
            this.listBox_Metadata.Name = "listBox_Metadata";
            this.listBox_Metadata.Size = new System.Drawing.Size(677, 224);
            this.listBox_Metadata.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(28F, 55F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 956);
            this.Controls.Add(this.listBox_Metadata);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox_EPC);
            this.Controls.Add(this.Button_Connect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GAO246008 C# Sample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_Connect;
        private System.Windows.Forms.ListBox listBox_EPC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Button_Read;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_PowerLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Button_Set;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label number;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button Button_Save;
        private System.Windows.Forms.ListBox listBox_Metadata;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Button_WriteData;
        private System.Windows.Forms.Button Button_ReadData;
        private System.Windows.Forms.TextBox textBox_NewData;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_DataLength;
        private System.Windows.Forms.TextBox textBox_DataOffset;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_AccessPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox_Distance;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_Humidity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_Angle;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_Temperature;
        private System.Windows.Forms.TextBox textBox_NumberOfTag;
        private System.Windows.Forms.Label label14;
      //  private System.Windows.Forms.Button button4;
    }
}

