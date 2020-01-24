using System;
using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{
    class Memory
    {
        /*
            TODO FILIP
            Třída Memory, která drží všechny registersMemory1 - registersMemory4 (nový soubor Memory.cs)
            V kontroktoru ZATÍM může dostat view aby si zjistila hodnoty (jak to delat je v controller.cs, ten ma referenci na view)
            => napsat todo pro změnu na hodnoty z kontrolleru
            => Případně může Memory.cs znát ZATÍM nějaké defoult hardcoded hodnoty

            Memory bude mít funkce na vrácení registru podle čísla paměti a indexu
            např. public MyRegister(int memory, int regIndex)
            => pozor na větší číslo než je paměť => vrátit null?
        */
        private readonly Form1 view;
        public MyRegister[] registersMemory1;
        public MyRegister[] registersMemory2;
        public MyRegister[] registersMemory3;
        public MyRegister[] registersMemory4;
        // TODO FILIP other memories
        public Memory(Form1 view)
        {
            this.view = view;
            // TODO FILIP  změna hodnoty v kontroleru
            var mem1Reg0 = new MyRegister(view.R0M1.Text, view.R0M1);
            var mem1Reg1 = new MyRegister(view.R1M1.Text, view.R1M1);
            var mem1Reg2 = new MyRegister(view.R2M1.Text, view.R2M1);
            var mem1Reg3 = new MyRegister(view.R3M1.Text, view.R3M1);
            var mem1Reg4 = new MyRegister(view.R4M1.Text, view.R4M1);
            var mem1Reg5 = new MyRegister(view.R5M1.Text, view.R5M1);

            registersMemory1 = new MyRegister[] {mem1Reg0, mem1Reg1, mem1Reg2, mem1Reg3, mem1Reg4, mem1Reg5};

            var mem2Reg0 = new MyRegister(view.R0M2.Text, view.R0M2);
            var mem2Reg1 = new MyRegister(view.R1M2.Text, view.R1M2);
            var mem2Reg2 = new MyRegister(view.R2M2.Text, view.R2M2);
            var mem2Reg3 = new MyRegister(view.R3M2.Text, view.R3M2);
            var mem2Reg4 = new MyRegister(view.R4M2.Text, view.R4M2);
            var mem2Reg5 = new MyRegister(view.R5M2.Text, view.R5M2);

            registersMemory1 = new MyRegister[] {mem1Reg0, mem1Reg1, mem1Reg2, mem1Reg3, mem1Reg4, mem1Reg5};

            var mem3Reg0 = new MyRegister(view.R0M3.Text, view.R0M3);
            var mem3Reg1 = new MyRegister(view.R1M3.Text, view.R1M3);
            var mem3Reg2 = new MyRegister(view.R2M3.Text, view.R2M3);
            var mem3Reg3 = new MyRegister(view.R3M3.Text, view.R3M3);
            var mem3Reg4 = new MyRegister(view.R4M3.Text, view.R4M3);
            var mem3Reg5 = new MyRegister(view.R5M3.Text, view.R5M3);

            registersMemory1 = new MyRegister[] {mem1Reg0, mem1Reg1, mem1Reg2, mem1Reg3, mem1Reg4, mem1Reg5};

            var mem4Reg0 = new MyRegister(view.R0M4.Text, view.R0M4);
            var mem4Reg1 = new MyRegister(view.R1M4.Text, view.R1M4);
            var mem4Reg2 = new MyRegister(view.R2M4.Text, view.R2M4);
            var mem4Reg3 = new MyRegister(view.R3M4.Text, view.R3M4);
            var mem4Reg4 = new MyRegister(view.R4M4.Text, view.R4M4);
            var mem4Reg5 = new MyRegister(view.R5M4.Text, view.R5M4);

            registersMemory1 = new MyRegister[] {mem1Reg0, mem1Reg1, mem1Reg2, mem1Reg3, mem1Reg4, mem1Reg5};
            
        }

        public void MyRegister(int memory, int regIndex)
        {

        }
    }
}