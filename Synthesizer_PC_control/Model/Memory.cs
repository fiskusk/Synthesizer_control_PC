using System;
using System.Windows.Forms;
using System.Drawing;

namespace Synthesizer_PC_control.Model
{
    /// <summary>
    /// This class is used to handle the synthesizer module memory.
    /// </summary>
    class Memory : I_UiLinked
    {
        /// <summary>
        /// registers for memory 1
        /// </summary>
        private MyRegister[] registersMemory1;

        /// <summary>
        /// registers for memory 2
        /// </summary>
        private MyRegister[] registersMemory2;

        /// <summary>
        /// registers for memory 3
        /// </summary>
        private MyRegister[] registersMemory3;

        /// <summary>
        /// registers for memory 4
        /// </summary>
        private MyRegister[] registersMemory4;

        /// <summary>
        /// hold value if memory has active output 1
        /// </summary>
        private bool[] memActiveOut1;

        /// <summary>
        /// hold value if memory has active output 2
        /// </summary>
        private bool[] memActiveOut2;

        /// <summary>
        /// hold value if memory has active internal reference
        /// </summary>
        private bool[] memIntRefState;

        /// <summary>
        /// hold frequency at output 1 for memory
        /// </summary>
        private decimal[] memFreq1Value;

        /// <summary>
        /// hold frequency at output 2 for memory
        /// </summary>
        private decimal[] memFreq2Value;

        /// <summary>
        /// hold power at output 1 for memory
        /// </summary>
        private int[] memPwrAIndex;

        /// <summary>
        /// hold power at output 1 for memory
        /// </summary>
        private int[] memPwrBIndex;
        
        // hold memory UI elements
        private readonly Label[] ui_memActiveOut1;
        private readonly Label[] ui_memActiveOut2;
        private readonly Label[] ui_memIntRefState;
        private readonly Label[] ui_memFreq1Value;
        private readonly Label[] ui_memFreq2Value;
        private readonly Label[] ui_memPwrAIndex;
        private readonly Label[] ui_memPwrBIndex;

        /// <summary>
        /// Constructor for the synthesizer module memory.
        /// </summary>
        /// <param name="registersMemory1"> registers for memory 1 as MyRegister[] </param>
        /// <param name="registersMemory2"> registers for memory 2 as MyRegister[] </param>
        /// <param name="registersMemory3"> registers for memory 3 as MyRegister[] </param>
        /// <param name="registersMemory4"> registers for memory 4 as MyRegister[] </param>
        public Memory(MyRegister[] registersMemory1, MyRegister[] registersMemory2,
                      MyRegister[] registersMemory3, MyRegister[] registersMemory4)
        {
            this.registersMemory1 = registersMemory1;
            this.registersMemory2 = registersMemory2;
            this.registersMemory3 = registersMemory3;
            this.registersMemory4 = registersMemory4;
        }

