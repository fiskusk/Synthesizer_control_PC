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
            _serialPort.Close();
        }

        private void Out1Button_Click(object sender, EventArgs e)
        {
            if (Out1Button.Text == "Out 1 Off")
            {
                Out1Button.Text = "Out 1 On";
                _serialPort.WriteLine("out 1 on");
            }
            else if (Out1Button.Text == "Out 1 On")
            {
                Out1Button.Text = "Out 1 Off";
                _serialPort.WriteLine("out 1 off");
            }
        }

        private void Out2Button_Click(object sender, EventArgs e)
        {
            if (Out2Button.Text == "Out 2 Off")
            {
                Out2Button.Text = "Out 2 On";
                _serialPort.WriteLine("out 2 on");
            }
            else if (Out2Button.Text == "Out 2 On")
            {
                Out2Button.Text = "Out 2 Off";
                _serialPort.WriteLine("out 2 off");
            }
        }

        private void PloInitButton_Click(object sender, EventArgs e)
        {
            _serialPort.WriteLine("PLO init");
        }
    }
}
