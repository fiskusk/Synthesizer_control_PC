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
using Synthesizer_PC_control.Utilities;

using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Globalization;

using Synthesizer_PC_control.Model;

namespace Synthesizer_PC_control
{
    public partial class Form1 : Form
        {
        //private MyRegister[] registers;
        private Controller controller;

        public class SaveAsDefaultRegisters
        {
            public IList<string> Registers { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        
            controller = new Controller(this);

            EnableControls(false);
            controller.LoadSavedWorkspaceData();
        }

        void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void EnableControls(bool command)
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

        private void PortButton_Click(object sender, EventArgs e)
        {
            controller.SwitchPort();
        }

        public void ProccesReceivedData(object Object)
        {
            try
            { // TODO zde si zjistovat na zacasku jestli je ID max2871, jinak vyhodit hlasku a zavrit port. 
                // TODO vycitat info o tom, jestli je int/ext ref, out1, out2 on/off
                // TODO a asi vycist pekne test register a ten soupnout do okna
                //string text = _serialPort.ReadLine();
                string text = controller.serialPort.ReadLine();
                ConsoleTextBox.AppendText(Environment.NewLine + DateTime.Now.ToString("HH:mm:ss: ") + text);
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

        private void LoadRegistersFromFile(SaveAsDefaultRegisters data)
        {
            controller.registers[0].SetValue(data.Registers[0]);
            controller.registers[1].SetValue(data.Registers[1]);
            controller.registers[2].SetValue(data.Registers[2]);
            controller.registers[3].SetValue(data.Registers[3]);
            controller.registers[4].SetValue(data.Registers[4]);
            controller.registers[5].SetValue(data.Registers[5]);
        }

        // TODO FILIP_NOW out1 Butt as switch (inpiruj se comportem)
        private void Out1Button_Click(object sender, EventArgs e)
        {
            if (Out1Button.Text == "Out 1 On")
            {
                Out1Button.Text = "Out 1 Off";
                controller.serialPort.SendStringSerialPort("out 1 on");
            }
            else if (Out1Button.Text == "Out 1 Off")
            {
                Out1Button.Text = "Out 1 On";
                controller.serialPort.SendStringSerialPort("out 1 off");
            }
        }

        private void Out2Button_Click(object sender, EventArgs e)
        {
            if (Out2Button.Text == "Out 2 On")
            {
                Out2Button.Text = "Out 2 Off";
                controller.serialPort.SendStringSerialPort("out 2 on");
            }

            else if (Out2Button.Text == "Out 2 Off")
            {
                Out2Button.Text = "Out 2 On";
                controller.serialPort.SendStringSerialPort("out 2 off");
            }
        }

        private void RefButton_Click(object sender, EventArgs e)
        {
            if (RefButton.Text == "Ext Ref")
            {
                RefButton.Text = "Int Ref";
                controller.serialPort.SendStringSerialPort("ref ext");
            }

            else if (RefButton.Text == "Int Ref")
            {
                RefButton.Text = "Ext Ref";
                controller.serialPort.SendStringSerialPort("ref int");
            }
        }

        private void PloInitButton_Click(object sender, EventArgs e)
        {
            controller.serialPort.SendStringSerialPort("PLO init");
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
            controller.registers[0].SetValue(Reg0TextBox.Text);
            if ((controller.serialPort.IsPortOpen()) && 
                (!string.Equals(controller.registers[0].string_GetValue(), 
                                controller.old_registers[0].string_GetValue(),
                                StringComparison.CurrentCultureIgnoreCase)))
            {
                controller.GetAllFromReg(0);
                controller.ApplyChangeReg(0);
                controller.RecalcFreqInfo();
            }
        }

        private void CheckAndApplyReg1Changes()
        {
            controller.registers[1].SetValue(Reg1TextBox.Text);
            if ((controller.serialPort.IsPortOpen()) && 
                (!string.Equals(controller.registers[1].string_GetValue(), 
                                controller.old_registers[1].string_GetValue(),
                                StringComparison.CurrentCultureIgnoreCase)))
            {
                controller.GetAllFromReg(1);
                controller.ApplyChangeReg(1);
                controller.ApplyChangeReg(0);
                controller.RecalcFreqInfo();
            }
        }

        private void CheckAndApplyReg2Changes()
        {
            controller.registers[2].SetValue(Reg2TextBox.Text);
            if ((controller.serialPort.IsPortOpen()) && 
                (!string.Equals(controller.registers[2].string_GetValue(), 
                                controller.old_registers[2].string_GetValue(),
                                StringComparison.CurrentCultureIgnoreCase)))
            {
                controller.GetAllFromReg(2);
                controller.ApplyChangeReg(2);
                controller.ApplyChangeReg(0);
                controller.RecalcFreqInfo();
            }
        }

        private void CheckAndApplyReg3Changes()
        {
            controller.registers[3].SetValue(Reg3TextBox.Text);
            if ((controller.serialPort.IsPortOpen()) && 
                (!string.Equals(controller.registers[3].string_GetValue(), 
                                controller.old_registers[3].string_GetValue(),
                                StringComparison.CurrentCultureIgnoreCase)))
            {
                controller.ApplyChangeReg(3);
            }
        }

        private void CheckAndApplyReg4Changes()
        {
            controller.registers[4].SetValue(Reg4TextBox.Text);
            if ((controller.serialPort.IsPortOpen()) && 
                (!string.Equals(controller.registers[4].string_GetValue(), 
                                controller.old_registers[4].string_GetValue(),
                                StringComparison.CurrentCultureIgnoreCase)))
            {
                controller.GetAllFromReg(4);
                controller.ApplyChangeReg(4);
                controller.RecalcFreqInfo();
            }
        }

        private void CheckAndApplyReg5Changes()
        {
            controller.registers[5].SetValue(Reg5TextBox.Text);
            if ((controller.serialPort.IsPortOpen()) && 
                (!string.Equals(controller.registers[5].string_GetValue(), 
                                controller.old_registers[5].string_GetValue(),
                                StringComparison.CurrentCultureIgnoreCase)))
            {
                controller.ApplyChangeReg(5);
            }
        }

        private void CheckAndApllyChangesForm1_Click(object sender, EventArgs e)
        {
            Reg0Label.Focus();
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
            controller.serialPort.SendStringSerialPort(data);
        }

        private void SaveRegsMemory2()
        {
            string data = String.Format("plo data 2 {0} {1} {2} {3} {4} {5} {6}", 
                    R0M2.Text, R1M2.Text, R2M2.Text, 
                    R3M2.Text, R4M2.Text, R5M2.Text,
                    GetControlRegister() );
            controller.serialPort.SendStringSerialPort(data);
        }

        private void SaveRegsMemory3()
        {
            string data = String.Format("plo data 3 {0} {1} {2} {3} {4} {5} {6}", 
                    R0M3.Text, R1M3.Text, R2M3.Text, 
                    R3M3.Text, R4M3.Text, R5M3.Text,
                    GetControlRegister() );
            controller.serialPort.SendStringSerialPort(data);
        }

        private void SaveRegsMemory4()
        {
            string data = String.Format("plo data 4 {0} {1} {2} {3} {4} {5} {6}", 
                    R0M4.Text, R1M4.Text, R2M4.Text, 
                    R3M4.Text, R4M4.Text, R5M4.Text,
                    GetControlRegister() );
            controller.serialPort.SendStringSerialPort(data);
        }

        private void CleanSavedRegisters()
        {
            string data = String.Format("plo data clean");
            controller.serialPort.SendStringSerialPort(data);
        }

        private void SetAsDefaultRegButton_Click(object sender, EventArgs e)
        {
            string fileName = FilesManager.GetFileNamePath(@"default.json");  
     
            SaveAsDefaultRegisters defaults = new SaveAsDefaultRegisters
            {
                Registers = new List<string>
                {
                    controller.registers[0].string_GetValue(),
                    controller.registers[1].string_GetValue(),
                    controller.registers[2].string_GetValue(),
                    controller.registers[3].string_GetValue(),
                    controller.registers[4].string_GetValue(),
                    controller.registers[5].string_GetValue()
                }
            };

            // serialize JSON to a string and then write string to a file
            File.WriteAllText(fileName, JsonConvert.SerializeObject(defaults, Formatting.Indented));
        }

        private void LoadDefRegButton_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = FilesManager.GetFileNamePath(@"default.json");

                SaveAsDefaultRegisters settings_loaded = JsonConvert.DeserializeObject<SaveAsDefaultRegisters>(File.ReadAllText(fileName));
                LoadRegistersFromFile(settings_loaded);
                ForceLoadRegButton_Click(this, new EventArgs());

            }
            catch
            {
                MessageBox.Show("File default.json with include settings for registers, doesn't exist. First create it by click to Set As Def Button", "File defaults.txt doesn't exist", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ForceLoadRegButton_Click(object sender, EventArgs e)
        {
            controller.ApplyChangeReg(5);
            controller.ApplyChangeReg(4);
            controller.ApplyChangeReg(3);
            controller.ApplyChangeReg(2);
            controller.ApplyChangeReg(1);
            controller.ApplyChangeReg(0);

            controller.GetAllFromRegisters();
        }

        private void AvaibleCOMsComBox_DropDown(object sender, EventArgs e)
        {
            controller.serialPort.GetAvaliablePorts();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.SaveWorkspaceData();
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
            controller.serialPort.SendStringSerialPort("plo data stored?");
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
            if (controller.serialPort.IsPortOpen())
            {
                controller.ChangeOutAEn(RF_A_EN_ComboBox.SelectedIndex);
                controller.ApplyChangeReg(4);
            }
        }

        private void RF_A_PWR_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (controller.serialPort.IsPortOpen())
            {
                controller.ChangeOutAPwr(RF_A_PWR_ComboBox.SelectedIndex);
                controller.ApplyChangeReg(4);
            }
        }

        private void ModeIntFracComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (controller.serialPort.IsPortOpen())
            {
                controller.ChangeIntFracMode(ModeIntFracComboBox.SelectedIndex);
                controller.ApplyChangeReg(2);
                controller.ApplyChangeReg(0);
                controller.RecalcFreqInfo();
            }
        }

        private void IntNNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (controller.serialPort.IsPortOpen())
            {
                controller.ChangeIntNValue(IntNNumUpDown.Value);
                controller.ApplyChangeReg(0);
                controller.RecalcFreqInfo();
            }
        }

