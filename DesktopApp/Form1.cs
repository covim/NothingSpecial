using System.ComponentModel;
using System.IO.Ports;
using TDC8000;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        TDC8000Parser tdc8000 = new TDC8000Parser();
        public Form1()
        {
            InitializeComponent();

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += ReadSerialPort;
            worker.ProgressChanged += UpdateUI;
            worker.RunWorkerAsync();
            
        }

        private static void ReadSerialPort(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            SerialPort port = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
            port.Open();
            while (true)
            {
                string data = port.ReadTo("\r");
                // Report progress to the UI
                worker.ReportProgress(0, data);
            }
            port.Close();
        }

        private void UpdateUI(object sender, ProgressChangedEventArgs e)
        {
            // Update the UI with the data from the serial port
            string data = e.UserState as string;
            textBox1.Text = data;  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tdc8000.TDC8000ParseManager(textBox1.Text);
            textBox2.Text = tdc8000.NextRacerToFinish.ToString();
            textBox3.Text = tdc8000.AktuelleTriggerZeit.TriggerTime.ToString();
        }
    }
}