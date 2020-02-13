using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
using System.IO; 
using System.IO.Ports; 
using System.Windows.Forms; 
using Synthesizer_PC_control.Utilities;
using Synthesizer_PC_control.Controllers;
 
namespace Synthesizer_PC_control.Model 
{ 
    class MySerialPort : I_UiLinked 
    { 
        private SerialPort port; 
        private string[] avaliablePorts; 
        private string selectedPort;
 
        //private readonly Control delegateHandle; 
        private readonly Form1 viewHandle; 
        delegate void MyDelegate(object MyObject); 
 
        private Button ui_openClosed; 
        private ComboBox ui_avaliablePorts; 
 
        private bool dontRunHandler; 
 
        public MySerialPort(Form1 viewHandle, Button ui_openClosed, ComboBox ui_avaliablePorts) 
        { 
 
            this.viewHandle = viewHandle; 
 
            this.ui_openClosed = ui_openClosed; 
            this.ui_avaliablePorts = ui_avaliablePorts; 
 
            dontRunHandler = false; 
 
            UpdateUiElements(); 
        }

        public void SetSelectedPort(string value)
        {
            this.selectedPort = value;

            UpdateUiElements();
        }

        public string GetSelectedPort()
        {
            return selectedPort;
        }
 
        public bool OpenPort() 
        { 
            try 
            { 
                //port = new SerialPort(AvaibleCOMsComBox.Text, 115200);
                port = new SerialPort(selectedPort, 115200); 
                port.DtrEnable = true; 
                port.ReadTimeout = 500; 
                port.WriteTimeout = 500; 
                port.Open();
                port.NewLine = "\r"; 
                port.DataReceived += new SerialDataReceivedEventHandler(MyDataReceivedHandler); 
 
                UpdateUiElements(); 
                return true; 
            } 
            catch 
            { 
                MessageBox.Show("Cannot open COM port. Please select valid Synthesizer COM port or check connection.", "Invalid COM port", 
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                // TODO dodelat overeni, jestli se jedna o syntezator. Odesilat z modulu nejaky string ID treba MAX2871byFKU. Kdyz takovy tvar neprijde, napsat, ze takove zarizeni nelze pouzit. 
 
                ClosePort(); 
 
                UpdateUiElements();
                return false; 
            } 
        } 
 
        public void ClosePort() 
        { 
            if (port == null) 
                return; 
 
            port.Close(); 
            port.Dispose(); 
            port = null; 
 
            UpdateUiElements(); 
        } 
 
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
 
        public void GetAvaliablePorts() 
        { 
            avaliablePorts = SerialPort.GetPortNames(); 
            UpdateUiElements(); 
        } 
 
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
 
        public void SendStringSerialPort(string text) 
        {
            try 
            { 
                dontRunHandler = true; 
                { 
                    port.WriteLine(text); 
                    while (port.ReadLine() != "OK") { } // FIXME: Is there not a better way than freezing whole programm? 
                    // TODO FILIP_NOW podbarvit při potvrzeném zápisu textbox
                } 
                dontRunHandler = false; 

                ConsoleController.Console().Write("command: '" + text + "' sended");
            } 
            catch 
            { 
                MessageBox.Show("Device doesn't work", "COM Port Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk); 
                ClosePort(); 
                viewHandle.EnableControls(false);
            } 
        }
 
        private void MyDataReceivedHandler(object sender, SerialDataReceivedEventArgs e) 
        { 
            if (dontRunHandler) return; 
            viewHandle.Invoke(new MyDelegate(viewHandle.ProccesReceivedData), e); 
        } 
 
        public void UpdateUiElements() 
        { 
            if(IsPortOpen())    // Port je otevreny 
            { 
                ui_openClosed.Text = "Close Port"; 
            } 
            else 
            { 
                ui_openClosed.Text = "Open Port"; 
            } 
            
            if (!GeneralUtilities.CompareStringArrays((string[])ui_avaliablePorts.DataSource, avaliablePorts))
                ui_avaliablePorts.DataSource = avaliablePorts;

            ui_avaliablePorts.Text = selectedPort;
        } 
    } 
} 
