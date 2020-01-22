using System;
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

        public string[] old_regs;

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

            old_regs = new string[6] {"80C90000", "800103E9", "00005F42", "00001F23", "63BE80E4", "00400005"};
        }

#region nejakeRozumneJmenoProSekci
        // Zapise a prevede hodnotu IntN do Reg0
        public void ChangeIntNValue(decimal IntNValue)
        {
            UInt32 reg = registers[0].uint32_GetValue();
            reg &= ~(UInt32)(0b01111111111111111000000000000000);
            reg += Convert.ToUInt32(IntNValue) << 15;
            registers[0].SetValue(reg);
        }

        public void ChangeFracNValue(decimal FracNNumValue)
        {
            UInt32 reg = registers[0].uint32_GetValue();
            reg &= ~(UInt32)(0b00000000000000000111111111111000);
            reg += Convert.ToUInt32(FracNNumValue) << 3;
            registers[0].SetValue(reg);
        }

        public void ChangeModValue(decimal ModValue)
        {
            UInt32 reg = registers[1].uint32_GetValue();
            reg &= ~(UInt32)(0b00000000000000000111111111111000);
            reg += Convert.ToUInt32(ModValue) << 3;
            registers[1].SetValue(reg);
            view.FracNNumUpDown.Maximum = ModValue - 1;
        }

        public void ChangeOutAPwr(int selectedIndex)
        {
            UInt32 reg = registers[4].uint32_GetValue();
            switch (selectedIndex)
            {
                case 0:
                    reg &= ~((UInt32)(1<<4) | (UInt32)(1<<3));
                    break;
                case 1:
                    reg &= ~(UInt32)(1<<4);
                    reg |= (UInt32)(1<<3);
                    break;
                case 2:
                    reg |= (UInt32)(1<<4);
                    reg &= ~(UInt32)(1<<3);
                    break;
                case 3:
                    reg |= (UInt32)(1<<4) | (UInt32)(1<<3);
                    break;
            }
            registers[4].SetValue(reg);
        }

        public void ChangeOutAEn(int selectedIndex)
        {
            UInt32 reg = registers[4].uint32_GetValue();
            if (selectedIndex == 0)
            {
                reg &= ~((UInt32)(1<<5));
            }
            else if (selectedIndex == 1)
            {
                reg |= (UInt32)(1<<5);
            }
            registers[4].SetValue(reg);
        }

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

        public void ChangePhaseP(decimal PhasePValue)
        {
            UInt32 reg = registers[1].uint32_GetValue();
            reg &= ~(UInt32)(0b1111111111111000000000000000);
            reg += Convert.ToUInt32(PhasePValue) << 15;
            registers[1].SetValue(reg);
        }

        public void ChangeCPLinearity(int selectedIndex)
        {
            UInt32 reg = registers[1].uint32_GetValue();
            reg &= ~(UInt32)((1<<30) | (1<<29));
            reg += Convert.ToUInt32(selectedIndex) << 29;
            registers[1].SetValue(reg);
        }

        public void ChangeRefDoubler(bool IsActive)
        {
            UInt32 reg = registers[2].uint32_GetValue();
            if (IsActive == true)
            {
                reg |= unchecked((UInt32)(1<<25));
                if ((view.IntNNumUpDown.Value / 2) < view.IntNNumUpDown.Minimum)
                    view.IntNNumUpDown.Value = view.IntNNumUpDown.Minimum;
                else
                    view.IntNNumUpDown.Value = view.IntNNumUpDown.Value/2;
            }
            else
            {
                reg &= ~unchecked((UInt32)(1<<25));
                if ((view.IntNNumUpDown.Value * 2) > view.IntNNumUpDown.Maximum)
                    view.IntNNumUpDown.Value = view.IntNNumUpDown.Maximum;
                else
                    view.IntNNumUpDown.Value = view.IntNNumUpDown.Value*2;

            }
            registers[2].SetValue(reg);
        }

        public void ChangeRefDivider(bool IsActive)
        {
            UInt32 reg = registers[2].uint32_GetValue();
            if (IsActive == true)
            {
                reg |= unchecked((UInt32)(1<<24));
                if ((view.IntNNumUpDown.Value * 2) > view.IntNNumUpDown.Maximum)
                    view.IntNNumUpDown.Value = view.IntNNumUpDown.Maximum;
                else
                    view.IntNNumUpDown.Value = view.IntNNumUpDown.Value*2;
            }
            else
            {
                reg &= ~unchecked((UInt32)(1<<24));
                if ((view.IntNNumUpDown.Value / 2) < view.IntNNumUpDown.Minimum)
                    view.IntNNumUpDown.Value = view.IntNNumUpDown.Minimum;
                else
                    view.IntNNumUpDown.Value = view.IntNNumUpDown.Value/2;

            }
            registers[2].SetValue(reg);
        }

        public void ChangeRDiv(decimal RDividerValue)
        {
            UInt32 reg = registers[2].uint32_GetValue();
            reg &= ~(UInt32)(0b111111111100000000000000);
            reg += Convert.ToUInt32(RDividerValue) << 14;
            registers[2].SetValue(reg);
        }

        public void ChangeCPCurrent(int selectedIndex)
        {
            UInt32 reg = registers[2].uint32_GetValue();
            reg &= ~(UInt32)((1<<12) | (1<<11) | (1<<10) | (1<<9));
            reg += Convert.ToUInt32(selectedIndex) << 9;
            registers[2].SetValue(reg);
        }

        public void ChangeADiv(int selectedIndex)
        {
            UInt32 reg = registers[4].uint32_GetValue();
            reg &= ~(UInt32)( (1<<22) | (1<<21) | (1<<20) );
            reg += Convert.ToUInt32(selectedIndex) << 20;
            registers[4].SetValue(reg);
        }

#endregion

#region Serial port

        public void ApplyChangeReg(int index)
        {
            string data = String.Format("plo set_register {0}", registers[index].string_GetValue());
            old_regs[index] = registers[index].string_GetValue();
            if(!serialPort.SendStringSerialPort(data))
                view.EnableControls(false);
        }

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
