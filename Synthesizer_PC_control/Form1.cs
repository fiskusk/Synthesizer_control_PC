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
using Synthesizer_PC_control.Controllers;
using Synthesizer_PC_control.Utilities;

using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Globalization;

using Synthesizer_PC_control.Model;

/* 
TODO CRITICAL
Jak updatovat element tak aby přepsal ui, ale nespůsobil event na view??
Otestovat jak funguje click?

Co potřebujeme:
view -textBox edit-> controller - upraví hodnotu-> MyModelObject (ten zavolá updateUiElements)
-edituje textBox2-> Zachytí text box edit událost na view?

controller lock?
view lock?

*/

namespace Synthesizer_PC_control
{
    public partial class Form1 : Form
        {
        //private MyRegister[] registers;
        private Controller controller;

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
                ConsoleController.Console().Write(text);
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
                            for (int i = 0; i < 7; i++)
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

        // TODO FILIP_NOW out1 Butt as switch (inpiruj se comportem)
        private void Out1Button_Click(object sender, EventArgs e)
        {
            controller.SwitchOut1();
        }

        private void Out2Button_Click(object sender, EventArgs e)
        {
            controller.SwitchOut2();
        }

        private void RefButton_Click(object sender, EventArgs e)
        {
            controller.SwitchRef();
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
                controller.CheckAndApplyRegChanges(0, Reg0TextBox.Text);
            }
        }

        private void Reg1TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyFormat.CheckIfHasHexInput(e);
            if (e.KeyChar == (char)13)
            {
                controller.CheckAndApplyRegChanges(1, Reg1TextBox.Text);
            }
        }

        private void Reg2TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyFormat.CheckIfHasHexInput(e);
            if (e.KeyChar == (char)13)
            {
                controller.CheckAndApplyRegChanges(2, Reg2TextBox.Text);
            }
        }

        private void Reg3TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyFormat.CheckIfHasHexInput(e);
            if (e.KeyChar == (char)13)
            {
                controller.CheckAndApplyRegChanges(3, Reg3TextBox.Text);
            }
        }

        private void Reg4TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyFormat.CheckIfHasHexInput(e);
            if (e.KeyChar == (char)13)
            {
                controller.CheckAndApplyRegChanges(4, Reg4TextBox.Text);
            }
        }

        private void Reg5TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyFormat.CheckIfHasHexInput(e);
            if (e.KeyChar == (char)13)
            {
                controller.CheckAndApplyRegChanges(5, Reg5TextBox.Text);
            }
        }

        private void CheckAndApllyChangesForm1_Click(object sender, EventArgs e)
        {
            Reg0Label.Focus();
        }

        private void SetAsDefaultRegButton_Click(object sender, EventArgs e)
        {
            controller.SaveDefRegsData();
        }

        private void LoadDefRegButton_Click(object sender, EventArgs e)
        {
            controller.LoadDefRegsData();
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
            controller.CheckAndApplyRegChanges(0, Reg0TextBox.Text);
        }

        private void WriteR1Button_Click(object sender, EventArgs e)
        {
            controller.CheckAndApplyRegChanges(1, Reg1TextBox.Text);
        }

        private void WriteR2Button_Click(object sender, EventArgs e)
        {
            controller.CheckAndApplyRegChanges(2, Reg2TextBox.Text);
        }

        private void WriteR3Button_Click(object sender, EventArgs e)
        {
            controller.CheckAndApplyRegChanges(3, Reg3TextBox.Text);
        }

        private void WriteR4Button_Click(object sender, EventArgs e)
        {
            controller.CheckAndApplyRegChanges(4, Reg4TextBox.Text);
        }

        private void WriteR5Button_Click(object sender, EventArgs e)
        {
            controller.CheckAndApplyRegChanges(5, Reg5TextBox.Text);
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
                controller.CheckAndApplyRegChanges(4);
            }
        }

        private void RF_A_PWR_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (controller.serialPort.IsPortOpen())
            {
                controller.ChangeOutAPwr(RF_A_PWR_ComboBox.SelectedIndex);
                controller.CheckAndApplyRegChanges(4);
            }
        }

        private void ModeIntFracComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (controller.serialPort.IsPortOpen())
            {
                controller.ChangeIntFracMode(ModeIntFracComboBox.SelectedIndex);
                controller.CheckAndApplyRegChanges(2);
            }
        }

        private void IntNNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (controller.serialPort.IsPortOpen())
            {
                controller.ChangeIntNValue(IntNNumUpDown.Value);
                controller.CheckAndApplyRegChanges(0);
            }
        }

        private void FracNNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (controller.serialPort.IsPortOpen())
            {
                controller.ChangeFracNValue(FracNNumUpDown.Value);
                controller.CheckAndApplyRegChanges(0);
            }
        }

        private void ModNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (controller.serialPort.IsPortOpen())
            {
                controller.ChangeModValue(ModNumUpDown.Value);
                controller.CheckAndApplyRegChanges(1);
            }
        }

        private void DoubleRefFCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (controller.serialPort.IsPortOpen())
            {
                controller.ChangeRefDoubler(DoubleRefFCheckBox.Checked);
                controller.GetFPfdFreq();
                controller.CheckAndApplyRegChanges(2);
            }
        }

        private void DivideBy2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (controller.serialPort.IsPortOpen())
            {
                controller.ChangeRefDivider(DivideBy2CheckBox.Checked);
                controller.GetFPfdFreq();
                controller.CheckAndApplyRegChanges(2);
            }
        }

        private void RDivUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (controller.serialPort.IsPortOpen())
            {
                controller.ChangeRDiv(RDivUpDown.Value);
                controller.GetFPfdFreq();
                controller.CheckAndApplyRegChanges(2);
            }
        }

        private void ADivComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (controller.serialPort.IsPortOpen())
            {
                controller.ChangeADiv(ADivComboBox.SelectedIndex);
                controller.GetFPfdFreq();
                controller.CheckAndApplyRegChanges(4);
            }
        }

        private void PhasePNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(controller.serialPort.IsPortOpen())
            {
                controller.ChangePhaseP(PhasePNumericUpDown.Value);
                controller.CheckAndApplyRegChanges(1);
            }
        }

        private void CPCurrentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(controller.serialPort.IsPortOpen())
            {
                controller.ChangeCPCurrent(CPCurrentComboBox.SelectedIndex);
                controller.CheckAndApplyRegChanges(2);
            }
        }

        private void CPLinearityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(controller.serialPort.IsPortOpen())
            {
                controller.ChangeCPLinearity(CPLinearityComboBox.SelectedIndex);
                controller.CheckAndApplyRegChanges(1);
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
            controller.CheckAndApplyRegChanges(0, Reg0TextBox.Text);
        }

        private void Reg1TextBox_LostFocus(object sender, EventArgs e)
        {
            controller.CheckAndApplyRegChanges(1, Reg1TextBox.Text);
        }

        private void Reg2TextBox_LostFocus(object sender, EventArgs e)
        {
            controller.CheckAndApplyRegChanges(2, Reg2TextBox.Text);
        }

        private void Reg3TextBox_LostFocus(object sender, EventArgs e)
        {
            controller.CheckAndApplyRegChanges(3, Reg3TextBox.Text);
        }

        private void Reg4TextBox_LostFocus(object sender, EventArgs e)
        {
            controller.CheckAndApplyRegChanges(4, Reg4TextBox.Text);
        }

        private void Reg5TextBox_LostFocus(object sender, EventArgs e)
        {
            controller.CheckAndApplyRegChanges(5, Reg5TextBox.Text);
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
            controller.GetCPCurrentFromTextBox();
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
