using System;
using System.Windows;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Globalization;

namespace Synthesizer_PC_control
{
    class Controller
    {
        public MyRegister[] registers;

        public MySerialPort serialPort;
    // NOTE: static SerialPort _serialPort; => Nevím jsetli to nemusí být static
        

        public Controller(TextBox[] ui_registers, Button ui_openClosed, ComboBox ui_avaliablePorts)
        {
            // Nastaví se data modelu
            serialPort = new MySerialPort(ui_openClosed, ui_avaliablePorts);

            // Vytvoření registrů
            // TODO If config file does not exist
            // TODO pozor na nutných 6 registrů
            var reg0 = new MyRegister(ui_registers[0].Text, ui_registers[0]);
            var reg1 = new MyRegister(ui_registers[1].Text, ui_registers[1]);
            var reg2 = new MyRegister(ui_registers[2].Text, ui_registers[2]);
            var reg3 = new MyRegister(ui_registers[3].Text, ui_registers[3]);
            var reg4 = new MyRegister(ui_registers[4].Text, ui_registers[4]);
            var reg5 = new MyRegister(ui_registers[5].Text, ui_registers[5]);

            registers = new MyRegister[] { reg0, reg1, reg2, reg3, reg4, reg5};
        }

#region nejakeRozumneJmenoProSekci

        public void ChangeIntFracMode(int selectedIndex)
        {
            UInt32 reg0 = registers[0].uint32_GetValue();
            UInt32 reg2 = registers[2].uint32_GetValue();
            
            if (selectedIndex == 0)
            //if (ModeIntFracComboBox.SelectedIndex == 0)
            {
                reg0 &= ~unchecked((UInt32)(1<<31));
                reg2 &= ~unchecked((UInt32)(1<<8));
                IntNNumUpDown.Minimum = 19;
                IntNNumUpDown.Maximum = 4091;

            }
            else if (selectedIndex == 1)
            //else if (RF_A_EN_ComboBox.SelectedIndex == 1)
            {
                reg0 |= unchecked((UInt32)(1<<31));
                reg2 |= unchecked((UInt32)(1<<8));
                IntNNumUpDown.Minimum = 16;
                IntNNumUpDown.Maximum = 65535;
            }
            registers[0].SetValue(reg0);
            registers[2].SetValue(reg2);
        }
#endregion

#region  Serial Port

#endregion

    }
}
