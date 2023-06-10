using System.IO.Ports; 
using System.Windows.Forms; 
using Synthesizer_PC_control.Utilities;
using Synthesizer_PC_control.Controllers;
 
namespace Synthesizer_PC_control.Model 
{
    /// <summary>
    /// This class is used to work with the serial port.
    /// </summary>
    class MySerialPort : I_UiLinked 
    {
        // error messages
        private string[] noneSelectedPortMsg = {"No valid serial port name is selected. Please select it from the menu and then try to connect again.", "No serial port is selected."};
        private string[] cannotOpenPortMsg = {"Cannot open COM port. Please select valid Synthesizer COM port or check connection.", "Invalid COM port"};
        private string[] devDoesNotWork = {"Device doesn't work", "COM Port Error"};

        /// <summary>
        /// It holds SerialPort component
        /// </summary>
        private SerialPort port; 

        /// <summary>
        /// Array of all avaliable ports in computer
        /// </summary>
        private string[] avaliablePorts; 

        /// <summary>
        /// Store selected port
        /// </summary>
        private string selectedPort;

        /// <summary>
        /// This handle, if sending into serial port is disabled or not
        /// </summary>
        private bool disableSending;

        /// <summary>
        /// This holds the identifier who caused the disable sending to the serial interface.
        /// </summary>
        private int disableID;
 
        //private readonly Control delegateHandle; 
        private readonly Form1 viewHandle; 
        delegate void MyDelegate(object MyObject); 

        // hold UI elements
        private Button ui_openClosed; 
        private ComboBox ui_avaliablePorts; 
        
        /// <summary>
        /// Handle if routine can run or not
        /// </summary>
        private bool dontRunHandler; 

        /// <summary>
        /// Constructor for work with the serial port.
        /// </summary>
        /// <param name="viewHandle"> view handle for the whole Form1 </param>
        /// <param name="ui_openClosed"> UI button for open/closed port </param>
        /// <param name="ui_avaliablePorts">UI combobox for avaliable serial ports</param>
        public MySerialPort(Form1 viewHandle, Button ui_openClosed, ComboBox ui_avaliablePorts) 
        { 
            this.viewHandle = viewHandle; 
 
            this.ui_openClosed = ui_openClosed; 
            this.ui_avaliablePorts = ui_avaliablePorts; 
 
            dontRunHandler = false; 

            UpdateUiElements(); 
        }

        /// <summary>
        /// Updates all graphic user elements
        /// </summary>
        public void UpdateUiElements() 
        { 
            if(IsPortOpen())    // Port is open
            { 
                ui_openClosed.Text = "Close Port"; 
            } 
            else 
            { 
                ui_openClosed.Text = "Open Port"; 
            } 

            string selectedPortBackup = selectedPort;
            
            // check if avaliable ports changed
            //if (!GeneralUtilities.CompareStringArrays((string[])ui_avaliablePorts.DataSource, avaliablePorts))
            ui_avaliablePorts.DataSource = avaliablePorts;
            ui_avaliablePorts.Text = selectedPortBackup;

        }

        #region Setters

        /// <summary>
        /// Sets the currently selected port to the class.
        /// </summary>
        /// <param name="value"> name of actual selected port </param>
        public void SetSelectedPort(string value)
        {
            // check if new value is in the list of avaliable ports
            if (GeneralUtilities.IsStringLocatedInArray(value, avaliablePorts))
                this.selectedPort = value;
            else
                this.selectedPort = null;

            UpdateUiElements();
        }

        /// <summary>
        /// Allows you to disable / allow sending based on the entered ID. 
        /// 
        /// If sending is not disabled and the function is called with 
        /// a request to disable sending, then the request is executed 
        /// with the ID with which the function is called. 
        /// 
        /// After that if the same request is called elsewhere in the code, 
        /// nothing will be executed. 
        /// 
        /// If sending is currently disabled and the function is called 
        /// to request that the sending be re-enabled, the request is granted 
        /// only if the ID with which the function is calling matches 
        /// the one that was saved when the sending was disabled. 
        /// In this case, disableID is set to '0' and the request is granted.
        /// Otherwise, if the ID does not match, nothing is performed.
        /// </summary>
        /// <param name="value"> disable sending or not </param>
        /// <param name="ID"> unique identifier for set disable sending into serial port </param>
        public void SetDisableSending(bool value, int ID)
        {
            if (this.disableSending == false && value == true)
            {
                this.disableID = ID;
                this.disableSending = value;
            }
            else if (this.disableSending == true && value == false)
            {
                if (this.disableID == ID)
                {
                    this.disableID = 0;
                    this.disableSending = value;
                }
            }
        }

        #endregion

        #region Getters

        /// <summary>
        /// This feature gets the status of disabling sending to serial port
        /// </summary>
        /// <returns> sending into serial port disabled or not </returns>
        public bool GetDisableSending()
        {
            return this.disableSending;
        }

        /// <summary>
        /// This feature gets the selected serial port
        /// </summary>
        /// <returns> selected serial port </returns>
        public string GetSelectedPort()
        {
            return selectedPort;
        }

