using System;
using System.Windows.Forms;

namespace Synthesizer_PC_control
{
    /// <summary>
    /// My formating utilities. 
    /// 
    /// It contains functions for checking if text input has hexadecimal 
    /// or integer format. Another function is checking
    /// and formatted print in the following format '12345.125 214'. 
    /// 
    /// Functions that add or subtract one by the direction of the mouse wheel or 
    /// the up / down arrow. Other functions add / subtract one by the cursor 
    /// position in a number that is in the format '12345.125 214'.
    /// </summary>
    static class MyFormat
    {
        /// <summary>
        /// This function is for checking if text has hexadecimal format
        /// </summary>
        /// <param name="sender"> 
        /// TextBox-type graphic element, where you need to check the input format
        /// </param>
        public static void CheckIfHasHexInput(TextBox sender)
        {
            string item = sender.Text;  // get text string from UI element

            int position;
            position = sender.SelectionStart; // get cursor position

            // goes through the entire text character by character
            for (UInt16 i = 0; i < item.Length; i++)
            {
                // check if text has hexadecimal characters
                if (!( (item[i] >= '0' && item[i] <= '9') || 
                      (item[i] >= 'A' && item[i] <= 'F') || 
                      (item[i] >= 'a' && item[i] <= 'f')) )
                {
                    item = item.Remove(i, 1);
                    i--;
                    position--;
                }
            }

            sender.Text = item;     // restores the edited text to the sender
            sender.SelectionStart = position;   // restores correct cursor position
        }

