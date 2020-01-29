using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Synthesizer_PC_control.Model;
using Synthesizer_PC_control.Utilities;

namespace Synthesizer_PC_control
{
    class Controller
    {
        private readonly Form1 view;

        public readonly MySerialPort serialPort;

        public MyRegister[] registers;

        public Memory memory;
        
        public MyRegister[] old_registers;

        public ModuleControls moduleControls;

        public Controller(Form1 view)
        {
            // TODO FILIP ... Hey, try this! Hey! It works! :)
            /*string test = null;
            FilesManager.LoadFile(out test);*/

            this.view = view;

            serialPort = new MySerialPort(view, view.ConsoleTextBox, view.PortButton, view.AvaibleCOMsComBox);
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

            old_registers = new MyRegister[] {old_reg0, old_reg1, old_reg2, old_reg3, old_reg4, old_reg5};

            memory = new Memory(this.view);

            moduleControls = new ModuleControls(view.Out1Button, view.Out2Button, view.RefButton);
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

        public void GetAllFromRegisters()
        {
            for (int i = 5; i >= 0; i--)
            {
                GetAllFromReg(i);
            }
            GetFPfdFreq();
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
            UInt16 DIVA = (UInt16)(1 << view.ADivComboBox.SelectedIndex);

            string f_pfd_string = view.fPfdScreenLabel.Text;
            f_pfd_string = f_pfd_string.Replace(" ", string.Empty);
            f_pfd_string = f_pfd_string.Replace(".", ",");
            decimal f_pfd = Convert.ToDecimal(f_pfd_string);

            decimal f_out_A = 0;
            decimal f_vco = 0;

            // TODO pohlidat f_vco

            if (view.ModeIntFracComboBox.SelectedIndex == 1)
            {
                f_out_A = ((f_pfd*view.IntNNumUpDown.Value)/(DIVA));
            }
            else
            {
                f_out_A = (f_pfd/DIVA)*(view.IntNNumUpDown.Value+(view.FracNNumUpDown.Value/(view.ModNumUpDown.Value*1.0M)));
            }
            f_vco = f_out_A*DIVA;
            if ((f_vco < 3000) || (f_vco > 6000))
            {
                view.fVcoScreenLabel.ForeColor = System.Drawing.Color.Red;
                view.IntNNumUpDown.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                view.fVcoScreenLabel.ForeColor = System.Drawing.Color.Black;
                view.IntNNumUpDown.BackColor = System.Drawing.Color.White;
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

        public void GetFPfdFreq()
        {
            // TODO osetrit fpfd
            string f_pfd_string = view.RefFTextBox.Text;
            f_pfd_string = f_pfd_string.Replace(" ", string.Empty);
            f_pfd_string = f_pfd_string.Replace(".", ",");
            decimal f_ref = decimal.Parse(f_pfd_string);
            UInt16 doubler = Convert.ToUInt16(view.DoubleRefFCheckBox.Checked);
            UInt16 divider2 = Convert.ToUInt16(view.DivideBy2CheckBox.Checked);
            decimal f_pfd = f_ref * ((1 + doubler) / (view.RDivUpDown.Value * (1 + divider2)));

            UInt16 f_pfd_MHz = (UInt16)(f_pfd);
            UInt32 f_pfd_kHz = (UInt32)(f_pfd*1000);
            UInt64 f_pfd_Hz = (UInt64)(f_pfd*1000000);
            UInt64 f_vco_mHz = (UInt64)(f_pfd*1000000000);
            UInt16 thousandths = (UInt16)(f_pfd_kHz - f_pfd_MHz*1000);
            UInt16 millionths = (UInt16)(f_pfd_Hz - (UInt64)(f_pfd_MHz)*1000000-(UInt64)(thousandths)*1000);
            UInt16 billionths = (UInt16)(f_vco_mHz - (UInt64)(f_pfd_Hz)*1000);
            float bill_f = (float)((billionths)/100.0);
            double rounding  = Math.Round((float)(billionths)/100.0, MidpointRounding.AwayFromZero);

            view.fPfdScreenLabel.Text = string.Format("{0},{1:000} {2:000} {3:0}", f_pfd_MHz, thousandths, millionths, rounding);
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
                GetAllFromReg(regNumber);
                ApplyChangeReg(regNumber);
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
                view.ConsoleTextBox.AppendText(Environment.NewLine + DateTime.Now.ToString("HH:mm:ss: ") + text);

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
                view.ConsoleTextBox.AppendText(Environment.NewLine + DateTime.Now.ToString("HH:mm:ss: ") + text);
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
                view.ConsoleTextBox.AppendText(Environment.NewLine + DateTime.Now.ToString("HH:mm:ss: ") + text);
                LoadDefRegsFromFile(loadedData);
                ForceLoadAllRegsIntoPlo();
            }
            else
            {
                string text = "When loading default registers occurs error!";
                view.ConsoleTextBox.AppendText(Environment.NewLine + DateTime.Now.ToString("HH:mm:ss: ") + text);
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
                view.ConsoleTextBox.AppendText(Environment.NewLine + DateTime.Now.ToString("HH:mm:ss: ") + text);
            }
            else
            {
                string text = "When saving default registers occurs error!";
                view.ConsoleTextBox.AppendText(Environment.NewLine + DateTime.Now.ToString("HH:mm:ss: ") + text);
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
