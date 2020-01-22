using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Synthesizer_PC_control.Model;

namespace Synthesizer_PC_control
{
    class Controller
    {
        private readonly Form1 view;

        public readonly MySerialPort serialPort;

        public Controller(Form1 view)
        {
            this.view = view;

            serialPort = new MySerialPort(view, view.textBox, view.PortButton, view.AvaibleCOMsComBox);
        }

        #region Serial port

        public void SwitchPort()
        {
            if(serialPort.IsPortOpen())
            {
                serialPort.ClosePort();
                view.EnableControls(false);
            }
            else
            {
                view.EnableControls( OpenPort() );
            }
        }

        private bool OpenPort()
        {
            // TODO Use AvaibleCOMsComBox.selectedIndex ?
            bool succes = serialPort.OpenPort(view.AvaibleCOMsComBox.Text);

            if (succes)
            {
                view.SaveWorkspaceData();   // FIXME Not OOD
                view.EnableControls(true);
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
