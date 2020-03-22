using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Synthesizer_PC_control.Model;
using Synthesizer_PC_control.Utilities;
using System.Text.RegularExpressions;

namespace Synthesizer_PC_control.Controllers
{
    class Controller
    {
        public readonly MySerialPort serialPort;
        public MyRegister[] registers;
        public Memory memory;
        public MyRegister[] old_registers;
        public ModuleControls moduleControls;
        public RefFreq refFreq;
        public OutFreqControl outFreqControl;
        public DirectFreqControl directFreqControl;
        public SynthFreqInfo synthFreqInfo;
        public SynthOutputControls synthOutputControls;
        public ChargePump chargePump;
        public PhaseDetector phaseDetector;
        public GenericControls genericControls;
        public Shutdowns shutdowns;
        public VcoControls vcoControls;
        public ReadRegister readRegister;

        public Controller(Form1 view)
        {
            // TODO FILIP ... Hey, try this! Hey! It works! :)
            /*string test = null;
            FilesManager.LoadFile(out test);*/

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

            memory = new Memory(view);

            moduleControls = new ModuleControls(view.Out1Button,
                                                view.Out2Button,
                                                view.RefButton);

            refFreq = new RefFreq(view.RefFTextBox,
                                  view.RefDoublerCheckBox, 
                                  view.DivideBy2CheckBox, 
                                  view.RDivUpDown, 
                                  view.pfdFreqLabel,
                                  view.LDSpeedAdjComboBox,
                                  view.AutoLDSpeedAdjCheckBox,
                                  view.LDSpeedAdjLabel,
                                  view.InternalLabel);

            outFreqControl = new OutFreqControl(view.IntNNumUpDown,
                                                view.FracNNumUpDown,
                                                view.ModNumUpDown,
                                                view.ModeIntFracComboBox,
                                                view.ADivComboBox,
                                                view.PhasePNumericUpDown,
                                                view.LDFuncComboBox,
                                                view.AutoLDFuncCheckBox, 
                                                view.RFoutBPathComboBox,
                                                view.LDfuncLabel,
                                                view.FBPathComboBox);

            directFreqControl = new DirectFreqControl(view.InputFreqTextBox, 
                                                      view.DeltaShowLabel,
                                                      view.CalcFreqShowLabel,
                                                      view.FreqAtOut1ShowLabel,
                                                      view.FreqAtOut2ShowLabel,
                                                      view.ActOut1ShowLabel,
                                                      view.ActOut2ShowLabel,
                                                      view.IntExtShowLabel);

            synthFreqInfo = new SynthFreqInfo(view.fVcoScreenLabel,
                                              view.fOutAScreenLabel,
                                              view.fOutBScreenLabel);

            synthOutputControls = new SynthOutputControls(view.OutAEn_ComboBox,
                                                          view.OutBEn_ComboBox,
                                                          view.OutAPwr_ComboBox,
                                                          view.OutBPwr_ComboBox);

            chargePump = new ChargePump(view.RSetTextBox,
                                        view.CPCurrentComboBox,
                                        view.CPLinearityComboBox,
                                        view.CPTestComboBox,
                                        view.CPFastLockCheckBox,
                                        view.CPTriStateOutCheckBox,
                                        view.CPCycleSlipCheckBox,
                                        view.CPCurrentLabel,
                                        view.CPLinearityLabel,
                                        view.PhaseAdjustmentModeCheckbox);

            phaseDetector = new PhaseDetector(view.SigmaDeltaNoiseModeComboBox,
                                              view.LDPrecisionComboBox,
                                              view.PfdPolarity);

            genericControls = new GenericControls(view.MuxPinModeCombobox,
                                                  view.Reg4DoubleBufferedCheckBox,
                                                  view.IntNAutoModeWhenF0CheckBox,
                                                  view.RandNCountersResetCheckBox);

            shutdowns = new Shutdowns(view.PloPowerDownCheckBox,
                                      view.RefInputShutdownCheckBox,
                                      view.PllShutDownCheckBox,
                                      view.VcoDividerShutdownCheckBox,
                                      view.VcoLdoShutDownCheckBox, 
                                      view.VcoShutDownCheckBox);

            vcoControls = new VcoControls(view.AutoVcoSelectionCheckBox,
                                          view.VASTempCompCheckBox,
                                          view.MuteUntilLockDetectCheckBox,
                                          view.DelayToPreventFlickeringCheckBox,
                                          view.ManualVCOSelectNumericUpDown,
                                          view.ShowDelayLabel,
                                          view.BandSelClockDivNumericUpDown, 
                                          view.ClockDividerNumericUpDown,
                                          view.AutoCDIVCalcCheckBox, 
                                          view.DelayInputNumericUpDown);

            readRegister = new ReadRegister(view.ReadedVCOValueTextBox,
                                            view.ReadedADCValueTextBox,
                                            view.ADCModeComboBox);

            ConsoleController.InitConsole(view.ConsoleRichTextBox);
        }

#region Change Functions for individual controls
    #region Serial Port Section
        public void SelectedSerialPortChanged(string value)
        {
            serialPort.SetSelectedPort(value);
        }
    #endregion

    #region Synthesizer Module Controls Section
        public void SwitchOut1()
        {
            bool state = moduleControls.GetOut1State();

            if (state)
                serialPort.SendStringSerialPort("out 1 off");
            else
                serialPort.SendStringSerialPort("out 1 on");

            moduleControls.SetOut1(!state);
            directFreqControl.SetActiveOut1(!state);
            synthOutputControls.SetOutAEnable((OutEnState)Convert.ToInt16(!state));
        }

        public void SwitchOut2()
        {
            bool state = moduleControls.GetOut2State();

            if (state)
                serialPort.SendStringSerialPort("out 2 off");
            else
                serialPort.SendStringSerialPort("out 2 on");

            moduleControls.SetOut2(!state);
            directFreqControl.SetActiveOut2(!state);
            synthOutputControls.SetOutBEnable((OutEnState)Convert.ToInt16(!state));
        }

        public void SwitchRef()
        {
            if (moduleControls.GetIntRefState())
            {
                serialPort.SendStringSerialPort("ref ext");
                refFreq.ChangeRefInpUIEnabled(true);
                moduleControls.SetIntRef(false);
                directFreqControl.SetIntRefState(false);
            }
            else
            {
                serialPort.SendStringSerialPort("ref int");
                refFreq.SetRefFreqValue(10);
                vcoControls.CalcBandSelClockDivValue(10);
                refFreq.ChangeRefInpUIEnabled(false);
                moduleControls.SetIntRef(true);
                directFreqControl.SetIntRefState(true);
            }
            RecalcWorkingFreqInfo();
        }

        public void PloModuleInit()
        {
            serialPort.SendStringSerialPort("PLO init");
        }
#endregion
    
    #region Reference Frequency Controls Group 
        public void FreqTextBoxBehavior(TextBox sender, KeyEventArgs e)
        {
            int position = sender.SelectionStart;
            if (e.KeyCode == Keys.Back)
            {
                string text = sender.Text;
                int commaPosition = text.IndexOf(".");
                if (position == commaPosition + 5  && commaPosition != -1)
                {
                   position = commaPosition + 4;
                }
            }
            else if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                int cursorPosition = MyFormat.UpDownKeyIncDecFunc(sender, e.KeyCode);
                if (sender.Name == "InputFreqTextBox")  
                    CalcSynthesizerRegValuesFromInpFreq(sender.Text);
                else if (sender.Name == "RefFTextBox")
                    ReferenceFrequencyValueChanged(sender.Text);
                sender.SelectionStart = cursorPosition;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (sender.Name == "InputFreqTextBox")
                    CalcSynthesizerRegValuesFromInpFreq(sender.Text);
                else if (sender.Name == "RefFTextBox")
                    ReferenceFrequencyValueChanged(sender.Text);
            }
            sender.SelectionStart = position;
        }

        public void TextBoxHandlerFunc(TextBox sender, MouseEventArgs e)
        {
            int cursorPosition = MyFormat.ScrollByPositionOfCursor(sender, e);
            if (sender.Name == "InputFreqTextBox")
                CalcSynthesizerRegValuesFromInpFreq(sender.Text);
            else if (sender.Name == "RefFTextBox")
                ReferenceFrequencyValueChanged(sender.Text);
            sender.SelectionStart = cursorPosition;
        }

