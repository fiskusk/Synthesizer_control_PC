using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer_PC_control.Utilities
{
    static class GeneralUtilities
    {
        public static bool CompareStringArrays(string[] firstStringArray, string[] secondStringArray)
        {
            bool found = false;
            if (firstStringArray == null || secondStringArray == null)
                return false;
            if (firstStringArray.Length < secondStringArray.Length || firstStringArray.Length > secondStringArray.Length)
                return false;
            foreach(string part1 in firstStringArray)
            {
                found = false;
                foreach(string part2 in secondStringArray)
                {
                    if (string.Equals(part1, part2))
                        found = true;
                }
                if (found == false)
                    return false;
            }
            return found;
        }
    }
}
