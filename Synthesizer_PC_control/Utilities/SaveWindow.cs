using System;
using System.Collections.Generic;

namespace Synthesizer_PC_control.Utilities
{
    /// <summary>
    /// A class that contains variables to store user data in a window.
    /// </summary>
    public class SaveWindow
    {
        /// <summary>
        /// Determines what type of data it is (1-defaults, 2-window, 3-memory)
        /// </summary>
        public DataType dataType { get; set; }

        /// <summary>
        /// Holds PLO register 0-5 values
        /// </summary>
        public IList<string> Registers { get; set; }

        /// <summary>
        /// Holds resistor value for set charge pump current
        /// </summary>
        public UInt16 RSetValue { get; set; }

        /// <summary>
        /// Holds value from direct freq input
        /// </summary>
        public string OutputFreqValue { get; set; }

        /// <summary>
        /// // Holds last entered reference signal frequency value
        /// </summary>
        public string ReferenceFrequency { get; set; }
        
        /// <summary>
        /// It holds module output 1 state (true - On, false - Off)
        /// </summary>
        public bool Out1En { get; set; }

        /// <summary>
        /// // It holds module output 2 state (true - On, false - Off)
        /// </summary>
        public bool Out2En { get; set; }
        
        /// <summary>
        /// It hold if was sellected Internal reference (true) or External (false)
        /// </summary>
        public bool IntRef { get; set; }
        
        /// <summary>
        /// It holds memory 1 registers
        /// </summary>
        public IList<string> Mem1 { get; set; }
        
        /// <summary>
        /// It holds memory 2 registers
        /// </summary>
        public IList<string> Mem2 { get; set; }

        /// <summary>
        /// It holds memory 3 registers
        /// </summary>
        public IList<string> Mem3 { get; set; }

        /// <summary>
        /// It holds memory 4 registers
        /// </summary>
        public IList<string> Mem4 { get; set; }

        /// <summary>
        /// It holds last successfully used COM-port
        /// </summary>
        public string COM_port { get; set; }

        /// <summary>
        /// It holds auto LD speed adjustment 
        /// (true - automaticaly compute LD speed adj., 
        /// false - user must set LD speed manualy from combobox values)
        /// </summary>
        public bool AutoLDSpeedAdj { get; set; }

        /// <summary>
        /// It holds auto LD function 
        /// (true - automaticaly compute LD function, 
        /// false - user must set LD funct. manualy from combobox values )
        /// </summary>
        public bool AutoLDFunc { get; set; }
        
        /// <summary>
        /// It holds automatic CDIV compute from user delay input
        /// </summary>
        public bool AutoCDIVFunc { get; set; }

        /// <summary>
        /// User delay input value in miliseconds
        /// </summary>
        public UInt16 DelayInput { get; set; }

        /// <summary>
        /// ADC Mode index (0 - temperature mode, 1 - Tune pin)
        /// </summary>
        public int AdcModeIndex { get; set; }

        public decimal VcoFreqStep { get; set; }

        /// <summary>
        /// It include default values for SaveWindow
        /// </summary>
        /// <returns>Default values for saving window</returns>
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
                AdcModeIndex = 0,
                VcoFreqStep = 1000
            };

            return saved;
        }
    }
}
