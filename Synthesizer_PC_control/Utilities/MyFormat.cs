using System;
using System.Windows.Forms;

namespace Synthesizer_PC_control
{
    /// <summary>
    /// My formating utilities. 
    /// 
    /// It contains functions for checking hexadecimal 
    /// or integer characters from keyboard input. Another function is checking
    /// and formatted print in the following format '12345.125 214'. 
    /// 
    /// Functions that add or subtract one by the direction of the mouse wheel or 
    /// the up / down arrow. Other functions add / subtract one by the cursor 
    /// position in a number that is in the format '12345.125 214'.
    /// </summary>
    static class MyFormat
    {
        /// <summary>
        /// This function is for checking hexadecimal characters from keyboard input
        /// </summary>
        /// <param name="sender"> 
        /// TextBox-type graphic element, where you need to check the input format
        /// </param>
        public static void CheckIfHasHexInput(TextBox sender)
        {
            string item = sender.Text;  // get text string from UI element

            int position;
            position = sender.SelectionStart;

            for (UInt16 i = 0; i < item.Length; i++)
            {
                // check if number has hexadecimal characters
                if (!( (item[i] >= '0' && item[i] <= '9') || 
                      (item[i] >= 'A' && item[i] <= 'F') || 
                      (item[i] >= 'a' && item[i] <= 'f')) )
                {
                    item = item.Remove(i, 1);
                    i--;
                    position--;
                }
            }

            sender.Text = item;
            sender.SelectionStart = position;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
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
                        (item[i] == '.') ||
                        (item[i] == ',') ||
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
            if (item.IndexOf(" ") != comma_position + 4)
            {
                item = item.Replace(" ", string.Empty);
            }
            if (position == comma_position + 9 && comma_position != -1)
            {
               item = item.Remove(comma_position + 8, 1);
               position--;
            }
            sender.Text = item;
            if (position < 0)
                position = 0;
            sender.SelectionStart = position;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        public static void CheckIfHasIntegerInput(TextBox sender)
        {
            string item = sender.Text;  // get text string from UI element

            int position;
            position = sender.SelectionStart;

            for (UInt16 i = 0; i < item.Length; i++)
            {
                // check if number has integer characters
                if ( !(item[i] >= '0' && item[i] <= '9'))
                {
                    item = item.Remove(i, 1);
                    i--;
                    position--;
                }
            }

            sender.Text = item;
            sender.SelectionStart = position;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
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
                if (position >= 0)
                {
                    if ((position-comma_position) <= 0)
                    {
                        if ((position-comma_position) < 0)
                            delenec = Math.Pow(10, position + 1 - comma_position);
                        else
                            delenec = Math.Pow(10, position - comma_position);
                    }
                    else
                    {
                        if ((position-comma_position) <= 3)
                            delenec = Math.Pow(10, position - comma_position);
                        else
                            delenec = Math.Pow(10, position - 1 - comma_position);
                    }
                    double increment = 1/(delenec);
                    f_input = (handledArgs.Delta > 0) ? f_input += increment : f_input -= increment;
                    f_input_string = string.Format("{0:f8}", f_input);
                    sender.Text = f_input_string;
                    if (comma_position == f_input_string.IndexOf(",") || comma_position == -1)
                        return position + 1;
                    else if ((comma_position == (f_input_string.IndexOf(",")) - 1))
                        return position + 2;
                    else
                        return position;
                }
                else
                {
                    return position + 1;
                }
            }
            catch{
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int UpDownKeyIncDecFunc(TextBox sender, Keys key)
        {
            string f_input_string = sender.Text;
            f_input_string = f_input_string.Replace(" ", string.Empty);
            f_input_string = f_input_string.Replace(".", ",");

            double f_input = double.Parse(f_input_string);

            try{
                int comma_position = f_input_string.IndexOf(",");
                int position = sender.SelectionStart-1;
                double delenec;
                if (position >= 0)
                {
                    if ((position-comma_position) <= 0)
                    {
                        if ((position-comma_position) < 0)
                            delenec = Math.Pow(10, position + 1 - comma_position);
                        else
                            delenec = Math.Pow(10, position - comma_position);
                    }
                    else
                    {
                        if ((position-comma_position) <= 3)
                            delenec = Math.Pow(10, position - comma_position);
                        else
                            delenec = Math.Pow(10, position - 1 - comma_position);
                    }
                    double increment = 1/(delenec);
                    f_input = (key == Keys.Up) ? f_input += increment : f_input -= increment;
                    f_input_string = string.Format("{0:f8}", f_input);
                    sender.Text = f_input_string;
                    if (comma_position == f_input_string.IndexOf(",") || comma_position == -1)
                        return position + 1;
                    else if ((comma_position == (f_input_string.IndexOf(",")) - 1))
                        return position + 2;
                    else
                        return position;
                }
                else
                {
                    return position + 1;
                }
            }
            catch{
                return 0;
            }
        }
    }
}
