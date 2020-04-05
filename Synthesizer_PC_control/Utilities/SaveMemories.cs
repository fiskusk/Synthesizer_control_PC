using System.Collections.Generic;

namespace Synthesizer_PC_control.Utilities
{
    public class SaveMemories
    {
        /// <summary>
        /// Determines what type of data it is (1-defaults, 2-window, 3-memory)
        /// </summary>
        public DataType dataType { get; set; }

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
        /// It include default values for SaveMemories
        /// </summary>
        /// <returns> Default values for save memories </returns>
        public static SaveMemories GetDefaultSaveMemories()
        {
            SaveMemories saved = new SaveMemories
            {
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
            };

            return saved;
        }
    }
}