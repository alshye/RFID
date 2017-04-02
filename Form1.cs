using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private SerialPort reader;
        string ReadCommand;
        string[] temp = null;

        const int count = 100;

        SqlConnection conn;
        int read_count = 0;
        string EPC, data;
        int success = 0, epc_fail = 0, data_fail = 0, both_fail = 0;

        private void ConnectDB() 
        {
            conn = new SqlConnection("Data Source=DESKTOP-NOOMVQH\\MSSQL;Initial Catalog=MSSQL;Integrated Security=True");
            try
            {
                conn.Open();
            }
            catch
            {
                MessageBox.Show("Database Open Error");
            }
        }

        private void InsertTagInfoDB(string EPC, string data)
        {
            string query = "Insert into TagInfo(EPC, DATA, DATE) Values ('" + EPC + "', '" + data + "', getdate())";
            SqlCommand sql = new SqlCommand(query, conn);
            try
            {
                sql.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error to save on TagInfo Database");
            }
        }

        private void InsertResultDB(float success_rate)
        {
            string query = "Insert into Read_Result(Success, EPC_Fail, Data_Fail, Both_Fail, TagPerSec, Distance, Angle, Temperature, Humidity, Success_Rate, Date) Values (" 
                + success + ", " + epc_fail + ", " + data_fail + ", " + both_fail + ", "
                + this.textBox_NumberOfTag.Text + ", " + this.textBox_Distance.Text + ", "
                + this.textBox_Angle.Text + ", " + this.textBox_Temperature.Text + ", "
                + this.textBox_Humidity.Text + ", " + success_rate + ", GetDate())";

            SqlCommand sql = new SqlCommand(query, conn);
            try
            {
                sql.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error to save on Result Database");
            }

            InsertResultIDDB();
        }

        private void InsertResultIDDB()
        {
            string query = "Update TagInfo Set ResultID = (Select MAX(ID) From Read_Result) Where ID Between (Select MAX(ID) From TagInfo)-99 And (Select MAX(ID) From TagInfo)";
            
            SqlCommand sql = new SqlCommand(query, conn);
            try
            {
                sql.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error to save ResultID on TagInfo Database");
            }
        }

        private void logFile(float success_rate)
        {
            StreamWriter log;
            string filename = this.textBox_NumberOfTag.Text + "_" + this.textBox_Distance.Text + "_" +
                this.textBox_Angle.Text + "_" + this.textBox_Temperature.Text + "_" + this.textBox_Humidity.Text +
                "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

            if (!File.Exists(filename))
                log = new StreamWriter(filename);
            else
                log = File.AppendText(filename);

            // Write to the file:
            log.WriteLine(count + "\t" + success + "\t" + epc_fail + "\t" + 
                           data_fail + "\t" + both_fail + "\t" + success_rate);

            log.Close();

           /* filename = this.textBox_NumberOfTag.Text + "_" + this.textBox_Distance.Text + "_" +
                this.textBox_Angle.Text + "_" + this.textBox_Temperature.Text + "_" + this.textBox_Humidity.Text;

            if (!File.Exists(filename))
            {
                log = new StreamWriter(filename);
            }
            else
            {
                log = File.AppendText(filename);
            }

            // Write to the file:
            log.WriteLine(count + "\t" + success + "\t" + epc_fail + "\t" +
                           data_fail + "\t" + both_fail + "\t" + success_rate);

            log.Close(); */
        }

        private void checkData(string EPC, string data)
        {
            Dictionary<string, string> tag = new Dictionary<string, string>();
            tag.Add("201602260000000000000271", "12345678900000000000");
            tag.Add("201602260000000000000279", "987600000121000000000000");
            tag.Add("201602260000000000000280", "765432090000000000000000");

            int count = 0;
            foreach (var item in tag)
            {
                if (item.Key.Equals(EPC))                   // At least one of them(EPC, DATA) is matched
                {
                    if (item.Value.Equals(data))
                        success++;
                    else 
                    {   
                        data_fail++;
                        break;
                    }
                    count++;
                }
                else                                        
                {
                    if (item.Value.Equals(data))            // At least DATA is matched
                    {
                        epc_fail++;
                        count++;
                        break;
                    }
                }
            }   
            if (count == 0)                                 // Nothing is matched
                both_fail++;
        }

        private void Initialize()
        {
            read_count = 0;
            success = epc_fail = data_fail = both_fail = 0;
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File | *.txt";
            saveFileDialog.Title = "Save a Log File";
            saveFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog.FileName != "" && saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter log = new StreamWriter(saveFileDialog.OpenFile());
                    if (!File.Exists(saveFileDialog.FileName))
                    {
                        log = File.AppendText(saveFileDialog.FileName);
                    }
                    log.Dispose();
                    log.Close();
                }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            this.Close();
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            if (this.textBox1.Text == "")
            {
                this.listBox_EPC.Items.Add("Make sure the com port number is valid!");
                this.listBox_EPC.SelectedIndex = this.listBox_EPC.Items.Count - 1;
                return;
            }
            if (int.TryParse(this.textBox1.Text, out n) == false)
            {
                this.listBox_EPC.Items.Add("Make sure the com port number is valid!");
                this.listBox_EPC.SelectedIndex = this.listBox_EPC.Items.Count - 1;
                return;
            }
            if (this.Button_Connect.Text == "Connect")
            {
                try
                {
                    if (reader != null)
                    {
                        reader = null;
                    }
                    reader = new SerialPort(
                        "COM" + this.textBox1.Text,
                        115200,
                        Parity.None,
                        8,
                        StopBits.One);
                    reader.ReadTimeout = 1000;
                    reader.WriteTimeout = 1000;
                    reader.Open();

                    if (reader.IsOpen)
                    {
                        this.listBox_EPC.Items.Add("Successfully Connected the 246008.");
                        this.listBox_EPC.SelectedIndex = this.listBox_EPC.Items.Count - 1;
                        this.Button_Connect.Text = "Disconnect";
                        this.groupBox1.Enabled = true;
                        this.groupBox2.Enabled = true;
                        this.groupBox3.Enabled = true;
                        this.groupBox4.Enabled = true;
                        Put246008intoASCII();
                        ConnectDB();
                    }
                    else
                    {
                        this.groupBox1.Enabled = false;
                        this.groupBox2.Enabled = false;
                        this.groupBox3.Enabled = false;
                        this.groupBox4.Enabled = false;
                        MessageBox.Show("Open 246008 Bluetooth virtual com port error ");
                    }
                }
                catch
                {
                    this.groupBox1.Enabled = false;
                    this.groupBox2.Enabled = false;
                    this.groupBox3.Enabled = false;
                    this.groupBox4.Enabled = false;
                    MessageBox.Show("Open serial port error, check the Bluetooth connection please, or re-opening the program may work.");
                }
            }
            else
            {
                try
                {
                    if (reader != null && reader.IsOpen)
                    {
                        Thread.Sleep(500);
                        reader.Close();
                    }
                }
                catch { }
                reader = null;
                this.Button_Connect.Text = "Connect";
                this.Button_Read.Text = "Tag Inventory";
                this.groupBox1.Enabled = false;
                this.groupBox2.Enabled = false;
                this.groupBox3.Enabled = false;
                this.groupBox4.Enabled = false;
            }
        }
        private void Put246008intoASCII()
        {
            string ASCIIModeCommand = "\u000d\u000a"; //put the reader into the ascii command line mode
            reader.Write(ASCIIModeCommand);
            reader.Write(ASCIIModeCommand);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.Button_Read.Text == "Tag Inventory")
            {
                Initialize();
                reader.DataReceived += new SerialDataReceivedEventHandler(reader_DataReceived);
                Put246008intoASCII();
                this.Button_Read.Text = "Stop";
                this.Button_Connect.Enabled = false;
                this.groupBox2.Enabled = false;
                this.groupBox3.Enabled = false;
                this.groupBox4.Enabled = false;
                this.listBox_EPC.Items.Add("Inventory Started! Press and hold the trigger button to scan tags...");
                this.listBox_EPC.SelectedIndex = this.listBox_EPC.Items.Count - 1;
            }
            else
            {
                float success_rate = (success / (float)count) * 100;
                InsertResultDB(success_rate);
                logFile(success_rate); 
                this.Button_Read.Text = "Tag Inventory";
                this.Button_Connect.Enabled = true;
                this.groupBox2.Enabled = true;
                this.groupBox3.Enabled = true;
                this.groupBox4.Enabled = true;
                reader.DataReceived -= new SerialDataReceivedEventHandler(reader_DataReceived);
            }
        }
        void reader_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (read_count == count) return;

            read_count++;
            EPC = "";
            data = "";

            Thread.Sleep(300 / int.Parse(this.textBox_NumberOfTag.Text));
            string result = reader.ReadExisting();
            Console.WriteLine(result);

            string readCommand = "r, 6, 3, 2, 000000000,0,0\u000d\u000a";
            Console.WriteLine(readCommand);
            reader.DiscardInBuffer();
            reader.Write(readCommand);

            Thread.Sleep(500 / int.Parse(this.textBox_NumberOfTag.Text));

            string StopReadCommand = "s\u000d\u000a";
            reader.Write(StopReadCommand);

            if ((result.Contains("ok") && (result.Contains(",e=") || result.Contains(",E=")) || result.Contains("end=-1,r")))       // reading either EPC or data back successfully, then parse it -
            {
                result = result.Replace("\r\n", ";").Replace("end=-1,r", "").Replace("ok", "").Replace("$>", "").Replace(",e=", ";");
                if (result.Contains("^")) result = result.Replace(result.Substring(result.IndexOf("^")), "");
                //igore the "ok" and the rest of the data, just retrieve the raw data back

                temp = result.Split(';');
                for (int i = 0; i < temp.Length; i++)
                {
                    try
                    {
                        if (temp[i] != "")
                        {
                            try
                            {
                                if (i % 2 == 0) EPC = temp[i].Substring(4, temp[i].Length - 8);
                                else data = temp[i].Substring(0, temp[i].Length - 4);
                            }
                            catch { }
                        }
                    }
                    catch { }
                }
            }
            
            if(EPC.Equals("")) EPC = "------------------------";
            if(data.Equals("")) data = "------------------------";
            this.listBox_EPC.Invoke((MethodInvoker)(() => this.listBox_EPC.Items.Add(EPC))); //output the data to the listbox
            this.listBox_EPC.Invoke((MethodInvoker)(() => this.listBox_EPC.SelectedIndex = this.listBox_EPC.Items.Count - 1));
            this.listBox_Metadata.Invoke((MethodInvoker)(() => this.listBox_Metadata.Items.Add(data))); //output the data to the listbox
            this.listBox_Metadata.Invoke((MethodInvoker)(() => this.listBox_Metadata.SelectedIndex = this.listBox_Metadata.Items.Count - 1));
            
            InsertTagInfoDB(EPC, data);
            checkData(EPC, data);

            if (result.Trim().Contains("trigger=1")) //trigger button pressed and held
            {
                this.groupBox1.Invoke((MethodInvoker)(() => this.groupBox1.Enabled = false));
                ReadCommand = "i,0\u000d\u000a";
                reader.Write(ReadCommand);
            }
            if (result.Trim().Contains("trigger=0")) //trigger button released
            {
                this.groupBox1.Invoke((MethodInvoker)(() => this.groupBox1.Enabled = true));
                StopReadCommand = "s\u000d\u000a";
                reader.Write(StopReadCommand);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = false;
            this.groupBox2.Enabled = false;
            this.groupBox3.Enabled = false;
            this.groupBox4.Enabled = false;
            this.comboBox1.SelectedIndex = 0;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(this.textBox_PowerLevel.Text, out n) == false)
            {
                this.listBox_EPC.Items.Add("Make sure the power level is an numeric value (0-30)");
                this.listBox_EPC.SelectedIndex = this.listBox_EPC.Items.Count - 1;
                return;
            }
            //convert the dBm to anntenuation value
            string singleCommand = "txp,-" + (30 - Convert.ToInt32(this.textBox_PowerLevel.Text)) + "\u000d\u000a";
            Console.WriteLine(singleCommand);
            reader.DiscardInBuffer();
            reader.Write(singleCommand);
            Thread.Sleep(200);
            string result = reader.ReadExisting();
            if (result.Contains("ok"))
            {
                this.listBox_EPC.Items.Add("Set reader power level OK!");
                this.listBox_EPC.SelectedIndex = this.listBox_EPC.Items.Count - 1;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string singleCommand = "br.batt,0\u000d\u000a";
            Console.WriteLine(singleCommand);
            reader.DiscardInBuffer();
            reader.Write(singleCommand);
            Thread.Sleep(200);
            string result = reader.ReadExisting();
            Console.WriteLine(result);
            string StopReadCommand = "s\u000d\u000a";
            reader.Write(StopReadCommand);
            if (result.Contains("ok"))
            {
                result = result.Replace("ok,", "");
                result = result.Replace("$>", "").Trim();
                this.listBox_EPC.Items.Add("The current Battery level is: " + result + "%");
                this.listBox_EPC.SelectedIndex = this.listBox_EPC.Items.Count - 1;
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ("0123456789ABCDEFabcdef".IndexOf(Char.ToUpper(e.KeyChar)) < 0);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox3.Text.Length > 30)
            {
                this.textBox3.Text = this.textBox3.Text.Substring(0, this.textBox3.Text.Length - 1);
            }
            else
            {
                this.number.Text = this.textBox3.Text.Length.ToString();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (this.textBox3.Text.Length > 30)
            {
                MessageBox.Show("Invalid data length! Typically an EPC Gen 2 tag EPC length is less than 30 Hex-decimal digits!");
                return;
            }
            reader.DiscardInBuffer();
            string writetagCommand = "w,6,1,2," + this.textBox3.Text + ",0,0,0\u000d\u000a";
            reader.Write(writetagCommand);
            Thread.Sleep(200);
            string result = reader.ReadExisting();
            if (result.Contains("ok"))
            {
                string StopReadCommand = "s\u000d\u000a";
                reader.Write(StopReadCommand);
                this.listBox_EPC.Items.Add("Encoding new EPC value OK!");
                this.listBox_EPC.SelectedIndex = this.listBox_EPC.Items.Count - 1;
            }
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ("0123456789".IndexOf(Char.ToUpper(e.KeyChar)) < 0);
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ("0123456789".IndexOf(Char.ToUpper(e.KeyChar)) < 0);
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ("0123456789".IndexOf(Char.ToUpper(e.KeyChar)) < 0);
        }
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ("0123456789ABCDEFabcdef".IndexOf(Char.ToUpper(e.KeyChar)) < 0);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (this.textBox_AccessPassword.Text.Length != 8)
            {
                this.listBox_EPC.Items.Add("The Access Password has to be 8 HEX-Decimal digits long!");
                this.listBox_EPC.SelectedIndex = this.listBox_EPC.Items.Count - 1;
                return;
            }
            string readCommand = "r," + this.textBox_DataLength.Text + ","
                                      + this.comboBox1.SelectedIndex
                                      + "," + this.textBox_DataOffset.Text
                                      + "," + this.textBox_AccessPassword.Text
                                      + "0,0,0\u000d\u000a";
            Console.WriteLine(readCommand);
            reader.DiscardInBuffer();
            reader.Write(readCommand);
            Thread.Sleep(200);
            string result = reader.ReadExisting();
            Console.WriteLine(result);
            string StopReadCommand = "s\u000d\u000a";
            reader.Write(StopReadCommand);
            if (result.Contains("ok") && (result.Contains(",e=") || result.Contains(",E="))) //reading data back successfully, then parse it -
            {
                result = result.Substring(2, Convert.ToInt32(this.textBox_DataLength.Text) * 4 + 2); //igore the "ok" and the rest of the data, just retrieve the raw data back
                this.listBox_EPC.Items.Add(result);
                this.listBox_EPC.SelectedIndex = this.listBox_EPC.Items.Count - 1;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(this.textBox_DataOffset.Text, out n) == false)
            {
                this.listBox_EPC.Items.Add("Data Offset cannot be empty!");
                this.listBox_EPC.SelectedIndex = this.listBox_EPC.Items.Count - 1;
                return;
            }
            if (int.TryParse(this.textBox_DataLength.Text, out n) == false)
            {
                this.listBox_EPC.Items.Add("Data Length cannot be empty!");
                this.listBox_EPC.SelectedIndex = this.listBox_EPC.Items.Count - 1;
                return;
            }
            if (this.comboBox1.SelectedIndex == 0 || this.comboBox1.SelectedIndex == 2)
            {
                this.listBox_EPC.Items.Add("The data in 'Reserved' or 'TID' Memory is NOT allowed to be changed!");
                this.listBox_EPC.SelectedIndex = this.listBox_EPC.Items.Count - 1;
                return;
            }
            if (this.textBox_NewData.Text.Length == 0 || this.textBox_NewData.Text.Length > Convert.ToInt32(this.textBox_DataLength.Text) * 4)
            {
                this.listBox_EPC.Items.Add("The data to be written is empty Or it has different length than the 'Data Length' * 4, Try again!");
                this.listBox_EPC.SelectedIndex = this.listBox_EPC.Items.Count - 1;
                return;
            }
            reader.DiscardInBuffer();
            string writetagCommand = "w," + this.textBox_DataLength.Text + ","
                          + this.comboBox1.SelectedIndex
                          + "," + this.textBox_DataOffset.Text
                          + "," + this.textBox_NewData.Text
                          + "," + this.textBox_AccessPassword.Text
                          + "0,0,0\u000d\u000a";
            reader.Write(writetagCommand);
            Thread.Sleep(200);
            string result = reader.ReadExisting();
            string StopReadCommand = "s\u000d\u000a";
            reader.Write(StopReadCommand);
            if (result.Contains("ok"))
            {
                this.listBox_EPC.Items.Add("Writing data onto tag OK!");
                this.listBox_EPC.SelectedIndex = this.listBox_EPC.Items.Count - 1;
            }
        }
    }
}