        /// <summary>
        /// Use this function to get available ports on your computer
        /// </summary>
        public void GetAvaliablePorts() 
        { 
            avaliablePorts = SerialPort.GetPortNames(); 
            UpdateUiElements(); 
        } 

        #endregion

        #region Other Serial Port Functions

        /// <summary>
        /// Open serial port. Fixed baud rate 115200, DTR enabled, 
        /// read and write timeout 500 ms, line separator is "\r" (CR-carriege return)
        /// </summary>
        /// <returns> success of operation </returns>
        public bool OpenPort() 
        {
            if (selectedPort == null)
            {
                MessageBox.Show(noneSelectedPortMsg[0], noneSelectedPortMsg[1], 
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                ConsoleController.Console().Write("Warning: " + noneSelectedPortMsg[0]);
                return false;
            }
            try 
            { 
                port = new SerialPort(selectedPort, 115200);  // baud rate = 115200
                port.DtrEnable = true;      // enable Data Terminal Ready
                port.ReadTimeout = 500;     // timeout for reading data (500 ms)
                port.WriteTimeout = 500;    // timeout for sending data (500 ms)
                port.Open();                // open serial port
                port.NewLine = "\r";        // identifier of new line is set to "\r" (carriege return CR)
                port.DataReceived += new SerialDataReceivedEventHandler(MyDataReceivedHandler); // sets new data recieved handler 
 
                UpdateUiElements();
                return true; 
            } 
            catch 
            { 
                ClosePort(); 
                MessageBox.Show(cannotOpenPortMsg[0], cannotOpenPortMsg[1], 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConsoleController.Console().Write("Warning: " + cannotOpenPortMsg[0]);
 
                UpdateUiElements();
                return false; 
            } 
        } 
        
        /// <summary>
        /// This feature close port, if is opened.
        /// </summary>
        public void ClosePort() 
        { 
            if (port == null) 
                return; 
            try {
                port.DtrEnable = false;
                port.RtsEnable = false;
                if (port.IsOpen) {
                    port.DiscardInBuffer();
                    port.DiscardOutBuffer();
                }
                port.Close(); 
                port.Dispose(); 
                port = null; 
            }
            catch
            {
                ConsoleController.Console().Write("Error when closing port!");
            }
 
            UpdateUiElements(); 
        } 

        /// <summary>
        /// This function gets if serial port is open or not.
        /// </summary>
        /// <returns> serial port is opened or not </returns>
        public bool IsPortOpen() 
        { 
            if (port != null) 
            { 
                return true; 
            } 
            else 
            { 
                return false; 
            } 
        }

        /// <summary>
        /// The function retrieves new data from the serial line 
        /// terminated with the line end flag (CR)
        /// </summary>
        /// <returns></returns>
        public string ReadLine() 
        { 
            if(IsPortOpen()) 
            { 
                return port.ReadLine(); 
            } 
            else 
            { 
                return ""; 
            } 
        } 

        public void SendStringSerialPortWOLogging(string text)
        {
            if (IsPortOpen())
            {
                try 
                { 
                    dontRunHandler = true; 
                    { 
                        port.WriteLine(text); 
                        while (port.ReadLine() != "OK") { } // wait for confirmation text from synthesizer module
                    } 
                    dontRunHandler = false; 

                    //ConsoleController.Console().Write("command: '" + text + "' sended");    // print current outgoing data into console
                } 
                catch 
                { 
                    ClosePort();    // if occur error, close port and show message and print into console
                    viewHandle.EnableControls(false);   // disable controls in UI
                    MessageBox.Show(devDoesNotWork[0], devDoesNotWork[1], 
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ConsoleController.Console().Write("Warning: " + devDoesNotWork[0]);
                }
            }
        }

        /// <summary>
        /// Use this function to send new data into serial port
        /// </summary>
        /// <param name="text"> outgoing data </param>
        public void SendStringSerialPort(string text) 
        {
            if (IsPortOpen())
            {
                try 
                { 
                    dontRunHandler = true; 
                    { 
                        port.WriteLine(text); 
                        while (port.ReadLine() != "OK") { } // wait for confirmation text from synthesizer module
                    } 
                    dontRunHandler = false; 

                    ConsoleController.Console().Write("command: '" + text + "' sended");    // print current outgoing data into console
                } 
                catch 
                { 
                    ClosePort();    // if occur error, close port and show message and print into console
                    viewHandle.EnableControls(false);   // disable controls in UI
                    MessageBox.Show(devDoesNotWork[0], devDoesNotWork[1], 
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ConsoleController.Console().Write("Warning: " + devDoesNotWork[0]);
                } 
            }
        }
    
        /// <summary>
        /// Serial port data received handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyDataReceivedHandler(object sender, SerialDataReceivedEventArgs e) 
        {
            if (dontRunHandler) return;    // if disabled return back
            viewHandle.Invoke(new MyDelegate(viewHandle.ProccesReceivedData), e); 
        }

        #endregion
    } 
} 
