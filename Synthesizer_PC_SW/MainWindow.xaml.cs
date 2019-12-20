using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Synthesizer_PC_SW
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static SerialPort _serialPort;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            _serialPort = new SerialPort("COM3", 115200);
            _serialPort.Open();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _serialPort.WriteLine("out 1 on");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _serialPort.WriteLine("out 1 off");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _serialPort.Close();
        }
    }
}
