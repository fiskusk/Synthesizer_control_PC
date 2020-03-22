using System.Collections.Generic;

namespace Synthesizer_PC_control.Utilities
{
    public class SaveDefaults
    {
        public IList<string> Registers { get; set; }
        public bool Out1State { get; set; }
        public bool Out2State { get; set; }
        public bool RefState { get; set; }

        public static SaveDefaults GetDefaultValues()
        {
            SaveDefaults saved = new SaveDefaults
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

                Out1State = true,
                Out2State = false,
                RefState = true
            };

            return saved;
        }
    }
}
