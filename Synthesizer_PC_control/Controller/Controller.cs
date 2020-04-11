using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Synthesizer_PC_control.Model;
using Synthesizer_PC_control.Utilities;

namespace Synthesizer_PC_control.Controllers
{
    /// <summary>
    /// Controller object for all models
    /// </summary>
    class Controller
    {
        /// <summary>
        /// Serial comunication
        /// </summary>
        public readonly MySerialPort serialPort;

        /// <summary>
        /// Currently syntesizer registery settings (registers 0-5)
        /// </summary>
        public MyRegister[] registers;
        
        /// <summary>
        /// Here program store what registry values were sent
        /// </summary>
        public MyRegister[] old_registers;

        /// <summary>
        /// Synthesizer module memory
        /// </summary>
        public Memory memory;

        /// <summary>
        /// Module controls (Out1, Out2, Int/Ext signal reference)
        /// </summary>
        public ModuleControls moduleControls;

        /// <summary>
        /// PLO reference frequency contorols
        /// </summary>
        public RefFreq refFreq;

        /// <summary>
        /// PLO output frequency controls
        /// </summary>
        public OutFreqControl outFreqControl;

        /// <summary>
        /// Direct frequency input control
        /// </summary>
        public DirectFreqControl directFreqControl;

        /// <summary>
        /// PLO frequency info
        /// </summary>
        public SynthFreqInfo synthFreqInfo;

        /// <summary>
        /// controls for PLO outputs (OutA, OutB)
        /// </summary>
        public SynthOutputControls synthOutputControls;

        /// <summary>
        /// PLO charge pump controls
        /// </summary>
        public ChargePump chargePump;

        /// <summary>
        /// PLO phase detector controls
        /// </summary>
        public PhaseDetector phaseDetector;

        /// <summary>
        /// Generic PLO controls
        /// </summary>
        public GenericControls genericControls;

        /// <summary>
        /// PLO shutdowns control
        /// </summary>
        public Shutdowns shutdowns;

        /// <summary>
        /// PLO VCO controls
        /// </summary>
        public VcoControls vcoControls;

        /// <summary>
        /// PLO register for read (Register 6)
        /// </summary>
        public ReadRegister readRegister;

        /// <summary>
        /// Controller constructor
        /// </summary>
        /// <param name="view"> view handle </param>
        public Controller(Form1 view)
        {
            // create model of serial port 
            serialPort = new MySerialPort(view, view.PortButton, 
                                          view.AvaibleCOMsComBox);
            serialPort.GetAvaliablePorts();

            // create model of currently syntesizer registery settings
            var reg0 = new MyRegister(String.Empty, view.Reg0TextBox);
            var reg1 = new MyRegister(String.Empty, view.Reg1TextBox);
            var reg2 = new MyRegister(String.Empty, view.Reg2TextBox);
            var reg3 = new MyRegister(String.Empty, view.Reg3TextBox);
            var reg4 = new MyRegister(String.Empty, view.Reg4TextBox);
            var reg5 = new MyRegister(String.Empty, view.Reg5TextBox);

            registers = new MyRegister[] { reg0, reg1, reg2, reg3, reg4, reg5};

            // here program store what registry values were sent
            var old_reg0 = new MyRegister(String.Empty);
            var old_reg1 = new MyRegister(String.Empty);
            var old_reg2 = new MyRegister(String.Empty);
            var old_reg3 = new MyRegister(String.Empty);
            var old_reg4 = new MyRegister(String.Empty);
            var old_reg5 = new MyRegister(String.Empty);

            old_registers = new MyRegister[] {old_reg0, old_reg1, old_reg2, 
                                              old_reg3, old_reg4, old_reg5};

            // create model of synthesizer module memory
            memory = new Memory(view);

            // create model of module controls
            moduleControls = new ModuleControls(view.Out1Button,
                                                view.Out2Button,
                                                view.RefButton);

            // create model of referece frequency 
            refFreq = new RefFreq(view.RefFTextBox,
                                  view.RefDoublerCheckBox, 
                                  view.DivideBy2CheckBox, 
                                  view.RDivUpDown, 
                                  view.pfdFreqLabel,
                                  view.LDSpeedAdjComboBox,
                                  view.AutoLDSpeedAdjCheckBox,
                                  view.LDSpeedAdjLabel,
                                  view.InternalLabel);

            // create model of output frequency control 
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

            // create model of direct frequency input control
            directFreqControl = new DirectFreqControl(view.InputFreqTextBox, 
                                                      view.DeltaShowLabel,
                                                      view.CalcFreqShowLabel,
                                                      view.FreqAtOut1ShowLabel,
                                                      view.FreqAtOut2ShowLabel,
                                                      view.ActOut1ShowLabel,
                                                      view.ActOut2ShowLabel,
                                                      view.IntExtShowLabel);

            // create model of synthesizer frequency info
            synthFreqInfo = new SynthFreqInfo(view.fVcoScreenLabel,
                                              view.fOutAScreenLabel,
                                              view.fOutBScreenLabel);

            // create model of synthesizer output controls
            synthOutputControls = new SynthOutputControls(view.OutAEn_ComboBox,
                                                          view.OutBEn_ComboBox,
                                                          view.OutAPwr_ComboBox,
                                                          view.OutBPwr_ComboBox);

            // create model of charge pump controls
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

            // create model of phase detector controls
            phaseDetector = new PhaseDetector(view.SigmaDeltaNoiseModeComboBox,
                                              view.LDPrecisionComboBox,
                                              view.PfdPolarity);

            // create model of generic controls
            genericControls = new GenericControls(view.MuxPinModeCombobox,
                                                  view.Reg4DoubleBufferedCheckBox,
                                                  view.IntNAutoModeWhenF0CheckBox,
                                                  view.RandNCountersResetCheckBox);

            // create model of shutdown controls
            shutdowns = new Shutdowns(view.PloPowerDownCheckBox,
                                      view.RefInputShutdownCheckBox,
                                      view.PllShutDownCheckBox,
                                      view.VcoDividerShutdownCheckBox,
                                      view.VcoLdoShutDownCheckBox, 
                                      view.VcoShutDownCheckBox);

            // create model of VCO controls
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

            // create model of PLO read register 6 
            readRegister = new ReadRegister(view.ReadedVCOValueTextBox,
                                            view.ReadedADCValueTextBox,
                                            view.ADCModeComboBox);

            // intialize console with RichTextBox 
            ConsoleController.InitConsole(view.ConsoleRichTextBox);
        }

#region Action functions for each control

    #region Serial Port Section
        /// <summary>
        /// The function applies a port change for the serial interface.
        /// </summary>
        /// <param name="value"> port name as string </param>
        public void SelectedSerialPortChanged(string value)
        {
            serialPort.SetSelectedPort(value);
        }
    #endregion

    #region Synthesizer Module Controls Section
        /// <summary>
        /// The function switches output 1 status.
        /// It also sets the corresponding state on the PLO OutA output.
        /// </summary>
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

        /// <summary>
        /// The function switches output 2 status.
        /// It also sets the corresponding state on the PLO OutB output.
        /// </summary>
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

        /// <summary>
        /// The function switches signal reference status.
        /// If internal reference is to be set, the value of the reference 
        /// frequency changes exactly 10 MHz and makes it impossible to adjust 
        /// the value.
        /// </summary>
        public void SwitchRef()
        {
            if (moduleControls.GetIntRefState())
            {
                serialPort.SendStringSerialPort("ref ext");
                refFreq.SetIntRefInpEnabled(true);
                moduleControls.SetIntRef(false);
                directFreqControl.SetIntRefState(false);
            }
            else
            {
                serialPort.SendStringSerialPort("ref int");
                refFreq.SetRefFreqValue(10);    // sets fix 10 MHz frequency
                vcoControls.CalcBandSelClockDivValue(10);   // recalc band select clock divider
                refFreq.SetIntRefInpEnabled(false); // disable UI element
                moduleControls.SetIntRef(true);
                directFreqControl.SetIntRefState(true);
            }
            RecalcWorkingFreqInfo();
        }
        
        /// <summary>
        /// Send initialize command into synthesizer module
        /// </summary>
        public void PloModuleInit()
        {
            serialPort.SendStringSerialPort("PLO init");
        }
#endregion
    
    #region Reference Frequency Controls Group

        /// <summary>
        /// Sets new reference frequency and perform changes
        /// </summary>
        /// <param name="value"> new reference frequency value </param>
        public void ReferenceFrequencyValueChanged(string value)
        {
            if (refFreq.SetRefFreqValue(value) == true)
            {
                // value was changed, so recalc working frequency info
                RecalcWorkingFreqInfo();
                // SetRefFreqValue automaticaly recalc frequency at PFD input, 
                // so we want get it and recalc new Band select clock divider value
                // and recalculate C-divider value
                CalcsValsRelatedToPfdFreq(true);    // recalc related values
            }
        }

        /// <summary>
        /// Sets reference doubler state. Then recalculate the register values 
        /// so that the output frequency does not change. Get new PFD frequency
        /// and recalculate band select clock divider and C-divider values.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> 
        ///     State of reference doubler. 
        ///     true - enabled,
        ///     false - disabled
        /// </param>
        public void ReferenceDoublerStateChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 5);      // disable sending

                // sets new state into register 2 bit 25
                registers[2].SetResetOneBit(25, (BitState)Convert.ToUInt16(value));
                refFreq.SetRefDoubler(value);   // sets into model

                // recalc new IntN, FracN and mod values for fix frequency
                outFreqControl.RecalcRegsForNewPfdFreq(value);

                CalcsValsRelatedToPfdFreq(true);    // recalc related values

