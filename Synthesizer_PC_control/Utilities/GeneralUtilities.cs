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

        public static bool IsStringLocatedInArray(string value, string[] arrayValues)
        {
            if (arrayValues == null)
                return false;
            foreach (string valueFromArray in arrayValues)
            {
                if (string.Equals(value, valueFromArray))
                    return true;
            }
            return false;
        }


        /*
            float a;
            int b;
            GeneralUtilities.IsWithin(a, (float)b, (float)b);
        */
        /* TODO Lukas IsWhithin and crop fnc? 
        public static bool IsWithin<T>(T value, T min, T max) where T : IComparable
        {
            if(value >= min && value <= max)
            {
                return true;
            }
            return false;
        }

        public static int Crop(int value, int min, int max)
        {
            if(value > max)
            {
                value = max;
            }
            else if(value < min)
            {
                value = min;
            }

            return value;
        }
        */
    }
}
