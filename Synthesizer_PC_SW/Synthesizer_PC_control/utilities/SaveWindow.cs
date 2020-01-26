using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer_PC_control.Utilities
{
    public class SaveWindow
    {
        public IList<string> Registers { get; set; }
        public UInt16 RSetValue { get; set; }
        public IList<string> Mem1 { get; set; }
        public IList<string> Mem2 { get; set; }
        public IList<string> Mem3 { get; set; }
        public IList<string> Mem4 { get; set; }
        public string COM_port { get; set; }

        public SaveWindow()
        {

        }
        public SaveWindow(int param1)
        {

        }

        public static SaveWindow GetDefaultSaveWindow()
        {
            SaveWindow saved = new SaveWindow
            {
                Registers = new List<string>
                {
                    //controller.registers[0].string_GetValue(),
                    //controller.registers[1].string_GetValue(),
                    //controller.registers[2].string_GetValue(),
                    //controller.registers[3].string_GetValue(),
                    //controller.registers[4].string_GetValue(),
                    //controller.registers[5].string_GetValue()
                },
                //RSetValue = Convert.ToUInt16(RSetTextBox.Text),
                RSetValue = 0,
                Mem1 = new List<string>
                {
                    //R0M1.Text,
                    //R1M1.Text,
                    //R2M1.Text,
                    //R3M1.Text,
                    //R4M1.Text,
                    //R5M1.Text,
                },
                Mem2 = new List<string>
                {
                    //R0M2.Text,
                    //R1M2.Text,
                    //R2M2.Text,
                    //R3M2.Text,
                    //R4M2.Text,
                    //R5M2.Text,
                },
                Mem3 = new List<string>
                {
                    //R0M3.Text,
                    //R1M3.Text,
                    //R2M3.Text,
                    //R3M3.Text,
                    //R4M3.Text,
                    //R5M3.Text,
                },
                Mem4 = new List<string>
                {
                    //R0M4.Text,
                    //R1M4.Text,
                    //R2M4.Text,
                    //R3M4.Text,
                    //R4M4.Text,
                    //R5M4.Text,
                },
                //COM_port = AvaibleCOMsComBox.Text
                COM_port = ""
            };

            return saved;
        }
    }
}
