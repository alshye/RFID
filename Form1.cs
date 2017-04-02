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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private SerialPort reader;
        string ReadCommand;
        string[] temp = null;
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
                this.listBox1.Items.Add("Make sure the com port number is valid!");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                return;
            }
            if (int.TryParse(this.textBox1.Text, out n) == false)
            {
                this.listBox1.Items.Add("Make sure the com port number is valid!");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                return;
            }
            if (this.button1.Text == "Connect")
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
                        this.listBox1.Items.Add("Successfully Connected the 246008.");
                        this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                        this.button1.Text = "Disconnect";
                        this.groupBox1.Enabled = true;
                        this.groupBox2.Enabled = true;
                        this.groupBox3.Enabled = true;
                        this.groupBox4.Enabled = true;
                        Put246008intoASCII();
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
                this.button1.Text = "Connect";
                this.button2.Text = "Tag Inventory";
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
            if (this.button2.Text == "Tag Inventory")
            {
                reader.DataReceived += new SerialDataReceivedEventHandler(reader_DataReceived);
                Put246008intoASCII();
                this.button2.Text = "Stop";
                this.button1.Enabled = false;
                this.groupBox2.Enabled = false;
                this.groupBox3.Enabled = false;
                this.groupBox4.Enabled = false;
                this.listBox1.Items.Add("Inventory Started! Press and hold the trigger button to scan tags...");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
            }
            else
            {
                this.button2.Text = "Tag Inventory";
                this.button1.Enabled = true;
                this.groupBox2.Enabled = true;
                this.groupBox3.Enabled = true;
                this.groupBox4.Enabled = true;
                reader.DataReceived -= new SerialDataReceivedEventHandler(reader_DataReceived);
            }
        }
        void reader_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(100);
            string rawString = reader.ReadExisting();
            Console.WriteLine(rawString);
            if (rawString.Trim().Contains("ok") || rawString.Trim().Contains("=0") || rawString.Trim().Contains("n") || rawString.Trim().Contains("=") || rawString.Trim().Contains("-") || rawString.Trim().Contains("$"))
            {
                // ignore the non-tag data operations
            }
            else
            {
                rawString = rawString.Replace("\r\n", ";");
                temp = rawString.Split(';');
                for (int i = 0; i < temp.Length; i++)
                {
                    try
                    {
                        if (temp[i] != "")
                        {
                            try
                            {
                                // Here is the tags' EPC ID
                                this.listBox1.Invoke((MethodInvoker)(() => this.listBox1.Items.Add(temp[i].Substring(0, temp[i].Length - 4)))); //output the data to the listbox
                                this.listBox1.Invoke((MethodInvoker)(() => this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1));
                            }
                            catch { }
                        }
                    }
                    catch { }
                }
            }
            if (rawString.Trim().Contains("trigger=1")) //trigger button pressed and held
            {
                this.groupBox1.Invoke((MethodInvoker)(() => this.groupBox1.Enabled = false));
                ReadCommand = "i,0\u000d\u000a";
                reader.Write(ReadCommand);
            }
            if (rawString.Trim().Contains("trigger=0")) //trigger button released
            {
                this.groupBox1.Invoke((MethodInvoker)(() => this.groupBox1.Enabled = true));
                string StopReadCommand = "s\u000d\u000a";
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
            if (int.TryParse(this.textBox2.Text, out n) == false)
            {
                this.listBox1.Items.Add("Make sure the power level is an numeric value (0-30)");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                return;
            }
            //convert the dBm to anntenuation value
            string singleCommand = "txp,-" + (30 - Convert.ToInt32(this.textBox2.Text)) + "\u000d\u000a";
            Console.WriteLine(singleCommand);
            reader.DiscardInBuffer();
            reader.Write(singleCommand);
            Thread.Sleep(200);
            string result = reader.ReadExisting();
            if (result.Contains("ok"))
            {
                this.listBox1.Items.Add("Set reader power level OK!");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
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
            if (result.Contains("ok"))
            {
                result = result.Replace("ok,", "");
                result = result.Replace("$>", "").Trim();
                this.listBox1.Items.Add("The current Battery level is: " + result + "%");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
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
                this.listBox1.Items.Add("Encoding new EPC value OK!");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
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
            if (this.textBox4.Text.Length != 8)
            {
                this.listBox1.Items.Add("The Access Password has to be 8 HEX-Decimal digits long!");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                return;
            }
            string readCommand = "r," + this.textBox6.Text + "," 
                                      + this.comboBox1.SelectedIndex 
                                      + "," + this.textBox5.Text 
                                      + "," + this.textBox4.Text
                                      + "0,0,0\u000d\u000a";
            Console.WriteLine(readCommand);
            reader.DiscardInBuffer();
            reader.Write(readCommand);
            Thread.Sleep(100);
            string result = reader.ReadExisting();
            Console.WriteLine(result);
            string StopReadCommand = "s\u000d\u000a";
            reader.Write(StopReadCommand);
            if (result.Contains("ok") && (result.Contains(",e=") || result.Contains(",E="))) //reading data back successfully, then parse it -
            {
                result = result.Substring(2, Convert.ToInt32(this.textBox6.Text) * 4 + 2); //igore the "ok" and the rest of the data, just retrieve the raw data back
                this.listBox1.Items.Add(result);
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(this.textBox5.Text, out n) == false)
            {
                this.listBox1.Items.Add("Data Offset cannot be empty!");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                return;
            }
            if (int.TryParse(this.textBox6.Text, out n) == false)
            {
                this.listBox1.Items.Add("Data Length cannot be empty!");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                return;
            }
            if (this.comboBox1.SelectedIndex == 0 || this.comboBox1.SelectedIndex == 2)
            {
                this.listBox1.Items.Add("The data in 'Reserved' or 'TID' Memory is NOT allowed to be changed!");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                return;
            }
            if (this.textBox7.Text.Length == 0 || this.textBox7.Text.Length > Convert.ToInt32(this.textBox6.Text) * 4)
            {
                this.listBox1.Items.Add("The data to be written is empty Or it has different length than the 'Data Length' * 4, Try again!");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                return;
            }
            reader.DiscardInBuffer();
            string writetagCommand = "w," + this.textBox6.Text + ","
                          + this.comboBox1.SelectedIndex
                          + "," + this.textBox5.Text
                          + "," + this.textBox7.Text
                          + "," + this.textBox4.Text
                          + "0,0,0\u000d\u000a";
            reader.Write(writetagCommand);
            Thread.Sleep(200);
            string result = reader.ReadExisting();
            string StopReadCommand = "s\u000d\u000a";
            reader.Write(StopReadCommand);
            if (result.Contains("ok"))
            {
                this.listBox1.Items.Add("Writing data onto tag OK!");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
            }
        }
    }
}