        public void ReferenceFrequencyValueChanged(string value)
        {
            if (refFreq.SetRefFreqValue(value) == true)
            {
                RecalcWorkingFreqInfo();
                decimal pfdFreq = refFreq.decimal_GetPfdFreq();
                vcoControls.CalcBandSelClockDivValue(pfdFreq);
                CalcCDivValue();
            }
        }

        public void ReferenceDoublerStateChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 5);

                registers[2].SetResetOneBit(25, (BitState)Convert.ToUInt16(value));
                refFreq.SetRefDoubler(value);

                outFreqControl.RecalcRegsForNewPfdFreq(value);

                decimal pfdFreq = refFreq.decimal_GetPfdFreq();
                vcoControls.CalcBandSelClockDivValue(pfdFreq);
                CalcCDivValue();

                serialPort.SetDisableSending(false, 5);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void ReferenceDivBy2StateChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 12);

                registers[2].SetResetOneBit(24, (BitState)Convert.ToUInt16(value));
                refFreq.SetRefDivBy2(value);
                outFreqControl.RecalcRegsForNewPfdFreq(!value);
                decimal pfdFreq = refFreq.decimal_GetPfdFreq();
                vcoControls.CalcBandSelClockDivValue(pfdFreq);
                CalcCDivValue();

                serialPort.SetDisableSending(false, 12);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void ReferenceRDividerValueChanged(UInt16 value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 14);

                registers[2].ChangeNBits((UInt32)value, 10, 14);
                refFreq.SetRDivider(value);
                decimal pfdFreq = refFreq.decimal_GetPfdFreq();
                vcoControls.CalcBandSelClockDivValue(pfdFreq);
                CalcCDivValue();

                serialPort.SetDisableSending(false, 14);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void LDSpeedAdjIndexChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 15);

                registers[2].SetResetOneBit(31, (BitState)value);
                refFreq.SetLDSpeedAdj(value);

                serialPort.SetDisableSending(false, 15);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void AutoLDSpeedAdjChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                refFreq.SetAutoLDSpeedAdj(value);
            }
        }
    #endregion

    #region Output Frequency Controls Group
        public void IntNValueChanged(UInt16 value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 6);

                registers[0].ChangeNBits((UInt32)value, 16, 15);
                outFreqControl.SetIntNVal(value);

                serialPort.SetDisableSending(false, 6);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void FracNValueChanged(UInt16 value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 7);

                registers[0].ChangeNBits((UInt32)value, 12, 3);
                outFreqControl.SetFracNVal(value);

                serialPort.SetDisableSending(false, 7);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void ModValueChanged(UInt16 value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 8);

                registers[1].ChangeNBits((UInt32)value, 12, 3);
                outFreqControl.SetModVal(value);
                
                CalcCDivValue();

                serialPort.SetDisableSending(false, 8);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void SynthModeChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 1);

                registers[0].SetResetOneBit(31, (BitState)value);
                outFreqControl.SetSynthMode((SynthMode)value);
                outFreqControl.CheckIfLDfuncToAppropriateModeIsSellected(false);

                refFreq.SetSynthModeInfoVariable((SynthMode)value);
                decimal pfdFreq = refFreq.decimal_GetPfdFreq();
                vcoControls.CalcBandSelClockDivValue(pfdFreq);

                if ((SynthMode)value == SynthMode.INTEGER)
                    chargePump.SetLinearityIndex(0, (SynthMode)value);
                else
                    chargePump.SetLinearityIndex(1, (SynthMode)value);

                serialPort.SetDisableSending(false, 1);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void ADivValueChanged(UInt16 value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 9);

                registers[4].ChangeNBits((UInt32)value, 3, 20);
                outFreqControl.SetADivVal(value);

                serialPort.SetDisableSending(false, 9);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void PhasePValueChanged(UInt16 value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 10);

                registers[1].ChangeNBits((UInt32)value, 12, 15);
                outFreqControl.SetPPhaseVal(value);

                serialPort.SetDisableSending(false, 10);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void LDFunctionIndexChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 2);

                registers[2].SetResetOneBit(8, (BitState)value);
                outFreqControl.SetLDFunction(value);
                outFreqControl.CheckIfLDfuncToAppropriateModeIsSellected(false);

                serialPort.SetDisableSending(false, 2);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void AutoLDFuncCheckedChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                outFreqControl.SetAutoLDFunction(value);
                outFreqControl.CheckIfLDfuncToAppropriateModeIsSellected(true);
            }
        }

        public void OutBPathIndexChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 11);

                registers[4].SetResetOneBit(9, (BitState)value);
                outFreqControl.SetOutBPath(value);

                serialPort.SetDisableSending(false, 11);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void FBPathIndexChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 30);

                registers[4].SetResetOneBit(23, (BitState)value);
                outFreqControl.SetFBPath(value);

                serialPort.SetDisableSending(false, 30);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }
    #endregion

    #region Synthesizer Output Controls Group
        public void OutAEnStateChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 16);

                registers[4].SetResetOneBit(5, (BitState)value);
                synthOutputControls.SetOutAEnable((OutEnState)value);

                serialPort.SetDisableSending(false, 16);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void OutBEnStateChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 17);

                registers[4].SetResetOneBit(8, (BitState)value);
                synthOutputControls.SetOutBEnable((OutEnState)value);

                serialPort.SetDisableSending(false, 17);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void OutAPwrValueChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 18);

                registers[4].ChangeNBits((UInt32)value, 2, 3);
                synthOutputControls.SetOutAPwr(value);

                serialPort.SetDisableSending(false, 18);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void OutBPwrValueChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 19);

                if (synthOutputControls.SetOutBPwr(value))
                    registers[4].ChangeNBits((UInt32)synthOutputControls.GetOutBPwrIndex(), 2, 6);

                serialPort.SetDisableSending(false, 19);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }
    #endregion

    #region Charge Pump Group
        public void GetCPCurrentFromTextBox(string value)
        {
            chargePump.SetRSetValue(value);
        }
        
        public void CPCurrentIndexChanged(int value)
        {
            if (serialPort.IsPortOpen() && chargePump.isCurrentComboboxFilled())
            {
                serialPort.SetDisableSending(true, 20);

                registers[2].ChangeNBits((UInt32)value, 4, 9);
                chargePump.SetCurrentIndex(value);

                serialPort.SetDisableSending(false, 20);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void CPLinearityIndexChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 3);

                SynthMode synthMode = outFreqControl.GetSynthMode();
                chargePump.SetLinearityIndex(value, synthMode);

                value = chargePump.GetLinearityIndex();

                registers[1].ChangeNBits((UInt32)value, 2, 29);

                serialPort.SetDisableSending(false, 3);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void CPTestModeIndexChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 21);

                registers[1].ChangeNBits((UInt32)value, 2, 27);
                chargePump.SetTestModeIndex(value);

                serialPort.SetDisableSending(false, 21);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void CPFastLockCheckedChanged(bool value)
        {
            if (serialPort.IsPortOpen() && !chargePump.GetDisableHandler())
            {
                serialPort.SetDisableSending(true, 22);

                if (value)
                    registers[3].ChangeNBits(Convert.ToUInt32(ClockDividerMode.FastLockEnable), 2, 15);
                else
                    registers[3].ChangeNBits(Convert.ToUInt32(ClockDividerMode.MuteUntilLockDelay), 2, 15);
                
                chargePump.SetFastLockMode(value);

                serialPort.SetDisableSending(false, 22);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void PhaseAdjustmentCheckedChanged(bool value)
        {
            if (serialPort.IsPortOpen() && !chargePump.GetDisableHandler())
            {
                serialPort.SetDisableSending(true, 23);
                if (value)
                    registers[3].ChangeNBits(Convert.ToUInt32(ClockDividerMode.PhaseAdjustment), 2, 15);
                else
                    registers[3].ChangeNBits(Convert.ToUInt32(ClockDividerMode.MuteUntilLockDelay), 2, 15);
                
                chargePump.SetPhaseAdjustmentMode(value);

                serialPort.SetDisableSending(false, 23);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void CPCycleSlipCheckedChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 24);

                registers[3].SetResetOneBit(18, (BitState)Convert.ToUInt16(value));
                chargePump.SetCycleSlipMode(value);

                serialPort.SetDisableSending(false, 24);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void CPTristateCheckedChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 25);

                registers[2].SetResetOneBit(4, (BitState)Convert.ToUInt16(value));
                chargePump.SetTriStateMode(value);

                serialPort.SetDisableSending(false, 25);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        #endregion

    #region Phase Detector Group
        public void SDNoiseModeIndexChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 26);

                phaseDetector.SetNoiseMode(value);
                if (value == 1 || value == 2)
                    value++;
                registers[2].ChangeNBits((UInt32)value, 2, 29);

                serialPort.SetDisableSending(false, 26);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void LDPrecisionIndexChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 27);

                registers[2].SetResetOneBit(7, (BitState)value);
                phaseDetector.SetPrecision(value);

                serialPort.SetDisableSending(false, 27);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void PositivePdfCheckedChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 28);

                registers[2].SetResetOneBit(6, (BitState)value);
                phaseDetector.SetPfdPolarity(value);

                serialPort.SetDisableSending(false, 28);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }
    #endregion

    #region VCO Settings Group
        public void AutoVcoSelectionStateChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 40);

                registers[3].SetResetOneBit(25, (BitState)Convert.ToUInt16(!value));
                vcoControls.SetAutoVcoSelectionState(value);

                serialPort.SetDisableSending(false, 40);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void VASTempComStateChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 41);

                registers[3].SetResetOneBit(24, (BitState)Convert.ToUInt16(value));
                if (value == true)
                    registers[5].ChangeNBits(0b11, 2, 29);
                else
                    registers[5].ChangeNBits(0b00, 2, 29);
                vcoControls.SetVASTempComState(value);

                serialPort.SetDisableSending(false, 41);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void ManualVCOSelectValueChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 42);

                registers[3].ChangeNBits((UInt32)value, 6, 26);
                vcoControls.SetManualVCOSelectValue((UInt16)value);

                serialPort.SetDisableSending(false, 42);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void BandSelClockDivValueChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 43);

                vcoControls.SetBandSelClockDivValue((UInt16)value);
                value = vcoControls.GetBandSelClockDivValue();

                UInt16 lsbs = (UInt16)(value & 0xFF);
                UInt16 msbs = (UInt16)((UInt16)value & 0x300);
                msbs = (UInt16)(msbs >> 8);

                registers[4].ChangeNBits((UInt32)lsbs, 8, 12);
                registers[4].ChangeNBits((UInt32)msbs, 2, 24);

                serialPort.SetDisableSending(false, 43);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void MuteUntilLockDetectStateChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 44);

                registers[4].SetResetOneBit(10, (BitState)Convert.ToUInt16(value));
                vcoControls.SetMuteUntilLockDetectState(value);

                serialPort.SetDisableSending(false, 44);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void DelayToPreventFlickeringStateChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 45);

                registers[3].SetResetOneBit(17, (BitState)Convert.ToUInt16(value));
                vcoControls.SetDelayToPreventFlickeringState(value);

                serialPort.SetDisableSending(false, 45);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void ClockDividerValueChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 46);

                vcoControls.SetClockDividerValue((UInt16)value);
                UInt16 modValue = outFreqControl.uint16_GetModVal();
                decimal fPfd = refFreq.decimal_GetPfdFreq();
                vcoControls.SetDelayLabel(modValue, fPfd);

                registers[3].ChangeNBits((UInt32)value, 12, 3);

                serialPort.SetDisableSending(false, 46);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void AutoCDIVCalcStateChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 47);

                vcoControls.SetAutoCdivCalc(value);

                CalcCDivValue();

                serialPort.SetDisableSending(false, 47);
                if (serialPort.GetDisableSending() == false)
                    SendData();
            }
        }

        public void DelayInputValueChanged(UInt16 value)
        {
            vcoControls.SetDelayInputValue(value);

            CalcCDivValue();
        }

        public void CalcCDivValue()
        {
            decimal fPfd = refFreq.decimal_GetPfdFreq();
            UInt16 mod = outFreqControl.uint16_GetModVal();
            
            if (vcoControls.GetAutoCDiv())
            {
                UInt16 delayMsValue = vcoControls.GetDelayInputValue();
                vcoControls.CalcCDIVValue(delayMsValue, fPfd, mod);
            }
            
            vcoControls.SetDelayLabel(mod, fPfd);
        }

    #endregion

    #region Generic Controls Group
        public void MuxPinModeIndexChanged(int value)
        {
            serialPort.SetDisableSending(true, 29);

            registers[2].ChangeNBits((UInt32)value, 3, 26);
            genericControls.SetMuxPinMode(value);

            serialPort.SetDisableSending(false, 29);
            if (serialPort.GetDisableSending() == false)
                SendData();
        }

        public void Reg4DoubleBufferedStateChanged(bool value)
        {
            serialPort.SetDisableSending(true, 37);

            registers[2].SetResetOneBit(13, (BitState)Convert.ToUInt16(value));
            genericControls.SetReg4DoubleBuffered(value);

            serialPort.SetDisableSending(false, 37);
            if (serialPort.GetDisableSending() == false)
                SendData();
        }

        public void IntNAutoModeWhenF0StateChanged(bool value) // TODO test it on SA
        {
            serialPort.SetDisableSending(true, 38);

            registers[5].SetResetOneBit(24, (BitState)Convert.ToUInt16(value));
            genericControls.SetF0AutoIntNMode(value);

            serialPort.SetDisableSending(false, 38);
            if (serialPort.GetDisableSending() == false)
                SendData();
        }

        public void RandNCountersResetStateChanged(bool value)
        {
            serialPort.SetDisableSending(true, 39);

            registers[2].SetResetOneBit(3, (BitState)Convert.ToUInt16(value));
            genericControls.SetRandNCountersReset(value);

            serialPort.SetDisableSending(false, 39);
            if (serialPort.GetDisableSending() == false)
                SendData();
        }
    #endregion

    #region Shutdown controls group

        public void PloPowerDownStateChanged(bool value)
        {
            serialPort.SetDisableSending(true, 31);

            registers[2].SetResetOneBit(5, (BitState)Convert.ToUInt16(value));
            shutdowns.SetShutdownAllState(value);

            serialPort.SetDisableSending(false, 31);
            if (serialPort.GetDisableSending() == false)
                SendData();
        }

        public void  RefInputShutdownStateChanged(bool value)
        {
            serialPort.SetDisableSending(true, 32);

            registers[4].SetResetOneBit(26, (BitState)Convert.ToUInt16(value));
            shutdowns.SetReferenceInputShutdownState(value);

            serialPort.SetDisableSending(false, 32);
            if (serialPort.GetDisableSending() == false)
                SendData();
        }

        public void PllShutDownStateChanged(bool value)
        {
            serialPort.SetDisableSending(true, 33);

            registers[5].SetResetOneBit(25, (BitState)Convert.ToUInt16(value));
            shutdowns.SetPllShutdownState(value);

            serialPort.SetDisableSending(false, 33);
            if (serialPort.GetDisableSending() == false)
                SendData();
        }

        public void VcoDividerShutDownStateChanged(bool value)
        {
            serialPort.SetDisableSending(true, 34);

            registers[4].SetResetOneBit(27, (BitState)Convert.ToUInt16(value));
            shutdowns.SetVcoDividerShutdownState(value);

            serialPort.SetDisableSending(false, 34);
            if (serialPort.GetDisableSending() == false)
                SendData();
        }

        public void VcoLdoShutDownStateChanged(bool value)
        {
            serialPort.SetDisableSending(true, 35);

            registers[4].SetResetOneBit(28, (BitState)Convert.ToUInt16(value));
            shutdowns.SetVcoLdoShutdownState(value);

            serialPort.SetDisableSending(false, 35);
            if (serialPort.GetDisableSending() == false)
                SendData();
        }

        public void VcoShutDownStateChanged(bool value)
        {
            serialPort.SetDisableSending(true, 36);

            registers[4].SetResetOneBit(11, (BitState)Convert.ToUInt16(value));
            shutdowns.SetVcoShutdownState(value);

            serialPort.SetDisableSending(false, 36);
            if (serialPort.GetDisableSending() == false)
                SendData();
        }

    #endregion

