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
        public static void CheckIfHasHexInput(KeyPressEventArgs e)
        {
            int n = 0;
            string item = Convert.ToString(e.KeyChar);
            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
                item != String.Empty && item != "\b")
            {
                e.Handled = true;
            }
        }

        public static void CheckIfHasDecimalInput(TextBox sender)
        {
            string item = sender.Text;
            decimal n = 0;
            if ((!decimal.TryParse(item, NumberStyles.AllowDecimalPoint, new NumberFormatInfo() {
                NumberDecimalSeparator = ".", NumberGroupSeparator = "" },  out n) &&
                !decimal.TryParse(item, NumberStyles.AllowDecimalPoint, new NumberFormatInfo() {
                NumberDecimalSeparator = ",", NumberGroupSeparator = "" }, out n)) &&
                item != String.Empty)
            {
                int position = sender.SelectionStart-1;
                item = item.Remove(position, 1);
                sender.Text = item;
                sender.SelectionStart = position;
            }
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

        public static void ScrollByPositionOfCursor(TextBox sender, MouseEventArgs e)
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
                sender.SelectionStart = position + 1;
            }
            catch{
                
            }
            
        }

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
        }
    }
}
