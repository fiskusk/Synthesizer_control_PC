using System;

namespace Synthesizer_PC_control.Utilities
{
    /// <summary>
    /// Enumerable to describe the state of the bit
    /// </summary>
    public enum BitState
    {
        RESET,
        SET,
        TRISTATE
    }

    /// <summary>
    /// A static class that contains functions for handling numbers at the base of bits.
    /// Includes a function to set and reset a specific bit in a 32-bit number,
    /// change specific N bits to a new value
    /// </summary>
    static class BitOperations
    {
        /// <summary>
        /// This function set and reset a specific bit in a 32-bit number
        /// </summary>
        /// <param name="val"> 32-bit usigned integer number to change </param>
        /// <param name="bit"> number of bit in 32-bit unsigned integer number to change </param>
        /// <param name="bitState"> Bit state to change to. (RESET or SET)</param>
        /// <returns> new changed value </returns>
        public static UInt32 SetResetOneBit(UInt32 val, UInt16 bit, BitState bitState)
        {
            if (bitState == BitState.SET)
                val |= unchecked((UInt32)(1<<bit));     // set appropriate bit
            else
                val &= ~unchecked((UInt32)(1<<bit));    // reset appropriate bit

            return val;
        }

        /// <summary>
        /// This function change specific N bits to a new value
        /// </summary>
        /// <param name="changedVal"> changed old 32-bit unsigned integer number </param>
        /// <param name="changingVal"> The value by which the input number will change </param>
        /// <param name="N"> Number of bits </param>
        /// <param name="startingBit"> The initial bit from which it will change </param>
        /// <returns> new changed value </returns>
        public static UInt32 ChangeNBits(UInt32 changedVal, UInt32 changingVal, int N, int startingBit)
        {
            changedVal &= ~(GetMask(N) << startingBit);     // Resets the appropriate bit positions
            changedVal += (changingVal <<  startingBit);    // Writes the input data to the appropriate positions

            return changedVal;
        }

        /// <summary>
        /// The function gets N bits from an unsigned 32-bit number from a specific position.
        /// </summary>
        /// <param name="input_value"> The input value from which to gets the N bits. </param>
        /// <param name="N"> Number of bits </param>
        /// <param name="StartingBit"> The initial bit </param>
        /// <returns> new parsed N-bit number </returns>
        public static UInt32 GetNBits(UInt32 input_value, int N, int StartingBit)
        {
            input_value &= (GetMask(N) << StartingBit);

            return (input_value >> StartingBit);
        }

        /// <summary>
        /// The function returns a mask of N-bits (N = 3, returns 0b111)
        /// </summary>
        /// <param name="N"> number of bits </param>
        /// <returns> created mask with N bits </returns>
        private static UInt32 GetMask(int N)
        {
            UInt32 mask = 0;
            for (UInt16 i = 0; i < N; i++)
            {
                mask += (UInt32)(1 << i);
            }
            return mask;
        }
    }
}