#endregion

#region Functions for get values from register
    #region Parsing register 0
        private void GetFracIntModeStatusFromRegister(UInt32 dataReg0)
        {
            UInt32 value = BitOperations.GetNBits(dataReg0, 1, 31);
            outFreqControl.SetSynthMode((SynthMode)value);
            outFreqControl.CheckIfLDfuncToAppropriateModeIsSellected(false);

            refFreq.SetSynthModeInfoVariable((SynthMode)value);
            decimal pfdFreq = refFreq.decimal_GetPfdFreq();
            vcoControls.CalcBandSelClockDivValue(pfdFreq);
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
            outFreqControl.SetModVal(mod);
            decimal fPfd = refFreq.decimal_GetPfdFreq();

            vcoControls.SetDelayLabel(mod, fPfd);
        }

        private void GetPhasePValueFromRegister(UInt32 dataReg1)
        {
            UInt16 phaseP = (UInt16)BitOperations.GetNBits(dataReg1, 12, 15);
            outFreqControl.SetPPhaseVal(phaseP);
        }

        private void GetCPLinearityFromRegister(UInt32 dataReg1)
        {
            int index = (int)BitOperations.GetNBits(dataReg1, 2, 29);
            chargePump.SetLinearityIndex(index);
        }

        private void GetCPTestModeFromRegister(UInt32 dataReg1)
        {
            int index = (int)BitOperations.GetNBits(dataReg1, 2, 27);
            chargePump.SetTestModeIndex(index);
        }
    #endregion

    #region Parsing register 2
        private void GetRefDoublerStatusFromRegister(UInt32 dataReg2)
        {
            bool refDoubler = Convert.ToBoolean(BitOperations.GetNBits(dataReg2, 1, 25));
            refFreq.SetRefDoubler(refDoubler);
            decimal pfdFreq = refFreq.decimal_GetPfdFreq();
            vcoControls.CalcBandSelClockDivValue(pfdFreq);
        }
        
        private void GetRefDividerStatusFromRegister(UInt32 dataReg2)
        {
            bool refDividerBy2 = Convert.ToBoolean(BitOperations.GetNBits(dataReg2, 1, 24));
            refFreq.SetRefDivBy2(refDividerBy2);
            decimal pfdFreq = refFreq.decimal_GetPfdFreq();
            vcoControls.CalcBandSelClockDivValue(pfdFreq);
        }

        private void GetRDivValueFromRegister(UInt32 dataReg2)
        {
            UInt16 rDiv = (UInt16)BitOperations.GetNBits(dataReg2, 10, 14);
            refFreq.SetRDivider(rDiv);
            decimal pfdFreq = refFreq.decimal_GetPfdFreq();
            vcoControls.CalcBandSelClockDivValue(pfdFreq);
        }

        private void GetCPCurrentIndexFromRegister(UInt32 dataReg2)
        {
            int index = (int)BitOperations.GetNBits(dataReg2, 4, 9);
            chargePump.SetCurrentIndex(index);
        }

        private void GetLDSpeedAdjIndexFromRegister(UInt32 dataReg2)
        {
            int index = (int)BitOperations.GetNBits(dataReg2, 1, 31);
            refFreq.SetLDSpeedAdj(index);
        }

        private void GetLDFunctionIndexFromRegister(UInt32 dataReg2)
        {
            int index = (int)BitOperations.GetNBits(dataReg2, 1, 8);
            outFreqControl.SetLDFunction(index);
            if (serialPort.IsPortOpen())
                outFreqControl.CheckIfLDfuncToAppropriateModeIsSellected(false);
        }

        private void GetTriStateModeFromRegister(UInt32 dataReg2)
        {
            bool enabled = Convert.ToBoolean(BitOperations.GetNBits(dataReg2, 1, 4));
            chargePump.SetTriStateMode(enabled);
        }

        private void GetNoiseModeFromRegister(UInt32 dataReg2)
        {
            int index = (int)BitOperations.GetNBits(dataReg2, 2, 29);
            if (index == 2 || index == 3)
                index--;
            phaseDetector.SetNoiseMode(index);
        }

        private void GetPrecisionFromRegister(UInt32 dataReg2)
        {
            int index = (int)BitOperations.GetNBits(dataReg2, 1, 7);
            phaseDetector.SetPrecision(index);
        }

        private void GetPfdPositionFromRegister(UInt32 dataReg2)
        {
            int index = (int)BitOperations.GetNBits(dataReg2, 1, 6);
            phaseDetector.SetPfdPolarity(index);
        }

        private void GetMuxPinModeFromRegister(UInt32 dataReg2)
        {
            int index = (int)BitOperations.GetNBits(dataReg2, 3, 26);
            genericControls.SetMuxPinMode(index);
        }

        private void GetShutDownAllStateFromRegister(UInt32 dataReg2)
        {
            bool shutdown = Convert.ToBoolean(BitOperations.GetNBits(dataReg2, 1, 5));
            shutdowns.SetShutdownAllState(shutdown);
        }

        private void GetReg4DoubleBufferedStateFromRegister(UInt32 dataReg2)
        {
            bool state = Convert.ToBoolean(BitOperations.GetNBits(dataReg2, 1, 13));
            genericControls.SetReg4DoubleBuffered(state);
        }

        private void GetRandNCountersResetStateFromRegister(UInt32 dataReg2)
        {
            bool state = Convert.ToBoolean(BitOperations.GetNBits(dataReg2, 1, 3));
            genericControls.SetRandNCountersReset(state);
        }

    #endregion

    #region Parsing register 3
        private void GetClockDividerModeFromRegister(UInt32 dataReg3)
        {
            ClockDividerMode cdm = (ClockDividerMode)BitOperations.GetNBits(dataReg3, 2, 15);
            if (cdm == ClockDividerMode.FastLockEnable)
                chargePump.SetFastLockMode(true);
            else
                chargePump.SetFastLockMode(false);

            if (cdm == ClockDividerMode.PhaseAdjustment)
                chargePump.SetPhaseAdjustmentMode(true);
            else
                chargePump.SetPhaseAdjustmentMode(false);
        }

        private void GetCycleSlipModeFromRegister(UInt32 dataReg3)
        {
            bool enabled = Convert.ToBoolean(BitOperations.GetNBits(dataReg3, 1, 18));
            chargePump.SetCycleSlipMode(enabled);
        }

        private void GetAutoVcoSelectionStateFromRegister(UInt32 dataReg3)
        {
            bool enabled = Convert.ToBoolean(BitOperations.GetNBits(dataReg3, 1, 25));
            vcoControls.SetAutoVcoSelectionState(!enabled);
        }

        private void GetVASTempComStateFromRegister(UInt32 dataReg3)
        {
            bool enabled = Convert.ToBoolean(BitOperations.GetNBits(dataReg3, 1, 24));
            vcoControls.SetVASTempComState(enabled);
        }

        private void GetManualVCOSelectValueFromRegister(UInt32 dataReg3)
        {
            UInt16 vcoValue = (UInt16)BitOperations.GetNBits(dataReg3, 6, 26);
            vcoControls.SetManualVCOSelectValue(vcoValue);
        }

        private void GetDelayToPreventFlickeringStateFromRegister(UInt32 dataReg3)
        {
            bool enabled = Convert.ToBoolean(BitOperations.GetNBits(dataReg3, 1, 17));
            vcoControls.SetDelayToPreventFlickeringState(enabled);
        }

        private void GetClockDividerValueFromRegister(UInt32 dataReg3)
        {
            UInt16 cdiv = (UInt16)BitOperations.GetNBits(dataReg3, 12, 3);
            vcoControls.SetClockDividerValue(cdiv);
        }

    #endregion

    #region Parsing register 4
        private void GetOutAENStatusFromRegister(UInt32 dataReg4)
        {
            OutEnState outAEn = (OutEnState)BitOperations.GetNBits(dataReg4, 1, 5);
            synthOutputControls.SetOutAEnable(outAEn);
        }

        private void GetOutBENStatusFromRegister(UInt32 dataReg4)
        {
            OutEnState outBEn = (OutEnState)BitOperations.GetNBits(dataReg4, 1, 8);
            synthOutputControls.SetOutBEnable(outBEn);
        }

        private void GetOutAPwrStatusFromRegister(UInt32 dataReg4)
        {
            int outAPwr = (int)BitOperations.GetNBits(dataReg4, 2, 3);
            synthOutputControls.SetOutAPwr(outAPwr);
        }

        private void GetOutBPwrStatusFromRegister(UInt32 dataReg4)
        {
            int outBPwr = (int)BitOperations.GetNBits(dataReg4, 2, 6);
            if (!synthOutputControls.SetOutBPwr(outBPwr))
                registers[4].ChangeNBits((UInt32)synthOutputControls.GetOutBPwrIndex(), 2, 6);
        }

        private void GetADividerValueFromRegister(UInt32 dataReg4)
        {
            UInt16 aDiv = (UInt16)BitOperations.GetNBits(dataReg4, 3, 20);
            outFreqControl.SetADivVal(aDiv);
        }

        public void GetOutBPathIndexFromRegister(UInt32 dataReg4)
        {
            int index = (int)BitOperations.GetNBits(dataReg4, 1, 9);
            outFreqControl.SetOutBPath(index);
        }

        public void GetFBPathIndexFromRegister(UInt32 dataReg4)
        {
            int index = (int)BitOperations.GetNBits(dataReg4, 1, 23);
            outFreqControl.SetFBPath(index);
        }

        private void GetRefInputShutdownStateFromRegister(UInt32 dataReg4)
        {
            bool shutdown = Convert.ToBoolean(BitOperations.GetNBits(dataReg4, 1, 26));
            shutdowns.SetReferenceInputShutdownState(shutdown);
        }

        private void GetVcoDividerShutDownStateFromRegister(UInt32 dataReg4)
        {
            bool shutdown = Convert.ToBoolean(BitOperations.GetNBits(dataReg4, 1, 27));
            shutdowns.SetVcoDividerShutdownState(shutdown);
        }

        private void GetVcoLdoShutDownStateFromRegister(UInt32 dataReg4)
        {
            bool shutdown = Convert.ToBoolean(BitOperations.GetNBits(dataReg4, 1, 28));
            shutdowns.SetVcoLdoShutdownState(shutdown);
        }

        private void GetVcoShutDownStateFromRegister(UInt32 dataReg4)
        {
            bool shutdown = Convert.ToBoolean(BitOperations.GetNBits(dataReg4, 1, 11));
            shutdowns.SetVcoShutdownState(shutdown);
        }

        private void GetMuteUntilLockDetectStateFromRegister(UInt32 dataReg4)
        {
            bool mtld = Convert.ToBoolean(BitOperations.GetNBits(dataReg4, 1, 10));
            vcoControls.SetMuteUntilLockDetectState(mtld);
        }

        public void GetBandSelClockDivValueFromRegister(UInt32 dataReg4)
        {
            UInt16 msbs = (UInt16)BitOperations.GetNBits(dataReg4, 2, 24);
            UInt16 lsbs = (UInt16)BitOperations.GetNBits(dataReg4, 8, 12);
            UInt16 bandSelectClockDiv = (UInt16)((msbs << 8) + lsbs);
            vcoControls.SetBandSelClockDivValue(bandSelectClockDiv);
        }

    #endregion

    #region Parsing register 5
        private void GetPllShutdownStateFromRegister(UInt32 dataReg5)
        {
            bool shutdown = Convert.ToBoolean(BitOperations.GetNBits(dataReg5, 1, 25));
            shutdowns.SetPllShutdownState(shutdown);
        }
        
        private void GetIntNAutoModeWhenF0StateFromRegister(UInt32 dataReg5)
        {
            bool state = Convert.ToBoolean(BitOperations.GetNBits(dataReg5, 1, 24));
            genericControls.SetF0AutoIntNMode(state);
        }

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
                    GetCPTestModeFromRegister(reg);
                    break;
                case 2:
                    GetRefDoublerStatusFromRegister(reg);
                    GetRefDividerStatusFromRegister(reg);
                    GetRDivValueFromRegister(reg);
                    GetCPCurrentIndexFromRegister(reg);
                    GetLDSpeedAdjIndexFromRegister(reg);
                    GetLDFunctionIndexFromRegister(reg);
                    GetTriStateModeFromRegister(reg);
                    GetNoiseModeFromRegister(reg);
                    GetPrecisionFromRegister(reg);
                    GetPfdPositionFromRegister(reg);
                    GetMuxPinModeFromRegister(reg);
                    GetShutDownAllStateFromRegister(reg);
                    GetReg4DoubleBufferedStateFromRegister(reg);
                    GetRandNCountersResetStateFromRegister(reg);
                    break;
                case 3:
                    GetClockDividerModeFromRegister(reg);
                    GetCycleSlipModeFromRegister(reg);
                    GetAutoVcoSelectionStateFromRegister(reg);
                    GetVASTempComStateFromRegister(reg);
                    GetManualVCOSelectValueFromRegister(reg);
                    GetDelayToPreventFlickeringStateFromRegister(reg);
                    GetClockDividerValueFromRegister(reg);
                    break;
                case 4:
                    GetOutAENStatusFromRegister(reg);
                    GetOutBENStatusFromRegister(reg);
                    GetOutAPwrStatusFromRegister(reg);
                    GetOutBPwrStatusFromRegister(reg);
                    GetADividerValueFromRegister(reg);
                    GetOutBPathIndexFromRegister(reg);
                    GetFBPathIndexFromRegister(reg);
                    GetRefInputShutdownStateFromRegister(reg);
                    GetVcoDividerShutDownStateFromRegister(reg);
                    GetVcoLdoShutDownStateFromRegister(reg);
                    GetVcoShutDownStateFromRegister(reg);
                    GetMuteUntilLockDetectStateFromRegister(reg);
                    GetBandSelClockDivValueFromRegister(reg);
                    break;
                case 5:
                    GetPllShutdownStateFromRegister(reg);
                    GetIntNAutoModeWhenF0StateFromRegister(reg);
                    break;
            }
        }

        public void GetAllFromRegisters()
        {
            for (int i = 5; i >= 0; i--)
            {
                GetAllFromReg(i);
            }
            RecalcWorkingFreqInfo(); 
        }
    #endregion

