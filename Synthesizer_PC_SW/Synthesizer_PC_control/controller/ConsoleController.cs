using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using Synthesizer_PC_control.Model;

namespace Synthesizer_PC_control.Controllers
{
    /// <summary>
    /// Console object, holding a lick to Ui. Uses Singleton pattern.
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

            ///Constructors (default time is Time.Now)
            public LogItem(string logText)
            {
                this.logTime = DateTime.Now;
                this.logText = logText;
            }
            public LogItem(DateTime logTime, string logText)
            {
                this.logTime = logTime;
                this.logText = logText;
            }

            /// <summary>
            /// To String override.
            /// </summary>
            /// <returns>Formatted logged time and text.</returns>
            public override string ToString()
            {
                string formatted = logTime.ToString("HH:mm:ss: ") + logText;
                return formatted;
            }
        }



        private static ConsoleController singleton = null;  // singleton holder

        private TextBox uiElement;  // ui element to update
        private List<LogItem> log;
        private const int initialLogCapacity = 32;
        private readonly bool updateUI; // is there ui element to update

        // Private constructors
        private ConsoleController()
        {
            log = new List<LogItem>(initialLogCapacity);
            updateUI = false;
        }
        private ConsoleController(TextBox uiElement)
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
        public static void InitConsole(TextBox uiElement)
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
        /// </summary>
        /// <param name="message">Text to write.</param>
        public void Write(string message)
        {
            var item = new LogItem(message);
            log.Add(item);

            if (!updateUI)
                return;

            uiElement.AppendText(Environment.NewLine + item.ToString());
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
