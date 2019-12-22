using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;

namespace Synthesizer_PC_control
{
    public partial class Form1 : Form
    {
        static SerialPort _serialPort;
        static bool Reg0TextBox_was_focused = false;
        static bool Reg1TextBox_was_focused = false;
        static bool Reg2TextBox_was_focused = false;
        static bool Reg3TextBox_was_focused = false;
        static bool Reg4TextBox_was_focused = false;
        static bool Reg5TextBox_was_focused = false;
        static string old_reg0 = "80C90000";
        static string old_reg1 = "800103E9";
        static string old_reg2 = "00005F42";
        static string old_reg3 = "00001F23";
        static string old_reg4 = "63BE80E4";
        static string old_reg5 = "00400005";

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenPortButton_Click(object sender, EventArgs e)
        {
            ClosePortButton.Enabled = true;
            OpenPortButton.Enabled = false;
            Out1Button.Enabled = true;
            Out2Button.Enabled = true;
            RefButton.Enabled = true;
            PloInitButton.Enabled = true;
            Reg0TextBox.Enabled = true;
            Reg1TextBox.Enabled = true;
            Reg2TextBox.Enabled = true;
            Reg3TextBox.Enabled = true;
            Reg4TextBox.Enabled = true;
            Reg5TextBox.Enabled = true;
            SetAsDefaultRegButton.Enabled = true;
            ForceLoadRegButton.Enabled = true;


            _serialPort = new SerialPort("COM3", 115200);   // TODO udelat rozeviraci nabidku pro vyber COM portu
            _serialPort.Open();                             // TODO po otevreni portu zjistit, jestli byl synt. programovan, a jestli ano, nacist data
            _serialPort.NewLine = "\r";
        }

        private void ClosePortButton_Click(object sender, EventArgs e)
        {
            ClosePortButton.Enabled = false;
            OpenPortButton.Enabled = true;
            Out1Button.Enabled = false;
            Out2Button.Enabled = false;
            RefButton.Enabled = false;
            PloInitButton.Enabled = false;
            Reg0TextBox.Enabled = false;
            Reg1TextBox.Enabled = false;
            Reg2TextBox.Enabled = false;
            Reg3TextBox.Enabled = false;
            Reg4TextBox.Enabled = false;
            Reg5TextBox.Enabled = false;
            SetAsDefaultRegButton.Enabled = false;
            ForceLoadRegButton.Enabled = false;

            _serialPort.Close();
        }

        private void Out1Button_Click(object sender, EventArgs e)
        {
            if (Out1Button.Text == "Out 1 On")
            {
                Out1Button.Text = "Out 1 Off";
                _serialPort.WriteLine("out 1 on");
            }
            else if (Out1Button.Text == "Out 1 Off")
            {
                Out1Button.Text = "Out 1 On";
                _serialPort.WriteLine("out 1 off");
            }
        }

        private void Out2Button_Click(object sender, EventArgs e)
        {
            if (Out2Button.Text == "Out 2 On")
            {
                Out2Button.Text = "Out 2 Off";
                _serialPort.WriteLine("out 2 on");
            }

            else if (Out2Button.Text == "Out 2 Off")
            {
                Out2Button.Text = "Out 2 On";
                _serialPort.WriteLine("out 2 off");
            }
        }

        private void RefButton_Click(object sender, EventArgs e)
        {
            if (RefButton.Text == "Ext Ref")
            {
                RefButton.Text = "Int Ref";
                _serialPort.WriteLine("ref ext");
            }

            else if (RefButton.Text == "Int Ref")
            {
                RefButton.Text = "Ext Ref";
                _serialPort.WriteLine("ref int");
            }
        }

        private void PloInitButton_Click(object sender, EventArgs e)
        {
            _serialPort.WriteLine("PLO init");
        }

        private void Reg0TextBox_Click(object sender, EventArgs e)
        {
            if (Reg0TextBox_was_focused == false)
            {
                Reg0TextBox.Focus();
                Reg0TextBox.SelectAll();
                Reg0TextBox_was_focused = true;
            }
        }

