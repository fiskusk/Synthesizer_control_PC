﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Synthesizer_PC_control.Model;
using Synthesizer_PC_control.Utilities;

namespace Synthesizer_PC_control.Controllers
{
    class Controller
    {
        private readonly Form1 view;

        public readonly MySerialPort serialPort;

        public MyRegister[] registers;

        public Memory memory;
        
        public MyRegister[] old_registers;

        public ModuleControls moduleControls;

        public RefFreq refFreq;

        public OutFreqControl outFreqControl;

        public Controller(Form1 view)
        {
            // TODO FILIP ... Hey, try this! Hey! It works! :)
            /*string test = null;
            FilesManager.LoadFile(out test);*/

            this.view = view;

            serialPort = new MySerialPort(view, view.PortButton, 
                                          view.AvaibleCOMsComBox);
            serialPort.GetAvaliablePorts();

            var reg0 = new MyRegister(String.Empty, view.Reg0TextBox);
            var reg1 = new MyRegister(String.Empty, view.Reg1TextBox);
            var reg2 = new MyRegister(String.Empty, view.Reg2TextBox);
            var reg3 = new MyRegister(String.Empty, view.Reg3TextBox);
            var reg4 = new MyRegister(String.Empty, view.Reg4TextBox);
            var reg5 = new MyRegister(String.Empty, view.Reg5TextBox);

            registers = new MyRegister[] { reg0, reg1, reg2, reg3, reg4, reg5};

            var old_reg0 = new MyRegister(String.Empty);
            var old_reg1 = new MyRegister(String.Empty);
            var old_reg2 = new MyRegister(String.Empty);
            var old_reg3 = new MyRegister(String.Empty);
            var old_reg4 = new MyRegister(String.Empty);
            var old_reg5 = new MyRegister(String.Empty);

            old_registers = new MyRegister[] {old_reg0, old_reg1, old_reg2, 
                                              old_reg3, old_reg4, old_reg5};

            memory = new Memory(this.view);

            moduleControls = new ModuleControls(view.Out1Button,
                                                view.Out2Button,
                                                view.RefButton);

            refFreq = new RefFreq(view.RefFTextBox,
                                  view.RefDoublerCheckBox, 
                                  view.DivideBy2CheckBox, 
                                  view.RDivUpDown, 
                                  view.pfdFreqLabel);

            outFreqControl = new OutFreqControl(view.IntNNumUpDown,
                                                view.FracNNumUpDown,
                                                view.ModNumUpDown,
                                                view.ModeIntFracComboBox,
                                                view.ADivComboBox,
                                                view.PhasePNumericUpDown);

            ConsoleController.InitConsole(view.ConsoleRichTextBox);
        }

#region Register Change Functions for individual controls

        #region Reference Frequency Part
        public void ChangeRDiv(UInt16 value)
        {
            registers[2].ChangeNBits(Convert.ToUInt32(value), 10, 14);
            refFreq.SetRDivider(value);
        }

        public void ChangeRefDoubler(bool IsActive)
        {
            if (IsActive == true)
                registers[2].SetResetOneBit(25, BitState.SET);
            else
                registers[2].SetResetOneBit(25, BitState.RESET);
            refFreq.SetRefDoubler(IsActive);
            outFreqControl.ChangeIntNVal(IsActive);
        }

        public void ChangeRefDivBy2State(bool IsActive)
        {
            refFreq.SetRefDivBy2(IsActive);
            outFreqControl.ChangeIntNVal(!IsActive);
            if (IsActive == true)
                registers[2].SetResetOneBit(24, BitState.SET);
            else
                registers[2].SetResetOneBit(24, BitState.RESET);
        }

        #endregion
        
        #region Output Frequency Control Part
        // Zapise a prevede hodnotu IntN do Reg0
        public void ChangeIntNValue(UInt16 value)
        {
            registers[0].ChangeNBits(Convert.ToUInt32(value), 16, 15);
            outFreqControl.SetIntNVal(value);
        }

