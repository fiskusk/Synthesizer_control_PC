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
    class MyFormat
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
                NumberDecimalSeparator = ".", NumberGroupSeparator = " " },  out n) &&
                !decimal.TryParse(item, NumberStyles.AllowDecimalPoint, new NumberFormatInfo() {
                NumberDecimalSeparator = ",", NumberGroupSeparator = " " }, out n)) &&
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
    }
}
