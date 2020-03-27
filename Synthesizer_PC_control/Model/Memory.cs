using System;
using System.Windows.Forms;
using System.Drawing;

namespace Synthesizer_PC_control.Model
{
    class Memory : I_UiLinked
    {
        private MyRegister[] registersMemory1;
        private MyRegister[] registersMemory2;
        private MyRegister[] registersMemory3;
        private MyRegister[] registersMemory4;

        private bool[] memActiveOut1;
        private bool[] memActiveOut2;
        private bool[] memIntRefState;
        private decimal[] memFreq1Value;
        private decimal[] memFreq2Value;
        private int[] memPwrAIndex;
        private int[] memPwrBIndex;

        private readonly Label[] ui_memActiveOut1;
        private readonly Label[] ui_memActiveOut2;
        private readonly Label[] ui_memIntRefState;
        private readonly Label[] ui_memFreq1Value;
        private readonly Label[] ui_memFreq2Value;
        private readonly Label[] ui_memPwrAIndex;
        private readonly Label[] ui_memPwrBIndex;

        public Memory(MyRegister[] registersMemory1, MyRegister[] registersMemory2,
                      MyRegister[] registersMemory3, MyRegister[] registersMemory4)
        {
            this.registersMemory1 = registersMemory1;
            this.registersMemory2 = registersMemory2;
            this.registersMemory3 = registersMemory3;
            this.registersMemory4 = registersMemory4;
        }

        public Memory(Form1 view)
        {
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

        public bool GetMemOut1State(int memory)
        {
            return memActiveOut1[--memory];
        }

        public bool GetMemOut2State(int memory)
        {
            return memActiveOut2[--memory];
        }

        public bool GetIntRefState(int memory)
        {
            return memIntRefState[--memory];
        }

        public void SetMemOut1State(bool state, int memory)
        {
            if (state != memActiveOut1[--memory])
            {
                memActiveOut1[memory] = state;

                UpdateUiElements();
            }
        }

        public void SetMemOut2State(bool state, int memory)
        {
            if (state != memActiveOut2[--memory])
            {
                memActiveOut2[memory] = state;

                UpdateUiElements();
            }
        }

        public void SetMemIntRefState(bool state, int memory)
        {
            if (state != memIntRefState[--memory])
            {
                memIntRefState[memory] = state;

                UpdateUiElements();
            }
        }

        public void SetMemFreq1Value(decimal value, UInt16 memoryNumber)
        {
            if (value != memFreq1Value[--memoryNumber])
            {
                memFreq1Value[memoryNumber] = value;

                UpdateUiElements();
            }

        }
        public void SetMemFreq2Value(decimal value, UInt16 memoryNumber)
        {
            if (value != memFreq2Value[--memoryNumber])
            {
                memFreq2Value[memoryNumber] = value;

                UpdateUiElements();
            }

        }
        public void SetMemPwrAIndex(int value, UInt16 memoryNumber)
        {
            if (value != memPwrAIndex[--memoryNumber])
            {
                memPwrAIndex[memoryNumber] = value;

                UpdateUiElements();
            }

        }
        public void SetMemPwrBIndex(int value, UInt16 memoryNumber)
        {
            if (value != memPwrBIndex[--memoryNumber])
            {
                memPwrBIndex[memoryNumber] = value;

                UpdateUiElements();
            }

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
    }
}