        public void ChangeFracNValue(UInt16 value)
        {
            registers[0].ChangeNBits(Convert.ToUInt32(value), 12, 3);
            outFreqControl.SetFracNVal(value);
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
            outFreqControl.SetIntNVal(IntN);
        }

        private void GetFracNValueFromRegister(UInt32 dataReg0)
        {
            UInt16 FracN = (UInt16)BitOperations.GetNBits(dataReg0, 12, 3);
            outFreqControl.SetFracNVal(FracN);
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
            refFreq.SetRefDoubler(Convert.ToBoolean(BitOperations.GetNBits(dataReg2, 1, 25)));
        }
        
        private void GetRefDividerStatusFromRegister(UInt32 dataReg2)
        {
            refFreq.SetRefDivBy2(Convert.ToBoolean(BitOperations.GetNBits(dataReg2, 1, 24)));
        }

        private void GetRDivValueFromRegister(UInt32 dataReg2)
        {
            refFreq.SetRDivider((UInt16)BitOperations.GetNBits(dataReg2, 10, 14));
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

        public void GetAllFromRegisters()
        {
            for (int i = 5; i >= 0; i--)
            {
                GetAllFromReg(i);
            }
            GetPfdFreq();
            RecalcFreqInfo(); 
        }
        #endregion

#endregion

#region Some magic calculations
        public void GetCPCurrentFromTextBox()
        {
            int value;
            if (int.TryParse(view.RSetTextBox.Text, out value))
            {
                if (value > 10000)
                    view.RSetTextBox.Text = "10000";
                else if (value < 2700)
                    view.RSetTextBox.Text = "2700";
            }
            UInt16 R_set = Convert.ToUInt16(view.RSetTextBox.Text);
            IList<string> list = new List<string>();
            decimal I_cp;
            for (UInt16 cp = 0; cp < 16; cp++)
            {
                I_cp = (decimal)(1.63*1000)/(decimal)(R_set) * (1 + cp);
                I_cp = Math.Round(I_cp, 3, MidpointRounding.AwayFromZero);
                list.Add(Convert.ToString(I_cp) + " mA");
            }
            view.CPCurrentComboBox.DataSource = list;
        }

        public void RecalcFreqInfo()
        {
            UInt16 aDiv = (UInt16)(1 << view.ADivComboBox.SelectedIndex);
            UInt16 intN = outFreqControl.uint16_GetIntNVal();
            UInt16 fracN = outFreqControl.uint16_GetFracNVal();

            decimal f_pfd = refFreq.decimal_GetPfdFreq();

            decimal f_out_A = 0;
            decimal f_vco = 0;

            // TODO pohlidat f_vco

            if (view.ModeIntFracComboBox.SelectedIndex == 1)
            {
                f_out_A = ((f_pfd*intN)/(aDiv));
            }
            else
            {
                f_out_A = (f_pfd/aDiv)*(intN+(fracN/(view.ModNumUpDown.Value*1.0M)));
            }
            f_vco = f_out_A*aDiv;
            if ((f_vco < 3000) || (f_vco > 6000))
            {
                view.fVcoScreenLabel.ForeColor = System.Drawing.Color.Red;
                outFreqControl.ChangeIntNBackColor(Color.Red);
            }
            else
            {
                view.fVcoScreenLabel.ForeColor = System.Drawing.Color.Black;
                outFreqControl.ChangeIntNBackColor(Color.White);
            }
                

            UInt16 f_out_A_MHz = (UInt16)(f_out_A);
            UInt32 f_out_A_kHz = (UInt32)(f_out_A*1000);
            UInt64 f_out_A_Hz = (UInt64)(f_out_A*1000000);
            UInt64 f_out_A_mHz = (UInt64)(f_out_A*1000000000);
            UInt16 thousandths = (UInt16)(f_out_A_kHz - f_out_A_MHz*1000);
            UInt16 millionths = (UInt16)(f_out_A_Hz - (UInt64)(f_out_A_MHz)*1000000-(UInt64)(thousandths)*1000);
            UInt16 billionths = (UInt16)(f_out_A_mHz - (UInt64)(f_out_A_Hz)*1000);
            float bill_f = (float)((billionths)/100.0);
            double rounding  = Math.Round((float)(billionths)/100.0, MidpointRounding.AwayFromZero);

            view.fOutAScreenLabel.Text = string.Format("{0:000},{1:000} {2:000} {3:0}", f_out_A_MHz, thousandths, millionths, rounding);

            UInt16 f_vco_MHz = (UInt16)(f_vco);
            UInt32 f_vco_kHz = (UInt32)(f_vco*1000);
            UInt64 f_vco_Hz = (UInt64)(f_vco*1000000);
            UInt64 f_vco_mHz = (UInt64)(f_vco*1000000000);
            thousandths = (UInt16)(f_vco_kHz - f_vco_MHz*1000);
            millionths = (UInt16)(f_vco_Hz - (UInt64)(f_vco_MHz)*1000000-(UInt64)(thousandths)*1000);
            billionths = (UInt16)(f_vco_mHz - (UInt64)(f_vco_Hz)*1000);
            bill_f = (float)((billionths)/100.0);
            rounding  = Math.Round((float)(billionths)/100.0, MidpointRounding.AwayFromZero);

            view.fVcoScreenLabel.Text = string.Format("{0:000},{1:000} {2:000} {3:0}", f_vco_MHz, thousandths, millionths, rounding);
        }

        public void GetPfdFreq()
        {
            // TODO osetrit fpfd
            decimal f_ref = refFreq.decimal_GetRefFreqValue();
            UInt16 doubler = Convert.ToUInt16(refFreq.IsDoubled());
            UInt16 divBy2 = Convert.ToUInt16(refFreq.IsDividedBy2());
            UInt16 rDivVal = refFreq.uint16_GetRefDividerValue();

            decimal f_pfd = f_ref * ((1 + doubler) / (decimal)(rDivVal * (1 + divBy2)));

            refFreq.SetPfdFreq(f_pfd);
        }

        public void CalcSynthesizerRegValuesFromInpFreq()
        {
            string f_input_string = view.InputFreqTextBox.Text;
            f_input_string = f_input_string.Replace(" ", string.Empty);
            f_input_string = f_input_string.Replace(".", ",");
            decimal f_input = decimal.Parse(f_input_string);

            decimal f_pfd = refFreq.decimal_GetPfdFreq();
            UInt16 rDivValue = 1;


            if (f_input >= 3000 && f_input <= 6000)
            {
                view.ADivComboBox.SelectedIndex = 0;
            }
            else if (f_input >= 1500 && f_input < 3000)
            {
                view.ADivComboBox.SelectedIndex = 1;
            }
            else if (f_input >= 750 && f_input < 1500)
            {
                view.ADivComboBox.SelectedIndex = 2;
            }
            else if (f_input >= 375 && f_input < 750)
            {
                view.ADivComboBox.SelectedIndex = 3;
            }
            else if (f_input >= 187.5M && f_input < 375)
            {
                view.ADivComboBox.SelectedIndex = 4;
            }
            else if (f_input >= 93.75M && f_input < 187.5M)
            {
                view.ADivComboBox.SelectedIndex = 5;
            }
            else if (f_input >= 46.875M && f_input < 93.75M)
            {
                view.ADivComboBox.SelectedIndex = 6;
            }
            else if (f_input >= 23.5M && f_input < 46.875M)
            {
                view.ADivComboBox.SelectedIndex = 7;
            }
            else if (f_input >= 1500 && f_input < 3000)
            {
                view.ADivComboBox.SelectedIndex = 8;
            }

            UInt16 DIVA = (UInt16)(1 << view.ADivComboBox.SelectedIndex);
            decimal intN = (f_input*DIVA/(f_pfd/rDivValue));
            decimal zbytek = intN-(UInt16)intN;

            if (zbytek>0)
            {
                Fractions.Fraction pokus = new Fractions.Fraction();
                //Fraction[] zaloha;
                double accuracy;
                int correction=1;
                //zaloha = new Fraction[500];
                UInt16 cnt = 0;
                do
                {
                    accuracy = 0.000001;
                    do
                    {
                        pokus = Fractions.RealToFraction((double)zbytek, accuracy);
                        //zaloha[cnt] = pokus;
                        cnt++;
                        accuracy = accuracy*10;
                    } while ((pokus.D < 2 || pokus.D > 4095) && accuracy <= 0.00001*correction);
                    if ((pokus.D < 2 || pokus.D > 4095))
                    {

                        rDivValue++;
                        intN = (f_input*DIVA/(f_pfd/rDivValue));
                        zbytek = intN-(UInt16)intN;
                        if (intN > 4091)
                        {
                            correction = correction * 10;
                            rDivValue--;
                            intN = (f_input*DIVA/(f_pfd/rDivValue));
                            zbytek = intN-(UInt16)intN;
                        }
                    }
                } while((pokus.D < 2 || pokus.D > 4095) && accuracy < 1);
                if ((pokus.D < 2 || pokus.D > 4095))
                {
                    view.ModeIntFracComboBox.SelectedIndex = 0;
                    pokus = new Fractions.Fraction (1, 4095);
                }
                view.ModeIntFracComboBox.SelectedIndex = 0;
                view.ModNumUpDown.Value = pokus.D;
                outFreqControl.SetFracNVal((UInt16)pokus.N);
            }
            else
            {
                view.ModeIntFracComboBox.SelectedIndex = 1;
            }
            refFreq.SetRDivider(rDivValue);
            outFreqControl.SetIntNVal((UInt16)intN);

            string f_outA_string = view.fOutAScreenLabel.Text;
            f_outA_string = f_outA_string.Replace(" ", string.Empty);
            f_outA_string = f_outA_string.Replace(".", ",");

            double f_out_A = double.Parse(f_outA_string);

            double delta = ((double)f_input - f_out_A) * 1e6;
            delta  = Math.Round(delta, 3, MidpointRounding.AwayFromZero);
            if (Math.Abs(delta) > 10)
                view.DeltaShowLabel.ForeColor = System.Drawing.Color.Red;
            else
                view.DeltaShowLabel.ForeColor = System.Drawing.Color.Black;

            view.DeltaShowLabel.Text = delta.ToString ("0.###");

        }
#endregion

#region Some other functions that I don't know where to include classify

        public void ReferenceFrequencyValueChanged(string value)
        {
            if (refFreq.IsUiUpdated())
            {
                refFreq.SetRefFreqValue(value);
                GetPfdFreq();
                RecalcFreqInfo();
            }
        }

        public void ReferenceDoublerStateChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                ChangeRefDoubler(value);
                GetPfdFreq();
                CheckAndApplyRegChanges(2);
            }
        }