                serialPort.SetDisableSending(false, 5);         // try enable sending
                if (serialPort.GetDisableSending() == false)    // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// sets new reference divider by two. Then recalculate the register values 
        /// so that the output frequency does not change. Get new PFD frequency
        /// and recalculate band select clock divider and C-divider values.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     State of reference divider by two. 
        ///     true - enabled,
        ///     false - disabled
        /// </param>
        public void ReferenceDivBy2StateChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 12);         // disable sending

                // sets new state into register 2 bit 24
                registers[2].SetResetOneBit(24, (BitState)Convert.ToUInt16(value));
                refFreq.SetRefDivBy2(value);    // sets into model

                // recalc new IntN, FracN and mod values for fix frequency
                outFreqControl.RecalcRegsForNewPfdFreq(!value);

                CalcsValsRelatedToPfdFreq(true);    // recalc related values

                serialPort.SetDisableSending(false, 12);         // try enable sending
                if (serialPort.GetDisableSending() == false)     // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets new reference R-divider value. Then it gets new PFD frequency 
        /// and recalc band select clock divider and C-divider value
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"></param>
        public void ReferenceRDividerValueChanged(UInt16 value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 14);         // disable sending

                // sets new state into register 2 bits 14-23
                registers[2].ChangeNBits((UInt32)value, 10, 14);
                refFreq.SetRDivider(value);         // sets into model

                CalcsValsRelatedToPfdFreq(true);    // recalc related values

                serialPort.SetDisableSending(false, 14);         // try enable sending
                if (serialPort.GetDisableSending() == false)     // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets Lock-Detect speed adjustment index.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     Lock-Detect speed adjustment 
        ///     0 - PFD freq > 32, 
        ///     1 - PFD freq <= 32
        /// </param>
        public void LDSpeedAdjIndexChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 15);          // disable sending
                
                // sets new state into register 2 bit 31
                registers[2].SetResetOneBit(31, (BitState)value);
                refFreq.SetLDSpeedAdjIndex(value);  // sets into model

                serialPort.SetDisableSending(false, 15);         // try enable sending
                if (serialPort.GetDisableSending() == false)     // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Enable or disable automatic LD speed setting
        /// </summary>
        /// <param name="value"></param>
        public void AutoLDSpeedAdjChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                refFreq.SetAutoLDSpeedAdj(value);
            }
        }
    #endregion

    #region Output Frequency Controls Group

        /// <summary>
        /// Sets new Integer-N value. If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> new IntN value </param>
        public void IntNValueChanged(UInt16 value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 6);          // disable sending

                // sets new value into register 0 bits 15-30
                registers[0].ChangeNBits((UInt32)value, 16, 15);
                outFreqControl.SetIntNVal(value);   // sets into model

                serialPort.SetDisableSending(false, 6);          // try enable sending
                if (serialPort.GetDisableSending() == false)     // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets new Fractional-N value. If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> new Frac-N value </param>
        public void FracNValueChanged(UInt16 value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 7);          // disable sending

                // sets new value into register 0 bits 3-14
                registers[0].ChangeNBits((UInt32)value, 12, 3);
                outFreqControl.SetFracNVal(value);   // sets into model

                serialPort.SetDisableSending(false, 7);          // try enable sending
                if (serialPort.GetDisableSending() == false)     // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets new modulus value and recalc C-Divider value.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> new modulus value </param>
        public void ModValueChanged(UInt16 value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 8);          // disable sending

                // sets new value into register 1 bits 3-14
                registers[1].ChangeNBits((UInt32)value, 12, 3);
                outFreqControl.SetModVal(value);   // sets into model
                
                CalcCDivValue();    // recalculate C-divider value

                serialPort.SetDisableSending(false, 8);          // try enable sending
                if (serialPort.GetDisableSending() == false)     // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets new synthesizer mode. Then check if the correct LD function 
        /// corresponding to the set synthesizer mode is set, sets this mode 
        /// into ref freq. model, recalculate PFD related values and sets
        /// the appropriate linearity index of the charging pump to the synthesizer mode.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> new synthesizer mode indexs </param>
        public void SynthModeChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 1);          // disable sending

                // sets new mode into register 0 bit 31
                registers[0].SetResetOneBit(31, (BitState)value);
                outFreqControl.SetSynthMode((SynthMode)value);   // sets into model

                // checks if the correct LD function corresponding to the set 
                // synthesizer mode is set
                outFreqControl.CheckIfLDfuncToAppropriateModeIsSellected(false);

                // sets mode into reference frequency model
                refFreq.SetSynthModeInfoVariable((SynthMode)value);

                CalcsValsRelatedToPfdFreq(false);    // recalc related values

                // sets the appropriate linearity index of the charging pump 
                // to the synthesizer mode
                if ((SynthMode)value == SynthMode.INTEGER)
                    chargePump.SetLinearityIndex(0, (SynthMode)value);
                else
                    chargePump.SetLinearityIndex(1, (SynthMode)value);

                serialPort.SetDisableSending(false, 1);          // try enable sending
                if (serialPort.GetDisableSending() == false)     // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets new A-divider value.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> new A-divider value </param>
        public void ADivValueChanged(UInt16 value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 9);          // disable sending

                // sets new value into register 4 bits 20-22
                registers[4].ChangeNBits((UInt32)value, 3, 20);
                outFreqControl.SetADivVal(value);   // sets into model

                serialPort.SetDisableSending(false, 9);          // try enable sending
                if (serialPort.GetDisableSending() == false)     // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets new phase-P value.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> new phase-P value </param>
        public void PhasePValueChanged(UInt16 value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 10);          // disable sending

                // sets new value into register 1 bits 15-26
                registers[1].ChangeNBits((UInt32)value, 12, 15);
                outFreqControl.SetPPhaseVal(value);   // sets into model

                serialPort.SetDisableSending(false, 10);          // try enable sending
                if (serialPort.GetDisableSending() == false)     // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets new lock-detect function value.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> new lock-detect function value </param>
        public void LDFunctionIndexChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 2);           // disable sending

                // sets new LD function into register 2 bit 8
                registers[2].SetResetOneBit(8, (BitState)value);
                outFreqControl.SetLDFunctionIndex(value);   // sets into model

                // checks if the correct LD value corresponding to the set 
                // synthesizer mode is set
                outFreqControl.CheckIfLDfuncToAppropriateModeIsSellected(false);

                serialPort.SetDisableSending(false, 2);          // try enable sending
                if (serialPort.GetDisableSending() == false)     // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Enable or disable automatic lock-detect setting.
        /// </summary>
        /// <param name="value">
        ///     true = do automatic setting LD func
        ///     false = does not automatic setting LD func
        /// </param>
        public void AutoLDFuncCheckedChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                outFreqControl.SetAutoLDFunction(value);
                outFreqControl.CheckIfLDfuncToAppropriateModeIsSellected(true);
            }
        }

        /// <summary>
        /// Sets new output B internal path value.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> new output B internal path value </param>
        public void OutBPathIndexChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 11);          // disable sending

                // sets new value into register 4 bit 9
                registers[4].SetResetOneBit(9, (BitState)value);
                outFreqControl.SetOutBPath(value);      // sets into model

                serialPort.SetDisableSending(false, 11);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets new VCO to N-counter feedback path.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> new VCO to N-counter feedback path </param>
        public void FBPathIndexChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 30);          // disable sending

                // sets new value into register 4 bit 23
                registers[4].SetResetOneBit(23, (BitState)value);
                outFreqControl.SetFBPath(value);   // sets into model

                serialPort.SetDisableSending(false, 30);          // try enable sending
                if (serialPort.GetDisableSending() == false)     // if success send new data
                    SendData();
            }
        }
    #endregion

    #region Synthesizer Output Controls Group

        /// <summary>
        /// Enable or disable output A.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> 
        ///     0 - disabled
        ///     1 - enabled
        /// </param>
        public void OutAEnStateChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 16);          // disable sending

                // sets new state into register 4 bit 5
                registers[4].SetResetOneBit(5, (BitState)value);
                synthOutputControls.SetOutAEnable((OutEnState)value);   // sets into model

                serialPort.SetDisableSending(false, 16);          // try enable sending
                if (serialPort.GetDisableSending() == false)     // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Enable or disable output B.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> 
        ///     0 - disabled
        ///     1 - enabled
        /// </param>
        public void OutBEnStateChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 17);          // disable sending

                // sets new state into register 4 bit 8
                registers[4].SetResetOneBit(8, (BitState)value);
                synthOutputControls.SetOutBEnable((OutEnState)value);   // sets into model

                serialPort.SetDisableSending(false, 17);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets new output A power by index.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> 
        ///     0 = -4 dBm,
        ///     1 = -1 dBm,
        ///     2 = +2 dBm,
        ///     3 = +5 dBm
        /// </param>
        public void OutAPwrValueChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 18);          // disable sending

                // sets new value into register 4 bits 3, 4
                registers[4].ChangeNBits((UInt32)value, 2, 3);
                synthOutputControls.SetOutAPwr(value);   // sets into model

                serialPort.SetDisableSending(false, 18);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets new output B power by index. Index 3 for +5 dBm is disabled due to
        /// frequency doubler at output (has +3 dBm maximul level at input)
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> 
        ///     0 = -4 dBm,
        ///     1 = -1 dBm,
        ///     2 = +2 dBm,
        ///     3 = +5 dBm
        /// </param>
        public void OutBPwrValueChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 19);          // disable sending

                // sets into model and if operation is success
                // sets new state into register 4 bits 6, 7, 
                if (synthOutputControls.SetOutBPwr(value))
                    registers[4].ChangeNBits((UInt32)synthOutputControls.GetOutBPwrIndex(), 2, 6);
   
                serialPort.SetDisableSending(false, 19);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }
    #endregion

    #region Charge Pump Group
        /// <summary>
        /// Sets new R-set resistor value into CP model. This model calculate 
        /// new CP current and fill this values into combobox.
        /// </summary>
        /// <param name="value"> new R-set resistor value </param>
        public void GetCPCurrentFromTextBox(string value)
        {
            chargePump.SetRSetValue(value);
        }
        
        /// <summary>
        /// Sets new charge pump current by index.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> charge pump current index </param>
        public void CPCurrentIndexChanged(int value)
        {
            if (serialPort.IsPortOpen() && chargePump.isCurrentComboboxFilled())
            {
                serialPort.SetDisableSending(true, 20);          // disable sending

                // sets new value into register 2 bits 9-12
                registers[2].ChangeNBits((UInt32)value, 4, 9);
                chargePump.SetCurrentIndex(value);   // sets into model

                serialPort.SetDisableSending(false, 20);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets new linearity index with respect currently set synth. mode.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> new linearity index </param>
        public void CPLinearityIndexChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 3);          // disable sending

                // gets synth. mode
                SynthMode synthMode = outFreqControl.GetSynthMode();
                // sets into model with respect synth. mode
                chargePump.SetLinearityIndex(value, synthMode);   

                // returns back a potentially corrected value
                value = chargePump.GetLinearityIndex();

                // sets new value into register 1 bits 29,30
                registers[1].ChangeNBits((UInt32)value, 2, 29);

                serialPort.SetDisableSending(false, 3);           // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets new charge pump mode by index.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> 
        ///     charge pump test mode index 
        ///     0 - normal mode,
        ///     1 - Long Reset mode,
        ///     2 - Force CP into source mode,
        ///     3 - Force CP into sink mode.
        /// </param>
        public void CPTestModeIndexChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 21);          // disable sending

                // sets new value into register 1 bits 27-28
                registers[1].ChangeNBits((UInt32)value, 2, 27);
                chargePump.SetTestModeIndex(value);   // sets into model

                serialPort.SetDisableSending(false, 21);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets new charge pump fast-lock mode state.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     Fast-lock state:
        ///     true - fast lock mode, 
        ///     false - mute until lock detect state 
        /// </param>
        public void CPFastLockCheckedChanged(bool value)
        {
            if (serialPort.IsPortOpen() && !chargePump.GetDisableHandler())
            {
                serialPort.SetDisableSending(true, 22);          // disable sending

                // sets new value into register 3 bits 15-16
                if (value)
                    registers[3].ChangeNBits(Convert.ToUInt32(ClockDividerMode.FastLockEnable), 2, 15);
                else
                    registers[3].ChangeNBits(Convert.ToUInt32(ClockDividerMode.MuteUntilLockDelay), 2, 15);
                
                chargePump.SetFastLockMode(value);   // sets into model

                serialPort.SetDisableSending(false, 22);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets phase adjustment mode state.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     Phase mode state:
        ///     true - phase adjusment mode,
        ///     false - mute until lock detect state 
        /// </param>
        public void PhaseAdjustmentCheckedChanged(bool value)
        {
            if (serialPort.IsPortOpen() && !chargePump.GetDisableHandler())
            {
                serialPort.SetDisableSending(true, 23);     // disable sending

                // sets new value into register 3 bits 15-16
                if (value)
                    registers[3].ChangeNBits(Convert.ToUInt32(ClockDividerMode.PhaseAdjustment), 2, 15);
                else
                    registers[3].ChangeNBits(Convert.ToUInt32(ClockDividerMode.MuteUntilLockDelay), 2, 15);
                
                chargePump.SetPhaseAdjustmentMode(value);   // sets into model

                serialPort.SetDisableSending(false, 23);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets charge pump cycle slip mode state.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> 
        ///     true - enabled, 
        ///     false - disabled 
        /// </param>
        public void CPCycleSlipCheckedChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 24);     // disable sending

                // sets new value into register 3 bit 18
                registers[3].SetResetOneBit(18, (BitState)Convert.ToUInt16(value));
                chargePump.SetCycleSlipMode(value);   // sets into model

                serialPort.SetDisableSending(false, 24);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets charge pump tri-state mode.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     true - enabled, 
        ///     false - disabled 
        /// </param>
        public void CPTristateCheckedChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 25);     // disable sending

                // sets new value into register 2 bit 4
                registers[2].SetResetOneBit(4, (BitState)Convert.ToUInt16(value));
                chargePump.SetTriStateMode(value);   // sets into model

                serialPort.SetDisableSending(false, 25);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        #endregion

    #region Phase Detector Group

        /// <summary>
        /// Sets noise mode value. If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     0 - Low-Noise mode, 
        ///     1 - Low-spur mode 1, 
        ///     2 - Low-spur mode 2 
        /// </param>
        public void SDNoiseModeIndexChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 26);     // disable sending

                phaseDetector.SetNoiseMode(value);  // sets into model
                // adjusts the value
                if (value == 1 || value == 2)
                    value++;
                // sets new value into register 2 bits 29, 30
                registers[2].ChangeNBits((UInt32)value, 2, 29);

                serialPort.SetDisableSending(false, 26);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets lock-detect precision by index.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     0 - 10ns, 
        ///     1 - 6ns
        /// </param>
        public void LDPrecisionIndexChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 27);     // disable sending

                // sets new value into register 2 bit 7
                registers[2].SetResetOneBit(7, (BitState)value);
                phaseDetector.SetPrecisionIndex(value);   // sets into model

                serialPort.SetDisableSending(false, 27);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets PFD polarity. If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     0 - negative, 
        ///     1 - positive (default) 
        /// </param>
        public void PositivePdfCheckedChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 28);     // disable sending

                // sets new value into register 2 bit 6
                registers[2].SetResetOneBit(6, (BitState)value);
                phaseDetector.SetPfdPolarity(value);   // sets into model

                serialPort.SetDisableSending(false, 28);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }
    #endregion

    #region VCO Settings Group

        /// <summary>
        /// Enable/disable automatic VCO selection.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     false = disabled automatic VCO selection,
        ///     true = enabled automatic VCO selection
        /// </param>
        public void AutoVcoSelectionStateChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 40);     // disable sending

                // sets new state into register 3 bit 25
                registers[3].SetResetOneBit(25, (BitState)Convert.ToUInt16(!value));
                vcoControls.SetAutoVcoSelectionState(value);   // sets into model

                serialPort.SetDisableSending(false, 40);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets VAS response to temperature drift.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     false = VAS temperature compensation disabled,
        ///     true =  VAS temperature compensation enabled
        /// </param>
        public void VASTempComStateChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 41);     // disable sending

                // sets new state into register 3 bit 24
                registers[3].SetResetOneBit(24, (BitState)Convert.ToUInt16(value));
                if (value == true)
                    registers[5].ChangeNBits(0b11, 2, 29);
                else
                    registers[5].ChangeNBits(0b00, 2, 29);

                vcoControls.SetVASTempComState(value);   // sets into model

                serialPort.SetDisableSending(false, 41);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Manual selection of VCO and VCO sub-band when VAS is disabled.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> value 0 - 63 (64 VCos) </param>
        public void ManualVCOSelectValueChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 42);     // disable sending

                // sets new value into register 3 bits 26-31
                registers[3].ChangeNBits((UInt32)value, 6, 26);
                vcoControls.SetManualVCOSelectValue((UInt16)value);   // sets into model

                serialPort.SetDisableSending(false, 42);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets new band select clock divider value.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> BS clock divider value (1-1023) </param>
        public void BandSelClockDivValueChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 43);     // disable sending

                // sets into model
                vcoControls.SetBandSelClockDivValue((UInt16)value);
                // returns back corrected value
                value = vcoControls.GetBandSelClockDivValue();

                // splits the value into most significant bits and least significant bits
                UInt16 lsbs = (UInt16)(value & 0xFF);
                UInt16 msbs = (UInt16)((UInt16)value & 0x300);
                msbs = (UInt16)(msbs >> 8);

                // sets new value into register 4 bits 12-19 (lsbs) and 24, 25 (msbs) 
                registers[4].ChangeNBits((UInt32)lsbs, 8, 12);
                registers[4].ChangeNBits((UInt32)msbs, 2, 24);
                serialPort.SetDisableSending(false, 43);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets RFOUT Mute until Lock Detect Mode.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     false = Disables RFOUT Mute until Lock Detect Mode,
        ///     true = Enables RFOUT Mute until Lock Detect Mode
        /// </param>
        public void MuteUntilLockDetectStateChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 44);     // disable sending

                // sets new value into register 4 bit 10
                registers[4].SetResetOneBit(10, (BitState)Convert.ToUInt16(value));
                vcoControls.SetMuteUntilLockDetectMode(value);   // sets into model

                serialPort.SetDisableSending(false, 44);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets mute delay. If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     false = Do not delay LD to MTLD function to prevent flickering,
        ///     true = Delay LD to MTLD function to prevent flickering
        /// </param>
        public void DelayToPreventFlickeringStateChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 45);     // disable sending

                // sets new value into register 3 bit 17
                registers[3].SetResetOneBit(17, (BitState)Convert.ToUInt16(value));
                vcoControls.SetDelayToPreventFlickeringState(value);   // sets into model

                serialPort.SetDisableSending(false, 45);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets 12-bit clock divider value. If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value"> CDIV value (1 - 4095) </param>
        public void ClockDividerValueChanged(int value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 46);     // disable sending

                vcoControls.SetClockDividerValue((UInt16)value);   // sets into model

                UInt16 modValue = outFreqControl.uint16_GetModVal();    // gets modus value
                decimal fPfd = refFreq.decimal_GetPfdFreq();    // gets PFD frequency
                vcoControls.SetDelayLabel(modValue, fPfd);      // calculcate and set delay label

                // sets new value into register 3 bits 3-14
                registers[3].ChangeNBits((UInt32)value, 12, 3);

                serialPort.SetDisableSending(false, 46);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Sets automatic C-divider calculations.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     false = automatic CDIV calculation Disabled,
        ///     true = automatic CDIV calculation Enabled
        /// </param>
        public void AutoCDIVCalcStateChanged(bool value)
        {
            if (serialPort.IsPortOpen())
            {
                serialPort.SetDisableSending(true, 47);     // disable sending

                vcoControls.SetAutoCdivCalc(value);     // sets into model

                CalcCDivValue();    // recalculate C-divider value

                serialPort.SetDisableSending(false, 47);          // try enable sending
                if (serialPort.GetDisableSending() == false)      // if success send new data
                    SendData();
            }
        }

        /// <summary>
        /// Recalculate delay
        /// </summary>
        /// <param name="value"> ms integer value </param>
        public void DelayInputValueChanged(UInt16 value)
        {
            vcoControls.SetDelayInputValue(value); // sets into model

            CalcCDivValue();    // recalculate C-divider value
        }

        /// <summary>
        /// This function get PFD frequency from model and recalculate calc
        /// band select clock divider value and if neccessary recalculate
        /// C-divider value
        /// </summary>
        /// <param name="calcCDivVal">
        ///     true = recalculate C-divider value
        ///     false = does not recalculate C-divider value
        /// </param>
        public void CalcsValsRelatedToPfdFreq(bool calcCDivVal)
        {
            // gets new PFD freq
            decimal pfdFreq = refFreq.decimal_GetPfdFreq(); 
             
            // recalc band select clock divider
            vcoControls.CalcBandSelClockDivValue(pfdFreq);

            if (calcCDivVal)
                CalcCDivValue();    // if neccessary recalc C-div value
        }

        /// <summary>
        /// Calculate C-divider value
        /// </summary>
        public void CalcCDivValue()
        {
            decimal fPfd = refFreq.decimal_GetPfdFreq();    // gets PFD frequency
            UInt16 mod = outFreqControl.uint16_GetModVal(); // gets modus value
            
            if (vcoControls.GetAutoCDiv())
            {
                // if automatic C-div value calculations enabled, then recalculate it
                UInt16 delayMsValue = vcoControls.GetDelayInputValue();
                vcoControls.CalcCDIVValue(delayMsValue, fPfd, mod);
            }
            
            // recalculate delay
            vcoControls.SetDelayLabel(mod, fPfd);
        }

    #endregion

    #region Generic Controls Group

        /// <summary>
        /// Sets new mux pin mode by index value.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     0 - Three-state output
        ///     1 - D_VDD
        ///     2 - D_GND
        ///     3 - R-divider output
        ///     4 - N-divider output/2
        ///     5 - Analog lock detect
        ///     6 - Digital lock detect
        ///     7 - Sync Input
        ///     8-11 - Reserved
        ///     12 - Read SPI registers 06
        ///     13-15 - Reserved
        /// </param>
        public void MuxPinModeIndexChanged(int value)
        {
            serialPort.SetDisableSending(true, 29);     // disable sending

            // sets new mode into register 2 bits 26-28
            registers[2].ChangeNBits((UInt32)value, 3, 26);
            genericControls.SetMuxPinMode(value);   // sets into model

            serialPort.SetDisableSending(false, 29);          // try enable sending
            if (serialPort.GetDisableSending() == false)      // if success send new data
                SendData();
        }

        /// <summary>
        /// Sets register 4 double buffered mode (by register 0)
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     false - disabled
        ///     true - enabled
        /// </param>
        public void Reg4DoubleBufferedStateChanged(bool value)
        {
            serialPort.SetDisableSending(true, 37);     // disable sending

            // sets new mode into register 2 bit 13
            registers[2].SetResetOneBit(13, (BitState)Convert.ToUInt16(value));
            genericControls.SetReg4DoubleBuffered(value);   // sets into model

            serialPort.SetDisableSending(false, 37);          // try enable sending
            if (serialPort.GetDisableSending() == false)      // if success send new data
                SendData();
        }

        /// <summary>
        /// Sets integer mode for F = 0
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     true = If F[11:0] = 0, then fractional-N mode is set
        ///     false = If F[11:0] = 0, then integer-N mode is auto set
        ///     </param>
        public void IntNAutoModeWhenF0StateChanged(bool value) // TODO test it on SA
        {
            serialPort.SetDisableSending(true, 38);     // disable sending

            // sets new mode into register 5 bit 24
            registers[5].SetResetOneBit(24, (BitState)Convert.ToUInt16(value));
            genericControls.SetF0AutoIntNMode(value);   // sets into model

            serialPort.SetDisableSending(false, 38);          // try enable sending
            if (serialPort.GetDisableSending() == false)      // if success send new data
                SendData();
        }

        /// <summary>
        /// Sets counter reset mode.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     false = Normal operation
        ///     true =  R and N counters reset
        /// </param>
        public void RandNCountersResetStateChanged(bool value)
        {
            serialPort.SetDisableSending(true, 39);     // disable sending

            // sets new mode into register 2 bit 3
            registers[2].SetResetOneBit(3, (BitState)Convert.ToUInt16(value));
            genericControls.SetRandNCountersReset(value);   // sets into model

            serialPort.SetDisableSending(false, 39);          // try enable sending
            if (serialPort.GetDisableSending() == false)      // if success send new data
                SendData();
        }
    #endregion

    #region Shutdown controls group

        /// <summary>
        /// Sets  new synthesizer shutdown mode
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     false = Normal mode,
        ///     true = Device shutdown
        /// </param>
        public void PloPowerDownStateChanged(bool value)
        {
            serialPort.SetDisableSending(true, 31);     // disable sending
        
            // sets new mode into register 2 bit 5
            registers[2].SetResetOneBit(5, (BitState)Convert.ToUInt16(value));
            shutdowns.SetShutdownAllState(value);   // sets into model

            serialPort.SetDisableSending(false, 31);          // try enable sending
            if (serialPort.GetDisableSending() == false)      // if success send new data
                SendData();
        }

        /// <summary>
        /// Sets Shutdown Reference input mode
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     false = Enables Reference Input,
        ///     true = Disables Reference Input
        /// </param>
        public void  RefInputShutdownStateChanged(bool value)
        {
            serialPort.SetDisableSending(true, 32);     // disable sending

            // sets new mode into register 4 bit 26
            registers[4].SetResetOneBit(26, (BitState)Convert.ToUInt16(value));
            shutdowns.SetReferenceInputShutdownState(value);   // sets into model

            serialPort.SetDisableSending(false, 32);          // try enable sending
            if (serialPort.GetDisableSending() == false)      // if success send new data
                SendData();
        }

        /// <summary>
        /// Sets Shutdown PLL mode.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     false = Enables PLL,
        ///     true = Disables PLL
        /// </param>
        public void PllShutDownStateChanged(bool value)
        {
            serialPort.SetDisableSending(true, 33);     // disable sending

            // sets new mode into register 5 bit 25
            registers[5].SetResetOneBit(25, (BitState)Convert.ToUInt16(value));
            shutdowns.SetPllShutdownState(value);   // sets into model

            serialPort.SetDisableSending(false, 33);          // try enable sending
            if (serialPort.GetDisableSending() == false)      // if success send new data
                SendData();
        }

        /// <summary>
        /// Sets Shutdown VCO Divider mode.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     false = Enables VCO Divider,
        ///     true = Disables VCO Divider
        /// </param>
        public void VcoDividerShutDownStateChanged(bool value)
        {
            serialPort.SetDisableSending(true, 34);     // disable sending

            // sets new mode into register 4 bit 27
            registers[4].SetResetOneBit(27, (BitState)Convert.ToUInt16(value));
            shutdowns.SetVcoDividerShutdownState(value);   // sets into model

            serialPort.SetDisableSending(false, 34);          // try enable sending
            if (serialPort.GetDisableSending() == false)      // if success send new data
                SendData();
        }

        /// <summary>
        /// Sets Shutdown VCO LDO mode.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     false = Enables VCO LDO,
        ///     true = Disables VCO LDO
        /// </param>
        public void VcoLdoShutDownStateChanged(bool value)
        {
            serialPort.SetDisableSending(true, 35);     // disable sending

            // sets new mode into register 4 bit 28
            registers[4].SetResetOneBit(28, (BitState)Convert.ToUInt16(value));
            shutdowns.SetVcoLdoShutdownState(value);   // sets into model

            serialPort.SetDisableSending(false, 35);          // try enable sending
            if (serialPort.GetDisableSending() == false)      // if success send new data
                SendData();
        }

        /// <summary>
        /// Sets VCO Shutdown mode.
        /// If sending is enabled, send new registers into PLO.
        /// </summary>
        /// <param name="value">
        ///     false = Enables VCO,
        ///     true = Disables VCO
        /// </param>
        public void VcoShutDownStateChanged(bool value)
        {
            serialPort.SetDisableSending(true, 36);     // disable sending

            // sets new mode into register 4 bit 11
            registers[4].SetResetOneBit(11, (BitState)Convert.ToUInt16(value));
            shutdowns.SetVcoShutdownState(value);   // sets into model

            serialPort.SetDisableSending(false, 36);          // try enable sending
            if (serialPort.GetDisableSending() == false)      // if success send new data
                SendData();
        }

    #endregion

    #region Functions for TextBox

        /// <summary>
        /// Performs an action based on keyboard input in the TextBox UI element. 
        /// The input has a frequency format, ie 12345.678 901.
        /// </summary>
        /// <param name="sender"> sender as TextBox UI elemnt</param>
        /// <param name="e"> key event arguments </param>
        public void FreqTextBoxBehavior(TextBox sender, KeyEventArgs e)
        {
            int position = sender.SelectionStart;   // gets position of cursor

            if (e.KeyCode == Keys.Back)
            {
                // backspace key pressed
                string text = sender.Text;      // gets text from UI element
                int commaPosition = text.IndexOf(".");  // gets position of comma
                if (position == commaPosition + 5  && commaPosition != -1)
                {
                    // comma is present and cursor position is here: 12345.678 |901
                    // so change position, new cursor position will be 12345.678| 901
                    // this allow delete thousands number, if cursor is behind space separator
                    position = commaPosition + 4;
                }
            }
            else if (e.KeyCode == Keys.Space)
            {
                // spaces not allowed
                e.SuppressKeyPress = true;  // causes the space key to be ignored
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // proccess up/down keys
                position = MyFormat.UpDownKeyIncDecFunc(sender, e.KeyCode);   // performs the action itself

                // procces new inc/dec value by sender name
                if (sender.Name == "InputFreqTextBox")  
                    CalcSynthesizerRegValuesFromInpFreq(sender.Text);
                else if (sender.Name == "RefFTextBox")
                    ReferenceFrequencyValueChanged(sender.Text);

                e.SuppressKeyPress = true;  // confirm that key is proccessed
            }
            else if (e.KeyCode == Keys.Enter)
            {
                // confirmation key pressed, proccess value
                if (sender.Name == "InputFreqTextBox")
                    CalcSynthesizerRegValuesFromInpFreq(sender.Text);
                else if (sender.Name == "RefFTextBox")
                    ReferenceFrequencyValueChanged(sender.Text);
            }
            
            sender.SelectionStart = position; // sets new cursor position
        }

        /// <summary>
        /// Performs an action based on mouse scroll wheelt in the TextBox UI element. 
        /// The input has a frequency format, ie 12345.678 901.
        /// </summary>
        /// <param name="sender"> sender as TextBox UI element </param>
        /// <param name="e"> key event arguments </param>
        public void FreqTextBoxMouseWheelFunc(TextBox sender, MouseEventArgs e)
        {
            // perform action
            int cursorPosition = MyFormat.ScrollByPositionOfCursor(sender, e);

            // apply changes, procces new inc/dec value by sender name
            if (sender.Name == "InputFreqTextBox")
                CalcSynthesizerRegValuesFromInpFreq(sender.Text);
            else if (sender.Name == "RefFTextBox")
                ReferenceFrequencyValueChanged(sender.Text);

            // sets new changed cursor position
            sender.SelectionStart = cursorPosition;
        }

    #endregion

