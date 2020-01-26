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
        

        public MyRegister[] old_registers;
        // TODO ... FILIP MyRegister without UI element

        public Controller(Form1 view)
        {
            // TODO FILIP ... Hey, try this! Hey! It works! :)
            /*string test = null;
            FilesManager.LoadFile(out test);*/

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

            var old_reg0 = new MyRegister(String.Empty);
            var old_reg1 = new MyRegister(String.Empty);
            var old_reg2 = new MyRegister(String.Empty);
            var old_reg3 = new MyRegister(String.Empty);
            var old_reg4 = new MyRegister(String.Empty);
            var old_reg5 = new MyRegister(String.Empty);

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

        public void GetAllFromRegisters()
        {
            
            GetAllFromReg(5);
            GetAllFromReg(4);
            GetAllFromReg(3);
            GetAllFromReg(2);
            GetAllFromReg(1);
            GetAllFromReg(0);
            GetFPfdFreq();
            RecalcFreqInfo(); 
        }
        #endregion

#endregion

#region Some magic calculations
        public void GetCPCurrentFromTextBox()
        {
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

        public void ApplyChangeReg(int index)
        {
            if (serialPort.IsPortOpen())
            {
                string data = String.Format("plo set_register {0}", registers[index].string_GetValue());
                old_registers[index].SetValue(registers[index].string_GetValue());
                serialPort.SendStringSerialPort(data);
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
                SaveWorkspaceData();
                view.ForceLoadRegButton_Click(this, new EventArgs()); // FIXME Not OOD
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

#region Load and Save Data

        public void LoadSavedWorkspaceData()
        {
            SaveWindow loadedData = new SaveWindow();
            bool succes = FilesManager.LoadSavedWorkspaceData(out loadedData);

            if (succes)
            {
                string text = "Workspace data succesfuly loaded.";
                view.ConsoleTextBox.AppendText(Environment.NewLine + DateTime.Now.ToString("HH:mm:ss: ") + text);

                view.AvaibleCOMsComBox.Text = loadedData.COM_port;
                LoadRegistersFromFile(loadedData);
            }
            else
            {
                MessageBox.Show("When loading worskspace data occurs error!", "Error Catch",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveWorkspaceData()
        {

            bool succes = FilesManager.SaveWorkspaceData(CreateSaveWindow());

            if(succes)
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

        public void LoadRegistersFromFile(SaveWindow data)
        {
            // registers
            MyRegister.SetValues(registers, data.Registers.ToArray());
            // old registers
            MyRegister.SetValues(old_registers, data.Registers.ToArray());

            view.RSetTextBox.Text = Convert.ToString(data.RSetValue);

            view.InputFreqTextBox.Text = data.OutputFreqValue;

            view.R0M1.Text = data.Mem1[0];
            view.R1M1.Text = data.Mem1[1];
            view.R2M1.Text = data.Mem1[2];
            view.R3M1.Text = data.Mem1[3];
            view.R4M1.Text = data.Mem1[4];
            view.R5M1.Text = data.Mem1[5];

            view.R0M2.Text = data.Mem2[0];
            view.R1M2.Text = data.Mem2[1];
            view.R2M2.Text = data.Mem2[2];
            view.R3M2.Text = data.Mem2[3];
            view.R4M2.Text = data.Mem2[4];
            view.R5M2.Text = data.Mem2[5];

            view.R0M3.Text = data.Mem3[0];
            view.R1M3.Text = data.Mem3[1];
            view.R2M3.Text = data.Mem3[2];
            view.R3M3.Text = data.Mem3[3];
            view.R4M3.Text = data.Mem3[4];
            view.R5M3.Text = data.Mem3[5];

            view.R0M4.Text = data.Mem4[0];
            view.R1M4.Text = data.Mem4[1];
            view.R2M4.Text = data.Mem4[2];
            view.R3M4.Text = data.Mem4[3];
            view.R4M4.Text = data.Mem4[4];
            view.R5M4.Text = data.Mem4[5];

            this.GetCPCurrentFromTextBox();
            this.GetAllFromRegisters();
        }

        private SaveWindow CreateSaveWindow()
        {
            SaveWindow saved = new SaveWindow
            {
                Registers = new List<string>
                {
                    this.registers[0].string_GetValue(),
                    this.registers[1].string_GetValue(),
                    this.registers[2].string_GetValue(),
                    this.registers[3].string_GetValue(),
                    this.registers[4].string_GetValue(),
                    this.registers[5].string_GetValue()
                },
                RSetValue = Convert.ToUInt16(view.RSetTextBox.Text),
                OutputFreqValue = view.InputFreqTextBox.Text,
                Mem1 = new List<string>
                {
                    view.R0M1.Text,
                    view.R1M1.Text,
                    view.R2M1.Text,
                    view.R3M1.Text,
                    view.R4M1.Text,
                    view.R5M1.Text,
                },
                Mem2 = new List<string>
                {
                    view.R0M2.Text,
                    view.R1M2.Text,
                    view.R2M2.Text,
                    view.R3M2.Text,
                    view.R4M2.Text,
                    view.R5M2.Text,
                },
                Mem3 = new List<string>
                {
                    view.R0M3.Text,
                    view.R1M3.Text,
                    view.R2M3.Text,
                    view.R3M3.Text,
                    view.R4M3.Text,
                    view.R5M3.Text,
                },
                Mem4 = new List<string>
                {
                    view.R0M4.Text,
                    view.R1M4.Text,
                    view.R2M4.Text,
                    view.R3M4.Text,
                    view.R4M4.Text,
                    view.R5M4.Text,
                },
                COM_port = view.AvaibleCOMsComBox.Text
            };

            return saved;
        }

#endregion



    }
}
