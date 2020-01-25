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
        

        public MyRegister[] old_registers;
        // TODO ... FILIP MyRegister without UI element

        public Controller(Form1 view)
        {
            this.view = view;

            serialPort = new MySerialPort(view, view.ConsoleTextBox, view.PortButton, view.AvaibleCOMsComBox);
            serialPort.GetAvaliablePorts();

            var reg0 = new MyRegister(view.Reg0TextBox.Text, view.Reg0TextBox);
            var reg1 = new MyRegister(view.Reg1TextBox.Text, view.Reg1TextBox);
            var reg2 = new MyRegister(view.Reg2TextBox.Text, view.Reg2TextBox);
            var reg3 = new MyRegister(view.Reg3TextBox.Text, view.Reg3TextBox);
            var reg4 = new MyRegister(view.Reg4TextBox.Text, view.Reg4TextBox);
            var reg5 = new MyRegister(view.Reg5TextBox.Text, view.Reg5TextBox);

            registers = new MyRegister[] { reg0, reg1, reg2, reg3, reg4, reg5};

            var old_reg0 = new MyRegister(null);
            var old_reg1 = new MyRegister(null);
            var old_reg2 = new MyRegister(null);
            var old_reg3 = new MyRegister(null);
            var old_reg4 = new MyRegister(null);
            var old_reg5 = new MyRegister(null);

            old_registers = new MyRegister[] {old_reg0, old_reg1, old_reg2, old_reg3, old_reg4, old_reg5};
        }

#region Register Change Functions for individual controls

        #region Reference Frequency Part
        public void ChangeRDiv(decimal RDividerValue)
        {
            registers[2].ChangeNBits(Convert.ToUInt32(RDividerValue), 10, 14);
        }

        public void ChangeRefDoubler(bool IsActive)
        {
            if (IsActive == true)
            {
                registers[2].SetResetOneBit(25, BitState.SET);
                if ((view.IntNNumUpDown.Value / 2) < view.IntNNumUpDown.Minimum)
                    view.IntNNumUpDown.Value = view.IntNNumUpDown.Minimum;
                else
                    view.IntNNumUpDown.Value = view.IntNNumUpDown.Value/2;
            }
            else
            {
                registers[2].SetResetOneBit(25, BitState.RESET);
                if ((view.IntNNumUpDown.Value * 2) > view.IntNNumUpDown.Maximum)
                    view.IntNNumUpDown.Value = view.IntNNumUpDown.Maximum;
                else
                    view.IntNNumUpDown.Value = view.IntNNumUpDown.Value*2;
            }
        }

        public void ChangeRefDivider(bool IsActive)
        {
            if (IsActive == true)
            {
                registers[2].SetResetOneBit(24, BitState.SET);
                if ((view.IntNNumUpDown.Value * 2) > view.IntNNumUpDown.Maximum)
                    view.IntNNumUpDown.Value = view.IntNNumUpDown.Maximum;
                else
                    view.IntNNumUpDown.Value = view.IntNNumUpDown.Value*2;
            }
            else
            {
                registers[2].SetResetOneBit(24, BitState.RESET);
                if ((view.IntNNumUpDown.Value / 2) < view.IntNNumUpDown.Minimum)
                    view.IntNNumUpDown.Value = view.IntNNumUpDown.Minimum;
                else
                    view.IntNNumUpDown.Value = view.IntNNumUpDown.Value/2;
            }
        }

        #endregion
        
        #region Output Frequency Control Part
        // Zapise a prevede hodnotu IntN do Reg0
        public void ChangeIntNValue(decimal intNValue)
        {
            registers[0].ChangeNBits(Convert.ToUInt32(intNValue), 16, 15);
        }

        public void ChangeFracNValue(decimal fracNNumValue)
        {
            registers[0].ChangeNBits(Convert.ToUInt32(fracNNumValue), 12, 3);
        }

        public void ChangeModValue(decimal modValue)
        {
            registers[1].ChangeNBits(Convert.ToUInt32(modValue), 12, 3);
            view.FracNNumUpDown.Maximum = modValue - 1;
        }


        public void ChangeIntFracMode(int selectedIndex)
        {
            if (selectedIndex == 0)
            {
                registers[2].SetResetOneBit(8, BitState.RESET);
                registers[0].SetResetOneBit(31, BitState.RESET);
                view.IntNNumUpDown.Minimum = 19;
                view.IntNNumUpDown.Maximum = 4091;
            }
            else if (selectedIndex == 1)
            {
                registers[2].SetResetOneBit(8, BitState.SET);
                registers[0].SetResetOneBit(31, BitState.SET);
                view.IntNNumUpDown.Minimum = 16;
                view.IntNNumUpDown.Maximum = 65535;
            }
        }

        public void ChangeADiv(int selectedIndex)
        {
            registers[4].ChangeNBits(Convert.ToUInt32(selectedIndex), 3, 20);
        }

        // TODO FILIP controller.Cha... -> registers
        /*public void ChangePhaseP(decimal val)
        {
            registers[0]
            registers[1].ChangePhaseP(val);
            controller.ApplyChangeReg(1);   // TODO FILIP, kde má byt to ApplyChangeReg
        }*/

        public void ChangePhaseP(decimal PhasePValue)
        {
            registers[1].ChangeNBits(Convert.ToUInt32(PhasePValue), 12, 15);
        }

        #endregion

        #region Charge Pump Section

        public void ChangeCPCurrent(int selectedIndex)
        {
            registers[2].ChangeNBits(Convert.ToUInt32(selectedIndex), 4, 9);
        }

        public void ChangeCPLinearity(int selectedIndex)
        {
            registers[1].ChangeNBits(Convert.ToUInt32(selectedIndex), 2, 29);
        }

        #endregion

        #region Output Controls

        public void ChangeOutAPwr(int selectedIndex)
        {
            registers[4].ChangeNBits(Convert.ToUInt32(selectedIndex), 2, 3);
        }

        public void ChangeOutAEn(int selectedIndex)
        {
            if (selectedIndex == 0)
            {
                registers[4].SetResetOneBit(5, BitState.RESET);
            }
            else if (selectedIndex == 1)
            {
                registers[4].SetResetOneBit(5, BitState.SET);
            }
        }

        #endregion