#endregion

#region Functions for obtaining individual values from registers
    #region Parsing register 0

        /// <summary>
        /// Gets and sets mode from register 0
        /// </summary>
        /// <param name="dataReg0"> register 0 </param>
        private void GetFracIntModeStatusFromRegister(UInt32 dataReg0)
        {
            // gets 31. bit from input data register 0
            UInt32 value = BitOperations.GetNBits(dataReg0, 1, 31);

            outFreqControl.SetSynthMode((SynthMode)value);  // sets into model
            outFreqControl.CheckIfLDfuncToAppropriateModeIsSellected(false); // check LD function

            // set mode into reference frequeny class
            refFreq.SetSynthModeInfoVariable((SynthMode)value);

            CalcsValsRelatedToPfdFreq(false);    // recalc related values
        }

        /// <summary>
        /// Gets and sets Integer-N value from register 0
        /// </summary>
        /// <param name="dataReg0"> register 0 </param>
        private void GetIntNValueFromRegister(UInt32 dataReg0)
        {
            // gets bits 15-30 from input data register 0
            UInt16 IntN = (UInt16)BitOperations.GetNBits(dataReg0, 16, 15);
            outFreqControl.SetIntNVal(IntN); // sets into model
        }

        /// <summary>
        /// Gets and sets Fractional-N value from register 0
        /// </summary>
        /// <param name="dataReg0"> register 0 </param>
        private void GetFracNValueFromRegister(UInt32 dataReg0)
        {
            // gets bits 3-14 from input data register 0
            UInt16 FracN = (UInt16)BitOperations.GetNBits(dataReg0, 12, 3);
            outFreqControl.SetFracNVal(FracN); // sets into model
        }
    #endregion

    #region Parsing register 1

        /// <summary>
        /// Gets and sets modus value from register 1
        /// </summary>
        /// <param name="dataReg1"> register 1 </param>
        private void GetModValueFromRegister(UInt32 dataReg1)
        {
            // gets bits 3-14 from input data register 1
            UInt16 mod = (UInt16)BitOperations.GetNBits(dataReg1, 12, 3);
            outFreqControl.SetModVal(mod); // sets into model

            // gets PFD frequency and recalc delay from these values
            decimal fPfd = refFreq.decimal_GetPfdFreq();
            vcoControls.SetDelayLabel(mod, fPfd);
        }

        /// <summary>
        /// Gets and sets phase-P value from register 1
        /// </summary>
        /// <param name="dataReg1"> register 1 </param>
        private void GetPhasePValueFromRegister(UInt32 dataReg1)
        {
            // gets bits 15-26 from input data register 1
            UInt16 phaseP = (UInt16)BitOperations.GetNBits(dataReg1, 12, 15);
            outFreqControl.SetPPhaseVal(phaseP); // sets into model
        }

        /// <summary>
        /// Gets and sets charge pump linearity value from register 1
        /// </summary>
        /// <param name="dataReg1"> register 1 </param>
        private void GetCPLinearityFromRegister(UInt32 dataReg1)
        {
            // gets bits 29, 30 from input data register 1
            int index = (int)BitOperations.GetNBits(dataReg1, 2, 29);
            chargePump.SetLinearityIndex(index); // sets into model
        }

        /// <summary>
        /// Gets and sets charge pump test mode value from register 1
        /// </summary>
        /// <param name="dataReg1"> register 1 </param>
        private void GetCPTestModeFromRegister(UInt32 dataReg1)
        {
            // gets bits 27, 28 from input data register 1
            int index = (int)BitOperations.GetNBits(dataReg1, 2, 27);
            chargePump.SetTestModeIndex(index); // sets into model
        }
    #endregion

    #region Parsing register 2

        /// <summary>
        /// Gets and sets reference signal doubler state from register 2
        /// </summary>
        /// <param name="dataReg2"> register 2 </param>
        private void GetRefDoublerStatusFromRegister(UInt32 dataReg2)
        {
            // gets bit 25 from input data register 2
            bool refDoubler = Convert.ToBoolean(BitOperations.GetNBits(dataReg2, 1, 25));
            refFreq.SetRefDoubler(refDoubler); // sets into model
            CalcsValsRelatedToPfdFreq(false);    // recalc related values
        }
        
        /// <summary>
        /// Gets and sets reference signal divider by 2 state from register 2
        /// </summary>
        /// <param name="dataReg2"> register 2 </param>
        private void GetRefDividerStatusFromRegister(UInt32 dataReg2)
        {
            // gets bit 24 from input data register 2
            bool refDividerBy2 = Convert.ToBoolean(BitOperations.GetNBits(dataReg2, 1, 24));
            refFreq.SetRefDivBy2(refDividerBy2); // sets into model
            CalcsValsRelatedToPfdFreq(false);    // recalc related values
        }

        /// <summary>
        /// Gets and sets reference R-divider value from register 2
        /// </summary>
        /// <param name="dataReg2"> register 2 </param>
        private void GetRDivValueFromRegister(UInt32 dataReg2)
        {
            // gets bits 14-23 from input data register 2
            UInt16 rDiv = (UInt16)BitOperations.GetNBits(dataReg2, 10, 14);
            refFreq.SetRDivider(rDiv); // sets into model
            CalcsValsRelatedToPfdFreq(false);    // recalc related values
        }

        /// <summary>
        /// Gets and sets charge pump current index from register 2
        /// </summary>
        /// <param name="dataReg2"> register 2 </param>
        private void GetCPCurrentIndexFromRegister(UInt32 dataReg2)
        {
            // gets bits 9-12 from input data register 2
            int index = (int)BitOperations.GetNBits(dataReg2, 4, 9);
            chargePump.SetCurrentIndex(index); // sets into model
        }

        /// <summary>
        /// Gets and sets lock-detect speed adjustment index from register 2
        /// </summary>
        /// <param name="dataReg2"> register 2 </param>
        private void GetLDSpeedAdjIndexFromRegister(UInt32 dataReg2)
        {
            // gets bit 31 from input data register 2
            int index = (int)BitOperations.GetNBits(dataReg2, 1, 31);
            refFreq.SetLDSpeedAdjIndex(index); // sets into model
        }

        /// <summary>
        /// Gets and sets lock-detect function index from register 2
        /// </summary>
        /// <param name="dataReg2"> register 2 </param>
        private void GetLDFunctionIndexFromRegister(UInt32 dataReg2)
        {
            // gets bit 8 from input data register 2
            int index = (int)BitOperations.GetNBits(dataReg2, 1, 8);
            outFreqControl.SetLDFunctionIndex(index); // sets into model
            if (serialPort.IsPortOpen())    // if port is open, check if correct LD func is sellected
                outFreqControl.CheckIfLDfuncToAppropriateModeIsSellected(false);
        }

        /// <summary>
        /// Gets and sets charge pump tri-state mode from register 2
        /// </summary>
        /// <param name="dataReg2"> register 2 </param>
        private void GetTriStateModeFromRegister(UInt32 dataReg2)
        {
            // gets bit 4 from input data register 2
            bool enabled = Convert.ToBoolean(BitOperations.GetNBits(dataReg2, 1, 4));
            chargePump.SetTriStateMode(enabled); // sets into model
        }

        /// <summary>
        /// Gets and sets phase detector noise mode from register 2
        /// </summary>
        /// <param name="dataReg2"> register 2 </param>
        private void GetNoiseModeFromRegister(UInt32 dataReg2)
        {
            // gets bits 29, 30 from input data register 2
            int index = (int)BitOperations.GetNBits(dataReg2, 2, 29);

            // fix values 2 and 3 -> 1 and 2, for model compabilitiy
            if (index == 2 || index == 3)
                index--;
            phaseDetector.SetNoiseMode(index); // sets into model
        }

        /// <summary>
        /// Gets and sets phase detector precision value from register 2
        /// </summary>
        /// <param name="dataReg2"> register 2 </param>
        private void GetPrecisionFromRegister(UInt32 dataReg2)
        {
            // gets bit 7 from input data register 2
            int index = (int)BitOperations.GetNBits(dataReg2, 1, 7);
            phaseDetector.SetPrecisionIndex(index); // sets into model
        }

        /// <summary>
        /// Gets and sets phase detector polarity from register 2
        /// </summary>
        /// <param name="dataReg2"> register 2 </param>
        private void GetPfdPositionFromRegister(UInt32 dataReg2)
        {
            // gets bit 6 from input data register 2
            int index = (int)BitOperations.GetNBits(dataReg2, 1, 6);
            phaseDetector.SetPfdPolarity(index); // sets into model
        }

        /// <summary>
        /// Gets and sets mux pin mode from register 2
        /// </summary>
        /// <param name="dataReg2"> register 2 </param>
        private void GetMuxPinModeFromRegister(UInt32 dataReg2)
        {
            // gets bits 26 - 28 from input data register 2
            int index = (int)BitOperations.GetNBits(dataReg2, 3, 26);
            genericControls.SetMuxPinMode(index); // sets into model
        }

        /// <summary>
        /// Gets and sets shutdown entire synthesizer mode from register 2
        /// </summary>
        /// <param name="dataReg2"> register 2 </param>
        private void GetShutDownAllStateFromRegister(UInt32 dataReg2)
        {
            // gets bit 5 from input data register 2
            bool shutdown = Convert.ToBoolean(BitOperations.GetNBits(dataReg2, 1, 5));
            shutdowns.SetShutdownAllState(shutdown); // sets into model
        }

        /// <summary>
        /// Gets and sets automatic register 4 double buffering by reg. 0 from register 2
        /// </summary>
        /// <param name="dataReg2"> register 2 </param>
        private void GetReg4DoubleBufferedStateFromRegister(UInt32 dataReg2)
        {
            // gets bit 13 from input data register 2
            bool state = Convert.ToBoolean(BitOperations.GetNBits(dataReg2, 1, 13));
            genericControls.SetReg4DoubleBuffered(state); // sets into model
        }

        /// <summary>
        /// Gets and sets R and N counter reset mode from register 2
        /// </summary>
        /// <param name="dataReg2"> register 2 </param>
        private void GetRandNCountersResetStateFromRegister(UInt32 dataReg2)
        {
            // gets bit 3 from input data register 2
            bool state = Convert.ToBoolean(BitOperations.GetNBits(dataReg2, 1, 3));
            genericControls.SetRandNCountersReset(state); // sets into model
        }

    #endregion

    #region Parsing register 3

        /// <summary>
        /// Gets and sets clock divider mode from register 3
        /// </summary>
        /// <param name="dataReg3"> register 3 </param>
        private void GetClockDividerModeFromRegister(UInt32 dataReg3)
        {
            // gets bits 15, 16 from input data register 3
            ClockDividerMode cdm = (ClockDividerMode)BitOperations.GetNBits(dataReg3, 2, 15);

            // sets into model
            if (cdm == ClockDividerMode.FastLockEnable)
                chargePump.SetFastLockMode(true);
            else
                chargePump.SetFastLockMode(false);

            if (cdm == ClockDividerMode.PhaseAdjustment)
                chargePump.SetPhaseAdjustmentMode(true);
            else
                chargePump.SetPhaseAdjustmentMode(false);
        }

        /// <summary>
        /// Gets and sets charge pump cycle slip mode from register 3
        /// </summary>
        /// <param name="dataReg3"> register 3 </param>
        private void GetCycleSlipModeFromRegister(UInt32 dataReg3)
        {
            // gets bit 18 from input data register 3
            bool enabled = Convert.ToBoolean(BitOperations.GetNBits(dataReg3, 1, 18));
            chargePump.SetCycleSlipMode(enabled);   // sets into model
        }

        /// <summary>
        /// Gets and sets automatic VCO selection mode from register 3
        /// </summary>
        /// <param name="dataReg3"> register 3 </param>
        private void GetAutoVcoSelectionStateFromRegister(UInt32 dataReg3)
        {
            // gets bit 25 from input data register 3
            bool enabled = Convert.ToBoolean(BitOperations.GetNBits(dataReg3, 1, 25));
            vcoControls.SetAutoVcoSelectionState(!enabled); // sets into model
        }

        /// <summary>
        /// Gets and sets VCO auto selection with temperature compensation from register 3
        /// </summary>
        /// <param name="dataReg3"> register 3 </param>
        private void GetVASTempComStateFromRegister(UInt32 dataReg3)
        {
            // gets bit 24 from input data register 3
            bool enabled = Convert.ToBoolean(BitOperations.GetNBits(dataReg3, 1, 24));
            vcoControls.SetVASTempComState(enabled);    // sets into model
        }
        
        /// <summary>
        /// Gets and sets manual VCO selection mode from register 3
        /// </summary>
        /// <param name="dataReg3"> register 3 </param>
        private void GetManualVCOSelectValueFromRegister(UInt32 dataReg3)
        {
            // gets bits 26 - 31 from input data register 3
            UInt16 vcoValue = (UInt16)BitOperations.GetNBits(dataReg3, 6, 26);
            vcoControls.SetManualVCOSelectValue(vcoValue);  // sets into model
        }

        /// <summary>
        /// Gets and sets delay mode to prevent flickering from register 3
        /// </summary>
        /// <param name="dataReg3"> register 3 </param>
        private void GetDelayToPreventFlickeringStateFromRegister(UInt32 dataReg3)
        {
            // gets bit 17 from input data register 3
            bool enabled = Convert.ToBoolean(BitOperations.GetNBits(dataReg3, 1, 17));
            vcoControls.SetDelayToPreventFlickeringState(enabled);  // sets into model
        }

        /// <summary>
        /// Gets and sets clock divider value from register 3
        /// </summary>
        /// <param name="dataReg3"> register 3 </param>
        private void GetClockDividerValueFromRegister(UInt32 dataReg3)
        {
            // gets bits 3-14 from input data register 3
            UInt16 cdiv = (UInt16)BitOperations.GetNBits(dataReg3, 12, 3);
            vcoControls.SetClockDividerValue(cdiv); // sets into model
        }

    #endregion

    #region Parsing register 4

        /// <summary>
        /// Gets and sets output A state from register 4
        /// </summary>
        /// <param name="dataReg4"> register 4 </param>
        private void GetOutAENStatusFromRegister(UInt32 dataReg4)
        {
            // gets bit 5 from input data register 4
            OutEnState outAEn = (OutEnState)BitOperations.GetNBits(dataReg4, 1, 5);
            synthOutputControls.SetOutAEnable(outAEn); // sets into model
        }

        /// <summary>
        /// Gets and sets output B state from register 4
        /// </summary>
        /// <param name="dataReg4"> register 4 </param>
        private void GetOutBENStatusFromRegister(UInt32 dataReg4)
        {
            // gets bit 8 from input data register 4
            OutEnState outBEn = (OutEnState)BitOperations.GetNBits(dataReg4, 1, 8);
            synthOutputControls.SetOutBEnable(outBEn); // sets into model
        }

        /// <summary>
        /// Gets and sets output A power level from register 4
        /// </summary>
        /// <param name="dataReg4"> register 4 </param>
        private void GetOutAPwrStatusFromRegister(UInt32 dataReg4)
        {
            // gets bits 3, 4  from input data register 4
            int outAPwr = (int)BitOperations.GetNBits(dataReg4, 2, 3);
            synthOutputControls.SetOutAPwr(outAPwr); // sets into model
        }

        /// <summary>
        /// Gets and sets output B power level from register 4
        /// </summary>
        /// <param name="dataReg4"> register 4 </param>
        private void GetOutBPwrStatusFromRegister(UInt32 dataReg4)
        {
            // gets bits 6, 7 from input data register 4
            int outBPwr = (int)BitOperations.GetNBits(dataReg4, 2, 6); 
            // sets into model and if not successfull, fix register value into correct level
            if (!synthOutputControls.SetOutBPwr(outBPwr))
                registers[4].ChangeNBits((UInt32)synthOutputControls.GetOutBPwrIndex(), 2, 6);
        }

        /// <summary>
        /// Gets and sets A-divider value from register 4
        /// </summary>
        /// <param name="dataReg4"> register 4 </param>
        private void GetADividerValueFromRegister(UInt32 dataReg4)
        {
            // gets bits 20-22 from input data register 4
            UInt16 aDiv = (UInt16)BitOperations.GetNBits(dataReg4, 3, 20);
            outFreqControl.SetADivVal(aDiv); // sets into model
        }

        /// <summary>
        /// Gets and sets output B internal path index from register 4
        /// </summary>
        /// <param name="dataReg4"> register 4 </param>
        public void GetOutBPathIndexFromRegister(UInt32 dataReg4)
        {
            // gets bit 9 from input data register 4
            int index = (int)BitOperations.GetNBits(dataReg4, 1, 9);
            outFreqControl.SetOutBPath(index); // sets into model
        }

        /// <summary>
        /// Gets and sets VCO to N-counter internal path from register 4
        /// </summary>
        /// <param name="dataReg4"> register 4 </param>
        public void GetFBPathIndexFromRegister(UInt32 dataReg4)
        {
            // gets bit 23 from input data register 4
            int index = (int)BitOperations.GetNBits(dataReg4, 1, 23);
            outFreqControl.SetFBPath(index); // sets into model
        }

        /// <summary>
        /// Gets and sets reference input shutdown state from register 4
        /// </summary>
        /// <param name="dataReg4"> register 4 </param>
        private void GetRefInputShutdownStateFromRegister(UInt32 dataReg4)
        {
            // gets bit 26 from input data register 4
            bool shutdown = Convert.ToBoolean(BitOperations.GetNBits(dataReg4, 1, 26));
            shutdowns.SetReferenceInputShutdownState(shutdown); // sets into model
        }

        /// <summary>
        /// Gets and sets VCO divider shutdown state from register 4
        /// </summary>
        /// <param name="dataReg4"> register 4 </param>
        private void GetVcoDividerShutDownStateFromRegister(UInt32 dataReg4)
        {
            // gets bit 27 from input data register 4
            bool shutdown = Convert.ToBoolean(BitOperations.GetNBits(dataReg4, 1, 27));
            shutdowns.SetVcoDividerShutdownState(shutdown); // sets into model
        }

        /// <summary>
        /// Gets and sets VCO LDO shutdown state from register 4
        /// </summary>
        /// <param name="dataReg4"> register 4 </param>
        private void GetVcoLdoShutDownStateFromRegister(UInt32 dataReg4)
        {
            // gets bit 28 from input data register 4
            bool shutdown = Convert.ToBoolean(BitOperations.GetNBits(dataReg4, 1, 28));
            shutdowns.SetVcoLdoShutdownState(shutdown); // sets into model
        }

        /// <summary>
        /// Gets and VCO shutdown state from register 4
        /// </summary>
        /// <param name="dataReg4"> register 4 </param>
        private void GetVcoShutDownStateFromRegister(UInt32 dataReg4)
        {
            // gets bit 11 from input data register 4
            bool shutdown = Convert.ToBoolean(BitOperations.GetNBits(dataReg4, 1, 11));
            shutdowns.SetVcoShutdownState(shutdown); // sets into model
        }

        /// <summary>
        /// Gets and sets mute until lock-detect mode from register 4
        /// </summary>
        /// <param name="dataReg4"> register 4 </param>
        private void GetMuteUntilLockDetectStateFromRegister(UInt32 dataReg4)
        {
            // gets bit 10 from input data register 4
            bool mtld = Convert.ToBoolean(BitOperations.GetNBits(dataReg4, 1, 10));
            vcoControls.SetMuteUntilLockDetectMode(mtld); // sets into model
        }

        /// <summary>
        /// Gets and sets band select clock divider value from register 4
        /// </summary>
        /// <param name="dataReg4"> register 4 </param>
        public void GetBandSelClockDivValueFromRegister(UInt32 dataReg4)
        {
            // gets bits 12-19 and 24, 25 from input data register 4
            UInt16 msbs = (UInt16)BitOperations.GetNBits(dataReg4, 2, 24);
            UInt16 lsbs = (UInt16)BitOperations.GetNBits(dataReg4, 8, 12);
            UInt16 bandSelectClockDiv = (UInt16)((msbs << 8) + lsbs);  // join msbs and lsbs
            vcoControls.SetBandSelClockDivValue(bandSelectClockDiv); // sets into model
        }

    #endregion

    #region Parsing register 5

        /// <summary>
        /// Gets and sets PLL shutdown mode from register 5
        /// </summary>
        /// <param name="dataReg5"> register 5 </param>
        private void GetPllShutdownStateFromRegister(UInt32 dataReg5)
        {
            // gets bit 25 from input data register 5
            bool shutdown = Convert.ToBoolean(BitOperations.GetNBits(dataReg5, 1, 25));
            shutdowns.SetPllShutdownState(shutdown); // sets into model
        }
        
        /// <summary>
        /// Gets and sets auto Integer-N mode, when Frac-N = 0 from register 5
        /// </summary>
        /// <param name="dataReg5"> register 5 </param>
        private void GetIntNAutoModeWhenF0StateFromRegister(UInt32 dataReg5)
        {
            // gets bit 24 from input data register 5
            bool state = Convert.ToBoolean(BitOperations.GetNBits(dataReg5, 1, 24));
            genericControls.SetF0AutoIntNMode(state); // sets into model
        }

    #endregion

    #region Collection function
        /// <summary>
        /// This function parse all values from the specified synthesizer register
        /// </summary>
        /// <param name="index"> Specified register value (0-5) </param>
        public void GetAllFromReg(int index)
        {
            // gets appropriate register value
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
                default:
                    break;
            }
        }

        /// <summary>
        /// This function parse all values from each synthesizer register
        /// and updates the frequency info
        /// </summary>
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

        /// <summary>
        /// Updates the frequency info. If VCO frequency is beyond limits, it set
        /// freq. at outputs A and B to zero.
        /// </summary>
        public void RecalcWorkingFreqInfo()
        {
            // gets importat values from models
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
                // if VCO freq is beyond limits set zeros into direct freq module group and return
                directFreqControl.SetFreqAtOut1(0);
                directFreqControl.SetFreqAtOut2(0);
            }
            else
            {
                // sets new frequencies into appropriate models
                synthFreqInfo.SetOutAFreq(fOutA);
                synthFreqInfo.SetOutBFreq(fOutB);
                directFreqControl.SetFreqAtOut1(fOutA);
                directFreqControl.SetFreqAtOut2(fOutB * 2);
                memory.UpdateUiElements();  
            }
        }

        /// <summary>
        /// This function updates some properties resulting from 
        /// 0 - 5 synthesizer registers for the specified memory number.
        /// Especially it is frequency at output 1 and 2, output A and B state 
        /// and power level for memory number.
        /// </summary>
        /// <param name="memoryNumber"> specified memory number </param>
        public void RecalcMemoryInfo(UInt16 memoryNumber)
        {  
            // gets important memory register values
            UInt32 dataReg0 = memory.GetRegister(memoryNumber, 0).uint32_GetValue();
            UInt32 dataReg1 = memory.GetRegister(memoryNumber, 1).uint32_GetValue();
            UInt32 dataReg2 = memory.GetRegister(memoryNumber, 2).uint32_GetValue();
            UInt32 dataReg4 = memory.GetRegister(memoryNumber, 4).uint32_GetValue();

            // parsing important values for calc freq info
            UInt16 intN = (UInt16)BitOperations.GetNBits(dataReg0, 16, 15);
            UInt16 fracN = (UInt16)BitOperations.GetNBits(dataReg0, 12, 3);
            UInt16 mod = (UInt16)BitOperations.GetNBits(dataReg1, 12, 3);
            UInt16 aDiv = (UInt16)BitOperations.GetNBits(dataReg4, 3, 20);
            aDiv = (UInt16)(1 << aDiv);
            SynthMode mode = (SynthMode)BitOperations.GetNBits(dataReg0, 1, 31);
            int outBpath = (int)BitOperations.GetNBits(dataReg4, 1, 9);
            int FBpath = (int)BitOperations.GetNBits(dataReg4, 1, 23);

            UInt16 refDoubler = (UInt16)BitOperations.GetNBits(dataReg2, 1, 25);
            UInt16 refDividerBy2 = (UInt16)BitOperations.GetNBits(dataReg2, 1, 24);
            UInt16 rDiv = (UInt16)BitOperations.GetNBits(dataReg2, 10, 14);

            // calculate frequency at phase frequency detector from parsed values
            decimal fPfd = 10.0M * (1 + refDoubler) / (decimal)(rDiv * (1 + refDividerBy2));

            decimal fOutA;
            decimal fOutB;
            decimal fVco;

            // gets freq at out A, B
            CalcFreqInfo(intN, fracN, mod, aDiv, mode, outBpath, FBpath, fPfd, 
                         out fOutA, out fOutB, out fVco);
            
            // sets this values into models
            if (memory.GetMemOut1State(memoryNumber))
                memory.SetMemFreq1Value(fOutA, memoryNumber);
            else
                memory.SetMemFreq1Value(0, memoryNumber);

            if (memory.GetMemOut2State(memoryNumber))
                memory.SetMemFreq2Value(2 * fOutB, memoryNumber);
            else
                memory.SetMemFreq2Value(0, memoryNumber);

            // parsing important values for output power and status info
            int outAPwr = (int)BitOperations.GetNBits(dataReg4, 2, 3);
            int outBPwr = (int)BitOperations.GetNBits(dataReg4, 2, 6);
            OutEnState outAEn = (OutEnState)BitOperations.GetNBits(dataReg4, 1, 5);
            OutEnState outBEn = (OutEnState)BitOperations.GetNBits(dataReg4, 1, 8);

            // sets these values into models
            if (outAEn == OutEnState.ENABLE)
                memory.SetMemPwrAIndex(outAPwr, memoryNumber);
            else
                memory.SetMemPwrAIndex(-1, memoryNumber);

            if (outBEn == OutEnState.ENABLE)
                memory.SetMemPwrBIndex(outBPwr, memoryNumber);
            else
                memory.SetMemPwrBIndex(-1, memoryNumber);
            
        }

        /// <summary>
        /// This function is used to obtain the frequency at the synthesizer
        /// outputs A and B and the frequency at the VCO output
        /// </summary>
        /// <param name="intN"> Int-N value </param>
        /// <param name="fracN"> Frac-N value </param>
        /// <param name="mod"> modulus value </param>
        /// <param name="aDiv"> A-divider value </param>
        /// <param name="mode"> Synthesize mode (fractional/integer) </param>
        /// <param name="outBpath"> OutB internal path </param>
        /// <param name="FBpath"> VCO to N counter internal path </param>
        /// <param name="fPfd"> frequency at phase freq input </param>
        /// <param name="fOutA"> frequency at output A </param>
        /// <param name="fOutB"> frequency at output A </param>
        /// <param name="fVco"> frequency at VCO output </param>
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
                    if (aDiv <= 16)
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

        /// <summary>
        /// This function calculate registers values for desired synthesizer frequency.
        /// </summary>
        /// <param name="value"> desired frequency as string </param>
        public void CalcSynthesizerRegValuesFromInpFreq(string value)
        {
            // sets input desired freq into direct Freq Control class
            directFreqControl.SetDirectInputFreqValue(value);

            // this disable sending into serial port, if any value make changes (event)
            serialPort.SetDisableSending(true, 13);

            // gets input freq back from direct Freq Control class 
            decimal f_input = directFreqControl.decimal_GetDirectInputFreqVal();

            // gets reference input states
            bool isDoubled = refFreq.GetIsDoubled();    // ref doubler state
            bool isDivBy2 = refFreq.GetIsDividedBy2();  // ref divider by 2 state
            decimal refInFreq = refFreq.decimal_GetRefFreqValue();  // reference frequency
            int outBPathIndex = outFreqControl.GetOutBPathIndex();  // synth OUTB path select (0 - VCO divided, 1 - VCO fundamental)
            int FBPathIndex   = outFreqControl.GetFBPathIndex();    // VCO to N counter feedback mode (0 - divided, 1 - fundamental)

            // calculate new register settings
            CalcRegs calcRegs = CalcRegisters.CalcRegistersFromInput(f_input, 
                                                                     refInFreq, 
                                                                     isDoubled, 
                                                                     isDivBy2, 
                                                                     outBPathIndex,
                                                                     FBPathIndex);

            outFreqControl.SetADivVal((UInt16)calcRegs.aDivIndex);  // sets new calculated ADiv index value
            refFreq.SetAutoLDSpeedAdj(true);            // sets Auto LDSpeed Adjustment
            outFreqControl.SetAutoLDFunction(true);     // sets Auto LD funtion
            outFreqControl.SetSynthMode(calcRegs.mode); // sets new calculated synthesizer mode
            outFreqControl.SetIntNVal(calcRegs.intN);   // sets new calculated IntN Value
            refFreq.SetRDivider(calcRegs.rDiv);         // sets new calculated R divider value
            CalcsValsRelatedToPfdFreq(false);           // recalc related values
            
            // if mode was calculated as Fractional, so set Mod and FracN values
            if (calcRegs.mode == SynthMode.FRACTIONAL)
            {
                outFreqControl.SetModVal(calcRegs.mod);     // sets Frac value
                outFreqControl.SetFracNVal(calcRegs.fracN); // sets Mod value
            }

            RecalcWorkingFreqInfo(); // reload frequency info

            decimal delta;  // delta frequency variable

            // gets synthesizer frequency at each output
            decimal f_out_A = synthFreqInfo.decimal_GetOutAFreq();
            decimal f_out_B = synthFreqInfo.decimal_GetOutBFreq();
            
            // sets correct module frequency at each output
            directFreqControl.SetFreqAtOut1(f_out_A);
            directFreqControl.SetFreqAtOut2(2*f_out_B);

            // activate/deactivate corrensponding outputs on synthesizer and whole module by frequency range
            if (f_input <= 6000)
            {
                if (!moduleControls.GetOut1State())
                {
                    SwitchOut1();
                }

                if (moduleControls.GetOut2State())
                {
                    SwitchOut2();
                }

                // calc delta freq between currently set frequency at synth. output and desired frequency
                delta = (f_out_A - f_input) * 1e6M;
                directFreqControl.SetCalcFreq(f_out_A);
            }
            else
            {
                if (moduleControls.GetOut1State())
                {
                    SwitchOut1();
                }

                if (!moduleControls.GetOut2State())
                {
                    SwitchOut2();
                }

                delta = (f_out_B * 2 - f_input) * 1e6M;
                directFreqControl.SetCalcFreq(f_out_B * 2);
            }

            // sets delta freq into GUI
            directFreqControl.SetDeltaFreqValue(delta);
            // Try send data
            serialPort.SetDisableSending(false, 13);
            if (serialPort.GetDisableSending() == false)
                SendData();
            
        }
