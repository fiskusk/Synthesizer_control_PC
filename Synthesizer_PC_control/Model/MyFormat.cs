using System;
using System.Windows;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Globalization;

namespace Synthesizer_PC_control
{
    static class MyFormat
    {
        public static void CheckIfHasHexInput(TextBox sender)
        {
            string item = sender.Text;
            int n = 0;
            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
                item != String.Empty)
            {
                int position = sender.SelectionStart-1;
                item = item.Remove(position, 1);
                sender.Text = item;
                sender.SelectionStart = position;
            }
        }

        /*
        public static void CheckIfHasDecimalInput(TextBox sender)
        {
            string item = sender.Text;
            decimal n = 0;
            if ((!decimal.TryParse(item, NumberStyles.AllowDecimalPoint, new NumberFormatInfo() {
                NumberDecimalSeparator = ".", NumberGroupSeparator = " " },  out n) &&
                !decimal.TryParse(item, NumberStyles.AllowDecimalPoint, new NumberFormatInfo() {
                NumberDecimalSeparator = ",", NumberGroupSeparator = " " }, out n)) &&
                item != String.Empty)
            {
                if (sender.SelectionStart != 0)
                {
                    int position = sender.SelectionStart-1;
                    item = item.Remove(position, 1);
                    sender.Text = item;
                    sender.SelectionStart = position;
                }
            }
        }
        */
        public static void CheckIfHasDecimalInput(TextBox sender)
        {
            string item = sender.Text;
            int position;
            position = sender.SelectionStart;
            bool[] commaIsHere = new bool[item.Length];
            UInt16 commaCounter = 0;

            for (UInt16 i = 0; i < item.Length; i++)
            {
                // check if number with . or , decimal separator input. 
                // Spaces for separates orders are allowed
                if (!((item[i] >= '0' && item[i] <= '9') || 
                       item[i] == ' ' || item[i] == '.' || item[i] == ','))
                {
                    item = item.Remove(i, 1);
                    i--;
                    position--;
                }

                // now check, if spaces or decimal separators doesn't repeat
                else if (i == 0)
                {
                    if ((item[i] == ' ') ||
                        (item[i] == '.' && item[i+1] == '.') ||
                        (item[i] == ',' && item[i+1] == ',') ||
                        (item[i] == '.' && item[i+1] == ',') ||
                        (item[i] == ',' && item[i+1] == '.') ||
                        (item[i] == ' ' && item[i+1] == '.') ||
                        (item[i] == ' ' && item[i+1] == ','))
                    {
                        item = item.Remove(i, 1);
                        i--;
                        position--;
                    }
                }
                else if (i == item.Length - 1)
                {
                    if ((item[i] == ' ' && item[i-1] == ' ') ||
                        (item[i] == '.' && item[i-1] == '.') ||
                        (item[i] == ',' && item[i-1] == ',') ||
                        (item[i] == '.' && item[i-1] == ',') ||
                        (item[i] == ',' && item[i-1] == '.') ||
                        (item[i] == ' ' && item[i-1] == '.') ||
                        (item[i] == ' ' && item[i-1] == ',') )
                    {
                        item = item.Remove(i, 1);
                        i--;
                        position--;
                    }
                }
                else if ((item[i] == ' ' && item[i-1] == ' ') ||
                    (item[i] == ' ' && item[i+1] == ' ') ||
                    (item[i] == '.' && item[i-1] == '.') ||
                    (item[i] == '.' && item[i+1] == '.') ||
                    (item[i] == ',' && item[i-1] == ',') ||
                    (item[i] == ',' && item[i+1] == ',') ||
                    (item[i] == '.' && item[i-1] == ',') ||
                    (item[i] == '.' && item[i+1] == ',') ||
                    (item[i] == ',' && item[i-1] == '.') ||
                    (item[i] == ',' && item[i+1] == '.') )
                {
                    item = item.Remove(i, 1);
                    i--;
                    position--;
                }

                // here counts how many decimal separators inputs
                if (i <= item.Length)
                {
                    if (item[i] == ',' || item[i] == '.')
                    {
                        commaIsHere[i] = true;
                        commaCounter++;
                    }
                    else
                        commaIsHere[i] = false;
                }
            }

            if (commaCounter == 2)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    // if cursor position refer next decimal separator, delete it
                    if (i == position-1 && commaIsHere[i] == true)
                    {
                        item = item.Remove(i, 1);
                        commaCounter--;
                        i--;
                        position--;
                    }
                }
            }
            if (commaCounter > 2)
            {
                for (int i = item.Length - 1; i >= 0; i--)
                {
                    // if cursor position refer next decimal separator, delete it
                    if (commaIsHere[i] == true)
                    {
                        item = item.Remove(i, 1);
                        for (int x = i; x < item.Length; x++) {
                            commaIsHere[x] = commaIsHere[x + 1];
                        }
                        commaCounter--;
                        i--;
                        position--;
                    }
                    if (commaCounter == 1)
                        i = 0;
                }
            }
            
            item = item.Replace(',', '.');
            int comma_position = item.IndexOf(".");
            if (position == comma_position + 4  && comma_position != -1)
            {
               item = item.Insert(comma_position + 4, " ");
               position++;
            }
            if (position == comma_position + 9 && comma_position != -1)
            {
               item = item.Remove(comma_position + 8, 1);
               position--;
            }
            sender.Text = item;
            sender.SelectionStart = position;/*
            item = item.Replace(" ", string.Empty);
            item = item.Replace(".", ",");
            item = item.Replace(",,", ",");
            item = item.Replace("..", ",");
            item = item.Replace(",.", ",");
            item = item.Replace(".,", ",");
            int comma_position = item.IndexOf(",");
            if (comma_position != position && comma_position != -1)
                item = item.Remove(position, 1);
            decimal itemDecimal = Convert.ToDecimal(item);
            sender.Text =  itemDecimal.ToString("0.0## ###");
            if (!(position == comma_position + 1) && position == comma_position + 4)
                position++;*/
        }

        public static void CheckIfHasIntegerInput(TextBox sender)
        {
            string item = sender.Text;
            int n = 0;
            if (!int.TryParse(item, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
                item != String.Empty)
            {
                int position = sender.SelectionStart-1;
                item = item.Remove(position, 1);
                sender.Text = item;
                sender.SelectionStart = position;
            }
        }

        public static void ScrollHandlerFunction(NumericUpDown sender, MouseEventArgs e)
        {
            HandledMouseEventArgs handledArgs = e as HandledMouseEventArgs;
            handledArgs.Handled = true;
            try{
                sender.Value += (handledArgs.Delta > 0) ? 1 : -1;
            }
            catch{
                if (sender.Value < sender.Minimum)
                    sender.Value = sender.Minimum;
                else if (sender.Value > sender.Maximum)
                    sender.Value = sender.Maximum;
            }
        }

        public static int ScrollByPositionOfCursor(TextBox sender, MouseEventArgs e)
        {
            string f_input_string = sender.Text;
            f_input_string = f_input_string.Replace(" ", string.Empty);
            f_input_string = f_input_string.Replace(".", ",");

            double f_input = double.Parse(f_input_string);

            HandledMouseEventArgs handledArgs = e as HandledMouseEventArgs;
            handledArgs.Handled = true;
            try{
                int comma_position = f_input_string.IndexOf(",");
                int position = sender.SelectionStart-1;
                double delenec;
                if ((position-comma_position) < 0)
                    delenec = Math.Pow(10, position + 1 - comma_position);
                else
                    delenec = Math.Pow(10, position - comma_position);
                double increment = 1/(delenec);
                f_input = (handledArgs.Delta > 0) ? f_input += increment : f_input -= increment;
                f_input_string = string.Format("{0:f8}", f_input);
                sender.Text = f_input_string;
                return position + 1;
            }
            catch{
                return 0;
            }
            
        }

        /*
        public static string ParseFrequencyDecimalValue(decimal freq)
        {
            UInt16 f_MHz = (UInt16)(freq);
            UInt32 f_kHz = (UInt32)(freq*1000);
            UInt64 f_Hz = (UInt64)(freq*1000000);
            UInt64 f_mHz = (UInt64)(freq*1000000000);
            UInt16 thousandths = (UInt16)(f_kHz - f_MHz*1000);
            UInt16 millionths = (UInt16)(f_Hz - (UInt64)(f_MHz)*1000000-(UInt64)(thousandths)*1000);
            UInt16 billionths = (UInt16)(f_mHz - (UInt64)(f_Hz)*1000);
            float bill_f = (float)((billionths)/100.0);
            double roundedBillionths  = Math.Round((float)(billionths)/100.0, MidpointRounding.AwayFromZero);

            return string.Format("{0},{1:000} {2:000} {3:0}", f_MHz, thousandths, millionths, roundedBillionths);
        }*/
    }
}
