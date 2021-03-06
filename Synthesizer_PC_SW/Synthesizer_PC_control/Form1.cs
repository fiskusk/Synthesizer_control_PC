﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Globalization;

namespace Synthesizer_PC_control
{
    public partial class Form1 : Form
    {
        static SerialPort _serialPort;
        bool dontRunHandler = false;

        static string old_reg0 = "80C90000";
        static string old_reg1 = "800103E9";
        static string old_reg2 = "00005F42";
        static string old_reg3 = "00001F23";
        static string old_reg4 = "63BE80E4";
        static string old_reg5 = "00400005";

        private MyRegister[] registers;

        delegate void MojDelegat(object MojObjekt);

        public class SaveWindow
        {
            public IList<string> Registers { get; set; }
            public IList<string> Mem1 { get; set; }
            public IList<string> Mem2 { get; set; }
            public IList<string> Mem3 { get; set; }
            public IList<string> Mem4 { get; set; }
            public string COM_port { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

            InitRegisters();
        }

        private void InitRegisters()
        {
            // TODO If config file does not exist
            var reg0 = new MyRegister(Reg0TextBox.Text, Reg0TextBox);
            var reg1 = new MyRegister(Reg1TextBox.Text, Reg1TextBox);
            var reg2 = new MyRegister(Reg2TextBox.Text, Reg2TextBox);
            var reg3 = new MyRegister(Reg3TextBox.Text, Reg3TextBox);
            var reg4 = new MyRegister(Reg4TextBox.Text, Reg4TextBox);
            var reg5 = new MyRegister(Reg5TextBox.Text, Reg5TextBox);

            registers = new MyRegister[] { reg0, reg1, reg2, reg3, reg4, reg5};
        }

        void Form1_Load(object sender, EventArgs e)
        {   
            // load avaible com ports into combbox
            var ports = SerialPort.GetPortNames();
            AvaibleCOMsComBox.DataSource = ports;

            EnableControls(false);

            // load last used COM port, if exist
            LoadSavedWorkspaceData();
        }

        private void EnableControls(bool command)
        {
            AvaibleCOMsComBox.Enabled = !command;
            Out1Button.Enabled = command;
            Out2Button.Enabled = command;
            RefButton.Enabled = command;
            PloInitButton.Enabled = command;
            Reg0TextBox.Enabled = command;
            Reg1TextBox.Enabled = command;
            Reg2TextBox.Enabled = command;
            Reg3TextBox.Enabled = command;
            Reg4TextBox.Enabled = command;
            Reg5TextBox.Enabled = command;
            SetAsDefaultRegButton.Enabled = command;
            ForceLoadRegButton.Enabled = command;
            LoadDefRegButton.Enabled = command;
            WriteR0Button.Enabled = command;
            WriteR1Button.Enabled = command;
            WriteR2Button.Enabled = command;
            WriteR3Button.Enabled = command;
            WriteR4Button.Enabled = command;
            WriteR5Button.Enabled = command;
            R0M1.Enabled = command;
            R1M1.Enabled = command;
            R2M1.Enabled = command;
            R3M1.Enabled = command;
            R4M1.Enabled = command;
            R5M1.Enabled = command;
            R0M2.Enabled = command;
            R1M2.Enabled = command;
            R2M2.Enabled = command;
            R3M2.Enabled = command;
            R4M2.Enabled = command;
            R5M2.Enabled = command;
            R0M3.Enabled = command;
            R1M3.Enabled = command;
            R2M3.Enabled = command;
            R3M3.Enabled = command;
            R4M3.Enabled = command;
            R5M3.Enabled = command;
            R0M4.Enabled = command;
            R1M4.Enabled = command;
            R2M4.Enabled = command;
            R3M4.Enabled = command;
            R4M4.Enabled = command;
            R5M4.Enabled = command;
            LoadRegMemory.Enabled = command;
            SaveRegMemory.Enabled = command;
            RF_A_EN_ComboBox.Enabled = command;
            RF_B_EN_ComboBox.Enabled = command;
            RF_A_PWR_ComboBox.Enabled = command;
            RF_B_PWR_ComboBox.Enabled = command;
            IntNNumUpDown.Enabled = command;
            FracNNumUpDown.Enabled = command;
            ModNumUpDown.Enabled = command;
            ModeIntFracComboBox.Enabled = command;
            RefFTextBox.Enabled = command;
            RDivUpDown.Enabled = command;
            DoubleRefFCheckBox.Enabled = command;
            DivideBy2CheckBox.Enabled = command;
            fPfdScreenLabel.Enabled = command;
            fVcoScreenLabel.Enabled = command;
            fOutAScreenLabel.Enabled = command;
            fOutBScreenLabel.Enabled = command;
            ADivComboBox.Enabled = command;
            PhasePNumericUpDown.Enabled = command;
            RSetTextBox.Enabled = command;
            CPCurrentComboBox.Enabled = command;
            CPLinearityComboBox.Enabled = command;
            CPTestComboBox.Enabled = command;
            CPFastLockCheckBox.Enabled = command;
            CPTriStateOutCheckBox.Enabled = command;
            CPCycleSlipCheckBox.Enabled = command;
            PosPFDCheckBox.Enabled = command;
            InputFreqTextBox.Enabled = command;
            DeltaShowLabel.Enabled = command;
        }

        private void SendStringSerialPort(string text)
        {
            try
                {
                    dontRunHandler = true;
                    _serialPort.WriteLine(text);
                    while(_serialPort.ReadLine() != "OK"){}
                    dontRunHandler = false;
                    textBox.AppendText(Environment.NewLine + DateTime.Now.ToString("HH:mm:ss: ") + "command: '" + text + "' sended");
                    //_serialPort.ReadLine();
                }
            catch
            {
                MessageBox.Show("Device doesn't work", "COM Port Error",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                PortButton_Click(this, new EventArgs());
            }
        }

        private void PortButton_Click(object sender, EventArgs e)
        {
            if (PortButton.Text == "Open Port")
            {
                PortButton.Text = "Close Port";
                OpenPort();

            }
            else if (PortButton.Text == "Close Port")
            {
                PortButton.Text = "Open Port";
                ClosePort();
            }
            
            
        }

        void MyDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (dontRunHandler) return;
            Invoke(new MojDelegat(Spracovanie), e);
        }

