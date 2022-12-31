using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using LiteDB;
using LiteDB_Class;
using System.ComponentModel;
using System.IO.Ports;
using TDC8000;
using Types;


namespace WPF_DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        TDC8000Parser tdc8000 = new TDC8000Parser();
        BackgroundWorker worker = new BackgroundWorker();
        bool run = false;
        Veranstaltung veranstaltung1 = new Veranstaltung
        {
            Id = 1,
            VeranstaltungsName = "SuperVeranstaltung",
            TeilnehmerListe = new List<Teilnehmer>(),
            TriggerTimesListe = new List<TriggerTimes>()
        };
        LiteDatabase db;
        ILiteCollection<Veranstaltung> col;
        IEnumerable<TriggerTimes> triggerTimesList;
        bool eins = false;

        public MainWindow()
        {
            InitializeComponent();

            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            System.IO.File.Delete(@"C:\Temp\MyData1.db");
            System.IO.File.Delete(@"C:\Temp\MyData1-log.db");
            db = new LiteDatabase(@"C:\Temp\MyData1.db");
            col = db.GetCollection<Veranstaltung>("Veranstaltung");
            Database.SaveDataToDB(veranstaltung1, col);
            textBox1.IsEnabled = false;
        }

        private void ReadSerialPort(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker1 = sender as BackgroundWorker;
            SerialPort port = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
            port.Open();
            while (run)
            {
                string data = port.ReadTo("\r");
                // Report progress to the UI
                worker1.ReportProgress(0, data);
            }
            port.Close();
        }

        private void UpdateUI(object sender, ProgressChangedEventArgs e)
        {
            // Update the UI with the data from the serial port
            string data = e.UserState as string;
            textBox1.Text = data;

            if (tdc8000.TDC8000ParseManager(data))
            {
                veranstaltung1.TriggerTimesListe.Add(tdc8000.AktuelleTriggerZeit);
                col.Update(veranstaltung1);
                //triggerTimesList = col.Query().ToList()[0].TriggerTimesListe;

                dataGridView1.ItemsSource = textBox1.Text.ToList(); //ohne ein überschreiben der Quelle wird die tabelle nicht aktuell gehalten
                dataGridView1.ItemsSource = veranstaltung1.TriggerTimesListe;
                dataGridView1.AutoGenerateColumns = true;
            }
            else
            {
                //racerOnTrack = Tdc8000.NextRacerToFinish;
            }

            textBox2.Text = tdc8000.NextRacerToFinish.ToString();
            textBox3.Text = tdc8000.AktuelleTriggerZeit.TriggerTime.ToString();

            textBox4.Text = veranstaltung1.TriggerTimesListe.Count.ToString();

        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void checkBox1_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)checkBox1.IsChecked)
            {
                run = true;
                worker.DoWork += ReadSerialPort;
                worker.ProgressChanged += UpdateUI;
                if (!worker.CancellationPending)
                {
                    worker.RunWorkerAsync();
                }

            }
            if (!(bool)checkBox1.IsChecked)
            {
                run = false;
                worker.DoWork -= ReadSerialPort;
                worker.ProgressChanged -= UpdateUI;
                worker.CancelAsync();
            }
        }
    }
}