        public void ReferenceDivBy2StateChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                ChangeRefDivBy2State(value);
                GetPfdFreq();
                CheckAndApplyRegChanges(2);
            }
        }

        public void ReferenceRDividerValueChanged(UInt16 value)
        {
            if (serialPort.IsPortOpen())
            {
                ChangeRDiv(value);
                GetPfdFreq();
                CheckAndApplyRegChanges(2);
            }
        }

        public void IntNValueChanged(UInt16 value)
        {
            if (serialPort.IsPortOpen())
            {
                ChangeIntNValue(value);
                CheckAndApplyRegChanges(0);
            }
        }

        public void FracNValueChanged(UInt16 value)
        {
            if (serialPort.IsPortOpen())
            {
                ChangeFracNValue(value);
                CheckAndApplyRegChanges(0);
            }
        }

#endregion

#region Serial port

        public void ForceLoadAllRegsIntoPlo()
        {
            for (int i = 5; i >= 0; i--)
            {
                ApplyChangeReg(i);
            }

            GetAllFromRegisters();

            if (moduleControls.GetOut1State())
                serialPort.SendStringSerialPort("out 1 on");
            else
                serialPort.SendStringSerialPort("out 1 off");
            
            if (moduleControls.GetOut2State())
                serialPort.SendStringSerialPort("out 2 on");
            else
                serialPort.SendStringSerialPort("out 2 off");
            
            if (moduleControls.GetRefState())
                serialPort.SendStringSerialPort("ref int");
            else
                serialPort.SendStringSerialPort("ref ext");
        }

        public void CheckAndApplyRegChanges(int regNumber, string text)
        {
            registers[regNumber].SetValue(text);
            if ((serialPort.IsPortOpen()) && 
                (!string.Equals(registers[regNumber].string_GetValue(), 
                                old_registers[regNumber].string_GetValue(),
                                StringComparison.CurrentCultureIgnoreCase)))
            {
                ApplyChangeReg(regNumber);
                GetAllFromReg(regNumber);
                if (regNumber == 1 || regNumber == 2)
                    ApplyChangeReg(0);
                if (regNumber != 3 || regNumber != 5)
                    RecalcFreqInfo();
            }
        }

        public void CheckAndApplyRegChanges(int regNumber)
        {
            if ((serialPort.IsPortOpen()) && 
                (!string.Equals(registers[regNumber].string_GetValue(), 
                                old_registers[regNumber].string_GetValue(),
                                StringComparison.CurrentCultureIgnoreCase)))
            {
                ApplyChangeReg(regNumber);
                if (regNumber == 1 || regNumber == 2)
                    ApplyChangeReg(0);
                if (regNumber != 3 || regNumber != 5)
                    RecalcFreqInfo();
            }
        }

        public void ApplyChangeReg(int index)
        {
            if (serialPort.IsPortOpen())
            {
                string value = registers[index].string_GetValue();
                old_registers[index].SetValue(value);

                string data = String.Format("plo set_register {0}", value);
                serialPort.SendStringSerialPort(data);
            }
        }

        public void SwitchPort()
        {
            if(serialPort.IsPortOpen())
            {
                serialPort.ClosePort();
                SaveWorkspaceData();
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
                SaveWorkspaceData();
                //view.ForceLoadRegButton_Click(this, new EventArgs()); // FIXME Not OOD
                ForceLoadAllRegsIntoPlo();
                bool isOpen;
                if (serialPort.IsPortOpen())
                    isOpen = true;
                else
                    isOpen = false;
                view.EnableControls(isOpen);
                return isOpen;
            }
            else
            {
                return false;
            }
        }

        #endregion