        void Spracovanie(object Objekt)
        {
            try
            { // TODO zde si zjistovat na zacasku jestli je ID max2871, jinak vyhodit hlasku a zavrit port. 
                // TODO vycitat info o tom, jestli je int/ext ref, out1, out2 on/off
                // TODO a asi vycist pekne test register a ten soupnout do okna
                string text = _serialPort.ReadLine();
                textBox.AppendText(Environment.NewLine + DateTime.Now.ToString("HH:mm:ss: ") + text);
                if (text == "plo locked")
                    toolStripStatusLabel1.Text = "plo is locked";
                else if (text == "plo isn't locked")
                    toolStripStatusLabel1.Text = "plo isn't locked!";
                else if (text == "plo state is not known")
                    toolStripStatusLabel1.Text = "plo state is not known";
                else
                {
                    string[] separrated = text.Split(' ');
                    if (separrated[0] == "stored_data_1")
                    {
                        R0M1.Text = separrated[1];
                        R1M1.Text = separrated[2];
                        R2M1.Text = separrated[3];
                        R3M1.Text = separrated[4];
                        R4M1.Text = separrated[5];
                        R5M1.Text = separrated[6];
                    }
                    else if (separrated[0] == "stored_data_2")
                    {
                        R0M2.Text = separrated[1];
                        R1M2.Text = separrated[2];
                        R2M2.Text = separrated[3];
                        R3M2.Text = separrated[4];
                        R4M2.Text = separrated[5];
                        R5M2.Text = separrated[6];
                    }
                    else if (separrated[0] == "stored_data_3")
                    {
                        R0M3.Text = separrated[1];
                        R1M3.Text = separrated[2];
                        R2M3.Text = separrated[3];
                        R3M3.Text = separrated[4];
                        R4M3.Text = separrated[5];
                        R5M3.Text = separrated[6];
                    }
                    else if (separrated[0] == "stored_data_4")
                    {
                        R0M4.Text = separrated[1];
                        R1M4.Text = separrated[2];
                        R2M4.Text = separrated[3];
                        R3M4.Text = separrated[4];
                        R4M4.Text = separrated[5];
                        R5M4.Text = separrated[6];
                    }
                }
            }
            catch
            {
                
            }
        }

        private void ClosePort()
        {
            EnableControls(false);
            _serialPort.Close();
        }