#endregion

#region Serial port

        /// <summary>
        /// Force sends all registers into synthesizer including module control states.
        /// </summary>
        public void ForceLoadAllRegsIntoPlo()
        {   
            // sends all PLO registers 
            for (int i = 5; i >= 0; i--)
            {
                if (!serialPort.IsPortOpen())
                    return;
                ApplyChangeReg(i);
            }

            GetAllFromRegisters();  // reflesh all register values

            // sends module control states
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

        /// <summary>
        /// This function force set new register value into model and
        /// sends it into synthesizer by sender UI name.
        /// </summary>
        /// <param name="sender"> sender name </param>
        /// <param name="value"> register value to send </param>
        public void SetAndSendRegChangesIntoPlo(string sender, string value)
        {
            serialPort.SetDisableSending(true, 4);          // disable sending

            // parse register number from UI element name
            sender = string.Join("", sender.ToCharArray().Where(Char.IsDigit));
            int regNumber = int.Parse(sender);

            registers[regNumber].SetValue(value);   // set this register into model
            GetAllFromReg(regNumber);               // get all from this register

            serialPort.SetDisableSending(false, 4);          // try enable sending
            if (serialPort.GetDisableSending() == false)     // if success send new data
                SendData();
        }

        /// <summary>
        /// This function sends a new registry value to the synthesizer only if 
        /// the new value differs from the last sent value. This prevents 
        /// the same registry values from being sent again accidentally.
        /// </summary>
        /// <param name="regNumber"> register number value (0-5) </param>
        public void CheckAndApplyRegChanges(int regNumber)
        {
            if ((serialPort.IsPortOpen()) && 
                (!string.Equals(registers[regNumber].string_GetValue(), 
                                old_registers[regNumber].string_GetValue(),
                                StringComparison.CurrentCultureIgnoreCase)))
            {
                // only if new value differs from old value
                ApplyChangeReg(regNumber);
                if (regNumber == 1 || regNumber == 2)
                    ApplyChangeReg(0); // these registers must be double bufferef by register 0
                if (regNumber != 3 || regNumber != 5)
                    RecalcWorkingFreqInfo();    // recalculate frequency info for registers 1, 2, 4
            }
        }

        /// <summary>
        /// This function first parse register number from sender name and then
        /// sends a new registry value to the synthesizer only if 
        /// the new value differs from the last sent value. This prevents 
        /// the same registry values from being sent again accidentally.
        /// </summary>
        /// <param name="sender"> sender name </param>
        public void CheckAndApplyRegChanges(string sender)
        {
            // parse register number from sender UI element name
            sender = string.Join("", sender.ToCharArray().Where(Char.IsDigit));
            int regNumber = int.Parse(sender);

            CheckAndApplyRegChanges(regNumber);
        }

        /// <summary>
        /// Function for send data into PLO. The function is called only after 
        /// sending has been unblocked and this is based on a unique ID. 
        /// Only the initial request can unblock sending. This ensures that all 
        /// edits are sent at once.
        /// </summary>
        private void SendData()
        {
            if (serialPort.IsPortOpen())
            {
                // only at opened port
                bool[] needUpdate = new bool[6];    // flag if register need send

                // compares the current values with those last sent and 
                // sets a flag for updating.
                for (int regNumber = 0; regNumber <= 5; regNumber++)
                {
                    if ((!string.Equals(registers[regNumber].string_GetValue(), 
                                old_registers[regNumber].string_GetValue(),
                                StringComparison.CurrentCultureIgnoreCase)))
                        needUpdate[regNumber] = true;
                    else
                        needUpdate[regNumber] = false;
                }

                // Separates individual data only from registers that need updating.
                for (int regNumber = 5; regNumber >= 0; regNumber--)
                {
                    if (needUpdate[regNumber] == true)
                        GetAllFromReg(regNumber);
                }

                for (int regNumber = 5; regNumber >= 0; regNumber--)
                {
                    if (needUpdate[regNumber] == true)
                    {
                        // sends data only if flag is enabled
                        GetAllFromReg(regNumber);
                        switch (regNumber)
                        {
                            case 5:
                                ApplyChangeReg(5);
                                break;
                            case 4:
                                ApplyChangeReg(4);
                                // if PLO is set to automatic Reg 4 double buffered by Reg 0
                                // changes need not be applied by manually uploading registry 0
                                if (!genericControls.GetReg4DoubleBuffered()) // TODO test me on SA, comment needUpdate true flag and test it
                                    needUpdate[0] = true;
                                break;
                            case 3:
                                ApplyChangeReg(3);
                                break;
                            case 2:
                                ApplyChangeReg(2);
                                needUpdate[0] = true; // it need double buffered by reg 0
                                break;
                            case 1:
                                ApplyChangeReg(1);
                                needUpdate[0] = true; // it need double buffered by reg 0
                                break;
                            default:
                                ApplyChangeReg(0);
                                break;
                        }
                    }
                }

                if (needUpdate[0] || needUpdate[1] || needUpdate[2] || needUpdate[4])
                    RecalcWorkingFreqInfo(); // recalculate frequency info
            }
        }

        /// <summary>
        /// The function first obtains the given register and then sends 
        /// its value to the serial link in the appropriate format. 
        /// The value is also stored in old_registers, which is used to 
        /// determine if the current value differs from the last sent.
        /// </summary>
        /// <param name="index"> register number </param>
        public void ApplyChangeReg(int index)
        {
            if (serialPort.IsPortOpen())
            {
                string value = registers[index].string_GetValue();  // gets register
                old_registers[index].SetValue(value);   // backup this value

                // create text string in appropriate format
                string data = String.Format("plo set_register {0}", value);
                serialPort.SendStringSerialPort(data); // send into serial link
            }
        }

        /// <summary>
        /// Open/close serial port. When closing port, it save workspace data into file.
        /// </summary>
        /// <returns> 
        ///     false if port is closed,
        ///     true if port is opened
        /// </returns>
        public bool SwitchPort()
        {
            if(serialPort.IsPortOpen())
            {
                // serial port is open, close it
                serialPort.ClosePort();
                SaveWorkspaceData();    // save workspace data
                return false;   // port is closed
            }
            else
            {
                return OpenPort();  // try to open port
            }
        }

        /// <summary>
        /// Function for open serial link port. If the opening succeeds, 
        /// it loads all the registers into the PLO and saves the current window 
        /// state to a file if there is no error during the upload.
        /// </summary>
        /// <returns>
        ///     true = port was successfully opened,
        ///     false = port was not successfully opened
        /// </returns>
        private bool OpenPort()
        {
            // try to open serial link port
            bool success = serialPort.OpenPort();

            if (success)
            {
                ForceLoadAllRegsIntoPlo();  // send all registers into PLO
                if (serialPort.IsPortOpen())
                {
                    // if still port open save current window into file
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

        /// <summary>
        /// Loads saved data from file */saved_workspace.json into workspace
        /// </summary>
        public void LoadSavedWorkspaceData()
        {
            SaveWindow loadedData = new SaveWindow();
            bool success = FilesManager.LoadSavedWorkspaceData(out loadedData);

            if (success)
            {
                // if success print message into console and load data into workspace
                string text = "Workspace data succesfuly loaded.";
                ConsoleController.Console().Write(text);

                LoadDataIntoWorkspace(loadedData);
            }
            else
            {
                //print error message
                MessageBox.Show("When loading worskspace data occurs error!", "Error Catch",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Saves the current window status into file */saved_workspace.json 
        /// so that it can be reloaded when the program starts.
        /// </summary>
        public void SaveWorkspaceData()
        {
            bool success = FilesManager.SaveWorkspaceData(CreateSaveWindow());

            // print message into console, if saving was successfull or was not
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

        /// <summary>
        /// Loads data into the workspace
        /// </summary>
        /// <param name="data"> data to be loaded into the workspace </param>
        public void LoadDataIntoWorkspace(SaveWindow data)
        {
            // registers
            MyRegister.SetValues(registers, data.Registers.ToArray());
            // old registers
            MyRegister.SetValues(old_registers, data.Registers.ToArray());

            chargePump.SetRSetValue(data.RSetValue);

            directFreqControl.SetDirectInputFreqValue(data.OutputFreqValue);

            refFreq.SetRefFreqValue(data.ReferenceFrequency);
            CalcsValsRelatedToPfdFreq(false);    // recalc related values

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
            refFreq.SetIntRefInpEnabled(!moduleControls.GetIntRefState());
        }

        /// <summary>
        /// Reads individual items from the models and returns them as SaveWindow.
        /// </summary>
        /// <returns> loaded workspace data </returns>
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

        /// <summary>
        /// Loads saved default registers from file */default.json into workspace 
        /// and send it into PLO
        /// </summary>
        public void LoadDefRegsData()
        {
            SaveDefaults loadedData = new SaveDefaults();
            bool success = FilesManager.LoadDefRegsData(out loadedData);

            if (success)
            {
                // if success print message into console and load data into workspace
                string text = "Default registers succesfuly loaded.";
                ConsoleController.Console().Write(text);


                serialPort.SetDisableSending(true, 49); // disable sending
                LoadDefRegsFromFile(loadedData);        // load data into workspace
                SendData();                             // send data
                serialPort.SetDisableSending(false, 49); // enable sending
            }
            else
            {
                //print error message and show message box warning
                string text = "When loading default registers occurs error!";
                ConsoleController.Console().Write(text);
                MessageBox.Show("File default.json with include settings for registers, doesn't exist. First create it by click to Set As Def Button", "File defaults.txt doesn't exist", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Saves the registers as defaults into file */default.json
        /// </summary>
        public void SaveDefRegsData()
        {
            bool success = FilesManager.SaveDefRegsData(CreateDefaultsData());

            if(success)
            {
                // if success print message into console
                string text = "Default registers succesfuly saved.";
                ConsoleController.Console().Write(text);
            }
            else
            {
                //print error message and show message box warning
                string text = "When saving default registers occurs error!";
                ConsoleController.Console().Write(text);
                MessageBox.Show(text, "Error Catch",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads default registers data into the workspace
        /// </summary>
        /// <param name="data"> default data to be loaded </param>
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

        /// <summary>
        /// Function gets all neccessary states and values from model and
        /// they form a SaveDefaults class.
        /// </summary>
        /// <returns> defaults data </returns>
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

        /// <summary>
        /// Saves the registers into file. Using Window Form dialog. Default 
        /// file name is by current module states.
        /// </summary>
        public void SaveRegistersIntoFile()
        {
            string test = null;     // file name path including file name
            // gets file name with path using Window form dialog
            FilesManager.SaveFile(out test, GetDefaultRegistersFileName());

            if (test != string.Empty)
            {
                // only if path with file name does not empty
                bool success = FilesManager.SaveDefRegsData(CreateDefaultsData(), test);

                if(success)
                {
                    // print success into console
                    string text = "Currently registers succesfuly saved into file: '" + test + "'";
                    ConsoleController.Console().Write(text);
                }
                else
                {
                    // print error message into console and messageBox
                    string text = "When saving registers occurs error!";
                    ConsoleController.Console().Write(text);
                    MessageBox.Show(text, "Error Catch",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Loads the registers from file into workspace. Using Window Form 
        /// dialog.
        /// </summary>
        public void LoadRegistersFromFile()
        {
            string test = null; // file name path including file name
            FilesManager.LoadFile(out test);

            if (test != string.Empty)
            {
                SaveDefaults loadedData = new SaveDefaults();
                bool success = FilesManager.LoadDefRegsData(out loadedData, test);

                if (success)
                {
                    // if successfully loaded print msg into console and load it into workspace and send it into PLO
                    string text = "Currently registers succesfuly loaded from file: '" + test + "'";
                    ConsoleController.Console().Write(text);

                    serialPort.SetDisableSending(true, 48); // disable sending
                    LoadDefRegsFromFile(loadedData);        // load data into workspace
                    SendData();                             // send data
                    serialPort.SetDisableSending(false, 48); // enable sending
                }
                else
                {
                    // print error message into console and messageBox
                    string text = "When loading registers occurs error!";
                    ConsoleController.Console().Write(text);
                    MessageBox.Show(text, "Error Catch", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        ///  This function create default file name by current module states.
        /// </summary>
        /// <returns> default file name by current module states </returns>
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

    /// <summary>
    /// 
    /// </summary>
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


    /// <summary>
    /// Load memory registers from input date
    /// </summary>
    /// <param name="data"> data to be loaded</param>
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
            RecalcMemoryInfo(memoryNumber);
        }
    }

    /// <summary>
    /// Load data into workspace
    /// </summary>
    /// <param name="data"> data to be loaded </param>
    public void LoadMemoryRegsFromFile(SaveWindow data)
    {   
        // load memory 1-4 registers 0-6 (6 is control register for module controls)
        for (int i = 0; i < 7; i++)
        {
            memory.GetRegister(1, i).SetValue(data.Mem1[i]);
            memory.GetRegister(2, i).SetValue(data.Mem2[i]);
            memory.GetRegister(3, i).SetValue(data.Mem3[i]);
            memory.GetRegister(4, i).SetValue(data.Mem4[i]);
        }

        // for all memories fill additional information
        for (UInt16 memoryNumber = 1; memoryNumber <= 4; memoryNumber++)
        {
            SetMemOutsAndRefFromControlReg(memoryNumber);
            RecalcMemoryInfo(memoryNumber);
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
            RecalcMemoryInfo((UInt16)memoryNumber);
        }

        /// <summary>
        /// For the specified memory number, it reads data from 
        /// the control register and set into the memory synthesizer controls group
        /// </summary>
        /// <param name="memoryNumber"> memory number </param>
        public void SetMemOutsAndRefFromControlReg(UInt16 memoryNumber)
        {
            // gets all states from control register model data
            UInt32 out1State = BitOperations.GetNBits(memory.GetRegister(memoryNumber, 6).uint32_GetValue(), 1, 0);
            UInt32 out2State = BitOperations.GetNBits(memory.GetRegister(memoryNumber, 6).uint32_GetValue(), 1, 1);
            UInt32 refState  = BitOperations.GetNBits(memory.GetRegister(memoryNumber, 6).uint32_GetValue(), 1, 2);

            // sets them into appropriate models
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

            if (state)
                memory.SetMemFreq1Value(0, (UInt16)memNum);
            else
                RecalcMemoryInfo((UInt16)memNum);
        }

        public void SwitchMemActOut2(int memNum)
        {
            bool state = memory.GetMemOut2State(memNum);

            memory.SetMemOut2State(!state, memNum);
            memory.GetRegister(memNum, 6).SetResetOneBit(1, (BitState)Convert.ToUInt16(!state));

            if (state)
                memory.SetMemFreq2Value(0, (UInt16)memNum);
            else
                RecalcMemoryInfo((UInt16)memNum);
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
