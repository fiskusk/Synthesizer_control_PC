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
            _serialPort = new SerialPort("COM3", 115200);
            _serialPort.Open();
            _serialPort.NewLine = "\r";
        }

        private void ClosePortButton_Click(object sender, EventArgs e)
        {
            _serialPort.Close();
        }

        private void out1Button_Click(object sender, EventArgs e)
        {
            if (out1Button.Text == "Out 1 Off")
            {
                out1Button.Text = "Out 1 On";
                _serialPort.WriteLine("out 1 on");
            }
            else if (out1Button.Text == "Out 1 On")
            {
                out1Button.Text = "Out 1 Off";
                _serialPort.WriteLine("out 1 off");
            }
        }

        private void out2Button_Click(object sender, EventArgs e)
        {
            if (out2Button.Text == "Out 2 Off")
            {
                out2Button.Text = "Out 2 On";
                _serialPort.WriteLine("out 2 on");
            }
            else if (out2Button.Text == "Out 2 On")
            {
                out2Button.Text = "Out 2 Off";
                _serialPort.WriteLine("out 2 off");
            }
        }

        private void ploInitButton_Click(object sender, EventArgs e)
        {
            _serialPort.WriteLine("PLO init");
        }
    }
}