        /// <summary>
        /// Constructor for the synthesizer module memory.
        /// </summary>
        /// <param name="view"> handle for all Form1 </param>
        public Memory(Form1 view)
        {   
            // memory 1-4 and registers 0-5 is for synthesizer registers,
            // register 6 is control and his porpose is storing module controls 
            // (outputs 1/2 state, internal or external reference)
            var mem1Reg0 = new MyRegister(string.Empty, view.R0M1);
            var mem1Reg1 = new MyRegister(string.Empty, view.R1M1);
            var mem1Reg2 = new MyRegister(string.Empty, view.R2M1);
            var mem1Reg3 = new MyRegister(string.Empty, view.R3M1);
            var mem1Reg4 = new MyRegister(string.Empty, view.R4M1);
            var mem1Reg5 = new MyRegister(string.Empty, view.R5M1);
            var mem1ControlReg = new MyRegister(string.Empty);  

            registersMemory1 = new MyRegister[] {mem1Reg0, mem1Reg1, mem1Reg2, mem1Reg3, mem1Reg4, mem1Reg5, mem1ControlReg};

            var mem2Reg0 = new MyRegister(string.Empty, view.R0M2);
            var mem2Reg1 = new MyRegister(string.Empty, view.R1M2);
            var mem2Reg2 = new MyRegister(string.Empty, view.R2M2);
            var mem2Reg3 = new MyRegister(string.Empty, view.R3M2);
            var mem2Reg4 = new MyRegister(string.Empty, view.R4M2);
            var mem2Reg5 = new MyRegister(string.Empty, view.R5M2);
            var mem2ControlReg = new MyRegister(string.Empty);

            registersMemory2 = new MyRegister[] {mem2Reg0, mem2Reg1, mem2Reg2, mem2Reg3, mem2Reg4, mem2Reg5, mem2ControlReg};

            var mem3Reg0 = new MyRegister(string.Empty, view.R0M3);
            var mem3Reg1 = new MyRegister(string.Empty, view.R1M3);
            var mem3Reg2 = new MyRegister(string.Empty, view.R2M3);
            var mem3Reg3 = new MyRegister(string.Empty, view.R3M3);
            var mem3Reg4 = new MyRegister(string.Empty, view.R4M3);
            var mem3Reg5 = new MyRegister(string.Empty, view.R5M3);
            var mem3ControlReg = new MyRegister(string.Empty);

            registersMemory3 = new MyRegister[] {mem3Reg0, mem3Reg1, mem3Reg2, mem3Reg3, mem3Reg4, mem3Reg5, mem3ControlReg};

            var mem4Reg0 = new MyRegister(string.Empty, view.R0M4);
            var mem4Reg1 = new MyRegister(string.Empty, view.R1M4);
            var mem4Reg2 = new MyRegister(string.Empty, view.R2M4);
            var mem4Reg3 = new MyRegister(string.Empty, view.R3M4);
            var mem4Reg4 = new MyRegister(string.Empty, view.R4M4);
            var mem4Reg5 = new MyRegister(string.Empty, view.R5M4);
            var mem4ControlReg = new MyRegister(string.Empty);

            registersMemory4 = new MyRegister[] {mem4Reg0, mem4Reg1, mem4Reg2, mem4Reg3, mem4Reg4, mem4Reg5, mem4ControlReg};


            ui_memActiveOut1 = new Label[] {view.Mem1ActOut1ShowLabel,
                                            view.Mem2ActOut1ShowLabel,
                                            view.Mem3ActOut1ShowLabel,
                                            view.Mem4ActOut1ShowLabel};

            ui_memActiveOut2 = new Label[] {view.Mem1ActOut2ShowLabel,
                                            view.Mem2ActOut2ShowLabel,
                                            view.Mem3ActOut2ShowLabel,
                                            view.Mem4ActOut2ShowLabel};


            ui_memIntRefState = new Label[] {view.Mem1RefShowLabel,
                                             view.Mem2RefShowLabel,
                                             view.Mem3RefShowLabel,
                                             view.Mem4RefShowLabel};

            ui_memFreq1Value = new Label[] {view.Mem1Freq1ShowLabel,
                                            view.Mem2Freq1ShowLabel,
                                            view.Mem3Freq1ShowLabel,
                                            view.Mem4Freq1ShowLabel};

            ui_memFreq2Value = new Label[] {view.Mem1Freq2ShowLabel,
                                            view.Mem2Freq2ShowLabel,
                                            view.Mem3Freq2ShowLabel,
                                            view.Mem4Freq2ShowLabel};

            ui_memPwrAIndex = new Label[] {view.Mem1PwrAShowLabel,
                                           view.Mem2PwrAShowLabel,
                                           view.Mem3PwrAShowLabel,
                                           view.Mem4PwrAShowLabel};

            ui_memPwrBIndex = new Label[] {view.Mem1PwrBShowLabel,
                                           view.Mem2PwrBShowLabel,
                                           view.Mem3PwrBShowLabel,
                                           view.Mem4PwrBShowLabel};

            memActiveOut1 = new bool[] {false, false, false, false};
            memActiveOut2 = new bool[] {false, false, false, false};
            memIntRefState = new bool[] {false, false, false, false};
            memFreq1Value = new decimal[] {0, 0, 0, 0};
            memFreq2Value = new decimal[] {0, 0, 0, 0};
            memPwrAIndex = new int[] {0, 0, 0, 0};
            memPwrBIndex = new int[] {0, 0, 3, 0};
        }

