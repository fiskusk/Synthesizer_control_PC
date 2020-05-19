using System;
using System.Drawing;
using System.Windows.Forms;

using Synthesizer_PC_control.Controllers;
using Synthesizer_PC_control.Properties;

namespace Synthesizer_PC_control
{
    public partial class Form1 : Form
    {
        private Controller controller;
        private bool isForm1Load;
        bool windowInitialized;

        public Form1()
        {
            isForm1Load = false;        // sets to false, Form loading
            InitializeComponent();      // initialize components
            this.Load += Form1_Load;    // load form1
        
            controller = new Controller(this);

            InitializeToolTip();

            controller.LoadSavedWorkspaceData();    // load workspace data
            isForm1Load = true;
            EnableControls(false);
        }

        private void InitializeToolTip()
        {
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 250;

            // Set up the ToolTip text for the Serial Port UI elements.
            toolTip1.SetToolTip(this.PortButton, 
            "Click to estabilish or close connection to the synthesizer board");
            toolTip1.SetToolTip(this.AvaibleCOMsComBox, 
            "Detected COM ports. Updated when the list is expanded");

            // Set up the ToolTip text for the Module Controls UI elements.
            toolTip1.SetToolTip(this.Out1Button, 
            "Activate or deactivate synthesizer module output 1");
            toolTip1.SetToolTip(this.Out2Button, 
            "Activate or deactivate synthesizer module output 2");
            toolTip1.SetToolTip(this.RefButton, 
            "Selection of reference signal source");
            toolTip1.SetToolTip(this.PloInitButton, 
            "Executes the initialization procedure for the PLO");

            // Set up the ToolTip text for the DirectFreqControl UI elements.
            toolTip1.SetToolTip(this.InputFreqTextBox, 
            @"Input field for calculating registers based on the entered frequency. 
Accepts decimal point and comma. Depending on the cursor position, 
you can increment, decrement the digit to the left of the cursor.");
            toolTip1.SetToolTip(this.DeltaShowLabel, 
            @"Deviation of the real frequency from the specified frequency
Delta greater than 10 Hz is highlighted in red");
            toolTip1.SetToolTip(this.CalcFreqShowLabel, 
            "Calculated actual current synthesizer frequency");
            toolTip1.SetToolTip(this.FreqAtOut1ShowLabel, 
            "Frequency at the first output of the synthesizer module");
            toolTip1.SetToolTip(this.FreqAtOut2ShowLabel, 
            "Frequency at the second output of the synthesizer module");
            toolTip1.SetToolTip(this.ActOut1ShowLabel, 
            @"Status of the first output. 
Click to activate / deactivate");
            toolTip1.SetToolTip(this.ActOut2ShowLabel, 
            @"Status of the second output. 
Click to activate / deactivate");
            toolTip1.SetToolTip(this.IntExtShowLabel, 
            @"Reference signal source status. 
Click to switch");

            // Set up the ToolTip text for the Register Controls UI elements.
            toolTip1.SetToolTip(this.Reg0TextBox, 
            "The value of the 32-bit register 0 in hexadecimal");
            toolTip1.SetToolTip(this.Reg1TextBox, 
            "The value of the 32-bit register 1 in hexadecimal");
            toolTip1.SetToolTip(this.Reg2TextBox, 
            "The value of the 32-bit register 2 in hexadecimal");
            toolTip1.SetToolTip(this.Reg3TextBox, 
            "The value of the 32-bit register 3 in hexadecimal");
            toolTip1.SetToolTip(this.Reg4TextBox, 
            "The value of the 32-bit register 4 in hexadecimal");
            toolTip1.SetToolTip(this.Reg5TextBox, 
            "The value of the 32-bit register 5 in hexadecimal");

            toolTip1.SetToolTip(this.WriteR0Button, 
            @"If the entered register value 0 differs from the last one sent, 
it sends it to the synthesizer module.");
            toolTip1.SetToolTip(this.WriteR1Button, 
            @"If the entered register value 1 differs from the last one sent, 
it sends it to the synthesizer module.");
            toolTip1.SetToolTip(this.WriteR2Button, 
            @"If the entered register value 2 differs from the last one sent, 
it sends it to the synthesizer module.");
            toolTip1.SetToolTip(this.WriteR3Button, 
            @"If the entered register value 3 differs from the last one sent, 
it sends it to the synthesizer module.");
            toolTip1.SetToolTip(this.WriteR4Button, 
            @"If the entered register value 4 differs from the last one sent, 
it sends it to the synthesizer module.");
            toolTip1.SetToolTip(this.WriteR5Button, 
            @"If the entered register value 5 differs from the last one sent, 
it sends it to the synthesizer module.");

            toolTip1.SetToolTip(this.SetAsDefaultRegButton, 
            @"Sets the currently specified registers as default. 
Including the registers, the states of the module outputs 
and the selection of the reference signal are also stored. 
The default settings are saved in the \conf\default.json file");
            toolTip1.SetToolTip(this.LoadDefRegButton, 
            @"Loads previously saved default registers, including output 
states and reference signal source, into the workspace");
            toolTip1.SetToolTip(this.SaveIntoFileButton,
            @"Opens a windows dialog to save the current register settings, 
including output states and reference signal source");
            toolTip1.SetToolTip(this.LoadFromFileButton,
            @"Opens a windows dialog to load the current register settings, 
including output states and reference signal source");
            toolTip1.SetToolTip(this.ForceLoadRegButton,
            @"Forces all registers to be sent to the synthesizer module, 
including the states of the module outputs and the reference signal source");

            // Set up the ToolTip text for Export to memory tab UI elements.
            string exportMsgString = 
            @"Exports the currently set registers, including the status 
of the outputs and the reference signal source, to the memory tab.";
            toolTip1.SetToolTip(this.ExportIntoMem1Button, exportMsgString);
            toolTip1.SetToolTip(this.ExportIntoMem2Button, exportMsgString);
            toolTip1.SetToolTip(this.ExportIntoMem3Button, exportMsgString);
            toolTip1.SetToolTip(this.ExportIntoMem4Button, exportMsgString);

            // Set up the ToolTip text for Reference frequency control UI elements.
            toolTip1.SetToolTip(this.RefFTextBox, 
            "Frequency of the reference signal source.");
            toolTip1.SetToolTip(this.RDivUpDown,
            @"Sets reference divide value (R).
Double buffered by register 0.
Register 2, bits 9:0");
            toolTip1.SetToolTip(this.RefDoublerCheckBox,
            @"Sets reference doubler mode (DBR). The program will also try to recalculate 
the N and MOD values so that the output frequency does not change.
Register 2, bit 25");
            toolTip1.SetToolTip(this.DivideBy2CheckBox,
            @"Sets reference divide-by-2 mode (RDIV2. The program will also try to recalculate 
the N and MOD values so that the output frequency does not change.
Register 2, bit 24");
            toolTip1.SetToolTip(this.pfdFreqLabel,
            @"Frequency at the input of the phase detector");
            toolTip1.SetToolTip(this.LDSpeedAdjComboBox,
            @"Lock-detect speed adjustment (LDS)
Register 2, bit 31");
            toolTip1.SetToolTip(this.AutoLDSpeedAdjCheckBox,
            @"If checked, automatically sets the LD speed adjustment according to 
the current frequency at the input of the phase detector (LDS)");

            // Set up the ToolTip text for Output frequency control UI elements.
            toolTip1.SetToolTip(this.IntNNumUpDown, 
            @"Sets integer part (N-divider) of the feedback divider factor. All integer
values from 16 to 65,535 are allowed for integer mode. Integer values
from 0 to 15 are not allowed. Integer values from 19 to 4091 are allowed
for fractional mode.
Register 0, bits 30:15");
            toolTip1.SetToolTip(this.FracNNumUpDown, 
            @"Sets fractional value (FRAC). Integer values from 0 to 4095
Register 0, bits 14:3");
            toolTip1.SetToolTip(this.ModNumUpDown, 
            @"Fractional modulus value (M). Integer values from 2 to 4095 are alowed.
Double buffered by register 0.
Register 1, bits 14:3");
            toolTip1.SetToolTip(this.ModeIntFracComboBox, 
            @"Int-N or Frac-N Mode Control (INT)
Register 0, bit 31");
            toolTip1.SetToolTip(this.ADivComboBox, 
            @"Sets RFOUT_ output divider mode (ADIV). 
Double buffered by register 0 when REG4DB = 1.
Register 4, bits 22:20");
            toolTip1.SetToolTip(this.PhasePNumericUpDown, 
            @"Sets phase value. (P). 
Register 1, bits 26:15");
            toolTip1.SetToolTip(this.LDFuncComboBox, 
            @"Sets lock-detect function (LDF) 
Register 2, bit 8");
            toolTip1.SetToolTip(this.AutoLDFuncCheckBox, 
            @"If checked, automatically sets the LD function
according to the current synthesizer mode");
            toolTip1.SetToolTip(this.RFoutBPathComboBox, 
            @"Sets RFOUTB output path select (BDIV).
Register 4, bit 9");
            toolTip1.SetToolTip(this.FBPathComboBox, 
            @"Sets VCO to N counter feedback mode (FB).
Register 4, bit 23");
            toolTip1.SetToolTip(this.SigmaDeltaNoiseModeComboBox,
            @"Sets noise mode (SDN)
Register 2, bits 30:29");

            // Set up the ToolTip text for Phase detector control UI elements.
            toolTip1.SetToolTip(this.LDPrecisionComboBox, 
            @"Sets lock-detect precision (LDP).
Register 2, bit 7");
            toolTip1.SetToolTip(this.PfdPolarity, 
            @"Sets phase detector polarity (PDP).
Register 2, bit 6");

            // Set up the ToolTip text for Shutdown control UI elements.
            toolTip1.SetToolTip(this.PloPowerDownCheckBox, 
            @"Sets power-down mode (SHDN).
Register 2, bit 5");
            toolTip1.SetToolTip(this.RefInputShutdownCheckBox, 
            @"Sets Shutdown Reference input mode (SDREF).
Register 4, bit 26");
            toolTip1.SetToolTip(this.PllShutDownCheckBox, 
            @"Sets Shutdown PLL mode (SDPLL).
Register 5, bit 25");
            toolTip1.SetToolTip(this.VcoDividerShutdownCheckBox, 
            @"Sets Shutdown VCO Divider mode (SDDIV).
Register 4, bit 27");
            toolTip1.SetToolTip(this.VcoLdoShutDownCheckBox, 
            @"Sets Shutdown VCO LDO mode (SDLDO).
Register 4, bit 28");
            toolTip1.SetToolTip(this.VcoShutDownCheckBox, 
            @"Sets VCO Shutdown mode (SDVCO).
Register 4, bit 11");

            // Set up the ToolTip text for VCO controls UI elements.
            toolTip1.SetToolTip(this.AutoVcoSelectionCheckBox, 
            @"Sets VCO auto selection shutdown mode (VAS_SHDN).
Register 3, bit 25");
            toolTip1.SetToolTip(this.VASTempCompCheckBox, 
            @"Sets VCO auto selection response to temperature drift (VAS_TEMP).
Register 3, bit 24");
            toolTip1.SetToolTip(this.ManualVCOSelectNumericUpDown, 
            @"Manual selection of VCO and VCO sub-band when VAS is disabled (VCO).
Register 3, bits 31:26");
            toolTip1.SetToolTip(this.BandSelClockDivNumericUpDown, 
            @"Sets band select clock divider value (BS).
Register 4, bits 25:24 and 19:12");
            toolTip1.SetToolTip(this.MuteUntilLockDetectCheckBox, 
            @"Sets RFOUT Mute until Lock Detect Mode (MTLD).
Register 4, bit 10");
            toolTip1.SetToolTip(this.DelayToPreventFlickeringCheckBox, 
            @"Mute delay (MUTEDEL).
Register 3, bit 17");
            toolTip1.SetToolTip(this.ClockDividerNumericUpDown, 
            @"Sets 12-bit clock divider value (CDIV).
Register 3, bits 14:3");
            toolTip1.SetToolTip(this.AutoCDIVCalcCheckBox, 
            @"If checked, the CDIV value for the specified delay is automatically calculated.");
            toolTip1.SetToolTip(this.DelayInputNumericUpDown, 
            @"Output activation delay setpoint in milliseconds.");

            // Set up the ToolTip text for Charge pump controls UI elements.
            toolTip1.SetToolTip(this.RSetTextBox, 
            @"An integer value of the resistor RSET that sets 
the maximum current of the charge pump.");
            toolTip1.SetToolTip(this.CPCurrentComboBox, 
            @"Sets charge-pump current in mA (CP). 
Double buffered by register 0.
Register 2, bits 12:9");    
            toolTip1.SetToolTip(this.CPLinearityComboBox, 
            @"Sets CP linearity mode (CPL)
Register 1, bits 30:29");
            toolTip1.SetToolTip(this.CPTestComboBox, 
            @"Sets charge-pump test modes (CPT)
Register 1, bits 28:27");
            toolTip1.SetToolTip(this.CPFastLockCheckBox, 
            @"Sets clock divider mode for Fast-lock (CDM)
Register 3, bits 16:15 = '01'");
            toolTip1.SetToolTip(this.PhaseAdjustmentModeCheckbox, 
            @"Sets clock divider mode for Phase Adjustment mode (CDM)
Register 3, bits 16:15 = '10'");
            toolTip1.SetToolTip(this.CPTriStateOutCheckBox, 
            @"Sets charge-pump output high-impedance mode (TRI)
Register 2, bit 4");
            toolTip1.SetToolTip(this.CPCycleSlipCheckBox, 
            @"Cycle Slip Reduction Mode
Register 3, bit 18");

            // Set up the ToolTip text for Generic controls UI elements.
            toolTip1.SetToolTip(this.MuxPinModeCombobox, 
            @"Sets MUX pin configuration (MUX)
Register 2, bits 28:26");
            toolTip1.SetToolTip(this.Reg4DoubleBufferedCheckBox, 
            @"Sets double buffer mode (REG4DB)
Register 2, bit 13");
            toolTip1.SetToolTip(this.IntNAutoModeWhenF0CheckBox, 
            @"Sets integer mode for F = 0 (F01)
Register 5, bit 24");
            toolTip1.SetToolTip(this.RandNCountersResetCheckBox, 
            @"Sets counter reset mode (RST)
Register 2, bit 3");

            // Set up the ToolTip text for Output controls UI elements.
            toolTip1.SetToolTip(this.OutAEn_ComboBox, 
            @"Sets RFOUTA output mode (RFA_EN)
Register 4, bit 5");
            toolTip1.SetToolTip(this.OutBEn_ComboBox, 
            @"Sets RFOUTB output mode (RFB_EN)
Register 4, bit 8");
            toolTip1.SetToolTip(this.OutAPwr_ComboBox, 
            @"Sets RFOUTA single-ended output power. (APWR)
Register 4, bits 7:6");
            toolTip1.SetToolTip(this.OutBPwr_ComboBox, 
            @"Sets RFOUTB single-ended output power. (BPWR)
Register 4, bits 4:3");

            // Set up the ToolTip text for Output frequency info UI elements.
            toolTip1.SetToolTip(this.fVcoScreenLabel, 
            "Frequency at the VCO output");
            toolTip1.SetToolTip(this.fVcoLabel, 
            "Frequency at the VCO output");
            toolTip1.SetToolTip(this.fOutAScreenLabel, 
            "Frequency at the RF synthesizer output A");
            toolTip1.SetToolTip(this.fOutALabel, 
            "Frequency at the RF synthesizer output A");
            toolTip1.SetToolTip(this.fOutBScreenLabel, 
            "Frequency at the RF synthesizer output B");
            toolTip1.SetToolTip(this.fOutBLabel, 
            "Frequency at the RF synthesizer output B");

            // Set up the ToolTip text for Register 6 control UI elements.
            toolTip1.SetToolTip(this.ADCModeComboBox, 
            @"Sets ADC mode (ADCM)
Register 5, bits 5:3");
            toolTip1.SetToolTip(this.GetADCValueButton, 
            @"Sends a command to the synthesizer module to read 
the ADC value according to the mode set above");
            toolTip1.SetToolTip(this.ReadedADCValueTextBox, 
            @"Readed temperature or tuning voltage
It depends on the set ADC mode");
            toolTip1.SetToolTip(this.GetCurrentVCOButton, 
            @"Sends a command to the synthesizer module 
to read the number of the currently used VCO.");
            toolTip1.SetToolTip(this.ReadedVCOValueTextBox, 
            @"The number of the currently used VCO.");

            // Set up the ToolTip text for Register memory control UI elements.
            toolTip1.SetToolTip(this.R0M1, 
            "The value of the 32-bit register 0 of memory 1 in hexadecimal");
            toolTip1.SetToolTip(this.R1M1, 
            "The value of the 32-bit register 1 of memory 1 in hexadecimal");
            toolTip1.SetToolTip(this.R2M1, 
            "The value of the 32-bit register 2 of memory 1 in hexadecimal");
            toolTip1.SetToolTip(this.R3M1, 
            "The value of the 32-bit register 3 of memory 1 in hexadecimal");
            toolTip1.SetToolTip(this.R4M1, 
            "The value of the 32-bit register 4 of memory 1 in hexadecimal");
            toolTip1.SetToolTip(this.R5M1, 
            "The value of the 32-bit register 5 of memory 1 in hexadecimal");
            toolTip1.SetToolTip(this.R0M2, 
            "The value of the 32-bit register 0 of memory 2 in hexadecimal");
            toolTip1.SetToolTip(this.R1M2, 
            "The value of the 32-bit register 1 of memory 2 in hexadecimal");
            toolTip1.SetToolTip(this.R2M2, 
            "The value of the 32-bit register 2 of memory 2 in hexadecimal");
            toolTip1.SetToolTip(this.R3M2, 
            "The value of the 32-bit register 3 of memory 2 in hexadecimal");
            toolTip1.SetToolTip(this.R4M2, 
            "The value of the 32-bit register 4 of memory 2 in hexadecimal");
            toolTip1.SetToolTip(this.R5M2, 
            "The value of the 32-bit register 5 of memory 2 in hexadecimal");
            toolTip1.SetToolTip(this.R0M3, 
            "The value of the 32-bit register 0 of memory 3 in hexadecimal");
            toolTip1.SetToolTip(this.R1M3, 
            "The value of the 32-bit register 1 of memory 3 in hexadecimal");
            toolTip1.SetToolTip(this.R2M3, 
            "The value of the 32-bit register 2 of memory 3 in hexadecimal");
            toolTip1.SetToolTip(this.R3M3, 
            "The value of the 32-bit register 3 of memory 3 in hexadecimal");
            toolTip1.SetToolTip(this.R4M3, 
            "The value of the 32-bit register 4 of memory 3 in hexadecimal");
            toolTip1.SetToolTip(this.R5M3, 
            "The value of the 32-bit register 5 of memory 3 in hexadecimal");
            toolTip1.SetToolTip(this.R0M4, 
            "The value of the 32-bit register 0 of memory 4 in hexadecimal");
            toolTip1.SetToolTip(this.R1M4, 
            "The value of the 32-bit register 1 of memory 4 in hexadecimal");
            toolTip1.SetToolTip(this.R2M4, 
            "The value of the 32-bit register 2 of memory 4 in hexadecimal");
            toolTip1.SetToolTip(this.R3M4, 
            "The value of the 32-bit register 3 of memory 4 in hexadecimal");
            toolTip1.SetToolTip(this.R4M4, 
            "The value of the 32-bit register 4 of memory 4 in hexadecimal");
            toolTip1.SetToolTip(this.R5M4, 
            "The value of the 32-bit register 5 of memory 4 in hexadecimal");

            toolTip1.SetToolTip(this.Mem1ActOut1ShowLabel, 
            @"Status of the first synthesizer module output for memory 1. 
Click to activate / deactivate");
            toolTip1.SetToolTip(this.Mem1ActOut2ShowLabel, 
            @"Status of the second synthesizer module output for memory 1. 
Click to activate / deactivate");
            toolTip1.SetToolTip(this.Mem1RefShowLabel, 
            @"Reference signal source status for memory 1. 
Click to switch");
            toolTip1.SetToolTip(this.Mem2ActOut1ShowLabel, 
            @"Status of the first synthesizer module output for memory 2. 
Click to activate / deactivate");
            toolTip1.SetToolTip(this.Mem2ActOut2ShowLabel, 
            @"Status of the second synthesizer module output for memory 2. 
Click to activate / deactivate");
            toolTip1.SetToolTip(this.Mem2RefShowLabel, 
            @"Reference signal source status for memory 2. 
Click to switch");
            toolTip1.SetToolTip(this.Mem3ActOut1ShowLabel, 
            @"Status of the first synthesizer module output for memory 3. 
Click to activate / deactivate");
            toolTip1.SetToolTip(this.Mem3ActOut2ShowLabel, 
            @"Status of the second synthesizer module output for memory 3. 
Click to activate / deactivate");
            toolTip1.SetToolTip(this.Mem3RefShowLabel, 
            @"Reference signal source status for memory 3. 
Click to switch");
            toolTip1.SetToolTip(this.Mem4ActOut1ShowLabel, 
            @"Status of the first synthesizer module output for memory 4. 
Click to activate / deactivate");
            toolTip1.SetToolTip(this.Mem4ActOut2ShowLabel, 
            @"Status of the second synthesizer module output for memory 4. 
Click to activate / deactivate");
            toolTip1.SetToolTip(this.Mem4RefShowLabel, 
            @"Reference signal source status for memory 4. 
Click to switch");

            toolTip1.SetToolTip(this.Mem1Freq1ShowLabel, 
            "Frequency that will be on output 1 for memory 1.");
            toolTip1.SetToolTip(this.Mem1Freq2ShowLabel, 
            "Frequency that will be on output 2 for memory 1.");
            toolTip1.SetToolTip(this.Mem1PwrAShowLabel, 
            "Power at output A of the MAX2871 circuit for memory 1.");
            toolTip1.SetToolTip(this.Mem1PwrBShowLabel, 
            "Power at output B of the MAX2871 circuit for memory 1.");
            toolTip1.SetToolTip(this.Mem2Freq1ShowLabel, 
            "Frequency that will be on output 1 for memory 2.");
            toolTip1.SetToolTip(this.Mem2Freq2ShowLabel, 
            "Frequency that will be on output 2 for memory 2.");
            toolTip1.SetToolTip(this.Mem2PwrAShowLabel, 
            "Power at output A of the MAX2871 circuit for memory 2.");
            toolTip1.SetToolTip(this.Mem2PwrBShowLabel, 
            "Power at output B of the MAX2871 circuit for memory 2.");
            toolTip1.SetToolTip(this.Mem3Freq1ShowLabel, 
            "Frequency that will be on output 1 for memory 3.");
            toolTip1.SetToolTip(this.Mem3Freq2ShowLabel, 
            "Frequency that will be on output 2 for memory 3.");
            toolTip1.SetToolTip(this.Mem3PwrAShowLabel, 
            "Power at output A of the MAX2871 circuit for memory 3.");
            toolTip1.SetToolTip(this.Mem3PwrBShowLabel, 
            "Power at output B of the MAX2871 circuit for memory 3.");
            toolTip1.SetToolTip(this.Mem4Freq1ShowLabel, 
            "Frequency that will be on output 1 for memory 4.");
            toolTip1.SetToolTip(this.Mem4Freq2ShowLabel, 
            "Frequency that will be on output 2 for memory 4.");
            toolTip1.SetToolTip(this.Mem4PwrAShowLabel, 
            "Power at output A of the MAX2871 circuit for memory 4.");
            toolTip1.SetToolTip(this.Mem4PwrBShowLabel, 
            "Power at output B of the MAX2871 circuit for memory 4.");

            toolTip1.SetToolTip(this.ImportMem1Button, 
            @"Click to move the register settings, 
including the module output settings 
and the reference signal source 
for memory 1, to the workspace");
            toolTip1.SetToolTip(this.ImportMem2Button, 
            @"Click to move the register settings, 
including the module output settings 
and the reference signal source 
for memory 2, to the workspace");
            toolTip1.SetToolTip(this.ImportMem3Button, 
            @"Click to move the register settings, 
including the module output settings 
and the reference signal source 
for memory 3, to the workspace");
            toolTip1.SetToolTip(this.ImportMem4Button, 
            @"Click to move the register settings, 
including the module output settings 
and the reference signal source 
for memory 4, to the workspace");

            toolTip1.SetToolTip(this.SaveRegMemory, 
            @"Loads register settings, including module output 
and reference signal source settings for memories, 
into the synthesizer module.");
            toolTip1.SetToolTip(this.LoadRegMemory, 
            @"Gets register settings, including module output 
settings and a reference signal source for memories 
from the synthesizer module.");
            toolTip1.SetToolTip(this.MemSaveIntoFileButton, 
            @"Saves the current register settings, 
module output and reference source settings 
for memories to a file on your computer.");
            toolTip1.SetToolTip(this.MemLoadFromFileButton, 
            @"Loads the register settings, module output 
and reference source settings for
memories to a file on your computer.");
        }

        /// <summary>
        /// Form looading routine. This code is reload window position 
        /// and state from saved values. Code is inspired from this discuss.
        /// https://stackoverflow.com/questions/937298/restoring-window-size-position-with-multiple-monitors?noredirect=1&lq=1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Form1_Load(object sender, EventArgs e)
        {
            // sets this as the default
            this.Visible = false;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.WindowsDefaultBounds;

            // check if the saved bounds are nonzero and visible on any screen
            if (Settings.Default.WindowPosition != Rectangle.Empty &&
                IsVisibleOnAnyScreen(Settings.Default.WindowPosition))
            {
                // first set the bounds
                this.StartPosition = FormStartPosition.Manual;
                this.DesktopBounds = Settings.Default.WindowPosition;

                // afterwards set the window state to the saved value (which could be Maximized)
                this.WindowState = Settings.Default.WindowState;
            }
            else
            {
                // this resets the upper left corner of the window to windows standards
                this.StartPosition = FormStartPosition.WindowsDefaultLocation;

            }

            // sets default size of window
            this.Size = new System.Drawing.Size(821, 771);
            this.Visible = true;
            windowInitialized = true;       // window initialized
        }

        private bool IsVisibleOnAnyScreen(Rectangle rect)
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.IntersectsWith(rect))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// this routine runs when you close the application.
        /// It store actual state and postion.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
             base.OnClosed(e);

            // only save the WindowState if Normal or Maximized
            switch (this.WindowState)
            {
                case FormWindowState.Normal:
                case FormWindowState.Maximized:
                    Settings.Default.WindowState = this.WindowState;
                    break;

                default:
                    Settings.Default.WindowState = FormWindowState.Normal;
                    break;
            }

            // save current state
            Settings.Default.Save();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            TrackWindowState();
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            TrackWindowState();
        }

        /// <summary>
        /// On a move or resize in Normal state, record the new values as they occur.
        /// This solves the problem of closing the app when minimized or maximized.
        /// </summary>
        private void TrackWindowState()
        {
            // Don't record the window setup, otherwise we lose the persistent values!
            if (!windowInitialized) { return; }

            if (WindowState == FormWindowState.Normal)
            {
                Settings.Default.WindowPosition = this.DesktopBounds;
            }
        }

        /// <summary>
        /// When user close program, store workspace data into json file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.SaveWorkspaceData();
        }

        /// <summary>
        /// This function controls the status of UI elements whether they are enabled or disabled
        /// </summary>
        /// <param name="command"> controls enabled or not </param>
        public void EnableControls(bool command)
        {
            AvaibleCOMsComBox.Enabled       = !command;
            Out1Button.Enabled              = command;
            Out2Button.Enabled              = command;
            RefButton.Enabled               = command;
            PloInitButton.Enabled           = command;
            Reg0TextBox.Enabled             = command;
            Reg1TextBox.Enabled             = command;
            Reg2TextBox.Enabled             = command;
            Reg3TextBox.Enabled             = command;
            Reg4TextBox.Enabled             = command;
            Reg5TextBox.Enabled             = command;
            SetAsDefaultRegButton.Enabled   = command;
            ForceLoadRegButton.Enabled      = command;
            LoadDefRegButton.Enabled        = command;
            WriteR0Button.Enabled           = command;
            WriteR1Button.Enabled           = command;
            WriteR2Button.Enabled           = command;
            WriteR3Button.Enabled           = command;
            WriteR4Button.Enabled           = command;
            WriteR5Button.Enabled           = command;
            R0M1.Enabled                    = command;
            R1M1.Enabled                    = command;
            R2M1.Enabled                    = command;
            R3M1.Enabled                    = command;
            R4M1.Enabled                    = command;
            R5M1.Enabled                    = command;
            R0M2.Enabled                    = command;
            R1M2.Enabled                    = command;
            R2M2.Enabled                    = command;
            R3M2.Enabled                    = command;
            R4M2.Enabled                    = command;
            R5M2.Enabled                    = command;
            R0M3.Enabled                    = command;
            R1M3.Enabled                    = command;
            R2M3.Enabled                    = command;
            R3M3.Enabled                    = command;
            R4M3.Enabled                    = command;
            R5M3.Enabled                    = command;
            R0M4.Enabled                    = command;
            R1M4.Enabled                    = command;
            R2M4.Enabled                    = command;
            R3M4.Enabled                    = command;
            R4M4.Enabled                    = command;
            R5M4.Enabled                    = command;
            LoadRegMemory.Enabled           = command;
            SaveRegMemory.Enabled           = command;
            OutAEn_ComboBox.Enabled         = command;
            OutBEn_ComboBox.Enabled         = command;
            OutAPwr_ComboBox.Enabled        = command;
            OutBPwr_ComboBox.Enabled        = command;
            IntNNumUpDown.Enabled           = command;
            FracNNumUpDown.Enabled          = command;
            ModNumUpDown.Enabled            = command;
            ModeIntFracComboBox.Enabled     = command;
            RefFTextBox.Enabled             = command;
            RDivUpDown.Enabled              = command;
            RefDoublerCheckBox.Enabled      = command;
            DivideBy2CheckBox.Enabled       = command;
            pfdFreqLabel.Enabled            = command;
            fVcoScreenLabel.Enabled         = command;
            fOutAScreenLabel.Enabled        = command;
            fOutBScreenLabel.Enabled        = command;
            ADivComboBox.Enabled            = command;
            PhasePNumericUpDown.Enabled     = command;
            RSetTextBox.Enabled             = command;
            CPCurrentComboBox.Enabled       = command;
            CPLinearityComboBox.Enabled     = command;
            CPTestComboBox.Enabled          = command;
            CPFastLockCheckBox.Enabled      = command;
            CPTriStateOutCheckBox.Enabled   = command;
            CPCycleSlipCheckBox.Enabled     = command;
            PfdPolarity.Enabled             = command;
            InputFreqTextBox.Enabled        = command;
            DeltaShowLabel.Enabled          = command;
            ExportIntoMem1Button.Enabled    = command;
            ExportIntoMem2Button.Enabled    = command;
            ExportIntoMem3Button.Enabled    = command;
            ExportIntoMem4Button.Enabled    = command;
            ImportMem1Button.Enabled        = command;
            ImportMem2Button.Enabled        = command;
            ImportMem3Button.Enabled        = command;
            ImportMem4Button.Enabled        = command;
            CalcFreqShowLabel.Enabled       = command;
            ActOut1ShowLabel.Enabled        = command;
            if (!command)
            {
                ActOut1ShowLabel.BackColor      = SystemColors.ScrollBar;
                ActOut2ShowLabel.BackColor      = SystemColors.ScrollBar;
                Mem1ActOut1ShowLabel.BackColor  = SystemColors.ScrollBar;
                Mem2ActOut1ShowLabel.BackColor  = SystemColors.ScrollBar;
                Mem3ActOut1ShowLabel.BackColor  = SystemColors.ScrollBar;
                Mem4ActOut1ShowLabel.BackColor  = SystemColors.ScrollBar;
                Mem1ActOut2ShowLabel.BackColor  = SystemColors.ScrollBar;
                Mem2ActOut2ShowLabel.BackColor  = SystemColors.ScrollBar;
                Mem3ActOut2ShowLabel.BackColor  = SystemColors.ScrollBar;
                Mem4ActOut2ShowLabel.BackColor  = SystemColors.ScrollBar;
                toolStripStatusLabel1.Text = "";
                LedOnPicBox.Visible = false;
                LedOffPicBox.Visible = false;
            }
            ActOut2ShowLabel.Enabled        = command;
            FreqAtOut1ShowLabel.Enabled     = command;
            FreqAtOut2ShowLabel.Enabled     = command;
            LDSpeedAdjComboBox.Enabled      = command;
            AutoLDSpeedAdjCheckBox.Enabled  = command;
            LDFuncComboBox.Enabled          = command;
            AutoLDFuncCheckBox.Enabled      = command;
            RFoutBPathComboBox.Enabled      = command;
            PhaseAdjustmentModeCheckbox.Enabled = command;
            SigmaDeltaNoiseModeComboBox.Enabled = command;
            LDPrecisionComboBox.Enabled     = command;
            MuxPinModeCombobox.Enabled      = command;
            FBPathComboBox.Enabled          = command;
            PloPowerDownCheckBox.Enabled    = command;
            RefInputShutdownCheckBox.Enabled = command;
            PllShutDownCheckBox.Enabled     = command;
            VcoDividerShutdownCheckBox.Enabled = command;
            VcoLdoShutDownCheckBox.Enabled  = command;
            VcoShutDownCheckBox.Enabled     = command;
            Reg4DoubleBufferedCheckBox.Enabled = command;
            IntNAutoModeWhenF0CheckBox.Enabled = command;
            RandNCountersResetCheckBox.Enabled = command;
            AutoVcoSelectionCheckBox.Enabled = command;
            VASTempCompCheckBox.Enabled     = command;
            ManualVCOSelectNumericUpDown.Enabled = command;
            BandSelClockDivNumericUpDown.Enabled = command;
            MuteUntilLockDetectCheckBox.Enabled   = command; 
            DelayToPreventFlickeringCheckBox.Enabled = command;
            ClockDividerNumericUpDown.Enabled    = command;
            AutoCDIVCalcCheckBox.Enabled         = command;
            DelayInputNumericUpDown.Enabled      = command;
            ADCModeComboBox.Enabled         = command;
            GetADCValueButton.Enabled       = command;
            ReadedADCValueTextBox.Enabled   = command;
            GetCurrentVCOButton.Enabled     = command;
            ReadedVCOValueTextBox.Enabled   = command;
            SaveIntoFileButton.Enabled      = command;
            LoadFromFileButton.Enabled      = command;
            Mem1ActOut1ShowLabel.Enabled    = command;
            Mem2ActOut1ShowLabel.Enabled    = command;
            Mem3ActOut1ShowLabel.Enabled    = command;
            Mem4ActOut1ShowLabel.Enabled    = command;
            Mem1ActOut2ShowLabel.Enabled    = command;
            Mem2ActOut2ShowLabel.Enabled    = command;
            Mem3ActOut2ShowLabel.Enabled    = command;
            Mem4ActOut2ShowLabel.Enabled    = command;
            Mem1RefShowLabel.Enabled    = command;
            Mem2RefShowLabel.Enabled    = command;
            Mem3RefShowLabel.Enabled    = command;
            Mem4RefShowLabel.Enabled    = command;
            MemSaveIntoFileButton.Enabled   = command;
            MemLoadFromFileButton.Enabled   = command;
            Mem1Freq1ShowLabel.Enabled  = command;
            Mem2Freq1ShowLabel.Enabled  = command;
            Mem3Freq1ShowLabel.Enabled  = command;
            Mem4Freq1ShowLabel.Enabled  = command;
            Mem1Freq2ShowLabel.Enabled  = command;
            Mem2Freq2ShowLabel.Enabled  = command;
            Mem3Freq2ShowLabel.Enabled  = command;
            Mem4Freq2ShowLabel.Enabled  = command;
            Mem1PwrAShowLabel.Enabled   = command;
            Mem2PwrAShowLabel.Enabled   = command;
            Mem3PwrAShowLabel.Enabled   = command;
            Mem4PwrAShowLabel.Enabled   = command;
            Mem1PwrBShowLabel.Enabled   = command;
            Mem2PwrBShowLabel.Enabled   = command;
            Mem3PwrBShowLabel.Enabled   = command;
            Mem4PwrBShowLabel.Enabled   = command;
        }

        /// <summary>
        /// If new data arrives via the serial line, 
        /// this function is called, in which incoming data is processed.
        /// </summary>
        /// <param name="Object"></param>
        public void ProccesReceivedData(object Object)
        {
            try
            {
                string text = controller.serialPort.ReadLine();     // read line of new data
                ConsoleController.Console().Write(text);            // write actual readed data
                // Displays the synthesizer locked status information into 
                // the status strip. Also shows LedOn or LedOff picture
                if (text == "plo locked")
                {
                    toolStripStatusLabel1.Text = "        plo is locked";
                    LedOnPicBox.Visible = true;
                    LedOffPicBox.Visible = false;

                }
                else if (text == "plo isn't locked")
                {
                    toolStripStatusLabel1.Text = "        plo isn't locked!";
                    LedOnPicBox.Visible = false;
                    LedOffPicBox.Visible = true;
                }
                else if (text == "plo state is not known")
                {
                    toolStripStatusLabel1.Text = "        plo state is not known";
                    LedOnPicBox.Visible = false;
                    LedOffPicBox.Visible = true;
                }
                else
                {
                    // the received string contains other data
                    // therefore it divides them into individual parts and these 
                    // are further recognized
                    string[] separrated = text.Split(' ');
                    switch (separrated[0])
                    {
                        case "stored_data_1":
                            // data stored in memory 1
                            for (int i = 0; i < 7; i++)
                            {
                                // for all registers, including module control register,
                                // set it into memory 1 model
                                controller.memory.GetRegister(1, i).SetValue(separrated[i+1]);
                            }
                            // refresh memory 1 info 
                            controller.SetMemOutsAndRefFromControlReg(1);
                            controller.RecalcMemoryInfo(1);
                            break;
                        case "stored_data_2":
                            // data stored in memory 2
                            for (int i = 0; i < 7; i++)
                            {
                                // for all registers, including module control register,
                                // set it into memory 2 model
                                controller.memory.GetRegister(2, i).SetValue(separrated[i+1]);
                            }
                            // refresh memory 2 info 
                            controller.SetMemOutsAndRefFromControlReg(2);
                            controller.RecalcMemoryInfo(2);
                            break;
                        case "stored_data_3":
                            // data stored in memory 3
                            for (int i = 0; i < 7; i++)
                            {
                                // for all registers, including module control register,
                                // set it into memory 3 model
                                controller.memory.GetRegister(3, i).SetValue(separrated[i+1]);
                            }
                            // refresh memory 3 info 
                            controller.SetMemOutsAndRefFromControlReg(3);
                            controller.RecalcMemoryInfo(3);
                            break;
                        case "stored_data_4":
                            // data stored in memory 4
                            for (int i = 0; i < 7; i++)
                            {
                                // for all registers, including module control register,
                                // set it into memory 4 model
                                controller.memory.GetRegister(4, i).SetValue(separrated[i+1]);
                            }
                            // refresh memory 4 info 
                            controller.SetMemOutsAndRefFromControlReg(4);
                            controller.RecalcMemoryInfo(4);
                            break;
                        case "register6_vco":
                            // readed VCO number
                            UInt32 reg6 = UInt32.Parse(separrated[1], System.Globalization.NumberStyles.HexNumber);
                            UInt16 currentVCO = (UInt16)Utilities.BitOperations.GetNBits(reg6, 6, 3);
                            controller.readRegister.SetReadedCurrentVCO(currentVCO.ToString());
                            break;
                        case "register6_temp":
                             // readed temperature 
                            UInt32 reg = UInt32.Parse(separrated[1], System.Globalization.NumberStyles.HexNumber);
                            UInt16 ADCvalue = (UInt16)Utilities.BitOperations.GetNBits(reg, 7, 16);
                            decimal temp = 95 - 1.14M * ADCvalue;
                            controller.readRegister.SetReadededADC(temp.ToString() + " °C");
                            break;
                        case "register6_tune":
                            // readed voltage at Tune pin
                            UInt32 regSix = UInt32.Parse(separrated[1], System.Globalization.NumberStyles.HexNumber);
                            UInt16 ADCval = (UInt16)Utilities.BitOperations.GetNBits(regSix, 7, 16);
                            decimal tune = 0.315M + 0.0165M * ADCval;
                            controller.readRegister.SetReadededADC(tune.ToString() + " V");
                            break;
                    }
                }
            }
            catch
            {
                // catch error 
            }
        }

        
        private void NumericUpDwScrollHandlerFunction(object sender, MouseEventArgs e)
        {
            MyFormat.ScrollHandlerFunction((NumericUpDown)sender, e);
        }

#region Synthesizer Module controls
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
            controller.PloModuleInit();
        }

#endregion

#region Registers controls group
        private void RegisterTextBox_TextChanged(object sender, EventArgs e)
        {
            MyFormat.CheckIfHasHexInput((TextBox)sender);
        }
        
        private void RegisterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                controller.SetAndSendRegChangesIntoPlo((((TextBox)(sender)).Name), ((TextBox)(sender)).Text);
            }
        }

        private void RegisterTextBox_LostFocus(object sender, EventArgs e)
        {
            controller.SetAndSendRegChangesIntoPlo((((TextBox)(sender)).Name), ((TextBox)(sender)).Text);
        }

        private void WriteRegisterButton_Click(object sender, EventArgs e)
        {
            controller.CheckAndApplyRegChanges(((Button)(sender)).Name);
        }

        private void RegistersPage_Click(object sender, EventArgs e)
        {
            Reg0Label.Focus();
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

        private void SaveIntoFileButton_Click(object sender, EventArgs e)
        {
            controller.SaveRegistersIntoFile();
        }

        private void LoadFromFileButton_Click(object sender, EventArgs e)
        {
            controller.LoadRegistersFromFile();
        }
        public void ForceLoadRegButton_Click(object sender, EventArgs e)
        {
            controller.ForceLoadAllRegsIntoPlo();
        }

#endregion

#region Serial Port Controls group
        private void AvaibleCOMsComBox_DropDown(object sender, EventArgs e)
        {
            controller.serialPort.GetAvaliablePorts();
        }

        private void AvaibleCOMsComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isForm1Load == true)
                controller.SelectedSerialPortChanged(AvaibleCOMsComBox.Text);
        }

        private void PortButton_Click(object sender, EventArgs e)
        {
            EnableControls(controller.SwitchPort());
            if (controller.moduleControls.GetIntRefState())
                RefFTextBox.Enabled = false;
            if (AutoLDSpeedAdjCheckBox.Checked)
                LDSpeedAdjComboBox.Enabled = false;
            if (AutoLDFuncCheckBox.Checked)
                LDFuncComboBox.Enabled = false;
            if (AutoVcoSelectionCheckBox.Checked)
                ManualVCOSelectNumericUpDown.Enabled = false;
            else 
                VASTempCompCheckBox.Enabled = false;
            if (!AutoCDIVCalcCheckBox.Checked)
                DelayInputNumericUpDown.Enabled = false;
            else
                ClockDividerNumericUpDown.Enabled = false;
        }

#endregion

#region Registers memory

        private void LoadRegMemory_Click(object sender, EventArgs e)
        {
            controller.LoadRegsFromPloMemory();
        }

        private void SaveRegMemory_Click(object sender, EventArgs e)
        {

            controller.SaveRegsIntoPloMemory();
        }

        private void ExportIntoMememoryButton_Click(object sender, EventArgs e)
        {
            controller.ExportMemory(((Button)(sender)).Name);
        }

        private void ImportMememoryButton_Click(object sender, EventArgs e)
        {
            controller.ImportMemory(((Button)(sender)).Name);
        }
        
        private void MemoryRegister_TextChanged(object sender, EventArgs e)
        {
            controller.SetMemoryRegisterValue(((TextBox)(sender)).Name, ((TextBox)(sender)).Text);
        }

        private void MemActOutShowLabel_Click(object sender, EventArgs e)
        {
            controller.MemActOutSwitch(((Label)(sender)).Name);
        }

        
        private void MemRefShowLabel_Click(object sender, EventArgs e)
        {
            controller.MemIntRefStateSwitch(((Label)(sender)).Name);
        }

        private void MemSaveIntoFileButton_Click(object sender, EventArgs e)
        {
            controller.SaveRegMemoriesIntoFile();
        }

        private void MemLoadFromFileButton_Click(object sender, EventArgs e)
        {
            controller.LoadRegMemoriesFromFile();
        }

        #endregion

        #region Output Controls group
        private void OutAEn_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.OutAEnStateChanged(OutAEn_ComboBox.SelectedIndex);
        }

        private void OutBEn_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.OutBEnStateChanged(OutBEn_ComboBox.SelectedIndex);
        }

        private void OutAPwr_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.OutAPwrValueChanged(OutAPwr_ComboBox.SelectedIndex);
        }

        private void OutBPwr_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.OutBPwrValueChanged(OutBPwr_ComboBox.SelectedIndex);
        }

        private void OutBPwr_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {        
            ComboBox comboBox = (ComboBox)sender;

            if (e.Index == 3) //We are disabling item based on Index, you can have your logic here
            {
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), comboBox.Font, SystemBrushes.GrayText, e.Bounds);            }
            else
            {
                e.DrawBackground();

                // Using winwaed's advice for selected items:
                // sets the brush according to whether the item is selected or not
                Brush brush = ( (e.State & DrawItemState.Selected) > 0) ? SystemBrushes.HighlightText : SystemBrushes.ControlText;
                e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), comboBox.Font, brush, e.Bounds);

                e.DrawFocusRectangle();
            }
        }

        private void OutAPwr_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {        
            ComboBox comboBox = (ComboBox)sender;

            e.DrawBackground();

            // Using winwaed's advice for selected items:
            // sets the brush according to whether the item is selected or not
            Brush brush = ( Convert.ToUInt16(e.State & DrawItemState.Selected) == 1 ) ? SystemBrushes.HighlightText : SystemBrushes.ControlText;
            e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), comboBox.Font, brush, e.Bounds);

            e.DrawFocusRectangle();
        }

#endregion

#region Output Frequency Controls group
        private void IntNNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            controller.IntNValueChanged((UInt16)IntNNumUpDown.Value);
        }

        private void FracNNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            controller.FracNValueChanged((UInt16)FracNNumUpDown.Value);
        }

        private void ModNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            controller.ModValueChanged((UInt16)ModNumUpDown.Value);
        }

        private void ModeIntFracComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.SynthModeChanged(ModeIntFracComboBox.SelectedIndex);
        }
        
        private void ADivComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.ADivValueChanged((UInt16)ADivComboBox.SelectedIndex);
        }

        private void PhasePNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            controller.PhasePValueChanged((UInt16)PhasePNumericUpDown.Value);
        }
        
        private void LDFuncComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.LDFunctionIndexChanged(LDFuncComboBox.SelectedIndex);
        }
        
        private void AutoLDFuncCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.AutoLDFuncCheckedChanged(AutoLDFuncCheckBox.Checked);
            LDFuncComboBox.Enabled = !AutoLDFuncCheckBox.Checked;
        }
        
        private void RFoutBPathComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.OutBPathIndexChanged(RFoutBPathComboBox.SelectedIndex);
        }

        
        private void FBPathComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.FBPathIndexChanged(FBPathComboBox.SelectedIndex);
        }
#endregion
        
#region Reference frequency control group
        private void RefFTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            controller.FreqTextBoxBehavior(((TextBox)(sender)), e);
        }

        private void RefFTextBox_LostFocus(object sender, EventArgs e)
        {
            controller.ReferenceFrequencyValueChanged(((TextBox)(sender)).Text);
        }

        private void RefFTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isForm1Load == true)
                MyFormat.CheckIfHasDecimalInput(RefFTextBox);
        }

        private void DoubleRefFCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.ReferenceDoublerStateChanged(RefDoublerCheckBox.Checked);
        }

        private void DivideBy2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.ReferenceDivBy2StateChanged(DivideBy2CheckBox.Checked);
        }

        private void RDivUpDown_ValueChanged(object sender, EventArgs e)
        {
            controller.ReferenceRDividerValueChanged((UInt16)RDivUpDown.Value);
        }

        private void LDSpeedAdjComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.LDSpeedAdjIndexChanged(LDSpeedAdjComboBox.SelectedIndex);
        }

        
        private void AutoLDSpeedAdjCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.AutoLDSpeedAdjChanged(AutoLDSpeedAdjCheckBox.Checked);
            LDSpeedAdjComboBox.Enabled = !AutoLDSpeedAdjCheckBox.Checked;
        }

        #endregion

#region Charge Pump group

        private void RSetTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RSetTextBox_LostFocus(sender, e);
            }
        }

        private void RSetTextBox_LostFocus(object sender, EventArgs e)
        {
            controller.GetCPCurrentFromTextBox(RSetTextBox.Text);
        }

        private void RSetTextBox_TextChanged(object sender, EventArgs e)
        {
            MyFormat.CheckIfHasIntegerInput(RSetTextBox);
        }

        private void CPCurrentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.CPCurrentIndexChanged(CPCurrentComboBox.SelectedIndex);
        }

        private void CPLinearityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.CPLinearityIndexChanged(CPLinearityComboBox.SelectedIndex);
        }

        private void CPTestComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.CPTestModeIndexChanged(CPTestComboBox.SelectedIndex);
        }

        
        private void CPFastLockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.CPFastLockCheckedChanged(CPFastLockCheckBox.Checked);
        }
        
        private void PhaseAdjustmentModeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            controller.PhaseAdjustmentCheckedChanged(PhaseAdjustmentModeCheckbox.Checked);
        }

        
        private void CPCycleSlipCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.CPCycleSlipCheckedChanged(CPCycleSlipCheckBox.Checked);
        }

        
        private void CPTriStateOutCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.CPTristateCheckedChanged(CPTriStateOutCheckBox.Checked);
        }

#endregion

#region Phase Detector group
        private void SDNoiseModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.SDNoiseModeIndexChanged(SigmaDeltaNoiseModeComboBox.SelectedIndex);
        }

        private void LDPrecisionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.LDPrecisionIndexChanged(LDPrecisionComboBox.SelectedIndex);
        }
        
        private void PfdPolarity_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.PositivePdfCheckedChanged(PfdPolarity.SelectedIndex);
        }

#endregion

#region Direct frequency controls
        private void InputFreqTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isForm1Load == true)
                MyFormat.CheckIfHasDecimalInput(InputFreqTextBox);
        }

        private void InputFreqTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            controller.FreqTextBoxBehavior(((TextBox)(sender)), e);
        }

        private void FrequencyTextBox_MouseWheel(object sender, MouseEventArgs e)
        {
            controller.FreqTextBoxMouseWheelFunc((TextBox)(sender), e);
        }

        
        private void ActOut1ShowLabel_Click(object sender, EventArgs e)
        {
            controller.SwitchOut1();
        }

        private void ActOut2ShowLabel_Click(object sender, EventArgs e)
        {
            controller.SwitchOut2();
        }

        private void IntExtShowLabel_Click(object sender, EventArgs e)
        {
            controller.SwitchRef();
        }

        #endregion

#region Generic controls Group

        private void MuxPinModeCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.MuxPinModeIndexChanged(MuxPinModeCombobox.SelectedIndex);
        }

        private void Reg4DoubleBufferedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.Reg4DoubleBufferedStateChanged(Reg4DoubleBufferedCheckBox.Checked);
        }

        private void IntNAutoModeWhenF0CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.IntNAutoModeWhenF0StateChanged(IntNAutoModeWhenF0CheckBox.Checked);
        }

        private void RandNCountersResetCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.RandNCountersResetStateChanged(RandNCountersResetCheckBox.Checked);
        }

#endregion

#region VCO controls group
        
        private void AutoVcoSelectionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.AutoVcoSelectionStateChanged(AutoVcoSelectionCheckBox.Checked);
        }

        private void VASTempCompCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.VASTempComStateChanged(VASTempCompCheckBox.Checked);
        }
        
        private void ManualVCOSelectNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.ManualVCOSelectValueChanged((int)ManualVCOSelectNumericUpDown.Value);
        }
        
        private void BandSelClockDivNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.BandSelClockDivValueChanged((int)BandSelClockDivNumericUpDown.Value);
        }

        private void MuteUntilLockDetectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.MuteUntilLockDetectStateChanged(MuteUntilLockDetectCheckBox.Checked);
        }
        
        private void DelayToPreventFlickeringCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.DelayToPreventFlickeringStateChanged(DelayToPreventFlickeringCheckBox.Checked);
        }

        private void ClockDividerNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.ClockDividerValueChanged((int)ClockDividerNumericUpDown.Value);
        }

        private void AutoCDIVCalcCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.AutoCDIVCalcStateChanged(AutoCDIVCalcCheckBox.Checked);
        }
        
        private void DelayInputNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.DelayInputValueChanged((UInt16)DelayInputNumericUpDown.Value);
        }

        #endregion

#region Shutdown control group

        private void PloPowerDownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.PloPowerDownStateChanged(PloPowerDownCheckBox.Checked);
        }

        private void RefInputShutdownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.RefInputShutdownStateChanged(RefInputShutdownCheckBox.Checked);
        }

        private void PllShutDownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.PllShutDownStateChanged(PllShutDownCheckBox.Checked);
        }

        private void VcoDividerShutdownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.VcoDividerShutDownStateChanged(VcoDividerShutdownCheckBox.Checked);
        }

        private void VcoLdoShutDownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.VcoLdoShutDownStateChanged(VcoLdoShutDownCheckBox.Checked);
        }

        private void VcoShutDownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isForm1Load)
                controller.VcoShutDownStateChanged(VcoShutDownCheckBox.Checked);
        }

#endregion

#region Read Register 6 Control group
        
        private void GetCurrentVCOButton_Click(object sender, EventArgs e)
        {
            controller.GetCurrentVCO();
        }

        private void GetADCValueButton_Click(object sender, EventArgs e)
        {
            controller.GetADCValue();
        }

        private void ADCModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.AdcModeIndexChanged(ADCModeComboBox.SelectedIndex);
        }

        #endregion

    }
}
