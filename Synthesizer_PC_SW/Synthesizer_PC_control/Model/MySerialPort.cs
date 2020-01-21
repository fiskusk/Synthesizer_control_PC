using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace Synthesizer_PC_control.Model
{
    class MySerialPort : I_UiLinked
    {
        private SerialPort port;
        private string[] avaliablePorts;

        //private readonly Control delegateHandle;
        private readonly Form1 viewHandle;
        delegate void MyDelegate(object MyObject);

        private Button ui_openClosed;
        private ComboBox ui_avaliablePorts;
        private TextBox ui_NAME_ME_BETTER;

        private bool dontRunHandler;

        public MySerialPort(Form1 viewHandle, TextBox ui_NAME_ME_BETTER, Button ui_openClosed, ComboBox ui_avaliablePorts)
        {

            this.viewHandle = viewHandle;

            this.ui_openClosed = ui_openClosed;
            this.ui_avaliablePorts = ui_avaliablePorts;
            this.ui_NAME_ME_BETTER = ui_NAME_ME_BETTER;

            dontRunHandler = false;

            GetAvaliablePorts();
            UpdateUiElements();
        }

        public bool OpenPort(string portName)
        {
            try
            {
                //port = new SerialPort(AvaibleCOMsComBox.Text, 115200);
                port = new SerialPort(portName, 115200);
                port.DtrEnable = true;
                port.ReadTimeout = 500;
                port.Open();                             // TODO po otevreni portu zjistit, jestli byl synt. programovan, a jestli ano, nacist data
                port.NewLine = "\r";
                port.DataReceived += new SerialDataReceivedEventHandler(MyDataReceivedHandler);

                UpdateUiElements();
                return true;
            }
            catch
            {
                // TODO Does this work?
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
                }
                dontRunHandler = false;

                ui_NAME_ME_BETTER.AppendText(Environment.NewLine + DateTime.Now.ToString("HH:mm:ss: ") + "command: '" + text + "' sended");
                //_serialPort.ReadLine();
            }
            catch
            {
                MessageBox.Show("Device doesn't work", "COM Port Error",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //PortButton_Click(this, new EventArgs());
                ClosePort();
            }
        }

        private void MyDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (dontRunHandler) return;
            viewHandle.Invoke(new MyDelegate(viewHandle.Spracovanie), e);
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
            
            ui_avaliablePorts.DataSource = avaliablePorts;
        }
    }
}
