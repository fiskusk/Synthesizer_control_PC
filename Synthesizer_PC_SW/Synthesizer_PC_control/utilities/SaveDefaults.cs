using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer_PC_control.Utilities
{
    public class SaveDefaults
    {
        public IList<string> Registers { get; set; }

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
                }
            };

            return saved;
        }
    }
}