#endregion

#region Some magic calculations
        public void RecalcWorkingFreqInfo()
        {
            UInt16 aDiv     = outFreqControl.uint16_GetADivVal();
            UInt16 intN     = outFreqControl.uint16_GetIntNVal();
            UInt16 fracN    = outFreqControl.uint16_GetFracNVal();
            UInt16 mod      = outFreqControl.uint16_GetModVal();
            SynthMode mode  = outFreqControl.GetSynthMode();
            int outBpath    = outFreqControl.GetOutBPathIndex();
            int FBpath      = outFreqControl.GetFBPathIndex();
            decimal fPfd    = refFreq.decimal_GetPfdFreq();

            decimal fOutA = 0;
            decimal fOutB = 0;
            decimal fVco = 0;

            CalcFreqInfo(intN, fracN, mod, aDiv, mode, outBpath, FBpath, fPfd, 
                         out fOutA, out fOutB, out fVco);

            if (synthFreqInfo.SetVcoFreq(fVco) == false)
            {
                directFreqControl.SetFreqAtOut1(0);
                directFreqControl.SetFreqAtOut2(0);
                
                return;
            }
            synthFreqInfo.SetOutAFreq(fOutA);
            synthFreqInfo.SetOutBFreq(fOutB);
            directFreqControl.SetFreqAtOut1(fOutA);
            directFreqControl.SetFreqAtOut2(fOutB * 2);
            memory.UpdateUiElements();
        }

        public void CalcFreqInfo(UInt16 intN, UInt16 fracN, UInt16 mod, UInt16 aDiv, 
                                SynthMode mode, int outBpath, int FBpath, decimal fPfd,
                                out decimal fOutA, out decimal fOutB, out decimal fVco)
        {
            fVco = 0;
            if (mode == SynthMode.INTEGER)
            {
                if (FBpath == 1)
                {
                    fVco = fPfd * intN;
                }
                else
                {
                    if (aDiv <=16)
                        fVco = fPfd * intN * aDiv;
                    else if (aDiv > 16)
                        fVco = fPfd * intN * 16; // FIXME calculating freq for all FB combinations
                }
            }
            else
            {
                if (FBpath == 1)
                {
                    fVco = (intN + (fracN / (mod*1.0M) ) ) * fPfd;
                }
                else
                {
                    if (aDiv <=16)
                        fVco = (intN + (fracN / (mod*1.0M) ) ) * fPfd * aDiv;
                    else if (aDiv > 16)
                        fVco = (intN + (fracN / (mod*1.0M) ) ) * fPfd * 16;
                }
            }

            fOutA = fVco / aDiv;

            if (outBpath == 0)
                fOutB = fOutA;
            else
                fOutB = fVco;
        }

        public void CalcSynthesizerRegValuesFromInpFreq(string value)
        {
            directFreqControl.SetDirectInputFreqValue(value);

            serialPort.SetDisableSending(true, 13);

            decimal f_input = directFreqControl.decimal_GetDirectInputFreqVal();

            bool isDoubled = refFreq.GetIsDoubled();
            bool isDivBy2 = refFreq.GetIsDividedBy2();
            decimal refInFreq = refFreq.decimal_GetRefFreqValue();
            int outBPathIndex = outFreqControl.GetOutBPathIndex();
            int FBPathIndex   = outFreqControl.GetFBPathIndex();

            CalcRegs calcRegs = CalcRegisters.CalcRegistersFromInput(f_input, 
                                                                     refInFreq, 
                                                                     isDoubled, 
                                                                     isDivBy2, 
                                                                     outBPathIndex,
                                                                     FBPathIndex);

            outFreqControl.SetADivVal((UInt16)calcRegs.aDivIndex);
            refFreq.SetAutoLDSpeedAdj(true);
            outFreqControl.SetAutoLDFunction(true);
            outFreqControl.SetSynthMode(calcRegs.mode);
            outFreqControl.SetIntNVal(calcRegs.intN);
            refFreq.SetRDivider(calcRegs.rDiv);
            decimal pfdFreq = refFreq.decimal_GetPfdFreq();
            vcoControls.CalcBandSelClockDivValue(pfdFreq);
            

            if (calcRegs.mode == SynthMode.FRACTIONAL)
            {
                outFreqControl.SetModVal(calcRegs.mod);
                outFreqControl.SetFracNVal(calcRegs.fracN);
            }

            if (f_input <= 6000)
            {
                synthOutputControls.SetOutAEnable(OutEnState.ENABLE);
                synthOutputControls.SetOutBEnable(OutEnState.DISABLE);
            }
            else
            {
                synthOutputControls.SetOutAEnable(OutEnState.DISABLE);
                synthOutputControls.SetOutBEnable(OutEnState.ENABLE);
            }

            serialPort.SetDisableSending(false, 13);
            if (serialPort.GetDisableSending() == false)
                SendData();
            
            decimal delta;
            decimal f_out_A = synthFreqInfo.decimal_GetOutAFreq();
            decimal f_out_B = synthFreqInfo.decimal_GetOutBFreq();

            directFreqControl.SetFreqAtOut1(f_out_A);
            directFreqControl.SetFreqAtOut2(2*f_out_B);

            if (f_input <= 6000)
            {
                if (!moduleControls.GetOut1State())
                {
                    serialPort.SendStringSerialPort("out 1 on");
                    moduleControls.SetOut1(true);
                    directFreqControl.SetActiveOut1(true);
                }
                if (moduleControls.GetOut2State())
                {
                    serialPort.SendStringSerialPort("out 2 off");
                    moduleControls.SetOut2(false);
                    directFreqControl.SetActiveOut2(false);
                }
                delta = (f_out_A - f_input) * 1e6M;
                directFreqControl.SetCalcFreq(f_out_A);
            }
            else
            {
                if (moduleControls.GetOut1State())
                {
                    serialPort.SendStringSerialPort("out 1 off");
                    moduleControls.SetOut1(false);
                    directFreqControl.SetActiveOut1(false);
                }
                if (!moduleControls.GetOut2State()) 
                {
                    serialPort.SendStringSerialPort("out 2 on");
                    moduleControls.SetOut2(true);
                    directFreqControl.SetActiveOut2(true);
                }
                delta = (f_out_B * 2 - f_input) * 1e6M;
                directFreqControl.SetCalcFreq(f_out_B * 2);
            }

            directFreqControl.SetDeltaFreqValue(delta);
        }
