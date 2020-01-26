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

        public static SaveWindow GetDefaultSaveWindow()
        {
            SaveWindow saved = new SaveWindow
            {
                Registers = new List<string>
                {
                    "00980318",
                    "A00107D1",
                    "78004042",
                    "00001F23",
                    "63AE80FC",
                    "00400005"
                },
                RSetValue = 4700,
                Mem1 = new List<string>
                {
                    "80C90000",
                    "800103E9",
                    "00005F42",
                    "00001F23",
                    "63BE80E4",
                    "00400005"
                },
                Mem2 = new List<string>
                {
                    "80C90000",
                    "800103E9",
                    "00005F42",
                    "00001F23",
                    "63BE80E4",
                    "00400005"
                },
                Mem3 = new List<string>
                {
                    "80C90000",
                    "800103E9",
                    "00005F42",
                    "00001F23",
                    "63BE80E4",
                    "00400005"
                },
                Mem4 = new List<string>
                {
                    "80C90000",
                    "800103E9",
                    "00005F42",
                    "00001F23",
                    "63BE80E4",
                    "00400005"
                },
                //COM_port = AvaibleCOMsComBox.Text
                COM_port = ""
            };

            return saved;
        }
    }
}