        private void FracNNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (controller.serialPort.IsPortOpen())
            {
                controller.ChangeFracNValue(FracNNumUpDown.Value);
                controller.ApplyChangeReg(0);
                controller.RecalcFreqInfo();
            }
        }

        private void ModNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (controller.serialPort.IsPortOpen())
            {
                controller.ChangeModValue(ModNumUpDown.Value);
                controller.ApplyChangeReg(1);
                controller.ApplyChangeReg(0);
                controller.RecalcFreqInfo();
            }
        }

        private void DoubleRefFCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (controller.serialPort.IsPortOpen()) // TODO prefdelat na stav port otevren tlacitko
            {
                controller.ChangeRefDoubler(DoubleRefFCheckBox.Checked);
                controller.ApplyChangeReg(2);
                controller.ApplyChangeReg(0);
                controller.GetFPfdFreq();
                controller.RecalcFreqInfo();
            }
        }

        private void DivideBy2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (controller.serialPort.IsPortOpen())
            {
                controller.ChangeRefDivider(DivideBy2CheckBox.Checked);
                controller.ApplyChangeReg(2);
                controller.ApplyChangeReg(0);
                controller.GetFPfdFreq();
                controller.RecalcFreqInfo();
            }
        }

        private void RDivUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (controller.serialPort.IsPortOpen())
            {
                controller.ChangeRDiv(RDivUpDown.Value);
                controller.ApplyChangeReg(2);
                controller.ApplyChangeReg(0);
                controller.GetFPfdFreq();
                controller.RecalcFreqInfo();
            }
        }

        private void ADivComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (controller.serialPort.IsPortOpen())
            {
                controller.ChangeADiv(ADivComboBox.SelectedIndex);
                controller.ApplyChangeReg(4);
                controller.GetFPfdFreq();
                controller.RecalcFreqInfo();
            }
        }

        private void PhasePNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(controller.serialPort.IsPortOpen())
            {
                controller.ChangePhaseP(PhasePNumericUpDown.Value);
                controller.ApplyChangeReg(1);
            }
        }

        private void CPCurrentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(controller.serialPort.IsPortOpen())
            {
                controller.ChangeCPCurrent(CPCurrentComboBox.SelectedIndex);
                controller.ApplyChangeReg(2);
                controller.ApplyChangeReg(0);
            }
        }

        private void CPLinearityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(controller.serialPort.IsPortOpen())
            {
                controller.ChangeCPLinearity(CPLinearityComboBox.SelectedIndex);
                controller.ApplyChangeReg(1);
            }
        }

        private void InputFreqTextBox_TextChanged(object sender, EventArgs e)
        {
            MyFormat.CheckIfHasDecimalInput(RefFTextBox);
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
                controller.GetFPfdFreq();
                controller.RecalcFreqInfo();
            }
        }

        private void RefFTextBox_LostFocus(object sender, EventArgs e)
        {
            controller.GetFPfdFreq();
            controller.RecalcFreqInfo();
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
            controller.GetCPCurrentFromTextBox();
            controller.RecalcFreqInfo();
        }

        private void RSetTextBox_TextChanged(object sender, EventArgs e)
        {
            MyFormat.CheckIfHasIntegerInput(RSetTextBox);
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
                int comma_position = f_input_string.IndexOf(",");
                int position = InputFreqTextBox.SelectionStart-1;
                double delenec;
                if ((position-comma_position) < 0)
                    delenec = Math.Pow(10, position + 1 - comma_position);
                else
                    delenec = Math.Pow(10, position - comma_position);
                double increment = 1/(delenec);
                f_input = (handledArgs.Delta > 0) ? f_input += increment : f_input -= increment;
                f_input_string = string.Format("{0:f8}", f_input);
                InputFreqTextBox.Text = f_input_string;
                InputFreqTextBox.SelectionStart = position + 1;
                CalcSynthesizerRegValuesFromInpFreq();
            }
            catch{
                
            }
        }

        private void MoveRegsIntoMem1Button_Click(object sender, EventArgs e)
        {
            R0M1.Text = controller.registers[0].string_GetValue();
            R1M1.Text = controller.registers[1].string_GetValue();
            R2M1.Text = controller.registers[2].string_GetValue();
            R3M1.Text = controller.registers[3].string_GetValue();
            R4M1.Text = controller.registers[4].string_GetValue();
            R5M1.Text = controller.registers[5].string_GetValue();
        }

        private void MoveRegsIntoMem2Button_Click(object sender, EventArgs e)
        {
            R0M2.Text = controller.registers[0].string_GetValue();
            R1M2.Text = controller.registers[1].string_GetValue();
            R2M2.Text = controller.registers[2].string_GetValue();
            R3M2.Text = controller.registers[3].string_GetValue();
            R4M2.Text = controller.registers[4].string_GetValue();
            R5M2.Text = controller.registers[5].string_GetValue();
        }

        private void MoveRegsIntoMem3Button_Click(object sender, EventArgs e)
        {
            R0M3.Text = controller.registers[0].string_GetValue();
            R1M3.Text = controller.registers[1].string_GetValue();
            R2M3.Text = controller.registers[2].string_GetValue();
            R3M3.Text = controller.registers[3].string_GetValue();
            R4M3.Text = controller.registers[4].string_GetValue();
            R5M3.Text = controller.registers[5].string_GetValue();
        }

        private void MoveRegsIntoMem4Button_Click(object sender, EventArgs e)
        {
            R0M4.Text = controller.registers[0].string_GetValue();
            R1M4.Text = controller.registers[1].string_GetValue();
            R2M4.Text = controller.registers[2].string_GetValue();
            R3M4.Text = controller.registers[3].string_GetValue();
            R4M4.Text = controller.registers[4].string_GetValue();
            R5M4.Text = controller.registers[5].string_GetValue();
        }

        private void ImportMem1Button_Click(object sender, EventArgs e)
        {
            controller.registers[0].SetValue(R0M1.Text);
            controller.registers[1].SetValue(R1M1.Text);
            controller.registers[2].SetValue(R2M1.Text);
            controller.registers[3].SetValue(R3M1.Text);
            controller.registers[4].SetValue(R4M1.Text);
            controller.registers[5].SetValue(R5M1.Text);
            controller.GetAllFromRegisters();
        }

        private void ImportMem2Button_Click(object sender, EventArgs e)
        {
            controller.registers[0].SetValue(R0M2.Text);
            controller.registers[1].SetValue(R1M2.Text);
            controller.registers[2].SetValue(R2M2.Text);
            controller.registers[3].SetValue(R3M2.Text);
            controller.registers[4].SetValue(R4M2.Text);
            controller.registers[5].SetValue(R5M2.Text);
            controller.GetAllFromRegisters();
        }

        private void ImportMem3Button_Click(object sender, EventArgs e)
        {
            controller.registers[0].SetValue(R0M3.Text);
            controller.registers[1].SetValue(R1M3.Text);
            controller.registers[2].SetValue(R2M3.Text);
            controller.registers[3].SetValue(R3M3.Text);
            controller.registers[4].SetValue(R4M3.Text);
            controller.registers[5].SetValue(R5M3.Text);
            controller.GetAllFromRegisters();
        }

        private void ImportMem4Button_Click(object sender, EventArgs e)
        {
            controller.registers[0].SetValue(R0M4.Text);
            controller.registers[1].SetValue(R1M4.Text);
            controller.registers[2].SetValue(R2M4.Text);
            controller.registers[3].SetValue(R3M4.Text);
            controller.registers[4].SetValue(R4M4.Text);
            controller.registers[5].SetValue(R5M4.Text);
            controller.GetAllFromRegisters();
        }
    }
}