#endregion

#region Functions for get values from register

        #region Parsing register 0
        private void GetFracIntModeStatusFromRegister(UInt32 dataReg0)
        {
            view.ModeIntFracComboBox.SelectedIndex = (int)BitOperations.GetNBits(dataReg0, 1, 31);
            if (dataReg0 == 1)
            {
                view.IntNNumUpDown.Minimum = 16;
                view.IntNNumUpDown.Maximum = 65535;
            }
            else
            {
                view.IntNNumUpDown.Minimum = 19;
                view.IntNNumUpDown.Maximum = 4091;
            }
        }

        private void GetIntNValueFromRegister(UInt32 dataReg0)
        {
            UInt16 IntN = (UInt16)BitOperations.GetNBits(dataReg0, 16, 15);

            if (IntN < view.IntNNumUpDown.Minimum)
                IntN = Convert.ToUInt16(view.IntNNumUpDown.Minimum);
            else if (IntN > view.IntNNumUpDown.Maximum)
                IntN = Convert.ToUInt16(view.IntNNumUpDown.Maximum);

            view.IntNNumUpDown.Value = IntN;
        }

        private void GetFracNValueFromRegister(UInt32 dataReg0)
        {
            view.FracNNumUpDown.Value = BitOperations.GetNBits(dataReg0, 12, 3);
        }

        #endregion

        #region Parsing register 1
        private void GetModValueFromRegister(UInt32 dataReg1)
        {
            UInt16 mod = (UInt16)BitOperations.GetNBits(dataReg1, 12, 3);
            view.ModNumUpDown.Value = mod;
            view.FracNNumUpDown.Maximum = mod-1;
        }

        private void GetPhasePValueFromRegister(UInt32 dataReg1)
        {
            view.PhasePNumericUpDown.Value = (UInt16)BitOperations.GetNBits(dataReg1, 12, 15);
        }

        private void GetCPLinearityFromRegister(UInt32 dataReg1)
        {
            view.CPLinearityComboBox.SelectedIndex = (int)BitOperations.GetNBits(dataReg1, 2, 29);
        }
        #endregion

        #region Parsing register 2
        private void GetRefDoublerStatusFromRegister(UInt32 dataReg2)
        {
            view.DoubleRefFCheckBox.Checked = Convert.ToBoolean(BitOperations.GetNBits(dataReg2, 1, 25));
        }
        
        private void GetRefDividerStatusFromRegister(UInt32 dataReg2)
        {
            view.DivideBy2CheckBox.Checked = Convert.ToBoolean(BitOperations.GetNBits(dataReg2, 1, 24));
        }

        private void GetRDivValueFromRegister(UInt32 dataReg2)
        {
            view.RDivUpDown.Value = BitOperations.GetNBits(dataReg2, 10, 14);
        }

        private void GetCPCurrentIndexFromRegister(UInt32 dataReg2)
        {
            view.CPCurrentComboBox.SelectedIndex = (int)BitOperations.GetNBits(dataReg2, 4, 9);
        }

        #endregion

        #region Parsing register 3

        #endregion

        #region Parsing register 4
        private void GetOutAENStatusFromRegister(UInt32 dataReg4)
        {
            view.RF_A_EN_ComboBox.SelectedIndex = (int)BitOperations.GetNBits(dataReg4, 1, 5);
        }

        private void GetOutAPwrStatusFromRegister(UInt32 dataReg4)
        {
            view.RF_A_PWR_ComboBox.SelectedIndex = (int)BitOperations.GetNBits(dataReg4, 2, 3);
        }

        private void GetADividerValueFromRegister(UInt32 dataReg4)
        {
            view.ADivComboBox.SelectedIndex = (int)BitOperations.GetNBits(dataReg4, 3, 20);
        }
        #endregion

        #region Parsing register 5

        #endregion

        #region Collection function
        public void GetAllFromReg(int index)
        {
            UInt32 reg = registers[index].uint32_GetValue();
            switch (index)
            {
                case 0:
                    GetFracIntModeStatusFromRegister(reg);
                    GetIntNValueFromRegister(reg);
                    GetFracNValueFromRegister(reg);
                    break;
                case 1:
                    GetModValueFromRegister(reg);
                    GetPhasePValueFromRegister(reg);
                    GetCPLinearityFromRegister(reg);
                    break;
                case 2:
                    GetRefDoublerStatusFromRegister(reg);
                    GetRefDividerStatusFromRegister(reg);
                    GetRDivValueFromRegister(reg);
                    GetCPCurrentIndexFromRegister(reg);
                    break;
                case 3:
                    break;
                case 4:
                    GetOutAENStatusFromRegister(reg);
                    GetOutAPwrStatusFromRegister(reg);
                    GetADividerValueFromRegister(reg);
                    break;
                case 5:
                    break;
            }
            
        }
        #endregion

#endregion

#region Serial port

        public void ApplyChangeReg(int index)
        {
            if (serialPort.IsPortOpen())
            {
                string data = String.Format("plo set_register {0}", registers[index].string_GetValue());
                old_registers[index].SetValue(registers[index].string_GetValue());
                if(!serialPort.SendStringSerialPort(data))
                    view.EnableControls(false);
            }
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
            bool success = serialPort.OpenPort(view.AvaibleCOMsComBox.Text);

            if (success)
            {
                view.SaveWorkspaceData();   // FIXME Not OOD
                view.ForceLoadRegButton_Click(this, new EventArgs());
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
