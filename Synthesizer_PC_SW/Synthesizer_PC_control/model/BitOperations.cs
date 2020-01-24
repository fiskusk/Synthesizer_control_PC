using System;

namespace Synthesizer_PC_control
{
    public enum BitState
    {
        RESET,
        SET,
        TRISTATE
    }

    static class BitOperations
    {
        public static UInt32 SetResetOneBit(UInt32 val, UInt16 bit, BitState bitState)
        {
            if (bitState == BitState.SET)
                val |= unchecked((UInt32)(1<<bit));
            else
                val &= ~unchecked((UInt32)(1<<bit));
            return val;
        }

        public static UInt32 ChangeNBits(UInt32 changedVal, UInt32 changingVal, int N, int StartingBit)
        {
            UInt32 mask = 0;
            for (UInt16 i = 0; i < N; i++)
            {
                mask += (UInt32)(1 << i);
            }
            changedVal &= ~(mask << StartingBit);
            changedVal += (changingVal <<  StartingBit);
            return changedVal;
        }
    }
}