#endregion

#region Serial port

        public void ForceLoadAllRegsIntoPlo()
        {
            for (int i = 5; i >= 0; i--)
            {
                if (!serialPort.IsPortOpen())
                    return;
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
            
            if (moduleControls.GetIntRefState())
                serialPort.SendStringSerialPort("ref int");
            else
                serialPort.SendStringSerialPort("ref ext");
        }

        public void CheckAndApplyRegChanges(string sender, string value)
        {
            serialPort.SetDisableSending(true, 4);

            sender = string.Join("", sender.ToCharArray().Where(Char.IsDigit));
            int regNumber = int.Parse(sender);

            registers[regNumber].SetValue(value);
            GetAllFromReg(regNumber);

            serialPort.SetDisableSending(false, 4);
            if (serialPort.GetDisableSending() == false)
                SendData();
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
                    RecalcWorkingFreqInfo();
            }
        }

        public void CheckAndApplyRegChanges(string sender)
        {
            sender = string.Join("", sender.ToCharArray().Where(Char.IsDigit));
            int regNumber = int.Parse(sender);

            CheckAndApplyRegChanges(regNumber);
        }

        private void SendData()
        {
            if (serialPort.IsPortOpen())
            {
                bool[] needUpdate = new bool[6];
                for (int regNumber = 0; regNumber <= 5; regNumber++)
                {
                    if ((!string.Equals(registers[regNumber].string_GetValue(), 
                                old_registers[regNumber].string_GetValue(),
                                StringComparison.CurrentCultureIgnoreCase)))
                        needUpdate[regNumber] = true;
                    else
                        needUpdate[regNumber] = false;
                }

                for (int regNumber = 5; regNumber >= 0; regNumber--)
                {
                    if (needUpdate[regNumber] == true)
                        GetAllFromReg(regNumber);
                }

                for (int regNumber = 5; regNumber >= 0; regNumber--)
                {
                    if (needUpdate[regNumber] == true)
                    {
                        GetAllFromReg(regNumber);
                        switch (regNumber)
                        {
                            case 5:
                                ApplyChangeReg(5);
                                break;
                            case 4:
                                ApplyChangeReg(4);
                                if (genericControls.GetReg4DoubleBuffered()) // TODO test me on SA, comment needUpdate true flag and test it
                                    needUpdate[0] = true;
                                break;
                            case 3:
                                ApplyChangeReg(3);
                                break;
                            case 2:
                                ApplyChangeReg(2);
                                needUpdate[0] = true;
                                break;
                            case 1:
                                ApplyChangeReg(1);
                                needUpdate[0] = true;
                                break;
                            default:
                                ApplyChangeReg(0);
                                break;
                        }
                    }
                }

                if (needUpdate[0] || needUpdate[1] || needUpdate[2] || needUpdate[4])
                    RecalcWorkingFreqInfo();
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

        public bool SwitchPort()
        {
            if(serialPort.IsPortOpen())
            {
                serialPort.ClosePort();
                SaveWorkspaceData();
                return false;
            }
            else
            {
                return OpenPort();
            }
        }

        private bool OpenPort()
        {
            bool success = serialPort.OpenPort();

            if (success)
            {
                ForceLoadAllRegsIntoPlo();
                if (serialPort.IsPortOpen())
                {
                    success = true;
                    SaveWorkspaceData();
                }
                else
                    success = false;
                return success;
            }
            else
            {
                return false;
            }
        }

        #endregion

#region Load and Save Data

    #region Workspace data part
        public void LoadSavedWorkspaceData()
        {
            SaveWindow loadedData = new SaveWindow();
            bool success = FilesManager.LoadSavedWorkspaceData(out loadedData);

            if (success)
            {
                string text = "Workspace data succesfuly loaded.";
                ConsoleController.Console().Write(text);

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

            chargePump.SetRSetValue(data.RSetValue);

            directFreqControl.SetDirectInputFreqValue(data.OutputFreqValue);

            refFreq.SetRefFreqValue(data.ReferenceFrequency);
            decimal pfdFreq = refFreq.decimal_GetPfdFreq();
            vcoControls.CalcBandSelClockDivValue(pfdFreq);

            serialPort.SetSelectedPort(data.COM_port);
            refFreq.SetAutoLDSpeedAdj(data.AutoLDSpeedAdj);
            outFreqControl.SetAutoLDFunction(data.AutoLDFunc);
            vcoControls.SetAutoCdivCalc(data.AutoCDIVFunc);
            vcoControls.SetDelayInputValue(data.DelayInput);

            moduleControls.SetOut1(data.Out1En);
            moduleControls.SetOut2(data.Out2En);
            moduleControls.SetIntRef(data.IntRef);
            directFreqControl.SetIntRefState(data.IntRef);
            directFreqControl.SetActiveOut1(data.Out1En);
            directFreqControl.SetActiveOut2(data.Out2En);

            readRegister.SetAdcMode((ReadRegister.AdcMode)data.AdcModeIndex);

            LoadMemoryRegsFromFile(data);

            this.GetAllFromRegisters();
            refFreq.ChangeRefInpUIEnabled(!moduleControls.GetIntRefState());
        }

        private SaveWindow CreateSaveWindow()
        {
            SaveWindow saved = new SaveWindow
            {
                Registers = new List<string>{},
                RSetValue = chargePump.GetRSetValue(),
                OutputFreqValue = directFreqControl.string_GetDirectInputFreqVal(),
                ReferenceFrequency = refFreq.string_GetRefFreqValue(),
                Out1En = moduleControls.GetOut1State(),
                Out2En = moduleControls.GetOut2State(),
                IntRef = moduleControls.GetIntRefState(),
                Mem1 = new List<string>{},
                Mem2 = new List<string>{},
                Mem3 = new List<string>{},
                Mem4 = new List<string>{},
                COM_port = serialPort.GetSelectedPort(),
                AutoLDSpeedAdj = refFreq.bool_GetAutoLdSpeedAdj(),
                AutoLDFunc = outFreqControl.GetAutoLDFunctionIsChecked(),
                AutoCDIVFunc = vcoControls.GetAutoCDiv(),
                DelayInput = vcoControls.GetDelayInputValue(),
                AdcModeIndex = (int)readRegister.GetAdcMode()
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
                serialPort.SetDisableSending(true, 49);
                LoadDefRegsFromFile(loadedData);
                SendData();
                serialPort.SetDisableSending(false, 49);
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
            
            if (data.Out1State != moduleControls.GetOut1State())
                SwitchOut1();
            if (data.Out2State != moduleControls.GetOut2State())
                SwitchOut2();
            if (data.RefState != moduleControls.GetIntRefState())
                SwitchRef();
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

            saved.Out1State = moduleControls.GetOut1State();
            saved.Out2State = moduleControls.GetOut2State();
            saved.RefState  = moduleControls.GetIntRefState();

            return saved;
        }

    #endregion
    
    #region Registers data part
        public void SaveRegistersIntoFile()
        {
            string test = null;
            FilesManager.SaveFile(out test, GetDefaultRegistersFileName());

            if (test != string.Empty)
            {
                bool success = FilesManager.SaveDefRegsData(CreateDefaultsData(), test);

                if(success)
                {
                    string text = "Currently registers succesfuly saved into file: '" + test + "'";
                    ConsoleController.Console().Write(text);
                }
                else
                {
                    string text = "When saving registers occurs error!";
                    ConsoleController.Console().Write(text);
                    MessageBox.Show(text, "Error Catch",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void LoadRegistersFromFile()
        {
            string test = null;
            FilesManager.LoadFile(out test);

            if (test != string.Empty)
            {
                SaveDefaults loadedData = new SaveDefaults();
                bool success = FilesManager.LoadDefRegsData(out loadedData, test);

                if (success)
                {
                    string text = "Currently registers succesfuly loaded from file: '" + test + "'";
                    ConsoleController.Console().Write(text);
                    serialPort.SetDisableSending(true, 48);
                    LoadDefRegsFromFile(loadedData);
                    SendData();
                    serialPort.SetDisableSending(false, 48);
                }
                else
                {
                    string text = "When loading registers occurs error!";
                    ConsoleController.Console().Write(text);
                    MessageBox.Show(text, "Error Catch", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public string GetDefaultRegistersFileName()
        {
            string freqOut1;
            string freqOut2;
            string refState;
            string out1State;
            string out2State;

            bool internalRef = moduleControls.GetIntRefState();
            if (internalRef == true)
                refState = "IntRef";
            else
                refState = "ExtRef";
            
            bool out1StateBool = moduleControls.GetOut1State();
            if (out1StateBool == true)
            {
                out1State = "Out1Act";
                freqOut1 = "fOUT1_" + directFreqControl.string_GetFreqAtOut1() + "MHz_";
            }
            else
            {
                out1State = "Out1Dis";
                freqOut1 =  string.Empty;
            }
            
            bool out2StateBool = moduleControls.GetOut2State();
            if (out2StateBool == true)
            {
                out2State = "Out2Act";
                freqOut2 = "fOUT2_" + directFreqControl.string_GetFreqAtOut2()+ "MHz_";
            }
            else
            {
                out2State = "Out2Dis";
                freqOut2 = string.Empty;
            }

            string defaultFileName = freqOut1.Replace(" ", string.Empty) + 
                                        freqOut2.Replace(" ", string.Empty) + 
                                        refState + "_" + out1State + "_" + out2State;
                                    
            return defaultFileName;
        }

    #endregion 

    #region Memory Data part
    public void SaveRegMemoriesIntoFile()
    {
        string test = null;
        FilesManager.SaveFile(out test, GetDefaultMemoryFileName());

        if (test != string.Empty)
        {
            bool success = FilesManager.SaveMemRegsData(CreateMemoryData(), test);

            if(success)
            {
                string text = "Currently memory set succesfuly saved into file: '" + test + "'";
                ConsoleController.Console().Write(text);
            }
            else
            {
                string text = "When saving memory set occurs error!";
                ConsoleController.Console().Write(text);
                MessageBox.Show(text, "Error Catch",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public void LoadRegMemoriesFromFile()
    {
        string test = null;

        FilesManager.LoadFile(out test);

        if (test != string.Empty)
        {
            SaveMemories loadedData = new SaveMemories();
            bool success = FilesManager.LoadMemRegsData(out loadedData, test);

            if (success)
            {
                string text = "Currently registers succesfuly loaded from file: '" + test + "'";
                ConsoleController.Console().Write(text);
                serialPort.SetDisableSending(true, 48);
                LoadMemoryRegsFromFile(loadedData);
                SendData();
                serialPort.SetDisableSending(false, 48);
            }
            else
            {
                string text = "When loading registers occurs error!";
                ConsoleController.Console().Write(text);
                MessageBox.Show(text, "Error Catch", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    public SaveMemories CreateMemoryData()
    {
        SaveMemories saved = new SaveMemories
            {
                Mem1 = new List<string>{},
                Mem2 = new List<string>{},
                Mem3 = new List<string>{},
                Mem4 = new List<string>{}
            };

            for (int i = 0; i < 7; i++)
            {
                saved.Mem1.Add(memory.GetRegister(1, i).string_GetValue());
                saved.Mem2.Add(memory.GetRegister(2, i).string_GetValue());
                saved.Mem3.Add(memory.GetRegister(3, i).string_GetValue());
                saved.Mem4.Add(memory.GetRegister(4, i).string_GetValue());
            }

            return saved;
    }

    public void LoadMemoryRegsFromFile(SaveMemories data)
    {
        for (int i = 0; i < 7; i++)
        {
            memory.GetRegister(1, i).SetValue(data.Mem1[i]);
            memory.GetRegister(2, i).SetValue(data.Mem2[i]);
            memory.GetRegister(3, i).SetValue(data.Mem3[i]);
            memory.GetRegister(4, i).SetValue(data.Mem4[i]);
        }

        for (UInt16 memoryNumber = 1; memoryNumber <= 4; memoryNumber++)
        {
            SetMemOutsAndRefFromControlReg(memoryNumber);
        }
    }

    public void LoadMemoryRegsFromFile(SaveWindow data)
    {
        for (int i = 0; i < 7; i++)
        {
            memory.GetRegister(1, i).SetValue(data.Mem1[i]);
            memory.GetRegister(2, i).SetValue(data.Mem2[i]);
            memory.GetRegister(3, i).SetValue(data.Mem3[i]);
            memory.GetRegister(4, i).SetValue(data.Mem4[i]);
        }

        for (UInt16 memoryNumber = 1; memoryNumber <= 4; memoryNumber++)
        {
            SetMemOutsAndRefFromControlReg(memoryNumber);
        }
    }

    public string GetDefaultMemoryFileName()
    {
        string defaultFileName;
        
        defaultFileName = "memorySet";

        return defaultFileName;
    }
    
    #endregion

#endregion
    
#region Memory operation
        public void SetMemoryRegisterValue(string sender, string value)
        {
            int memoryNumber;
            int registerNumber;

            sender = string.Join("", sender.ToCharArray().Where(Char.IsDigit));
            registerNumber = int.Parse(Convert.ToString(sender[0]));
            memoryNumber = int.Parse(Convert.ToString(sender[1]));
            
            memory.GetRegister(memoryNumber, registerNumber).SetValue(value);
        }

        public void ImportMemory(string sender)
        {
            sender = string.Join("", sender.ToCharArray().Where(Char.IsDigit));
            int memoryNumber = int.Parse(sender);

            ConsoleController.Console().Write("Memory " + memoryNumber.ToString() +
                                        " imported!");
            
            for (int i = 0; i < 6; i++)
            {
                registers[i].SetValue(memory.GetRegister(memoryNumber, i).string_GetValue());
            }
            
            serialPort.SetDisableSending(true, 50);

            GetAllFromControllReg(memoryNumber);

            SendData();
            serialPort.SetDisableSending(false, 50);
        }
        
        public void ExportMemory(string sender)
        {
            sender = string.Join("", sender.ToCharArray().Where(Char.IsDigit));
            int memoryNumber = int.Parse(sender);

            for (int i = 0; i < 6; i++)
            {
                memory.GetRegister(memoryNumber, i).SetValue(registers[i].string_GetValue());
            }
            memory.GetRegister(memoryNumber, 6).SetValue(moduleControls.GetControlRegister());

            SetMemOutsAndRefFromControlReg((UInt16)memoryNumber);
        }

        public void SetMemOutsAndRefFromControlReg(UInt16 memoryNumber)
        {
            UInt32 out1State = BitOperations.GetNBits(memory.GetRegister(memoryNumber, 6).uint32_GetValue(), 1, 0);
            UInt32 out2State = BitOperations.GetNBits(memory.GetRegister(memoryNumber, 6).uint32_GetValue(), 1, 1);
            UInt32 refState  = BitOperations.GetNBits(memory.GetRegister(memoryNumber, 6).uint32_GetValue(), 1, 2);

            memory.SetMemOut1State(Convert.ToBoolean(out1State), memoryNumber);
            memory.SetMemOut2State(Convert.ToBoolean(out2State), memoryNumber);
            memory.SetMemIntRefState(!Convert.ToBoolean(refState), memoryNumber);
        }

        public void MemActOutSwitch(string sender)
        {
            int memoryNumber;
            int outNumber;

            sender = string.Join("", sender.ToCharArray().Where(Char.IsDigit));
            outNumber = int.Parse(Convert.ToString(sender[1]));
            memoryNumber = int.Parse(Convert.ToString(sender[0]));

            switch (outNumber)
            {
                case 1:
                    SwitchMemActOut1(memoryNumber);
                    break;
                case 2:
                    SwitchMemActOut2(memoryNumber);
                    break;
                default:
                    break;
            }
        }

        public void MemIntRefStateSwitch(string sender)
        {
            int memoryNumber;

            sender = string.Join("", sender.ToCharArray().Where(Char.IsDigit));
            memoryNumber = int.Parse(Convert.ToString(sender[0]));

            SwitchRefIntState(memoryNumber);
        }

        public void SwitchMemActOut1(int memNum)
        {
            bool state = memory.GetMemOut1State(memNum);

            memory.SetMemOut1State(!state, memNum);
            memory.GetRegister(memNum, 6).SetResetOneBit(0, (BitState)Convert.ToUInt16(!state));
        }

        public void SwitchMemActOut2(int memNum)
        {
            bool state = memory.GetMemOut2State(memNum);

            memory.SetMemOut2State(!state, memNum);
            memory.GetRegister(memNum, 6).SetResetOneBit(1, (BitState)Convert.ToUInt16(!state));
        }

        public void SwitchRefIntState(int memNum)
        {
            bool state = memory.GetIntRefState(memNum);

            memory.SetMemIntRefState(!state, memNum);
            memory.GetRegister(memNum, 6).SetResetOneBit(2, (BitState)Convert.ToUInt16(state));
        }

        public void GetAllFromControllReg(int memoryNumber)
        {
            if (serialPort.IsPortOpen())
            {
                UInt32 out1State = BitOperations.GetNBits(memory.GetRegister(memoryNumber, 6).uint32_GetValue(), 1, 0);
                UInt32 out2State = BitOperations.GetNBits(memory.GetRegister(memoryNumber, 6).uint32_GetValue(), 1, 1);
                UInt32 refState  = BitOperations.GetNBits(memory.GetRegister(memoryNumber, 6).uint32_GetValue(), 1, 2);

                if (Convert.ToBoolean(out1State) != moduleControls.GetOut1State())
                    SwitchOut1();
                if (Convert.ToBoolean(out2State) != moduleControls.GetOut2State())
                    SwitchOut2();
                if (!Convert.ToBoolean(refState) != moduleControls.GetIntRefState())
                    SwitchRef();
            }
        }

        private void CleanSavedRegisters()
        {
            string data = String.Format("plo data clean");
            serialPort.SendStringSerialPort(data);
        }

        public void SaveRegsIntoPloMemory()
        {
            CleanSavedRegisters();
            if (serialPort.IsPortOpen())
            {
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
        }

        public void LoadRegsFromPloMemory()
        {
            serialPort.SendStringSerialPort("plo data stored?");
        }

        // TODO move into utillities???
        
#endregion
    
#region Read Register 6 Control
        public void GetCurrentVCO()
        {
            serialPort.SendStringSerialPort("plo read_reg6 vco");
        }

        public void GetADCValue()
        {
            decimal fPfd = refFreq.decimal_GetPfdFreq();
            UInt16 cdiv = (UInt16)(fPfd/0.1M);
            if (cdiv < 1)
                cdiv = 1;
            else if (cdiv > 4095)
                cdiv = 4095;
            
            UInt32 reg3 = registers[3].uint32_GetValue();
            reg3 = BitOperations.ChangeNBits(reg3, cdiv, 12, 3);

            if (readRegister.GetAdcMode() == ReadRegister.AdcMode.TEMPERATURE)
            {
                serialPort.SendStringSerialPort("plo read_reg6 temp " + Convert.ToString(reg3, 16));
            }
            else
            {
                serialPort.SendStringSerialPort("plo read_reg6 tune " + Convert.ToString(reg3, 16));
            }
        }

        public void AdcModeIndexChanged(int value)
        {
            readRegister.SetAdcMode((ReadRegister.AdcMode)value);
        }
#endregion
    }
}
