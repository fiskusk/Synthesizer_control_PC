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
                    switch (separrated[0])
                    {
                        case "stored_data_1":
                            for (int i = 0; i < 6; i++)
                            {
                                controller.memory.GetRegister(1, i).SetValue(separrated[i+1]);
                            }
                            break;
                        case "stored_data_2":
                            for (int i = 0; i < 6; i++)
                            {
                                controller.memory.GetRegister(2, i).SetValue(separrated[i+1]);
                            }
                            break;
                        case "stored_data_3":
                            for (int i = 0; i < 6; i++)
                            {
                                controller.memory.GetRegister(3, i).SetValue(separrated[i+1]);
                            }
                            break;
                        case "stored_data_4":
                            for (int i = 0; i < 6; i++)
                            {
                                controller.memory.GetRegister(4, i).SetValue(separrated[i+1]);
                            }
                            break;
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
            // TODO controller.CheckAndApplyReg0Changes()
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
                controller.ForceLoadAllRegsIntoPlo();

            }
            catch
            {
                MessageBox.Show("File default.json with include settings for registers, doesn't exist. First create it by click to Set As Def Button", "File defaults.txt doesn't exist", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ForceLoadRegButton_Click(object sender, EventArgs e)
        {
            controller.ForceLoadAllRegsIntoPlo();
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
            controller.LoadRegsFromPloMemory();
        }

        private void SaveRegMemory_Click(object sender, EventArgs e)
        {

            controller.SaveRegsIntoPloMemory();
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
            if (controller.serialPort.IsPortOpen())
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

        private void InputFreqTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               CalcRegsFromFreq.CalcSynthesizerRegValuesFromInpFreq(this);
            }
        }

        private void InputFreqHandlerFunction(object sender, MouseEventArgs e)
        {
            MyFormat.ScrollByPositionOfCursor(InputFreqTextBox, e);
            CalcRegsFromFreq.CalcSynthesizerRegValuesFromInpFreq(this);

        }

        private void MoveRegsIntoMem1Button_Click(object sender, EventArgs e)
        {
            controller.ExportMemory(1);
        }

        private void MoveRegsIntoMem2Button_Click(object sender, EventArgs e)
        {
            controller.ExportMemory(2);
        }

        private void MoveRegsIntoMem3Button_Click(object sender, EventArgs e)
        {
            controller.ExportMemory(3);
        }

        private void MoveRegsIntoMem4Button_Click(object sender, EventArgs e)
        {
            controller.ExportMemory(4);
        }

        private void ImportMem1Button_Click(object sender, EventArgs e)
        {
            controller.ImportMemory(1);
        }

        private void ImportMem2Button_Click(object sender, EventArgs e)
        {
            controller.ImportMemory(2);
        }

        private void ImportMem3Button_Click(object sender, EventArgs e)
        {
            controller.ImportMemory(3);
        }

        private void ImportMem4Button_Click(object sender, EventArgs e)
        {
            controller.ImportMemory(4);
        }
    }
}
