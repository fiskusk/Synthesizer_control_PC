﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Synthesizer_PC_control.Model;

namespace Synthesizer_PC_control
{
    class Controller
    {
        private readonly Form1 view;

        public readonly MySerialPort serialPort;

        public MyRegister[] registers;

        public Controller(Form1 view)
        {
            this.view = view;

            serialPort = new MySerialPort(view, view.textBox, view.PortButton, view.AvaibleCOMsComBox);

            var reg0 = new MyRegister(view.Reg0TextBox.Text, view.Reg0TextBox);
            var reg1 = new MyRegister(view.Reg1TextBox.Text, view.Reg1TextBox);
            var reg2 = new MyRegister(view.Reg2TextBox.Text, view.Reg2TextBox);
            var reg3 = new MyRegister(view.Reg3TextBox.Text, view.Reg3TextBox);
            var reg4 = new MyRegister(view.Reg4TextBox.Text, view.Reg4TextBox);
            var reg5 = new MyRegister(view.Reg5TextBox.Text, view.Reg5TextBox);

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
                view.IntNNumUpDown.Minimum = 19;
                view.IntNNumUpDown.Maximum = 4091;

            }
            else if (selectedIndex == 1)
            //else if (RF_A_EN_ComboBox.SelectedIndex == 1)
            {
                reg0 |= unchecked((UInt32)(1<<31));
                reg2 |= unchecked((UInt32)(1<<8));
                view.IntNNumUpDown.Minimum = 16;
                view.IntNNumUpDown.Maximum = 65535;
            }
            registers[0].SetValue(reg0);
            registers[2].SetValue(reg2);
        }
#endregion

#region Serial port

        public void SwitchPort()
        {
            if(serialPort.IsPortOpen())
            {
                serialPort.ClosePort();
                view.EnableControls(false);
            }
            else
            {
                view.EnableControls( OpenPort() );
            }
        }

        private bool OpenPort()
        {
            // TODO Use AvaibleCOMsComBox.selectedIndex ?
            bool success = serialPort.OpenPort(view.AvaibleCOMsComBox.Text);

            if (success)
            {
                view.SaveWorkspaceData();   // FIXME Not OOD
                view.EnableControls(true);
                return true;
            }
            else
            {
                return false;
            }
        }

#endregion

    }
}