        private  void OpenPort()
        {
            try
            {
                _serialPort = new SerialPort(AvaibleCOMsComBox.Text, 115200);
                _serialPort.DtrEnable = true;
                _serialPort.ReadTimeout = 500;
                _serialPort.Open();                             // TODO po otevreni portu zjistit, jestli byl synt. programovan, a jestli ano, nacist data
                _serialPort.NewLine = "\r";
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(MyDataReceivedHandler);

                SaveWorkspaceData();
                EnableControls(true);
            }
            catch
            {
                MessageBox.Show("Cannot open COM port. Please select valid Synthesizer COM port or check connection.", "Invalid COM port", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                PortButton_Click(this, new EventArgs());    // TODO dodelat overeni, jestli se jedna o syntezator. Odesilat z modulu nejaky string ID treba MAX2871byFKU. Kdyz takovy tvar neprijde, napsat, ze takove zarizeni nelze pouzit.
            }
        }
        private string GetFileNamePath(string fileName)
        {
            string actual_dir = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            if (!Directory.Exists(actual_dir + @"\conf\"))
                Directory.CreateDirectory(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\conf\");
            string folder = actual_dir + @"\conf\";
            return folder + fileName;
        }

        private void SaveWorkspaceData()
        {
            try   
            {   
                string fileName = GetFileNamePath(@"saved_workspace.json");

                SaveWindow saved = new SaveWindow
                {
                    Registers = new List<string>
                    {
                        registers[0].string_GetValue(),
                        registers[1].string_GetValue(),
                        registers[2].string_GetValue(),
                        registers[3].string_GetValue(),
                        registers[4].string_GetValue(),
                        registers[5].string_GetValue()
                    },
                    Mem1 = new List<string>
                    {
                        R0M1.Text,
                        R1M1.Text,
                        R2M1.Text,
                        R3M1.Text,
                        R4M1.Text,
                        R5M1.Text,
                    },
                    Mem2 = new List<string>
                    {
                        R0M2.Text,
                        R1M2.Text,
                        R2M2.Text,
                        R3M2.Text,
                        R4M2.Text,
                        R5M2.Text,
                    },
                    Mem3 = new List<string>
                    {
                        R0M3.Text,
                        R1M3.Text,
                        R2M3.Text,
                        R3M3.Text,
                        R4M3.Text,
                        R5M3.Text,
                    },
                    Mem4 = new List<string>
                    {
                        R0M4.Text,
                        R1M4.Text,
                        R2M4.Text,
                        R3M4.Text,
                        R4M4.Text,
                        R5M4.Text,
                    },
                    COM_port = AvaibleCOMsComBox.Text
                };

                // serialize JSON to a string and then write string to a file
                File.WriteAllText(fileName, JsonConvert.SerializeObject(saved, Formatting.Indented));
            }
            catch
            {
                MessageBox.Show("When saving worskspace data occurs error!", "Error Catch", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSavedWorkspaceData()
        {   
            string fileName = GetFileNamePath(@"saved_workspace.json");
            // if saved data doesn't exist, create it from default textboxes data
            if (!File.Exists(fileName))
            {
                SaveWindow saved = new SaveWindow
                {
                    Registers = new List<string>
                    {
                        registers[0].string_GetValue(),
                        registers[1].string_GetValue(),
                        registers[2].string_GetValue(),
                        registers[3].string_GetValue(),
                        registers[4].string_GetValue(),
                        registers[5].string_GetValue()
                    },
                    Mem1 = new List<string>
                    {
                        R0M1.Text,
                        R1M1.Text,
                        R2M1.Text,
                        R3M1.Text,
                        R4M1.Text,
                        R5M1.Text,
                    },
                    Mem2 = new List<string>
                    {
                        R0M2.Text,
                        R1M2.Text,
                        R2M2.Text,
                        R3M2.Text,
                        R4M2.Text,
                        R5M2.Text,
                    },
                    Mem3 = new List<string>
                    {
                        R0M3.Text,
                        R1M3.Text,
                        R2M3.Text,
                        R3M3.Text,
                        R4M3.Text,
                        R5M3.Text,
                    },
                    Mem4 = new List<string>
                    {
                        R0M4.Text,
                        R1M4.Text,
                        R2M4.Text,
                        R3M4.Text,
                        R4M4.Text,
                        R5M4.Text,
                    },
                    COM_port = AvaibleCOMsComBox.Text
                };
                // serialize JSON to a string and then write string to a file
                File.WriteAllText(fileName, JsonConvert.SerializeObject(saved, Formatting.Indented));
            }
            // if exist, load it into workspace
            else
            {
                SaveWindow settings_loaded = JsonConvert.DeserializeObject<SaveWindow>(File.ReadAllText(fileName));
                AvaibleCOMsComBox.Text = settings_loaded.COM_port;
                LoadRegistersFromFile(settings_loaded);
            }
        }

        private void LoadRegistersFromFile(SaveWindow data)
        {
            registers[0].SetValue(data.Registers[0]);
            registers[1].SetValue(data.Registers[1]);
            registers[2].SetValue(data.Registers[2]);
            registers[3].SetValue(data.Registers[3]);
            registers[4].SetValue(data.Registers[4]);
            registers[5].SetValue(data.Registers[5]);
            R0M1.Text = data.Mem1[0];
            R1M1.Text = data.Mem1[1];
            R2M1.Text = data.Mem1[2];
            R3M1.Text = data.Mem1[3];
            R4M1.Text = data.Mem1[4];
            R5M1.Text = data.Mem1[5];
            R0M2.Text = data.Mem2[0];
            R1M2.Text = data.Mem2[1];
            R2M2.Text = data.Mem2[2];
            R3M2.Text = data.Mem2[3];
            R4M2.Text = data.Mem2[4];
            R5M2.Text = data.Mem2[5];
            R0M3.Text = data.Mem3[0];
            R1M3.Text = data.Mem3[1];
            R2M3.Text = data.Mem3[2];
            R3M3.Text = data.Mem3[3];
            R4M3.Text = data.Mem3[4];
            R5M3.Text = data.Mem3[5];
            R0M4.Text = data.Mem4[0];
            R1M4.Text = data.Mem4[1];
            R2M4.Text = data.Mem4[2];
            R3M4.Text = data.Mem4[3];
            R4M4.Text = data.Mem4[4];
            R5M4.Text = data.Mem4[5];
            GetAllFromRegisters();
        }

         private void GetAllFromRegisters()
        {
            GetCPCurrentFromTextBox();
            GetAllFromReg4();
            GetAllFromReg2();
            GetAllFromReg1();
            GetAllFromReg0();
            GetFPfdFreq();
            GetCalcFreq(); 
            
        }

        private void GetAllFromReg0()
        {
            UInt32 reg = registers[0].uint32_GetValue();
            GetFracIntModeStatusFromRegister(reg);
            GetIntNValueFromRegister(reg);
            GetFracNValueFromRegister(reg);
        }

        private void GetAllFromReg1()
        {
            UInt32 reg = registers[1].uint32_GetValue();
            GetModValueFromRegister(reg);
            GetPhasePValueFromRegister(reg);
            GetCPLinearityFromRegister(reg);
        }

        private void GetAllFromReg2()
        {
            UInt32 reg = registers[2].uint32_GetValue();
            GetRefDoublerStatusFromRegister(reg);
            GetRefDividerStatusFromRegister(reg);
            GetRDivValueFromRegister(reg);
            GetCPCurrentIndexFromRegister(reg);
        }

        private void GetAllFromReg4()
        {
            UInt32 reg = registers[4].uint32_GetValue();
            GetOutAENStatusFromRegister(reg);
            GetOutAPwrStatusFromRegister(reg);
            GetADividerValueFromRegister(reg);
        }

        private void GetFracIntModeStatusFromRegister(UInt32 dataReg0)
        {
            dataReg0 = (UInt32)((dataReg0 & (1 << 31)) >> 31);
            ModeIntFracComboBox.SelectedIndex = (int)(dataReg0);
            if (dataReg0 == 1)
            {
                IntNNumUpDown.Minimum = 16;
                IntNNumUpDown.Maximum = 65535;
            }
            else
            {
                IntNNumUpDown.Minimum = 19;
                IntNNumUpDown.Maximum = 4091;
            }
        }

        private void GetIntNValueFromRegister(UInt32 dataReg0)
        {
            UInt16 IntN = (UInt16)((dataReg0 & 0b01111111111111111000000000000000) >> 15);

            if (IntN < IntNNumUpDown.Minimum)
                IntN = Convert.ToUInt16(IntNNumUpDown.Minimum);
            else if (IntN > IntNNumUpDown.Maximum)
                IntN = Convert.ToUInt16(IntNNumUpDown.Maximum);

            IntNNumUpDown.Value = IntN;
        }

        private void GetFracNValueFromRegister(UInt32 dataReg0)
        {
            UInt16 FracN = (UInt16)((dataReg0 & 0b111111111111000) >> 3);
            FracNNumUpDown.Value = FracN;
        }

        private void GetModValueFromRegister(UInt32 dataReg1)
        {
            UInt16 Mod = (UInt16)((dataReg1 & 0b111111111111000) >> 3);
            ModNumUpDown.Value = Mod;
            FracNNumUpDown.Maximum = ModNumUpDown.Value-1;
        }

        private void GetPhasePValueFromRegister(UInt32 dataReg1)
        {
            UInt16 PhaseP = (UInt16)((dataReg1 & 0b111111111111000000000000000) >> 15);
            PhasePNumericUpDown.Value = PhaseP;
        }

        private void GetCPLinearityFromRegister(UInt32 dataReg1)
        {
            UInt16 CPLinearity = (UInt16)((dataReg1 & ((1<<30) | (1<<29))) >> 29);
            CPLinearityComboBox.SelectedIndex = (int)CPLinearity;
        }

        private void GetRefDoublerStatusFromRegister(UInt32 dataReg2)
        {
            DoubleRefFCheckBox.Checked = Convert.ToBoolean((dataReg2 & (1 << 25)) >> 25);
        }
        
        private void GetRefDividerStatusFromRegister(UInt32 dataReg2)
        {
            DivideBy2CheckBox.Checked = Convert.ToBoolean((dataReg2 & (1 << 24)) >> 24);
        }

        private void GetRDivValueFromRegister(UInt32 dataReg2)
        {
            UInt16 RDiv = (UInt16)((dataReg2 & 0b111111111100000000000000) >> 14);
            RDivUpDown.Value = RDiv;
        }

        private void GetCPCurrentIndexFromRegister(UInt32 dataReg2)
        {
            UInt16 CPCurrentIndex = (UInt16)((dataReg2 & ((1<<12) | (1<<11) | (1<<10) | (1<<9))) >> 9);
            CPCurrentComboBox.SelectedIndex = (int)CPCurrentIndex;
        }

        private void GetCPCurrentFromTextBox()
        {
            // TODO ulozit hodnotu RSET do defaults a saved_workspace, pri startu ji nacist
            UInt16 R_set = Convert.ToUInt16(RSetTextBox.Text);
            IList<string> list = new List<string>();
            decimal I_cp;
            for (UInt16 cp = 0; cp < 16; cp++)
            {
                I_cp = (decimal)(1.63*1000)/(decimal)(R_set) * (1 + cp);
                I_cp = Math.Round(I_cp, 3, MidpointRounding.AwayFromZero);
                list.Add(Convert.ToString(I_cp) + " mA");
            }
            CPCurrentComboBox.DataSource = list;

        }

        private void GetOutAENStatusFromRegister(UInt32 dataReg4)
        {
            RF_A_EN_ComboBox.SelectedIndex = (int)((dataReg4 & (1<<5)) >> 5);
        }

        private void GetOutAPwrStatusFromRegister(UInt32 dataReg4)
        {
            RF_A_PWR_ComboBox.SelectedIndex = (int)((dataReg4 & 0b11000) >> 3);
        }

        private void GetADividerValueFromRegister(UInt32 dataReg4)
        {
            UInt16 ADiv = (UInt16)((dataReg4 & ((1<<22) | (1<<21) | (1<<20))) >> 20);
            ADivComboBox.SelectedIndex = ADiv;
        }

        private void GetCalcFreq()
        {
            UInt16 DIVA = (UInt16)(1 << ADivComboBox.SelectedIndex);

            string f_pfd_string = fPfdScreenLabel.Text;
            f_pfd_string = f_pfd_string.Replace(" ", string.Empty);
            f_pfd_string = f_pfd_string.Replace(".", ",");
            decimal f_pfd = Convert.ToDecimal(f_pfd_string);

            decimal f_out_A = 0;
            decimal f_vco = 0;

            // TODO pohlidat f_vco

            if (ModeIntFracComboBox.SelectedIndex == 1)
            {
                f_out_A = ((f_pfd*IntNNumUpDown.Value)/(DIVA));
            }
            else
            {
                f_out_A = (f_pfd/DIVA)*(IntNNumUpDown.Value+(FracNNumUpDown.Value/(ModNumUpDown.Value*1.0M)));
            }
            f_vco = f_out_A*DIVA;
            if ((f_vco < 3000) || (f_vco > 6000))
            {
                fVcoScreenLabel.ForeColor = System.Drawing.Color.Red;
                IntNNumUpDown.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                fVcoScreenLabel.ForeColor = System.Drawing.Color.Black;
                IntNNumUpDown.BackColor = System.Drawing.Color.White;
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

            fOutAScreenLabel.Text = string.Format("{0:000},{1:000} {2:000} {3:0}", f_out_A_MHz, thousandths, millionths, rounding);

            UInt16 f_vco_MHz = (UInt16)(f_vco);
            UInt32 f_vco_kHz = (UInt32)(f_vco*1000);
            UInt64 f_vco_Hz = (UInt64)(f_vco*1000000);
            UInt64 f_vco_mHz = (UInt64)(f_vco*1000000000);
            thousandths = (UInt16)(f_vco_kHz - f_vco_MHz*1000);
            millionths = (UInt16)(f_vco_Hz - (UInt64)(f_vco_MHz)*1000000-(UInt64)(thousandths)*1000);
            billionths = (UInt16)(f_vco_mHz - (UInt64)(f_vco_Hz)*1000);
            bill_f = (float)((billionths)/100.0);
            rounding  = Math.Round((float)(billionths)/100.0, MidpointRounding.AwayFromZero);

            fVcoScreenLabel.Text = string.Format("{0:000},{1:000} {2:000} {3:0}", f_vco_MHz, thousandths, millionths, rounding);
        }

        private void GetFPfdFreq()
        {
            // TODO osetrit fpfd
            string f_pfd_string = RefFTextBox.Text;
            f_pfd_string = f_pfd_string.Replace(" ", string.Empty);
            f_pfd_string = f_pfd_string.Replace(".", ",");
            decimal f_ref = decimal.Parse(f_pfd_string);
            UInt16 doubler = Convert.ToUInt16(DoubleRefFCheckBox.Checked);
            UInt16 divider2 = Convert.ToUInt16(DivideBy2CheckBox.Checked);
            decimal f_pfd = f_ref * ((1 + doubler) / (RDivUpDown.Value * (1 + divider2)));

            UInt16 f_pfd_MHz = (UInt16)(f_pfd);
            UInt32 f_pfd_kHz = (UInt32)(f_pfd*1000);
            UInt64 f_pfd_Hz = (UInt64)(f_pfd*1000000);
            UInt64 f_vco_mHz = (UInt64)(f_pfd*1000000000);
            UInt16 thousandths = (UInt16)(f_pfd_kHz - f_pfd_MHz*1000);
            UInt16 millionths = (UInt16)(f_pfd_Hz - (UInt64)(f_pfd_MHz)*1000000-(UInt64)(thousandths)*1000);
            UInt16 billionths = (UInt16)(f_vco_mHz - (UInt64)(f_pfd_Hz)*1000);
            float bill_f = (float)((billionths)/100.0);
            double rounding  = Math.Round((float)(billionths)/100.0, MidpointRounding.AwayFromZero);

            fPfdScreenLabel.Text = string.Format("{0},{1:000} {2:000} {3:0}", f_pfd_MHz, thousandths, millionths, rounding);
        }

        private void ChangeReg0IntFracMode()
        {
            UInt32 reg0 = registers[0].uint32_GetValue();
            UInt32 reg2 = registers[2].uint32_GetValue();
            
            if (ModeIntFracComboBox.SelectedIndex == 0)
            {
                reg0 &= ~unchecked((UInt32)(1<<31));
                reg2 &= ~unchecked((UInt32)(1<<8));
                IntNNumUpDown.Minimum = 19;
                IntNNumUpDown.Maximum = 4091;

            }
            else if (RF_A_EN_ComboBox.SelectedIndex == 1)
            {
                reg0 |= unchecked((UInt32)(1<<31));
                reg2 |= unchecked((UInt32)(1<<8));
                IntNNumUpDown.Minimum = 16;
                IntNNumUpDown.Maximum = 65535;
            }
            registers[0].SetValue(reg0);
            registers[2].SetValue(reg2);
        }

        // Zapise a prevede hodnotu IntN do Reg0
        private void ChangeReg0IntNValue()
        {
            UInt32 reg = registers[0].uint32_GetValue();
            reg &= ~(UInt32)(0b01111111111111111000000000000000);
            reg += Convert.ToUInt32(IntNNumUpDown.Value) << 15;
            registers[0].SetValue(reg);
        }

        private void ChangeReg0FracNValue()
        {
            UInt32 reg = registers[0].uint32_GetValue();
            reg &= ~(UInt32)(0b00000000000000000111111111111000);
            reg += Convert.ToUInt32(FracNNumUpDown.Value) << 3;
            registers[0].SetValue(reg);
        }

        private void ChangeReg1ModValue()
        {
            UInt32 reg = registers[1].uint32_GetValue();
            reg &= ~(UInt32)(0b00000000000000000111111111111000);
            reg += Convert.ToUInt32(ModNumUpDown.Value) << 3;
            registers[1].SetValue(reg);
            FracNNumUpDown.Maximum = ModNumUpDown.Value - 1;
        }

        private void ChangeReg1PhaseP()
        {
            UInt32 reg = registers[1].uint32_GetValue();
            reg &= ~(UInt32)(0b1111111111111000000000000000);
            reg += Convert.ToUInt32(PhasePNumericUpDown.Value) << 15;
            registers[1].SetValue(reg);
        }

        private void ChangeReg1CPLinearity()
        {
            UInt32 reg = registers[1].uint32_GetValue();
            reg &= ~(UInt32)((1<<30) | (1<<29));
            reg += Convert.ToUInt32(CPLinearityComboBox.SelectedIndex) << 29;
            registers[1].SetValue(reg);
        }

        private void ChangeReg2RefDoubler()
        {
            UInt32 reg = registers[2].uint32_GetValue();
            if (DoubleRefFCheckBox.Checked == true)
            {
                reg |= unchecked((UInt32)(1<<25));
                if ((IntNNumUpDown.Value / 2) < IntNNumUpDown.Minimum)
                    IntNNumUpDown.Value = IntNNumUpDown.Minimum;
                else
                    IntNNumUpDown.Value = IntNNumUpDown.Value/2;
            }
            else
            {
                reg &= ~unchecked((UInt32)(1<<25));
                if ((IntNNumUpDown.Value * 2) > IntNNumUpDown.Maximum)
                    IntNNumUpDown.Value = IntNNumUpDown.Maximum;
                else
                    IntNNumUpDown.Value = IntNNumUpDown.Value*2;

            }
            registers[2].SetValue(reg);
        }

        private void ChangeReg2RefDivider()
        {
            UInt32 reg = registers[2].uint32_GetValue();
            if (DivideBy2CheckBox.Checked == true)
            {
                reg |= unchecked((UInt32)(1<<24));
                if ((IntNNumUpDown.Value * 2) > IntNNumUpDown.Maximum)
                    IntNNumUpDown.Value = IntNNumUpDown.Maximum;
                else
                    IntNNumUpDown.Value = IntNNumUpDown.Value*2;
            }
            else
            {
                reg &= ~unchecked((UInt32)(1<<24));
                if ((IntNNumUpDown.Value / 2) < IntNNumUpDown.Minimum)
                    IntNNumUpDown.Value = IntNNumUpDown.Minimum;
                else
                    IntNNumUpDown.Value = IntNNumUpDown.Value/2;

            }
            registers[2].SetValue(reg);
        }

        private void ChangeReg2RDiv()
        {
            UInt32 reg = registers[2].uint32_GetValue();
            reg &= ~(UInt32)(0b111111111100000000000000);
            reg += Convert.ToUInt32(RDivUpDown.Value) << 14;
            registers[2].SetValue(reg);
        }

        private void ChangeReg2CPCurrent()
        {
            UInt32 reg = registers[2].uint32_GetValue();
            reg &= ~(UInt32)((1<<12) | (1<<11) | (1<<10) | (1<<9));
            reg += Convert.ToUInt32(CPCurrentComboBox.SelectedIndex) << 9;
            registers[2].SetValue(reg);
        }

        private void ChangeReg4OutAEn()
        {
            UInt32 reg = registers[4].uint32_GetValue();
            if (RF_A_EN_ComboBox.SelectedIndex == 0)
            {
                reg &= ~((UInt32)(1<<5));
            }
            else if (RF_A_EN_ComboBox.SelectedIndex == 1)
            {
                reg |= (UInt32)(1<<5);
            }
            registers[4].SetValue(reg);
        }

        private void ChangeReg4OutAPwr()
        {
            UInt32 reg = registers[4].uint32_GetValue();
            switch (RF_A_PWR_ComboBox.SelectedIndex)
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

        private void ChangeReg4ADiv()
        {
            UInt32 reg = registers[4].uint32_GetValue();
            reg &= ~(UInt32)( (1<<22) | (1<<21) | (1<<20) );
            reg += Convert.ToUInt32(ADivComboBox.SelectedIndex) << 20;
            registers[4].SetValue(reg);
        }

        private void Out1Button_Click(object sender, EventArgs e)
        {
            if (Out1Button.Text == "Out 1 On")
            {
                Out1Button.Text = "Out 1 Off";
                SendStringSerialPort("out 1 on");
            }
            else if (Out1Button.Text == "Out 1 Off")
            {
                Out1Button.Text = "Out 1 On";
                SendStringSerialPort("out 1 off");
            }
        }

        private void Out2Button_Click(object sender, EventArgs e)
        {
            if (Out2Button.Text == "Out 2 On")
            {
                Out2Button.Text = "Out 2 Off";
                SendStringSerialPort("out 2 on");
            }

            else if (Out2Button.Text == "Out 2 Off")
            {
                Out2Button.Text = "Out 2 On";
                SendStringSerialPort("out 2 off");
            }
        }

        private void RefButton_Click(object sender, EventArgs e)
        {
            if (RefButton.Text == "Ext Ref")
            {
                RefButton.Text = "Int Ref";
                SendStringSerialPort("ref ext");
            }

            else if (RefButton.Text == "Int Ref")
            {
                RefButton.Text = "Ext Ref";
                SendStringSerialPort("ref int");
            }
        }

        private void PloInitButton_Click(object sender, EventArgs e)
        {
            SendStringSerialPort("PLO init");
        }

        private void Reg0TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyFormat.CheckIfHasHexInput(e);
            if (e.KeyChar == (char)13)
            {
                CheckAndApplyReg0Changes();
            }
        }

        private void Reg1TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyFormat.CheckIfHasHexInput(e);
            if (e.KeyChar == (char)13)
            {
                CheckAndApplyReg1Changes();
            }
        }

        private void Reg2TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyFormat.CheckIfHasHexInput(e);
            if (e.KeyChar == (char)13)
            {
                CheckAndApplyReg2Changes();
            }
        }

        private void Reg3TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyFormat.CheckIfHasHexInput(e);
            if (e.KeyChar == (char)13)
            {
                CheckAndApplyReg3Changes();
            }
        }

        private void Reg4TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyFormat.CheckIfHasHexInput(e);
            if (e.KeyChar == (char)13)
            {
                CheckAndApplyReg4Changes();
            }
        }

        private void Reg5TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyFormat.CheckIfHasHexInput(e);
            if (e.KeyChar == (char)13)
            {
                CheckAndApplyReg5Changes();
            }
        }

        private void CheckAndApplyReg0Changes()
        {
            registers[0].SetValue(Reg0TextBox.Text);
            if ((Reg0TextBox.Enabled == true) && (!registers[0].string_GetValue().Equals(old_reg0)))
            {
                GetAllFromReg0();
                ApplyChangeReg0();
                GetCalcFreq();
                
            }
        }

        private void CheckAndApplyReg1Changes()
        {
            registers[1].SetValue(Reg1TextBox.Text);
            if ((Reg1TextBox.Enabled == true) && (!registers[1].string_GetValue().Equals(old_reg1)))
            {
                GetAllFromReg1();
                ApplyChangeReg1();
                ApplyChangeReg0();
                GetCalcFreq();
            }
        }

        private void CheckAndApplyReg2Changes()
        {
            registers[2].SetValue(Reg2TextBox.Text);
            if ((Reg2TextBox.Enabled == true) && (!registers[2].string_GetValue().Equals(old_reg2)))
            {
                GetAllFromReg2();
                ApplyChangeReg2();
                ApplyChangeReg0();
                GetCalcFreq();
            }
        }

        private void CheckAndApplyReg3Changes()
        {
            registers[3].SetValue(Reg3TextBox.Text);
            if ((Reg3TextBox.Enabled == true) && (!registers[3].string_GetValue().Equals(old_reg3)))
            {
                ApplyChangeReg3();
            }
        }

        private void CheckAndApplyReg4Changes()
        {
            registers[4].SetValue(Reg4TextBox.Text);
            if ((Reg4TextBox.Enabled == true) && (!registers[4].string_GetValue().Equals(old_reg4)))
            {
                GetAllFromReg4();
                ApplyChangeReg4();
                GetCalcFreq();
            }
        }

        private void CheckAndApplyReg5Changes()
        {
            registers[5].SetValue(Reg5TextBox.Text);
            if ((Reg5TextBox.Enabled == true) && (!registers[5].string_GetValue().Equals(old_reg5)))
            {
                ApplyChangeReg5();
            }
        }

        private void CheckAndApllyChangesForm1_Click(object sender, EventArgs e)
        {
            Reg0Label.Focus();
        }


        private void ApplyChangeReg0()
        {
            string data = String.Format("plo set_register {0}", registers[0].string_GetValue());
            old_reg0 = registers[0].string_GetValue();
            SendStringSerialPort(data);
        }

        private void ApplyChangeReg1()
        {
            string data = String.Format("plo set_register {0}", registers[1].string_GetValue());
            old_reg1 = registers[1].string_GetValue();
            SendStringSerialPort(data);
        }

        private void ApplyChangeReg2()
        {
            string data = String.Format("plo set_register {0}", registers[2].string_GetValue());
            old_reg2 = registers[2].string_GetValue();
            SendStringSerialPort(data);
        }

        private void ApplyChangeReg3()
        {
            string data = String.Format("plo set_register {0}", registers[3].string_GetValue());
            old_reg3 = registers[3].string_GetValue();
            SendStringSerialPort(data);
        }

        private void ApplyChangeReg4()
        {
            string data = String.Format("plo set_register {0}", registers[4].string_GetValue());
            old_reg4 = registers[4].string_GetValue();
            SendStringSerialPort(data);
        }

        private void ApplyChangeReg5()
        {
            string data = String.Format("plo set_register {0}", registers[5].string_GetValue());
            old_reg5 = registers[5].string_GetValue();
            SendStringSerialPort(data);
        }

        private string GetControlRegister()
        {
            UInt32 control_register = 0;

            if (Out1Button.Text == "Out 1 On")
                control_register &= unchecked((UInt32)(~(1<<0)));
            else
                control_register |= (1<<0);

            if (Out2Button.Text == "Out 2 On")
                control_register &= unchecked((UInt32)(~(1<<1)));
            else
                control_register |= (1<<1);

            if (RefButton.Text == "Ext Ref")
                control_register &= unchecked((UInt32)(~(1<<2)));
            else
                control_register |= (1<<2);

            return Convert.ToString(control_register, 16);
        }

        private void SaveRegsMemory1()
        {
            string data = String.Format("plo data 1 {0} {1} {2} {3} {4} {5} {6}", 
                    R0M1.Text, R1M1.Text, R2M1.Text, 
                    R3M1.Text, R4M1.Text, R5M1.Text,
                    GetControlRegister() );
            SendStringSerialPort(data);
        }

        private void SaveRegsMemory2()
        {
            string data = String.Format("plo data 2 {0} {1} {2} {3} {4} {5} {6}", 
                    R0M2.Text, R1M2.Text, R2M2.Text, 
                    R3M2.Text, R4M2.Text, R5M2.Text,
                    GetControlRegister() );
            SendStringSerialPort(data);
        }

        private void SaveRegsMemory3()
        {
            string data = String.Format("plo data 3 {0} {1} {2} {3} {4} {5} {6}", 
                    R0M3.Text, R1M3.Text, R2M3.Text, 
                    R3M3.Text, R4M3.Text, R5M3.Text,
                    GetControlRegister() );
            SendStringSerialPort(data);
        }

        private void SaveRegsMemory4()
        {
            string data = String.Format("plo data 4 {0} {1} {2} {3} {4} {5} {6}", 
                    R0M4.Text, R1M4.Text, R2M4.Text, 
                    R3M4.Text, R4M4.Text, R5M4.Text,
                    GetControlRegister() );
            SendStringSerialPort(data);
        }

        private void CleanSavedRegisters()
        {
            string data = String.Format("plo data clean");
            SendStringSerialPort(data);
        }

        private void SetAsDefaultRegButton_Click(object sender, EventArgs e)
        {
            string fileName = GetFileNamePath(@"default.json");  
     
            SaveWindow defaults = new SaveWindow
            {
                Registers = new List<string>
                {
                    registers[0].string_GetValue(),
                    registers[1].string_GetValue(),
                    registers[2].string_GetValue(),
                    registers[3].string_GetValue(),
                    registers[4].string_GetValue(),
                    registers[5].string_GetValue()
                }
            };

            // serialize JSON to a string and then write string to a file
            File.WriteAllText(fileName, JsonConvert.SerializeObject(defaults, Formatting.Indented));
        }

        private void LoadDefRegButton_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = GetFileNamePath(@"default.json");

                SaveWindow settings_loaded = JsonConvert.DeserializeObject<SaveWindow>(File.ReadAllText(fileName));
                LoadRegistersFromFile(settings_loaded);
                ForceLoadRegButton_Click(this, new EventArgs());

            }
            catch
            {
                MessageBox.Show("File default.json with include settings for registers, doesn't exist. First create it by click to Set As Def Button", "File defaults.txt doesn't exist", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ForceLoadRegButton_Click(object sender, EventArgs e)
        {
            GetAllFromRegisters();

            ApplyChangeReg5();
            //Thread.Sleep(1);
            ApplyChangeReg4();
            //Thread.Sleep(1);
            ApplyChangeReg3();
            //Thread.Sleep(1);
            ApplyChangeReg2();
            //Thread.Sleep(1);
            ApplyChangeReg1();
            //Thread.Sleep(1);
            ApplyChangeReg0();
            //Thread.Sleep(1);
        }

        private void AvaibleCOMsComBox_DropDown(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            AvaibleCOMsComBox.DataSource = ports;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveWorkspaceData();
        }

        private void WriteR0Button_Click(object sender, EventArgs e)
        {
            CheckAndApplyReg0Changes();
        }

        private void WriteR1Button_Click(object sender, EventArgs e)
        {
            CheckAndApplyReg1Changes();
        }

        private void WriteR2Button_Click(object sender, EventArgs e)
        {
            CheckAndApplyReg2Changes();
        }

        private void WriteR3Button_Click(object sender, EventArgs e)
        {
            CheckAndApplyReg3Changes();
        }

        private void WriteR4Button_Click(object sender, EventArgs e)
        {
            CheckAndApplyReg4Changes();
        }

        private void WriteR5Button_Click(object sender, EventArgs e)
        {
            CheckAndApplyReg5Changes();
        }

        private void LoadRegMemory_Click(object sender, EventArgs e)
        {
            SendStringSerialPort("plo data stored?");
        }

        private void SaveRegMemory_Click(object sender, EventArgs e)
        {
            CleanSavedRegisters();
            SaveRegsMemory1();
            SaveRegsMemory2();
            SaveRegsMemory3();
            SaveRegsMemory4();
        }

        private void RF_A_EN_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Reg4TextBox.Enabled == true)
            {
                ChangeReg4OutAEn();
                ApplyChangeReg4();
            }
        }

        private void RF_A_PWR_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Reg4TextBox.Enabled == true)
            {
                ChangeReg4OutAPwr();
                ApplyChangeReg4();
            }
        }