        private void Reg0TextBox_TextChanged(object sender, EventArgs e)
        {
            string item = Reg0TextBox.Text;
            int n = 0;
            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
                item != String.Empty)
            {
                Reg0TextBox.Text = item.Remove(item.Length - 1, 1);
                Reg0TextBox.SelectionStart = Reg0TextBox.Text.Length;
            }
        }

        private void Reg0TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Form1_Click(this, new EventArgs());
            }
        }

        private void Reg1TextBox_Click(object sender, EventArgs e)
        {
            if (Reg1TextBox_was_focused == false)
            {
                Reg1TextBox.Focus();
                Reg1TextBox.SelectAll();
                Reg1TextBox_was_focused = true;
            }
        }

        private void Reg1TextBox_TextChanged(object sender, EventArgs e)
        {
            string item = Reg1TextBox.Text;
            int n = 0;
            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
                item != String.Empty)
            {
                Reg1TextBox.Text = item.Remove(item.Length - 1, 1);
                Reg1TextBox.SelectionStart = Reg1TextBox.Text.Length;
            }
        }
        private void Reg1TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Form1_Click(this, new EventArgs());
            }
        }

        private void Reg2TextBox_Click(object sender, EventArgs e)
        {
            if (Reg2TextBox_was_focused == false)
            {
                Reg2TextBox.Focus();
                Reg2TextBox.SelectAll();
                Reg2TextBox_was_focused = true;
            }
        }

        private void Reg2TextBox_TextChanged(object sender, EventArgs e)
        {
            string item = Reg2TextBox.Text;
            int n = 0;
            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
                item != String.Empty)
            {
                Reg2TextBox.Text = item.Remove(item.Length - 1, 1);
                Reg2TextBox.SelectionStart = Reg2TextBox.Text.Length;
            }
        }
        private void Reg2TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Form1_Click(this, new EventArgs());
            }
        }

        private void Reg3TextBox_Click(object sender, EventArgs e)
        {
            if (Reg3TextBox_was_focused == false)
            {
                Reg3TextBox.Focus();
                Reg3TextBox.SelectAll();
                Reg3TextBox_was_focused = true;
            }
        }

        private void Reg3TextBox_TextChanged(object sender, EventArgs e)
        {
            string item = Reg3TextBox.Text;
            int n = 0;
            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
                item != String.Empty)
            {
                Reg3TextBox.Text = item.Remove(item.Length - 1, 1);
                Reg3TextBox.SelectionStart = Reg3TextBox.Text.Length;
            }
        }
        private void Reg3TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Form1_Click(this, new EventArgs());
            }
        }

        private void Reg4TextBox_Click(object sender, EventArgs e)
        {
            if (Reg4TextBox_was_focused == false)
            {
                Reg4TextBox.Focus();
                Reg4TextBox.SelectAll();
                Reg4TextBox_was_focused = true;
            }
        }

        private void Reg4TextBox_TextChanged(object sender, EventArgs e)
        {
            string item = Reg4TextBox.Text;
            int n = 0;
            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
                item != String.Empty)
            {
                Reg4TextBox.Text = item.Remove(item.Length - 1, 1);
                Reg4TextBox.SelectionStart = Reg4TextBox.Text.Length;
            }
        }
        private void Reg4TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Form1_Click(this, new EventArgs());
            }
        }

        private void Reg5TextBox_Click(object sender, EventArgs e)
        {
            if (Reg5TextBox_was_focused == false)
            {
                Reg5TextBox.Focus();
                Reg5TextBox.SelectAll();
                Reg5TextBox_was_focused = true;
            }
        }

        private void Reg5TextBox_TextChanged(object sender, EventArgs e)
        {
            string item = Reg5TextBox.Text;
            int n = 0;
            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
                item != String.Empty)
            {
                Reg5TextBox.Text = item.Remove(item.Length - 1, 1);
                Reg5TextBox.SelectionStart = Reg5TextBox.Text.Length;
            }
        }
        private void Reg5TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Form1_Click(this, new EventArgs());
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Reg0Label.Focus();
            Reg0TextBox_was_focused = false;
            Reg1TextBox_was_focused = false;
            Reg2TextBox_was_focused = false;
            Reg3TextBox_was_focused = false;
            Reg4TextBox_was_focused = false;
            Reg5TextBox_was_focused = false;
            if ((Reg0TextBox.Enabled == true) && (!Reg0TextBox.Text.Equals(old_reg0)))
            {
                ChangeReg0();
            }
            if ((Reg1TextBox.Enabled == true) && (!Reg1TextBox.Text.Equals(old_reg1)))
            {
                ChangeReg1();
                ChangeReg0();
            }
            if ((Reg2TextBox.Enabled == true) && (!Reg2TextBox.Text.Equals(old_reg2)))
            {
                ChangeReg2();
                ChangeReg0();
            }
            if ((Reg3TextBox.Enabled == true) && (!Reg3TextBox.Text.Equals(old_reg3)))
            {
                ChangeReg3();
            }
            if ((Reg4TextBox.Enabled == true) && (!Reg4TextBox.Text.Equals(old_reg4)))
            {
                ChangeReg4();;
            }
            if ((Reg5TextBox.Enabled == true) && (!Reg5TextBox.Text.Equals(old_reg5)))
            {
                ChangeReg5();
            }
        }

        private void ChangeReg0()
        {
            string data = String.Format("plo set_register {0}", Reg0TextBox.Text);
            old_reg0 = Reg0TextBox.Text;
            _serialPort.WriteLine(data);
        }

        private void ChangeReg1()
        {
            string data = String.Format("plo set_register {0}", Reg1TextBox.Text);
            old_reg1 = Reg1TextBox.Text;
            _serialPort.WriteLine(data);
        }

        private void ChangeReg2()
        {
            string data = String.Format("plo set_register {0}", Reg2TextBox.Text);
            old_reg2 = Reg2TextBox.Text;
            _serialPort.WriteLine(data);
        }

        private void ChangeReg3()
        {
            string data = String.Format("plo set_register {0}", Reg3TextBox.Text);
            old_reg3 = Reg3TextBox.Text;
            _serialPort.WriteLine(data);
        }

        private void ChangeReg4()
        {
            string data = String.Format("plo set_register {0}", Reg4TextBox.Text);
            old_reg4 = Reg4TextBox.Text;
            _serialPort.WriteLine(data);
        }

        private void ChangeReg5()
        {
            string data = String.Format("plo set_register {0}", Reg5TextBox.Text);
            old_reg5 = Reg5TextBox.Text;
            _serialPort.WriteLine(data);
        }

        private void SetAsDefaultRegButton_Click(object sender, EventArgs e)
        {
            // _serialPort.WriteLine("PLO init");  // TODO naucit se ukladat nastaveni
            string actual_dir = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            if (!Directory.Exists(actual_dir + @"\conf\"))
                Directory.CreateDirectory(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\conf\");
            string folder = actual_dir + @"\conf\";
            string fileName = folder + @"defaults.txt";    
     
            // Check if file already exists. If yes, delete it.     
            if (File.Exists(fileName))    
            {    
                File.Delete(fileName);    
            }    
            
            // Create a new file     
            using (StreamWriter sw = File.CreateText(fileName))
            {
                sw.WriteLine(Reg0TextBox.Text);
                sw.WriteLine(Reg1TextBox.Text);
                sw.WriteLine(Reg2TextBox.Text);
                sw.WriteLine(Reg3TextBox.Text);
                sw.WriteLine(Reg4TextBox.Text);
                sw.WriteLine(Reg5TextBox.Text);
            }
        }

        private void ForceLoadRegButton_Click(object sender, EventArgs e)
        {
            ChangeReg5();
            Thread.Sleep(1);
            ChangeReg4();
            Thread.Sleep(1);
            ChangeReg3();
            Thread.Sleep(1);
            ChangeReg2();
            Thread.Sleep(1);
            ChangeReg1();
            Thread.Sleep(1);
            ChangeReg0();
            Thread.Sleep(1);
        }
     }
}
