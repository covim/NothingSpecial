using LiteDB;
using LiteDB_Class;
using System.ComponentModel;
using System.IO.Ports;
using TDC8000;
using Types;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        TDC8000Parser tdc8000;
        BackgroundWorker worker = new BackgroundWorker();
        bool run = false;
        Veranstaltung veranstaltung1;
        ILiteDatabase _db;
        ILiteCollection<Veranstaltung> _col;
        IEnumerable<TriggerTimes> triggerTimesList;
        frm_neueVeranstaltung neueVeranstaltungsDaten;
        frm_TeilnehmerVerwaltung teilnehmerVerwaltung;
        string selectedComPort = string.Empty;


        public Form1()
        {
            InitializeComponent();

            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            textBox1.Enabled = false;
            veranstaltungToolStripMenuItem.Enabled = false;
            neueVeranstaltungsDaten = new frm_neueVeranstaltung();
            
            comboBox1.DataSource = SerialPort.GetPortNames();

        }

        private void ReadSerialPort(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker1 = sender as BackgroundWorker;
            SerialPort port = new SerialPort(selectedComPort, 9600, Parity.None, 8, StopBits.One);
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
                _col.Update(veranstaltung1);
                //triggerTimesList = col.Query().ToList()[0].TriggerTimesListe;

                UpdateGridView();
            }
            else
            {
                //racerOnTrack = Tdc8000.NextRacerToFinish;
            }

            textBox2.Text = tdc8000.NextRacerToFinish.ToString();
            textBox3.Text = tdc8000.AktuelleTriggerZeit.TriggerTime.ToString();

            dataGridView1.Refresh();
            dataGridView1.Update();

            textBox4.Text = veranstaltung1.TriggerTimesListe.Count.ToString();

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_TdC8000_Read.Checked)
            {
                run = true;
                worker.DoWork += ReadSerialPort;
                worker.ProgressChanged += UpdateUI;
                if (!worker.CancellationPending)
                {
                    worker.RunWorkerAsync();
                }

            }
            if (!cb_TdC8000_Read.Checked)
            {
                run = false;
                worker.DoWork -= ReadSerialPort;
                worker.ProgressChanged -= UpdateUI;
                worker.CancelAsync();
            }

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            neueVeranstaltungsDaten.StartDialog();

            this.Text = "Veranstaltung: " +
                neueVeranstaltungsDaten.VeranstaltungsName +
                " in: " +
                neueVeranstaltungsDaten.VeranstaltungsOrt;

            veranstaltung1 = new Veranstaltung
            {
                VeranstaltungsName = neueVeranstaltungsDaten.VeranstaltungsName,
                VeranstaltungsOrt = neueVeranstaltungsDaten.VeranstaltungsOrt,
                VeranstaltungsDatum = DateTime.Now,
                TeilnehmerListe = new List<Teilnehmer>(),
                TriggerTimesListe = new List<TriggerTimes>()
            };

            _db = new LiteDatabase(neueVeranstaltungsDaten.DbDateiPfad);
            _col = _db.GetCollection<Veranstaltung>("Veranstaltung");

            Database.SaveDataToDB(veranstaltung1, _col);

            tdc8000 = new TDC8000Parser();
            veranstaltungToolStripMenuItem.Enabled = true;

        }

        private void ladenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) { return; }

            _db = new LiteDatabase(openFileDialog1.FileName);
            _col = _db.GetCollection<Veranstaltung>("Veranstaltung");
            var veranstaltungsName = _col.Query().ToList()[0].VeranstaltungsName;
            var veranstaltungsOrt = _col.Query().ToList()[0].VeranstaltungsOrt;

            veranstaltung1 = Database.ReadAllDataFromDB(_col);


            tdc8000 = new TDC8000Parser(_col.Query().ToList()[0].TriggerTimesListe.ToList().Count + 1);

            this.Text = "Veranstaltung: " +
                        veranstaltung1.VeranstaltungsName +
                        " in: " +
                        veranstaltung1.VeranstaltungsOrt;

            UpdateGridView();
            veranstaltungToolStripMenuItem.Enabled = true;


        }

        private void UpdateGridView()
        {
            dataGridView1.DataSource = 1;
            dataGridView1.DataSource = veranstaltung1.TriggerTimesListe;
            triggerTimesList = _col.Query().ToList()[0].TriggerTimesListe;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Columns[3].DefaultCellStyle.Format = @"hh\:mm\:ss\.ffff";
            dataGridView1.Columns[2].DefaultCellStyle.Format = "dd.MM.yyyy hh:mm:ss.ffff";
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.AutoResizeColumn(i);
            }
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedComPort = comboBox1.SelectedItem.ToString();
        }

        private void veranstaltungToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void teilnehmerVerwaltenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            teilnehmerVerwaltung = new frm_TeilnehmerVerwaltung(veranstaltung1, _col);
            teilnehmerVerwaltung.ShowDialog();
            _col.Update(veranstaltung1);
        }
    }
}