        private void ModeIntFracComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Reg0TextBox.Enabled == true)
            {
                ChangeReg0IntFracMode();
                ApplyChangeReg2();
                ApplyChangeReg0();
                GetCalcFreq();
            }
        }

        private void IntNNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (Reg0TextBox.Enabled == true)
            {
                ChangeReg0IntNValue();
                ApplyChangeReg0();
                GetCalcFreq();
            }
        }

        private void FracNNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (Reg0TextBox.Enabled == true)
            {
                ChangeReg0FracNValue();
                ApplyChangeReg0();
                GetCalcFreq();
            }
        }

        private void ModNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (Reg0TextBox.Enabled == true)
            {
                ChangeReg1ModValue();
                ApplyChangeReg1();
                ApplyChangeReg0();
                GetCalcFreq();
            }
        }

        private void FracNScrollHandlerFunction(object sender, MouseEventArgs e)
        {
            MyFormat.ScrollHandlerFunction(FracNNumUpDown, e);
        }

        private void IntNScrollHandlerFunction(object sender, MouseEventArgs e)
        {
            MyFormat.ScrollHandlerFunction(IntNNumUpDown, e);
        }

        private void ModScrollHandlerFunction(object sender, MouseEventArgs e)
        {
            MyFormat.ScrollHandlerFunction(ModNumUpDown, e);
        }

        private void RDivScrollHandlerFunction(object sender, MouseEventArgs e)
        {
            MyFormat.ScrollHandlerFunction(RDivUpDown, e);
        }

        private void PhasePScrollHandlerFunction(object sender, MouseEventArgs e)
        {
            MyFormat.ScrollHandlerFunction(PhasePNumericUpDown, e);
        }

        private void RefFTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetFPfdFreq();
                GetCalcFreq();
            }
        }

        private void RefFTextBox_LostFocus(object sender, EventArgs e)
        {
            GetFPfdFreq();
            GetCalcFreq();
        }

        private void RefFTextBox_TextChanged(object sender, EventArgs e)
        {
            MyFormat.CheckIfHasDecimalInput(RefFTextBox);
        }

        private void Reg0TextBox_LostFocus(object sender, EventArgs e)
        {
            CheckAndApplyReg0Changes();
        }

        private void Reg1TextBox_LostFocus(object sender, EventArgs e)
        {
            CheckAndApplyReg1Changes();
        }

        private void Reg2TextBox_LostFocus(object sender, EventArgs e)
        {
            CheckAndApplyReg2Changes();
        }

        private void Reg3TextBox_LostFocus(object sender, EventArgs e)
        {
            CheckAndApplyReg3Changes();
        }

        private void Reg4TextBox_LostFocus(object sender, EventArgs e)
        {
            CheckAndApplyReg4Changes();
        }

        private void Reg5TextBox_LostFocus(object sender, EventArgs e)
        {
            CheckAndApplyReg5Changes();
        }

        private void RegistersPage_Click(object sender, EventArgs e)
        {
            Reg0Label.Focus();
        }

        private void DoubleRefFCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Reg0TextBox.Enabled == true) // TODO prefdelat na stav port otevren tlacitko
            {
                ChangeReg2RefDoubler();
                ApplyChangeReg2();
                ApplyChangeReg0();
                GetFPfdFreq();
                GetCalcFreq();
            }
        }

        private void DivideBy2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Reg0TextBox.Enabled == true)
            {
                ChangeReg2RefDivider();
                ApplyChangeReg2();
                ApplyChangeReg0();
                GetFPfdFreq();
                GetCalcFreq();
            }
        }

        private void RDivUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (Reg0TextBox.Enabled == true)
            {
                ChangeReg2RDiv();
                ApplyChangeReg2();
                ApplyChangeReg0();
                GetFPfdFreq();
                GetCalcFreq();
            }
        }

        private void ADivComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Reg0TextBox.Enabled == true)
            {
                ChangeReg4ADiv();
                ApplyChangeReg4();
                GetFPfdFreq();
                GetCalcFreq();
            }
        }

        private void PhasePNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(Reg0TextBox.Enabled == true)
            {
                ChangeReg1PhaseP();
                ApplyChangeReg1();
            }
        }

        private void RSetTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RSetTextBox_LostFocus(sender, e);
            }
        }

        private void RSetTextBox_LostFocus(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(RSetTextBox.Text, out value))
            {
                if (value > 10000)
                    RSetTextBox.Text = "10000";
                else if (value < 2700)
                    RSetTextBox.Text = "2700";
            }
            GetCPCurrentFromTextBox();
            GetCalcFreq();
        }

        private void RSetTextBox_TextChanged(object sender, EventArgs e)
        {
            MyFormat.CheckIfHasIntegerInput(RSetTextBox);
        }

        private void CPCurrentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Reg0TextBox.Enabled == true)
            {
                ChangeReg2CPCurrent();
                ApplyChangeReg2();
                ApplyChangeReg0();
            }
        }

        private void CPLinearityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Reg0TextBox.Enabled == true)
            {
                ChangeReg1CPLinearity();
                ApplyChangeReg1();
            }
        }

        private void InputFreqTextBox_TextChanged(object sender, EventArgs e)
        {
            MyFormat.CheckIfHasDecimalInput(RefFTextBox);
        }

        private void CalcSynthesizerRegValuesFromInpFreq()
        {
            string f_ref_string = RefFTextBox.Text;
            f_ref_string = f_ref_string.Replace(" ", string.Empty);
            f_ref_string = f_ref_string.Replace(".", ",");

            string f_input_string = InputFreqTextBox.Text;
            f_input_string = f_input_string.Replace(" ", string.Empty);
            f_input_string = f_input_string.Replace(".", ",");

            decimal f_ref = decimal.Parse(f_ref_string);
            decimal f_input = decimal.Parse(f_input_string);

            RDivUpDown.Value = 1;

            if (f_input >= 3000 && f_input <= 6000)
            {
                ADivComboBox.SelectedIndex = 0;
            }
            else if (f_input >= 1500 && f_input < 3000)
            {
                ADivComboBox.SelectedIndex = 1;
            }
            else if (f_input >= 750 && f_input < 1500)
            {
                ADivComboBox.SelectedIndex = 2;
            }
            else if (f_input >= 375 && f_input < 750)
            {
                ADivComboBox.SelectedIndex = 3;
            }
            else if (f_input >= 187.5M && f_input < 375)
            {
                ADivComboBox.SelectedIndex = 4;
            }
            else if (f_input >= 93.75M && f_input < 187.5M)
            {
                ADivComboBox.SelectedIndex = 5;
            }
            else if (f_input >= 46.875M && f_input < 93.75M)
            {
                ADivComboBox.SelectedIndex = 6;
            }
            else if (f_input >= 23.5M && f_input < 46.875M)
            {
                ADivComboBox.SelectedIndex = 7;
            }
            else if (f_input >= 1500 && f_input < 3000)
            {
                ADivComboBox.SelectedIndex = 8;
            }

            UInt16 DIVA = (UInt16)(1 << ADivComboBox.SelectedIndex);
            decimal IntN = (f_input*DIVA/(f_ref/RDivUpDown.Value));
            decimal zbytek = IntN-(UInt16)IntN;

            if (zbytek>0)
            {
                Fraction pokus = new Fraction();
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
                        pokus = RealToFraction((double)zbytek, accuracy);
                        //zaloha[cnt] = pokus;
                        cnt++;
                        accuracy = accuracy*10;
                    } while ((pokus.D < 2 || pokus.D > 4095) && accuracy <= 0.00001*correction);
                    if ((pokus.D < 2 || pokus.D > 4095))
                    {

                        RDivUpDown.Value = RDivUpDown.Value + 1;
                        IntN = (f_input*DIVA/(f_ref/RDivUpDown.Value));
                        zbytek = IntN-(UInt16)IntN;
                        if (IntN > 4091)
                        {
                            correction = correction * 10;
                            RDivUpDown.Value = RDivUpDown.Value - 1;
                            IntN = (f_input*DIVA/(f_ref/RDivUpDown.Value));
                            zbytek = IntN-(UInt16)IntN;
                        }
                    }
                } while((pokus.D < 2 || pokus.D > 4095) && accuracy < 1);
                if ((pokus.D < 2 || pokus.D > 4095))
                {
                    ModeIntFracComboBox.SelectedIndex = 0;
                    pokus = new Fraction (1, 4095);
                }
                ModeIntFracComboBox.SelectedIndex = 0;
                ModNumUpDown.Value = pokus.D;
                FracNNumUpDown.Value = pokus.N;
            }
            else
            {
                ModeIntFracComboBox.SelectedIndex = 1;
            }
            IntNNumUpDown.Value = (UInt16)IntN;

            string f_outA_string = fOutAScreenLabel.Text;
            f_outA_string = f_outA_string.Replace(" ", string.Empty);
            f_outA_string = f_outA_string.Replace(".", ",");

            double f_out_A = double.Parse(f_outA_string);

            double delta = ((double)f_input - f_out_A) * 1e6;
            delta  = Math.Round(delta, 3, MidpointRounding.AwayFromZero);
            if (Math.Abs(delta) > 10)
                DeltaShowLabel.ForeColor = System.Drawing.Color.Red;
            else
                DeltaShowLabel.ForeColor = System.Drawing.Color.Black;

            DeltaShowLabel.Text = delta.ToString ("0.###");

        }

        public Fraction RealToFraction(double value, double accuracy)
        {
            if (accuracy <= 0.0 || accuracy >= 1.0)
            {
                throw new ArgumentOutOfRangeException("accuracy", "Must be > 0 and < 1.");
            }

            int sign = Math.Sign(value);

            if (sign == -1)
            {
                value = Math.Abs(value);
            }

            // Accuracy is the maximum relative error; convert to absolute maxError
            double maxError = sign == 0 ? accuracy : value * accuracy;

            int n = (int) Math.Floor(value);
            value -= n;

            if (value < maxError)
            {
                return new Fraction(sign * n, 1);
            }

            if (1 - maxError < value)
            {
                return new Fraction(sign * (n + 1), 1);
            }

            // The lower fraction is 0/1
            int lower_n = 0;
            int lower_d = 1;

            // The upper fraction is 1/1
            int upper_n = 1;
            int upper_d = 1;

            while (true)
            {
                // The middle fraction is (lower_n + upper_n) / (lower_d + upper_d)
                int middle_n = lower_n + upper_n;
                int middle_d = lower_d + upper_d;

                if (middle_d * (value + maxError) < middle_n)
                {
                    // real + error < middle : middle is our new upper
                    upper_n = middle_n;
                    upper_d = middle_d;
                }
                else if (middle_n < (value - maxError) * middle_d)
                {
                    // middle < real - error : middle is our new lower
                    lower_n = middle_n;
                    lower_d = middle_d;
                }
                else
                {
                    // Middle is our best fraction
                    return new Fraction((n * middle_d + middle_n) * sign, middle_d);
                }
            }
        }

        public struct Fraction
        {
            public Fraction(int n, int d)
            {
                N = n;
                D = d;
            }

            public int N { get; private set; }
            public int D { get; private set; }
        }

        private void InputFreqTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalcSynthesizerRegValuesFromInpFreq();
            }
        }

        private void InputFreqHandlerFunction(object sender, MouseEventArgs e)
        {
            string f_input_string = InputFreqTextBox.Text;
            f_input_string = f_input_string.Replace(" ", string.Empty);
            f_input_string = f_input_string.Replace(".", ",");

            double f_input = double.Parse(f_input_string);

            HandledMouseEventArgs handledArgs = e as HandledMouseEventArgs;
            handledArgs.Handled = true;
            try{
                InputFreqTextBox.Text = Convert.ToString((handledArgs.Delta > 0) ? f_input += 0.000001 : f_input -= 0.000001);
                CalcSynthesizerRegValuesFromInpFreq();
            }
            catch{
                
            }
        }

        private void MoveRegsIntoMem1Button_Click(object sender, EventArgs e)
        {
            R0M1.Text = registers[0].string_GetValue();
            R1M1.Text = registers[1].string_GetValue();
            R2M1.Text = registers[2].string_GetValue();
            R3M1.Text = registers[3].string_GetValue();
            R4M1.Text = registers[4].string_GetValue();
            R5M1.Text = registers[5].string_GetValue();
        }

        private void MoveRegsIntoMem2Button_Click(object sender, EventArgs e)
        {
            R0M2.Text = registers[0].string_GetValue();
            R1M2.Text = registers[1].string_GetValue();
            R2M2.Text = registers[2].string_GetValue();
            R3M2.Text = registers[3].string_GetValue();
            R4M2.Text = registers[4].string_GetValue();
            R5M2.Text = registers[5].string_GetValue();
        }

        private void MoveRegsIntoMem3Button_Click(object sender, EventArgs e)
        {
            R0M3.Text = registers[0].string_GetValue();
            R1M3.Text = registers[1].string_GetValue();
            R2M3.Text = registers[2].string_GetValue();
            R3M3.Text = registers[3].string_GetValue();
            R4M3.Text = registers[4].string_GetValue();
            R5M3.Text = registers[5].string_GetValue();
        }

        private void MoveRegsIntoMem4Button_Click(object sender, EventArgs e)
        {
            R0M4.Text = registers[0].string_GetValue();
            R1M4.Text = registers[1].string_GetValue();
            R2M4.Text = registers[2].string_GetValue();
            R3M4.Text = registers[3].string_GetValue();
            R4M4.Text = registers[4].string_GetValue();
            R5M4.Text = registers[5].string_GetValue();
        }

        private void ImportMem1Button_Click(object sender, EventArgs e)
        {
            registers[0].SetValue(R0M1.Text);
            registers[1].SetValue(R1M1.Text);
            registers[2].SetValue(R2M1.Text);
            registers[3].SetValue(R3M1.Text);
            registers[4].SetValue(R4M1.Text);
            registers[5].SetValue(R5M1.Text);
            GetAllFromRegisters();
        }

        private void ImportMem2Button_Click(object sender, EventArgs e)
        {
            registers[0].SetValue(R0M2.Text);
            registers[1].SetValue(R1M2.Text);
            registers[2].SetValue(R2M2.Text);
            registers[3].SetValue(R3M2.Text);
            registers[4].SetValue(R4M2.Text);
            registers[5].SetValue(R5M2.Text);
            GetAllFromRegisters();
        }

        private void ImportMem3Button_Click(object sender, EventArgs e)
        {
            registers[0].SetValue(R0M3.Text);
            registers[1].SetValue(R1M3.Text);
            registers[2].SetValue(R2M3.Text);
            registers[3].SetValue(R3M3.Text);
            registers[4].SetValue(R4M3.Text);
            registers[5].SetValue(R5M3.Text);
            GetAllFromRegisters();
        }

        private void ImportMem4Button_Click(object sender, EventArgs e)
        {
            registers[0].SetValue(R0M4.Text);
            registers[1].SetValue(R1M4.Text);
            registers[2].SetValue(R2M4.Text);
            registers[3].SetValue(R3M4.Text);
            registers[4].SetValue(R4M4.Text);
            registers[5].SetValue(R5M4.Text);
            GetAllFromRegisters();
        }
    }
}
