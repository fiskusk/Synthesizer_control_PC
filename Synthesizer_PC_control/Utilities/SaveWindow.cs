using System;
using System.Collections.Generic;

namespace Synthesizer_PC_control.Utilities
{
    public class SaveWindow
    {
        public IList<string> Registers { get; set; }
        public UInt16 RSetValue { get; set; }
        public string OutputFreqValue { get; set; }
        public string ReferenceFrequency { get; set; }
        public bool Out1En { get; set; }
        public bool Out2En { get; set; }
        public bool IntRef { get; set; }
        public IList<string> Mem1 { get; set; }
        public IList<string> Mem2 { get; set; }
        public IList<string> Mem3 { get; set; }
        public IList<string> Mem4 { get; set; }
        public string COM_port { get; set; }
        public bool AutoLDSpeedAdj { get; set; }
        public bool AutoLDFunc { get; set; }
        public bool AutoCDIVFunc { get; set; }
        public UInt16 DelayInput { get; set; }
        public int AdcModeIndex { get; set; }

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
                    "63BE82BC",
                    "00400005"
                },
                RSetValue = 4700,
                OutputFreqValue = "500.0000000",
                ReferenceFrequency = "10,000000",
                Out1En = true,
                Out2En = false, 
                IntRef = true,
                Mem1 = new List<string>
                {
                    "80C80018",
                    "800003E9",
                    "18005F42",
                    "00001F23",
                    "63BE80FC",
                    "00400005",
                    "00000001"
                },
                Mem2 = new List<string>
                {
                    "00C80008",
                    "A00003E9",
                    "18005E42",
                    "00001F23",
                    "63BE80FC",
                    "00400005",
                    "00000001"
                },
                Mem3 = new List<string>
                {
                    "00C80018",
                    "A00007D1",
                    "18005E42",
                    "00001F23",
                    "63BE80FC",
                    "00400005",
                    "00000001"
                },
                Mem4 = new List<string>
                {
                    "00C80038",
                    "A0000FA1",
                    "18005E42",
                    "00001F23",
                    "63BE80FC",
                    "00400005",
                    "00000001"
                },
                COM_port = "COM3",
                AutoLDSpeedAdj = true,
                AutoLDFunc = true,
                AutoCDIVFunc = true,
                DelayInput = 20,
                AdcModeIndex = 0
            };

            return saved;
        }
    }
}
