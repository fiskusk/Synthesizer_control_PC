using System.Collections.Generic;

namespace Synthesizer_PC_control.Utilities
{
    public class SaveDefaults
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
        /// It holds module output 1 state (true - On, false - Off)
        /// </summary>
        public bool Out1State { get; set; }

        /// <summary>
        /// It holds module output 2 state (true - On, false - Off)
        /// </summary>
        public bool Out2State { get; set; }

        /// <summary>
        /// It hold if was sellected Internal reference (true) or External (false)
        /// </summary>
        public bool RefState { get; set; }

        /// <summary>
        /// It include default values for SaveDefaults
        /// </summary>
        /// <returns> Default values for save defaults </returns>
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