#region Synthesizer Module part

        public void SwitchOut1()
        {
            if (moduleControls.GetOut1State())
            {
                serialPort.SendStringSerialPort("out 1 off");
                moduleControls.SetOut1(false);
            }
            else
            {
                serialPort.SendStringSerialPort("out 1 on");
                moduleControls.SetOut1(true);
            }
        }

        public void SwitchOut2()
        {
            if (moduleControls.GetOut2State())
            {
                serialPort.SendStringSerialPort("out 2 off");
                moduleControls.SetOut2(false);
            }
            else
            {
                serialPort.SendStringSerialPort("out 2 on");
                moduleControls.SetOut2(true);
            }
        }

        public void SwitchRef()
        {
            if (moduleControls.GetRefState())
            {
                serialPort.SendStringSerialPort("ref ext");
                moduleControls.SetIntRef(false);
            }
            else
            {
                serialPort.SendStringSerialPort("ref int");
                moduleControls.SetIntRef(true);
            }
        }

#endregion

#region Load and Save Data

    #region  Workspace data part
        public void LoadSavedWorkspaceData()
        {
            SaveWindow loadedData = new SaveWindow();
            bool success = FilesManager.LoadSavedWorkspaceData(out loadedData);

            if (success)
            {
                string text = "Workspace data succesfuly loaded.";
                ConsoleController.Console().Write(text);

                view.AvaibleCOMsComBox.Text = loadedData.COM_port;
                LoadWorkspaceDataFromFile(loadedData);
            }
            else
            {
                MessageBox.Show("When loading worskspace data occurs error!", "Error Catch",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveWorkspaceData()
        {

            bool success = FilesManager.SaveWorkspaceData(CreateSaveWindow());

            if(success)
            {
                string text = "Workspace data succesfuly saved.";
                ConsoleController.Console().Write(text);

            }
            else
            {
                MessageBox.Show("When saving worskspace data occurs error!", "Error Catch",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadWorkspaceDataFromFile(SaveWindow data)
        {
            // registers
            MyRegister.SetValues(registers, data.Registers.ToArray());
            // old registers
            MyRegister.SetValues(old_registers, data.Registers.ToArray());

            view.RSetTextBox.Text = Convert.ToString(data.RSetValue);

            view.InputFreqTextBox.Text = data.OutputFreqValue;

            refFreq.SetRefFreqValue(data.ReferenceFrequency);

            moduleControls.SetOut1(data.Out1En);
            moduleControls.SetOut2(data.Out2En);
            moduleControls.SetIntRef(data.IntRef);

            for (int i = 0; i < 7; i++)
            {
                memory.GetRegister(1, i).SetValue(data.Mem1[i]);
                memory.GetRegister(2, i).SetValue(data.Mem2[i]);
                memory.GetRegister(3, i).SetValue(data.Mem3[i]);
                memory.GetRegister(4, i).SetValue(data.Mem4[i]);
            }

            this.GetCPCurrentFromTextBox();
            this.GetAllFromRegisters();
        }

        private SaveWindow CreateSaveWindow()
        {
            SaveWindow saved = new SaveWindow
            {
                Registers = new List<string>{},
                RSetValue = Convert.ToUInt16(view.RSetTextBox.Text),
                OutputFreqValue = view.InputFreqTextBox.Text,
                ReferenceFrequency = refFreq.string_GetRefFreqValue(),
                Out1En = moduleControls.GetOut1State(),
                Out2En = moduleControls.GetOut2State(),
                IntRef = moduleControls.GetRefState(),
                Mem1 = new List<string>{},
                Mem2 = new List<string>{},
                Mem3 = new List<string>{},
                Mem4 = new List<string>{},
                COM_port = view.AvaibleCOMsComBox.Text
            };

            for (int i = 0; i < 7; i++)
            {
                if (i < 6)
                    saved.Registers.Add(this.registers[i].string_GetValue());
                
                saved.Mem1.Add(memory.GetRegister(1, i).string_GetValue());
                saved.Mem2.Add(memory.GetRegister(2, i).string_GetValue());
                saved.Mem3.Add(memory.GetRegister(3, i).string_GetValue());
                saved.Mem4.Add(memory.GetRegister(4, i).string_GetValue());
            }

            return saved;
        }
    #endregion

    #region Default registers part

        public void LoadDefRegsData()
        {
            SaveDefaults loadedData = new SaveDefaults();
            bool success = FilesManager.LoadDefRegsData(out loadedData);

            if (success)
            {
                string text = "Default registers succesfuly loaded.";
                ConsoleController.Console().Write(text);
                LoadDefRegsFromFile(loadedData);
                ForceLoadAllRegsIntoPlo();
            }
            else
            {
                string text = "When loading default registers occurs error!";
                ConsoleController.Console().Write(text);
                MessageBox.Show("File default.json with include settings for registers, doesn't exist. First create it by click to Set As Def Button", "File defaults.txt doesn't exist", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SaveDefRegsData()
        {

            bool success = FilesManager.SaveDefRegsData(CreateDefaultsData());

            if(success)
            {
                string text = "Default registers succesfuly saved.";
                ConsoleController.Console().Write(text);
            }
            else
            {
                string text = "When saving default registers occurs error!";
                ConsoleController.Console().Write(text);
                MessageBox.Show(text, "Error Catch",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDefRegsFromFile(SaveDefaults data)
        {
            for (int i = 0; i < 6; i++)
            {
                registers[i].SetValue(data.Registers[i]);
            }
        }

        private SaveDefaults CreateDefaultsData()
        {
            SaveDefaults saved = new SaveDefaults
            {
                Registers = new List<string>{}
            };

            for (int i = 0; i < 6; i++)
            {
                saved.Registers.Add(this.registers[i].string_GetValue());
            }

            return saved;
        }

    #endregion

#endregion
    
#region Memory operation
        public void ImportMemory(int memoryNumber)
        {
            for (int i = 0; i < 6; i++)
            {
                registers[i].SetValue(memory.GetRegister(memoryNumber, i).string_GetValue());
            }
            GetAllFromRegisters();
            GetAllFromControllReg(memoryNumber);

        }
        public void GetAllFromControllReg(int memoryNumber)
        {
            if (BitOperations.GetNBits(memory.GetRegister(memoryNumber, 6).uint32_GetValue(), 1, 0) == 1)
            {
                moduleControls.SetOut1(true);
                serialPort.SendStringSerialPort("out 1 on");
            }
            else
            {
                moduleControls.SetOut1(false);
                serialPort.SendStringSerialPort("out 1 off");
            }
            
            if (BitOperations.GetNBits(memory.GetRegister(memoryNumber, 6).uint32_GetValue(), 1, 1) == 1)
            {
                moduleControls.SetOut2(true);
                serialPort.SendStringSerialPort("out 2 on");
            }
            else
            {
                moduleControls.SetOut2(false);
                serialPort.SendStringSerialPort("out 2 off");
            }
            
            if (BitOperations.GetNBits(memory.GetRegister(memoryNumber, 6).uint32_GetValue(), 1, 2) == 0)
            {
                moduleControls.SetIntRef(true);
                serialPort.SendStringSerialPort("ref int");
            }
            else
            {
                moduleControls.SetIntRef(false);
                serialPort.SendStringSerialPort("ref ext");
            }
        }

        public void ExportMemory(int memoryNumber)
        {
            for (int i = 0; i < 6; i++)
            {
                memory.GetRegister(memoryNumber, i).SetValue(registers[i].string_GetValue());
            }
            memory.GetRegister(memoryNumber, 6).SetValue(moduleControls.GetControlRegister());
        }

        private void CleanSavedRegisters()
        {
            string data = String.Format("plo data clean");
            serialPort.SendStringSerialPort(data);
        }

        public void SaveRegsIntoPloMemory()
        {
            CleanSavedRegisters();
            for (int memoryNumber = 1; memoryNumber <= 4; memoryNumber++)
            {
                string data = String.Format("plo data {0} {1} {2} {3} {4} {5} {6} {7}", 
                        Convert.ToString(memoryNumber),
                        memory.GetRegister(memoryNumber, 0).string_GetValue(),
                        memory.GetRegister(memoryNumber, 1).string_GetValue(),
                        memory.GetRegister(memoryNumber, 2).string_GetValue(),
                        memory.GetRegister(memoryNumber, 3).string_GetValue(),
                        memory.GetRegister(memoryNumber, 4).string_GetValue(),
                        memory.GetRegister(memoryNumber, 5).string_GetValue(),
                        memory.GetRegister(memoryNumber, 6).string_GetValue() );
                serialPort.SendStringSerialPort(data);
            }
        }

        public void LoadRegsFromPloMemory()
        {
            serialPort.SendStringSerialPort("plo data stored?");
        }

        // TODO move into utillities???
        
#endregion
    }
}