        /// <summary>
        /// This function is for checking decimal characters from keyboard input
        /// </summary>
        /// <param name="sender">
        /// TextBox-type graphic element, where you need to check the input format
        /// </param>
        public static void CheckIfHasDecimalInput(TextBox sender)
        {
            string item = sender.Text;  // get text string from UI element
            int position;
            position = sender.SelectionStart;   // get cursor position
            bool[] commaIsHere = new bool[item.Length]; // here will be flag for comma presence
            UInt16 commaCounter = 0;

            // goes through the entire text character by character
            for (UInt16 i = 0; i < item.Length; i++)
            {
                // make sure it's a decimal number ('.' and ',' separators allowed)
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
                    // first character cannot be space, comma separator
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
                    // last character cannot be space, comma separator
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
                // two consecutive characters cannot be 'space' and 'space', 
                // all combinations of comma separators (...,,. ,,)
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

                // now the number of commas in the text is calculated
                // it also saves the comma position
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

            // if the number of commas in the text is exactly two
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

            // if the number of commas in the text is greater than two
            if (commaCounter > 2)
            {
                for (int i = item.Length - 1; i >= 0; i--)
                {
                    // if cursor position refer next decimal separator, delete it
                    if (commaIsHere[i] == true)
                    {
                        item = item.Remove(i, 1);

                        // remove a comma flag by removing it from the field
                        for (int x = i; x < item.Length; x++) {
                            commaIsHere[x] = commaIsHere[x + 1];
                        }
                        commaCounter--;
                        i--;
                        position--;
                    }
                    // forces the loop to end
                    if (commaCounter == 1)
                        i = 0;
                }
            }
            
            // replace the decimal point with a dot
            item = item.Replace(',', '.');
            int comma_position = item.IndexOf("."); // get comma position

            // here the corresponding format of the separation of thousandths is created
            if (position == comma_position + 4  && comma_position != -1)
            {
               item = item.Insert(comma_position + 4, " ");
               position++;
            }
            if (item.IndexOf(" ") != comma_position + 4)
            {
                // removes a space that is in an inappropriate place
                item = item.Replace(" ", string.Empty);
            }
            if (position == comma_position + 9 && comma_position != -1)
            {
                // if the last or first character is a comma, it deletes it
                item = item.Remove(comma_position + 8, 1);
                position--;
            }
            sender.Text = item;     // restores the edited text to the sender
            if (position < 0)       // cursor position cannot less than zero
                position = 0;
            sender.SelectionStart = position;   // restores correct cursor position
        }

        /// <summary>
        /// This function is for checking integer characters from keyboard input
        /// </summary>
        /// <param name="sender">
        /// TextBox-type graphic element, where you need to check the input format
        /// </param>
        public static void CheckIfHasIntegerInput(TextBox sender)
        {
            string item = sender.Text;  // get text string from UI element

            int position;
            position = sender.SelectionStart;   // get cursor position

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

            sender.Text = item;     // restores the edited text to the sender
            sender.SelectionStart = position;   // restores correct cursor position
        }   

        /// <summary>
        /// Function that add or subtract one by the direction of the mouse wheel
        /// </summary>
        /// <param name="sender"> sender of NumericUpDown type </param>
        /// <param name="e"> mouse event argument </param>
        public static void ScrollHandlerFunction(NumericUpDown sender, MouseEventArgs e)
        {
            HandledMouseEventArgs handledArgs = e as HandledMouseEventArgs;
            handledArgs.Handled = true; // event processed 
            try{
                sender.Value += (handledArgs.Delta > 0) ? 1 : -1;   // try to increment/decrement
            }
            catch{
                // An event was detected when the number was out of range. 
                // Sets the minimum or maximum value.
                if (sender.Value < sender.Minimum)
                    sender.Value = sender.Minimum;
                else if (sender.Value > sender.Maximum)
                    sender.Value = sender.Maximum;
            }
        }

        /// <summary>
        /// Function that add or subtract one by the direction of the mouse 
        /// wheel at appropriate cursor position
        /// </summary>
        /// <param name="sender"> sender of TextBox type </param>
        /// <param name="e"> mouse event argument </param>
        /// <returns>
        /// position of cursor in the text
        /// </returns>
        public static int ScrollByPositionOfCursor(TextBox sender, MouseEventArgs e)
        {
            HandledMouseEventArgs handledArgs = e as HandledMouseEventArgs;
            handledArgs.Handled = true;     // event processed 

            return UpDownByPosition(sender, handledArgs.Delta > 0);
        }

        /// <summary>
        /// Function that add or subtract one by the up/down arrow keys 
        /// at appropriate cursor position
        /// </summary>
        /// <param name="sender"> sender of TextBox type </param>
        /// <param name="key"> mouse event argument </param>
        /// <returns>
        /// position of cursor in the text
        /// </returns>
        public static int UpDownKeyIncDecFunc(TextBox sender, Keys key)
        {
            return UpDownByPosition(sender, key == Keys.Up);
        }

        /// <summary>
        /// Function that add or subtract one
        /// </summary>
        /// <param name="sender"> sender of TextBox type </param>
        /// <param name="up"> flag whether to add or subtract </param>
        /// <returns>
        /// position of cursor in the text
        /// </returns>
        private static int UpDownByPosition(TextBox sender, bool up)
        {
            string f_input_string = sender.Text;    // get text string from UI element
            f_input_string = f_input_string.Replace(" ", string.Empty);     // remove spaces
            f_input_string = f_input_string.Replace(".", ",");  // , replace by .

            double f_input = double.Parse(f_input_string);      // string -> number
            int position = sender.SelectionStart;               // here get cursor position
            int comma_position = f_input_string.IndexOf(",");   // get position of comma

            try{
                double factor;

                if (position >= 1)
                {
                    if ((position - comma_position) <= 1)
                    {
                        // the cursor position is before or just after the decimal point
                        // for example:     12|34,254 125 or
                        //                  1234|,254 125 or
                        //                  1234,|254 125
                        if (position == 1 && f_input_string[0] == '1' && up == false && 
                            decimal.Parse(f_input_string.Remove(0,1)) < 23.4375M)
                        {
                            // 1|025.2056 down -> 9|25.2056
                            factor = Math.Pow(10, position + 1 - comma_position);
                        }
                        else if ((position - comma_position) < 1)
                        {
                            // the cursor is before comma 12|34,254 125 or 1234|,254 125
                            factor = Math.Pow(10, position - comma_position);
                            // fix cursor position
                            if (f_input_string[position - 1] == '9' && up == true)
                            {
                                // increment number is 9
                                if (position == 1)
                                    // position is at first number (ie. 9|25.25)
                                    position++;
                                else
                                {
                                    // position is somewhere here (ie. 99|95.236 or 999|5.)
                                    // get remaining string (99 or 999)
                                    string remainingString = f_input_string.Remove(position, f_input_string.Length - position);
                                    bool success =  true;
                                    
                                    // check if remaining string has all characters '9'
                                    for (UInt16 i = 0; i < remainingString.Length; i++)
                                    {
                                        // check if number has integer characters
                                        if ( remainingString[i] != '9')
                                        {
                                            success = false;
                                        }
                                    }
                                    // if all numbers are 9, next number will be 10095.236 or 10005.0
                                    if (success)
                                        position++;
                                }
                            }
                            else if (f_input_string[position - 1] == '0' && up == false)
                            {
                                // decrement number is 10
                                if (position == 2 && decimal.Parse(f_input_string.Remove(2, f_input_string.Length - 2)) == 10M)
                                    // position is at second number (ie. 10|25.25)
                                    position--;
                                else
                                {
                                    // position is somewhere here (ie. 100|5.236 or 1000|.236)
                                    // get remaining string (100 or 1000)
                                    string remainingString = f_input_string.Remove(position - 1, f_input_string.Length - position - 1);
                                    bool success =  true;
                                    
                                    // check if remaining string has all characters 100 or 1000
                                    for (UInt16 i = 1; i < remainingString.Length; i++)
                                    {
                                        // check if number has integer characters
                                        if ( remainingString[i] != '0')
                                        {
                                            success = false;
                                        }
                                    }
                                    // if all numbers are 000, next number will be 995.236 or 999.236
                                    if (success)
                                        position--;
                                }
                            }
                        }
                        else
                            // the cursor is just after the decimal point
                            factor = Math.Pow(10, position - 1 - comma_position);
                    }
                    else
                    {
                        // the cursor position is after the decimal point
                        // for example:     1234,2|54 125 or
                        //                  1234,254| 125 or
                        //                  1234,254 1|25
                        if ((position - comma_position) <= 4)
                            // the cursor position is somewhere in the range of thousands
                            // for example #,1|23 456 or #,12|3 456 or #,123| 456
                            factor = Math.Pow(10, position - 1 - comma_position);
                        else
                            // compensation of the space between thousandths and tens of thousands
                            factor = Math.Pow(10, position - 2 - comma_position);
                    }

                    // get increment
                    double increment = 1 / factor;
                    // increment or decrement input value
                    f_input = (up) ? f_input += increment : f_input -= increment;
                    // convert back into string
                    f_input_string = string.Format("{0:f8}", f_input);
                    // restores the edited text to the sender
                    sender.Text = f_input_string;

                    return position;
                }
                else
                {
                    // If the cursor position is at the beginning of the text, 
                    // no further action is taken and the function returns 
                    // the position increased by one
                    return position;
                }
            }
            catch{
                return 0;   // position must be greather or equal than zero
            }
        }
    }
}
