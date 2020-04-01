using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer_PC_control.Utilities
{
    /// <summary>
    /// General purpose utilities. It contains functions for searching 
    /// a text string in a string array and function for comparing two string fields
    /// </summary>
    static class GeneralUtilities
    {
        /// <summary>
        /// It compares whether the string arrays match
        /// </summary>
        /// <param name="firstStringArray"> first string to compare </param>
        /// <param name="secondStringArray"> second string to compare </param>
        /// <returns> result whether string arrays match </returns>
        public static bool CompareStringArrays(string[] firstStringArray, string[] secondStringArray)
        {
            bool found = false;

            // any array is empty
            if (firstStringArray == null || secondStringArray == null)
                return false;

            // array lengths vary
            if (firstStringArray.Length < secondStringArray.Length || firstStringArray.Length > secondStringArray.Length)
                return false;
                
            // searches if all items in the array are present
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


        /// <summary>
        /// Determines if the string input value is in the string array
        /// </summary>
        /// <param name="value"> the text string to be searched for </param>
        /// <param name="arrayValues">an array of text strings in which the value will be searched </param>
        /// <returns> located or not </returns>
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
    }
}