        /// <summary>
        /// Call this to refresh all registers in memory.
        /// </summary>
        public void UpdateUiElements()
        {
            foreach (var register in registersMemory1)
            {
                register.UpdateUiElements();
            }

            foreach (var register in registersMemory2)
            {
                register.UpdateUiElements();
            }

            foreach (var register in registersMemory3)
            {
                register.UpdateUiElements();
            }

            foreach (var register in registersMemory4)
            {
                register.UpdateUiElements();
            }

            for (UInt16 i = 0; i <= 3; i++)
            {
                if (memActiveOut1[i])
                {
                    ui_memActiveOut1[i].Text = "On";
                    ui_memActiveOut1[i].BackColor = Color.LimeGreen;
                }
                else
                {
                    ui_memActiveOut1[i].Text = "Off";
                    ui_memActiveOut1[i].BackColor = SystemColors.ControlDark;
                }

                if (memActiveOut2[i])
                {
                    ui_memActiveOut2[i].Text = "On";
                    ui_memActiveOut2[i].BackColor = Color.LimeGreen;
                }
                else
                {
                    ui_memActiveOut2[i].Text = "Off";
                    ui_memActiveOut2[i].BackColor = SystemColors.ControlDark;
                }

                if (memIntRefState[i])
                    ui_memIntRefState[i].Text = "Internal";
                else
                    ui_memIntRefState[i].Text = "External";
                
                if (memFreq1Value[i] == 0)
                    ui_memFreq1Value[i].Text = "-";
                else
                    ui_memFreq1Value[i].Text = memFreq1Value[i].ToString("0.000 000");
                
                if (memFreq2Value[i] == 0)
                    ui_memFreq2Value[i].Text = "-";
                else
                    ui_memFreq2Value[i].Text = memFreq2Value[i].ToString("0.000 000");

                switch (memPwrAIndex[i])
                {
                    case 0:
                        ui_memPwrAIndex[i].Text = "- 4 dBm";
                        ui_memPwrAIndex[i].ForeColor = Color.Black;
                        break;
                    case 1:
                        ui_memPwrAIndex[i].Text = "- 1 dBm";
                        ui_memPwrAIndex[i].ForeColor = Color.Black;
                        break;
                    case 2:
                        ui_memPwrAIndex[i].Text = "+ 2 dBm";
                        ui_memPwrAIndex[i].ForeColor = Color.Black;
                        break;
                    case 3:
                        ui_memPwrAIndex[i].Text = "+ 5 dBm";
                        ui_memPwrAIndex[i].ForeColor = Color.Black;
                        break;
                    default:
                        ui_memPwrAIndex[i].Text = "Disabled";
                        ui_memPwrAIndex[i].ForeColor = Color.Red;
                        break;
                }

                switch (memPwrBIndex[i])
                {
                    case 0:
                        ui_memPwrAIndex[i].Text = "- 4 dBm";
                        ui_memPwrBIndex[i].ForeColor = Color.Black;
                        break;
                    case 1:
                        ui_memPwrBIndex[i].Text = "- 1 dBm";
                        ui_memPwrBIndex[i].ForeColor = Color.Black;
                        break;
                    case 2:
                        ui_memPwrBIndex[i].Text = "+ 2 dBm";
                        ui_memPwrBIndex[i].ForeColor = Color.Black;
                        break;
                    case 3:
                        ui_memPwrBIndex[i].Text = "!!!+ 5 dBm!!!";
                        ui_memPwrBIndex[i].ForeColor = Color.Red;
                        break;
                    default:
                        ui_memPwrBIndex[i].Text = "Disabled";
                        ui_memPwrBIndex[i].ForeColor = Color.Red;
                        break;
                }
            }
        }

        #region Getters

        /// <summary>
        /// Call this function to get specific memory synthesizer register
        /// </summary>
        /// <param name="memory"> memory number (1-4) </param>
        /// <param name="regIndex"> specific register index (0-5) </param>
        /// <returns> 'null' if is bad sellected memory or register index, otherwise MyRegister </returns>
        public MyRegister GetRegister(int memory, int regIndex)
        {
            if (regIndex < 0 || regIndex > 6)
                return null;

            switch (memory)
            {
                case 1:
                    return registersMemory1[regIndex];
                case 2:
                    return registersMemory2[regIndex];
                case 3:
                    return registersMemory3[regIndex];
                case 4:
                    return registersMemory4[regIndex];
                default:
                    return null;
            }
        }

        /// <summary>
        /// This function return if specific memory have active output 1
        /// </summary>
        /// <param name="memory"> memory number (1-4) </param>
        /// <returns> 
        ///     true if enabled, 
        ///     false if disabled 
        /// </returns>
        public bool GetMemOut1State(int memory)
        {
            return memActiveOut1[--memory];
        }
        
