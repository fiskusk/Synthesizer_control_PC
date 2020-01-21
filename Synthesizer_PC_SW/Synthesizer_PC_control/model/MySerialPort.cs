using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace Synthesizer_PC_control
{
    class  MySerialPort
    {
        private SerialPort _serialPort;

        private Button ui_openClosed;
        private ComboBox ui_avaliablePorts;
        private string[] avaliablePorts;

        // TODO
        // Kontruktor zavolá GetAvaliablePorts()
        public MySerialPort(Button ui_openClosed, ComboBox ui_avaliablePorts)
        {
            this.ui_openClosed = ui_openClosed;
            this.ui_avaliablePorts = ui_avaliablePorts;

            GetAvaliablePorts();
        }

        public bool OpenPort()
        {
            try
            {
                _serialPort = new SerialPort(ui_avaliablePorts.Text, 115200);
                _serialPort.DtrEnable = true;
                _serialPort.ReadTimeout = 500;
                _serialPort.Open();                             // TODO po otevreni portu zjistit, jestli byl synt. programovan, a jestli ano, nacist data
                _serialPort.NewLine = "\r";
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(MyDataReceivedHandler);

                return true;
            }
            catch
            {
                // TODO Oznamit uzivateli chybu

                //MessageBox.Show("Cannot open COM port. Please select valid Synthesizer COM port or check connection.", "Invalid COM port", 
                //MessageBoxButtons.OK, MessageBoxIcon.Error);
                //PortButton_Click(this, new EventArgs());    // TODO dodelat overeni, jestli se jedna o syntezator. Odesilat z modulu nejaky string ID treba MAX2871byFKU. Kdyz takovy tvar neprijde, napsat, ze takove zarizeni nelze pouzit.
                _serialPort = null;
                return false;
            }
        }

        public void ClosePort()
        {
            if(_serialPort == null)
                return;

            _serialPort.Close();
            _serialPort.Dispose();
            _serialPort = null;
        }

        public bool IsPortOpen()
        {
            if(_serialPort != null)
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
        }

        private void UpdateUiElements()
        {
            ui_avaliablePorts.DataSource = avaliablePorts;
        }
    }
}
