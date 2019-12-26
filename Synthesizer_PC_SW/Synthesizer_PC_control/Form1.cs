using System;
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

namespace Synthesizer_PC_control
{
    public partial class Form1 : Form
    {
        static SerialPort _serialPort;
        static bool Reg0TextBox_was_focused = false;
        static bool Reg1TextBox_was_focused = false;
        static bool Reg2TextBox_was_focused = false;
        static bool Reg3TextBox_was_focused = false;
        static bool Reg4TextBox_was_focused = false;
        static bool Reg5TextBox_was_focused = false;
        static string old_reg0 = "80C90000";
        static string old_reg1 = "800103E9";
        static string old_reg2 = "00005F42";
        static string old_reg3 = "00001F23";
        static string old_reg4 = "63BE80E4";
        static string old_reg5 = "00400005";

        public class SaveWindow
        {
            public IList<string> Registers { get; set; }
            public string COM_port { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

        }

        private void SendStringSerialPort(string text)
        {
            try
                {
                    _serialPort.WriteLine(text);
                    //_serialPort.ReadLine();
                }
            catch
            {
                MessageBox.Show("Device doesn't work", "COM Port Error",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ClosePortButton_Click(this, new EventArgs());
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
                        Reg0TextBox.Text,
                        Reg1TextBox.Text,
                        Reg2TextBox.Text,
                        Reg3TextBox.Text,
                        Reg4TextBox.Text,
                        Reg5TextBox.Text
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
            Reg0TextBox.Text = data.Registers[0];
            UInt32 intValue = UInt32.Parse(data.Registers[0], System.Globalization.NumberStyles.HexNumber);
            CheckFracIntModeStatus(intValue);
            Reg1TextBox.Text = data.Registers[1];
            Reg2TextBox.Text = data.Registers[2];
            Reg3TextBox.Text = data.Registers[3];
            Reg4TextBox.Text = data.Registers[4];
            UInt32 intValue2 = UInt32.Parse(data.Registers[4], System.Globalization.NumberStyles.HexNumber);
            CheckOutAENStatus(intValue2);
            CheckOutAPwrStatus(intValue2);
            Reg5TextBox.Text = data.Registers[5];
        }

        private void CheckOutAENStatus(UInt32 data)
        {
            RF_A_EN_ComboBox.SelectedIndex = (int)((data & (1<<5)) >> 5);
        }

        private void CheckOutAPwrStatus(UInt32 data)
        {
            RF_A_PWR_ComboBox.SelectedIndex = (int)((data & 0b11000) >> 3);
        }

        private void CheckFracIntModeStatus(UInt32 data)
        {
            ModeIntFracComboBox.SelectedIndex = (int)((data & (1 << 31)) >> 31);
        }

        private void ChangeReg4OutAEn()
        {
            int intValue = int.Parse(Reg4TextBox.Text, System.Globalization.NumberStyles.HexNumber);
            if (RF_A_EN_ComboBox.SelectedIndex == 0)
            {
                intValue &= ~(1<<5);
            }
            else if (RF_A_EN_ComboBox.SelectedIndex == 1)
            {
                intValue |= (1<<5);
            }
            Reg4TextBox.Text = Convert.ToString(intValue, 16);
            ChangeReg4();
        }

        private void ChangeReg4OutAPwr()
        {
            int intValue = int.Parse(Reg4TextBox.Text, System.Globalization.NumberStyles.HexNumber);
            switch (RF_A_PWR_ComboBox.SelectedIndex)
            {
                case 0:
                    intValue &= ~((1<<4) | (1<<3));
                    break;
                case 1:
                    intValue &= ~(1<<4);
                    intValue |= 1<<3;
                    break;
                case 2:
                    intValue |= 1<<4;
                    intValue &= ~(1<<3);
                    break;
                case 3:
                    intValue |= (1<<4) | (1<<3);
                    break;
            }
            Reg4TextBox.Text = Convert.ToString(intValue, 16);
            ChangeReg4();
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
                        Reg0TextBox.Text,
                        Reg1TextBox.Text,
                        Reg2TextBox.Text,
                        Reg3TextBox.Text,
                        Reg4TextBox.Text,
                        Reg5TextBox.Text
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
            ClosePortButton.Enabled = command;
            OpenPortButton.Enabled = !command;
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
            RF_A_PWR_ComboBox.Enabled = command;
            IntNdomainUpDown.Enabled = command;
            FracNdomainUpDown.Enabled = command;
            MODdomainUpDown.Enabled = command;
            ModeIntFracComboBox.Enabled = command;
        }

        private void OpenPortButton_Click(object sender, EventArgs e)
        {
            try
            {
                _serialPort = new SerialPort(AvaibleCOMsComBox.Text, 115200);
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
            }
            
        }

        void MyDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string text = _serialPort.ReadLine();
                if (text == "plo locked")
                    toolStripStatusLabel1.Text = "plo is locked";
                else if (text == "plo isn't locked")
                    toolStripStatusLabel1.Text = "plo isn't locked!";
                else if (text == "plo state is not known")
                    toolStripStatusLabel1.Text = "plo state is not known";
            }
            catch
            {
                
            }
            
        }

