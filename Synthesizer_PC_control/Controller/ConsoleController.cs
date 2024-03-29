﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

using System.Windows.Forms;
using Synthesizer_PC_control.Model;

namespace Synthesizer_PC_control.Controllers
{
    /// <summary>
    /// Console object, holding a link to Ui. Uses Singleton pattern.
    /// </summary>
    class ConsoleController : I_UiLinked
    {
        /// <summary>
        /// Item that is logged.
        /// </summary>
        private class LogItem
        {
            public readonly DateTime logTime;   // Logged time.
            public readonly string logText;     // logged text.

            /// <summary>
            /// Constructor (default time is Time.Now)
            /// </summary>
            /// <param name="logText"> logged text </param>
            public LogItem(string logText)
            {
                this.logTime = DateTime.Now;
                this.logText = logText;
            }

            /// <summary>
            /// constructor with adjustable time
            /// </summary>
            /// <param name="logTime"> Logged time </param>
            /// <param name="logText"> logged text </param>
            public LogItem(DateTime logTime, string logText)
            {
                this.logTime = logTime;
                this.logText = logText;
            }

            /// <summary>
            /// To String override.
            /// </summary>
            /// <returns> Formatted logged time and text. </returns>
            public override string ToString()
            {
                string formatted = logTime.ToString("HH:mm:ss: ") + logText;
                return formatted;
            }
        }



        private static ConsoleController singleton = null;  // singleton holder

        private RichTextBox uiElement;  // ui element to update
        private List<LogItem> log;
        private const int initialLogCapacity = 32;
        private readonly bool updateUI; // is there ui element to update

        // Private constructors
        private ConsoleController()
        {
            log = new List<LogItem>(initialLogCapacity);
            updateUI = false;
        }
        private ConsoleController(RichTextBox uiElement)
        {
            log = new List<LogItem>(initialLogCapacity);
            this.uiElement = uiElement;
            updateUI = true;

            UpdateUiElements();
        }

        /// <summary>
        /// Create console singleton without ui.
        /// </summary>
        public static void InitConsole()
        {
            if (singleton == null)
            {
                singleton = new ConsoleController();
            }
        }
        /// <summary>
        /// Create console singleton with ui.
        /// </summary>
        /// <param name="uiElement"> Ui element which prints text sent to console.</param>
        public static void InitConsole(RichTextBox uiElement)
        {
            if(singleton == null)
            {
                singleton = new ConsoleController(uiElement);
            }
        }

        /// <summary>
        /// Public singleton getter.
        /// </summary>
        /// <returns>Console object.</returns>
        public static ConsoleController Console()
        {
            if(singleton != null)
            {
                return singleton;
            }
            else
            {
                singleton = new ConsoleController();
                return singleton;
            }
        }

        /// <summary>
        /// Stores text and writes it to ui.
        /// Usage: ConsoleController.Console().Write("text");
        /// If the text starts with "Warning:", this beginning will be highlighted 
        /// by red bold text in the console. Other texts will be printed 
        /// as normal text (black regular text).
        /// </summary>
        /// <param name="message"> Text to write. </param>
        public void Write(string message)
        {
            var item = new LogItem(message);
            log.Add(item);

            if (!updateUI)
                return;

            //uiElement.AppendText(Environment.NewLine + item.ToString());

            if(item.logText.Contains("Warning:")) 
            {                
                // this print red highlighted time: Warning: and residue normal black
                AppendFormattedText(uiElement, item.logTime.ToString("HH:mm:ss: ") , Color.Red, true, HorizontalAlignment.Left);
                AppendFormattedText(uiElement, "Warning: ", Color.Red, true, HorizontalAlignment.Left);
                string text = item.logText.Replace("Warning: ", string.Empty);
                AppendFormattedText(uiElement, text, Color.Black, false, HorizontalAlignment.Left);
            }
            else
            {
                // normal format print
                AppendFormattedText(uiElement, item.logTime.ToString("HH:mm:ss: ") , Color.Black, true, HorizontalAlignment.Left);
                AppendFormattedText(uiElement, item.logText , Color.Black, false, HorizontalAlignment.Left);
            }

            uiElement.AppendText("\r\n"); // terminate by CR+LF 

        }

        /// <summary>
        /// This code is inspirated here:<br/>
        /// https://stackoverflow.com/questions/22321456/how-to-append-rtf-text-in-richtextbox-win-c-sharp/25694247#25694247
        /// Append formatted text to a Rich Text Box control
        /// </summary>
        /// <param name="rtb"> Rich Text Box to which horizontal bar is to be added </param>
        /// <param name="text"> Text to be appended to Rich Text Box </param>
        /// <param name="textColour"> Colour of text to be appended </param>
        /// <param name="isBold"> Flag indicating whether appended text is bold </param>
        /// <param name="alignment"> Horizontal alignment of appended text </param>
        private void AppendFormattedText(RichTextBox rtb, string text, Color textColour, Boolean isBold, HorizontalAlignment alignment)
        {
            int start = rtb.TextLength;
            rtb.AppendText(text);
            int end = rtb.TextLength; // now longer by length of appended text

            // Select text that was appended
            rtb.Select(start, end - start);

            #region Apply Formatting
            rtb.SelectionColor = textColour;
            rtb.SelectionAlignment = alignment;
            rtb.SelectionFont = new Font(
                rtb.SelectionFont.FontFamily,
                rtb.SelectionFont.Size,
                (isBold ? FontStyle.Bold : FontStyle.Regular));
            #endregion

            // Unselect text
            rtb.SelectionLength = 0;
        }

        /// <summary>
        /// Clears and writes ui element.
        /// </summary>
        public void UpdateUiElements()
        {
            if (!updateUI)
                return;

            uiElement.Clear();

            foreach (var item in log)
            {
                uiElement.AppendText(Environment.NewLine + item.ToString());
            }
        }
    }
}