        /// <summary>
        /// This function return if specific memory have active output 2
        /// </summary>
        /// <param name="memory"> memory number (1-4) </param>
        /// <returns> 
        ///     true if enabled, 
        ///     false if disabled 
        /// </returns>
        public bool GetMemOut2State(int memory)
        {
            return memActiveOut2[--memory];
        }

        /// <summary>
        /// This function return if specific memory have active internal reference or external 
        /// </summary>
        /// <param name="memory"> memory number (1-4) </param>
        /// <returns> 
        ///     true - internal reference, 
        ///     false - external reference 
        /// </returns>
        public bool GetIntRefState(int memory)
        {
            return memIntRefState[--memory];
        }

        #endregion

        #region Setters

        /// <summary>
        /// This function set state of active output 1 for specific memory 
        /// </summary>
        /// <param name="state"> 
        ///     true if enabled, 
        ///     false if disabled 
        /// </param>
        /// <param name="memory"> specific memory number (1-4) </param>
        public void SetMemOut1State(bool state, int memory)
        {
            if (state != memActiveOut1[--memory])
            {
                memActiveOut1[memory] = state;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// This function set state of active output 2 for specific memory 
        /// </summary>
        /// <param name="state"> 
        ///     true if enabled, 
        ///     false if disabled 
        /// </param>
        /// <param name="memory"> specific memory number (1-4) </param>
        public void SetMemOut2State(bool state, int memory)
        {
            if (state != memActiveOut2[--memory])
            {
                memActiveOut2[memory] = state;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// This function set internal reference state for specific memory 
        /// </summary>
        /// <param name="state"> 
        ///     true if internal, 
        ///     false if external 
        /// </param>
        /// <param name="memory"> specific memory number (1-4) </param>
        public void SetMemIntRefState(bool state, int memory)
        {
            if (state != memIntRefState[--memory])
            {
                memIntRefState[memory] = state;

                UpdateUiElements();
            }
        }

        /// <summary>
        /// This function set frequency at output 1 for specific memory 
        /// </summary>
        /// <param name="value"> decimal value of frequency </param>
        /// <param name="memoryNumber"> specific memory number (1-4) </param>
        public void SetMemFreq1Value(decimal value, UInt16 memoryNumber)
        {
            if (value != memFreq1Value[--memoryNumber])
            {
                memFreq1Value[memoryNumber] = value;

                UpdateUiElements();
            }

        }

        /// <summary>
        /// This function set frequency at output 1 for specific memory 
        /// </summary>
        /// <param name="value"> decimal value of frequency </param>
        /// <param name="memoryNumber"> specific memory number (1-4) </param>
        public void SetMemFreq2Value(decimal value, UInt16 memoryNumber)
        {
            if (value != memFreq2Value[--memoryNumber])
            {
                memFreq2Value[memoryNumber] = value;

                UpdateUiElements();
            }

        }

        /// <summary>
        /// This function set index of power at synthesizer output A for specific memory 
        /// </summary>
        /// <param name="value"> 
        ///     index of power 
        ///     ('0' for "-4dBm", 
        ///     '1' for "-1dBm", 
        ///     '2' for "+2dBm", 
        ///     '3' for "+5dBm", 
        ///     otherwise "Disabled" )
        /// </param>
        /// <param name="memoryNumber"> specific memory number (1-4) </param>
        public void SetMemPwrAIndex(int value, UInt16 memoryNumber)
        {
            if (value != memPwrAIndex[--memoryNumber])
            {
                memPwrAIndex[memoryNumber] = value;

                UpdateUiElements();
            }

        }

        /// <summary>
        /// This function set index of power at synthesizer output B for specific memory 
        /// </summary>
        /// <param name="value"> 
        ///     index of power 
        ///     ('0' for "-4dBm", 
        ///     '1' for "-1dBm", 
        ///     '2' for "+2dBm", 
        ///     '3' for "!!!+5dBm!!!" [this value is disabled, because freq doubler allow max +3dBm at his input],
        ///     otherwise "Disabled" )
        /// </param>
        /// <param name="memoryNumber"> specific memory number (1-4) </param>
        public void SetMemPwrBIndex(int value, UInt16 memoryNumber)
        {
            if (value != memPwrBIndex[--memoryNumber])
            {
                memPwrBIndex[memoryNumber] = value;

                UpdateUiElements();
            }
        }
        
        #endregion
    }
}