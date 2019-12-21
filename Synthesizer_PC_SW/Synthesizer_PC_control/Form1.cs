using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Synthesizer_PC_control
{
    public partial class Form1 : Form
    {
        static SerialPort _serialPort;
        static bool Reg0TextBox_was_focused = false;
        static bool Reg1TextBox_was_focused = false;
        static string old_reg0 = "80C90000";
        static string old_reg1 = "800103E9";

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
            PloInitButton.Enabled = true;
            Reg0TextBox.Enabled = true;
            Reg1TextBox.Enabled = true;

            _serialPort = new SerialPort("COM3", 115200);
            _serialPort.Open();
            _serialPort.NewLine = "\r";
        }

        private void ClosePortButton_Click(object sender, EventArgs e)
        {
            ClosePortButton.Enabled = false;
            OpenPortButton.Enabled = true;
            Out1Button.Enabled = false;
            Out2Button.Enabled = false;
            PloInitButton.Enabled = false;
            Reg0TextBox.Enabled = false;
            Reg1TextBox.Enabled = false;

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

        private void Form1_Click(object sender, EventArgs e)
        {
            Reg0Label.Focus();
            Reg0TextBox_was_focused = false;
            Reg1TextBox_was_focused = false;
            if ((Reg0TextBox.Enabled == true) && (!Reg0TextBox.Text.Equals(old_reg0)))
            {
                ChangeReg0();
            }
            if ((Reg1TextBox.Enabled == true) && (!Reg1TextBox.Text.Equals(old_reg1)))
            {
                ChangeReg1();
                ChangeReg0();
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

     }
}
