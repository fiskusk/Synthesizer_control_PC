using System;
using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{
    class Memory : I_UiLinked
    {
        private MyRegister[] registersMemory1;
        private MyRegister[] registersMemory2;
        private MyRegister[] registersMemory3;
        private MyRegister[] registersMemory4;

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
        }
    }
}