        private void ClosePortButton_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            _serialPort.Close();
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

        private void Reg0TextBox_Click(object sender, EventArgs e)
        {
            if (Reg0TextBox_was_focused == false)
            {
                Reg0TextBox.Focus();
                Reg0TextBox.SelectAll();
                Reg0TextBox_was_focused = true;
            }
        }

        private void Reg0TextBox_TextChanged(object sender, EventArgs e)
        {
            string item = Reg0TextBox.Text;
            int n = 0;
            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
                item != String.Empty)
            {
                Reg0TextBox.Text = item.Remove(item.Length - 1, 1);
                Reg0TextBox.SelectionStart = Reg0TextBox.Text.Length;
            }
        }

        private void Reg0TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckAndApllyChangesForm1_Click(this, new EventArgs());
            }
        }

        private void Reg1TextBox_Click(object sender, EventArgs e)
        {
            if (Reg1TextBox_was_focused == false)
            {
                Reg1TextBox.Focus();
                Reg1TextBox.SelectAll();
                Reg1TextBox_was_focused = true;
            }
        }

        private void Reg1TextBox_TextChanged(object sender, EventArgs e)
        {
            string item = Reg1TextBox.Text;
            int n = 0;
            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
                item != String.Empty)
            {
                Reg1TextBox.Text = item.Remove(item.Length - 1, 1);
                Reg1TextBox.SelectionStart = Reg1TextBox.Text.Length;
            }
        }
        private void Reg1TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckAndApllyChangesForm1_Click(this, new EventArgs());
            }
        }

        private void Reg2TextBox_Click(object sender, EventArgs e)
        {
            if (Reg2TextBox_was_focused == false)
            {
                Reg2TextBox.Focus();
                Reg2TextBox.SelectAll();
                Reg2TextBox_was_focused = true;
            }
        }

        private void Reg2TextBox_TextChanged(object sender, EventArgs e)
        {
            string item = Reg2TextBox.Text;
            int n = 0;
            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
                item != String.Empty)
            {
                Reg2TextBox.Text = item.Remove(item.Length - 1, 1);
                Reg2TextBox.SelectionStart = Reg2TextBox.Text.Length;
            }
        }
        private void Reg2TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckAndApllyChangesForm1_Click(this, new EventArgs());
            }
        }

        private void Reg3TextBox_Click(object sender, EventArgs e)
        {
            if (Reg3TextBox_was_focused == false)
            {
                Reg3TextBox.Focus();
                Reg3TextBox.SelectAll();
                Reg3TextBox_was_focused = true;
            }
        }

        private void Reg3TextBox_TextChanged(object sender, EventArgs e)
        {
            string item = Reg3TextBox.Text;
            int n = 0;
            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
                item != String.Empty)
            {
                Reg3TextBox.Text = item.Remove(item.Length - 1, 1);
                Reg3TextBox.SelectionStart = Reg3TextBox.Text.Length;
            }
        }
        private void Reg3TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckAndApllyChangesForm1_Click(this, new EventArgs());
            }
        }

        private void Reg4TextBox_Click(object sender, EventArgs e)
        {
            if (Reg4TextBox_was_focused == false)
            {
                Reg4TextBox.Focus();
                Reg4TextBox.SelectAll();
                Reg4TextBox_was_focused = true;
            }
        }

        private void Reg4TextBox_TextChanged(object sender, EventArgs e)
        {
            string item = Reg4TextBox.Text;
            int n = 0;
            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
                item != String.Empty)
            {
                Reg4TextBox.Text = item.Remove(item.Length - 1, 1);
                Reg4TextBox.SelectionStart = Reg4TextBox.Text.Length;
            }
        }
        private void Reg4TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckAndApllyChangesForm1_Click(this, new EventArgs());
            }
        }

        private void Reg5TextBox_Click(object sender, EventArgs e)
        {
            if (Reg5TextBox_was_focused == false)
            {
                Reg5TextBox.Focus();
                Reg5TextBox.SelectAll();
                Reg5TextBox_was_focused = true;
            }
        }

        private void Reg5TextBox_TextChanged(object sender, EventArgs e)
        {
            string item = Reg5TextBox.Text;
            int n = 0;
            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
                item != String.Empty)
            {
                Reg5TextBox.Text = item.Remove(item.Length - 1, 1);
                Reg5TextBox.SelectionStart = Reg5TextBox.Text.Length;
            }
        }
        private void Reg5TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckAndApllyChangesForm1_Click(this, new EventArgs());
            }
        }



        private void CheckAndApllyChangesForm1_Click(object sender, EventArgs e)
        {
            Reg0Label.Focus();
            Reg0TextBox_was_focused = false;
            Reg1TextBox_was_focused = false;
            Reg2TextBox_was_focused = false;
            Reg3TextBox_was_focused = false;
            Reg4TextBox_was_focused = false;
            Reg5TextBox_was_focused = false;
            if ((Reg0TextBox.Enabled == true) && (!Reg0TextBox.Text.Equals(old_reg0)))
            {
                ChangeReg0();
            }
            if ((Reg1TextBox.Enabled == true) && (!Reg1TextBox.Text.Equals(old_reg1)))
            {
                ChangeReg1();
                ChangeReg0();
            }
            if ((Reg2TextBox.Enabled == true) && (!Reg2TextBox.Text.Equals(old_reg2)))
            {
                ChangeReg2();
                ChangeReg0();
            }
            if ((Reg3TextBox.Enabled == true) && (!Reg3TextBox.Text.Equals(old_reg3)))
            {
                ChangeReg3();
            }
            if ((Reg4TextBox.Enabled == true) && (!Reg4TextBox.Text.Equals(old_reg4)))
            {
                ChangeReg4();
            }
            if ((Reg5TextBox.Enabled == true) && (!Reg5TextBox.Text.Equals(old_reg5)))
            {
                ChangeReg5();
            }
        }

        private void ChangeReg0()
        {
            string data = String.Format("plo set_register {0}", Reg0TextBox.Text);
            old_reg0 = Reg0TextBox.Text;
            UInt32 intValue = UInt32.Parse(Reg0TextBox.Text, System.Globalization.NumberStyles.HexNumber);
            CheckFracIntModeStatus(intValue);
            SendStringSerialPort(data);
        }

        private void ChangeReg1()
        {
            string data = String.Format("plo set_register {0}", Reg1TextBox.Text);
            old_reg1 = Reg1TextBox.Text;
            SendStringSerialPort(data);
        }

        private void ChangeReg2()
        {
            string data = String.Format("plo set_register {0}", Reg2TextBox.Text);
            old_reg2 = Reg2TextBox.Text;
            SendStringSerialPort(data);
        }

        private void ChangeReg3()
        {
            string data = String.Format("plo set_register {0}", Reg3TextBox.Text);
            old_reg3 = Reg3TextBox.Text;
            SendStringSerialPort(data);
        }

        private void ChangeReg4()
        {
            string data = String.Format("plo set_register {0}", Reg4TextBox.Text);
            old_reg4 = Reg4TextBox.Text;
            UInt32 intValue = UInt32.Parse(Reg4TextBox.Text, System.Globalization.NumberStyles.HexNumber);
            CheckOutAENStatus(intValue);
            CheckOutAPwrStatus(intValue);
            SendStringSerialPort(data);
        }

        private void ChangeReg5()
        {
            string data = String.Format("plo set_register {0}", Reg5TextBox.Text);
            old_reg5 = Reg5TextBox.Text;
            SendStringSerialPort(data);
        }

        private void SaveRegsMemory1()
        {
            string data = String.Format("plo data 1 {0} {1} {2} {3} {4} {5}", 
                    R0M1.Text, R1M1.Text, R2M1.Text, 
                    R3M1.Text, R4M1.Text, R5M1.Text);
            SendStringSerialPort(data);
        }

        private void SaveRegsMemory2()
        {
            string data = String.Format("plo data 2 {0} {1} {2} {3} {4} {5}", 
                    R0M2.Text, R1M2.Text, R2M2.Text, 
                    R3M2.Text, R4M2.Text, R5M2.Text);
            SendStringSerialPort(data);
        }

        private void SaveRegsMemory3()
        {
            string data = String.Format("plo data 3 {0} {1} {2} {3} {4} {5}", 
                    R0M3.Text, R1M3.Text, R2M3.Text, 
                    R3M3.Text, R4M3.Text, R5M3.Text);
            SendStringSerialPort(data);
        }

        private void SaveRegsMemory4()
        {
            string data = String.Format("plo data 4 {0} {1} {2} {3} {4} {5}", 
                    R0M4.Text, R1M4.Text, R2M4.Text, 
                    R3M4.Text, R4M4.Text, R5M4.Text);
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
                    Reg0TextBox.Text,
                    Reg1TextBox.Text,
                    Reg2TextBox.Text,
                    Reg3TextBox.Text,
                    Reg4TextBox.Text,
                    Reg5TextBox.Text
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
            ChangeReg5();
            //Thread.Sleep(1);
            ChangeReg4();
            //Thread.Sleep(1);
            ChangeReg3();
            //Thread.Sleep(1);
            ChangeReg2();
            //Thread.Sleep(1);
            ChangeReg1();
            //Thread.Sleep(1);
            ChangeReg0();
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
            ChangeReg0();
        }

        private void WriteR1Button_Click(object sender, EventArgs e)
        {
            ChangeReg1();
        }

        private void WriteR2Button_Click(object sender, EventArgs e)
        {
            ChangeReg2();
        }

        private void WriteR3Button_Click(object sender, EventArgs e)
        {
            ChangeReg3();
        }

        private void WriteR4Button_Click(object sender, EventArgs e)
        {
            ChangeReg4();
        }

        private void WriteR5Button_Click(object sender, EventArgs e)
        {
            ChangeReg5();
        }

        private void LoadRegMemory_Click(object sender, EventArgs e)
        {

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
            if (Reg1TextBox.Enabled == true)
                ChangeReg4OutAEn();
        }

        private void RF_A_PWR_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Reg1TextBox.Enabled == true)
                ChangeReg4OutAPwr();
        }
    }
}
