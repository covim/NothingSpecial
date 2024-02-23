using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Types;

namespace DesktopApp
{
    public partial class frm_TeilnehmerVerwaltung : Form
    {
        private Veranstaltung _veranstaltung;
        private ILiteCollection<Veranstaltung> _col;
        public frm_TeilnehmerVerwaltung(Veranstaltung veranstaltung, ILiteCollection<Veranstaltung> collection)
        {
            InitializeComponent();
            _veranstaltung = veranstaltung;
            _col = collection;

            dataGridView2.DataSource = _veranstaltung.TeilnehmerListe;
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.AllowUserToAddRows = true;
            dataGridView2.AllowUserToDeleteRows = true;
            dataGridView2.AllowUserToOrderColumns = true;
            dataGridView2.VirtualMode = true;
            dataGridView2.MultiSelect = true;

            dataGridView3.AutoGenerateColumns = true;
            dataGridView3.AllowUserToAddRows = true;
            dataGridView3.AllowUserToDeleteRows = true;
            dataGridView3.AllowUserToOrderColumns = true;
            dataGridView3.VirtualMode = true;
            dataGridView3.MultiSelect = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            _col.Update(_veranstaltung);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nextId = _col.Query().ToList()[0].TeilnehmerListe.ToList().Count + 1;
            Teilnehmer neuerTeilnehmer = new Teilnehmer { Id = nextId };
            _veranstaltung.TeilnehmerListe.Add(neuerTeilnehmer);
            _col.Update(_veranstaltung);
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = 1;

            dataGridView2.DataSource = _veranstaltung.TeilnehmerListe;

            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                dataGridView2.AutoResizeColumn(i);
            }
            dataGridView2.Refresh();
            dataGridView2.Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Teilnehmer.UpdateRaceTimes(_veranstaltung.TriggerTimesListe, _veranstaltung.TeilnehmerListe);
            _col.Update(_veranstaltung);
            dataGridView2.AutoGenerateColumns = true;

            dataGridView2.DataSource = 1;

            dataGridView2.DataSource = _veranstaltung.TeilnehmerListe;

            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                dataGridView2.AutoResizeColumn(i);
            }
            dataGridView2.Refresh();
            dataGridView2.Update();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateLaufzeitenGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UpdateLaufzeitenGridView()
        {
            var startnummerSelektierterRow = dataGridView2.SelectedCells[0].OwningRow.Cells[3].Value.ToString();

            List<string> startNummern = new List<string>();
            for (int i = 0; i < dataGridView2.SelectedCells.Count; i++)
            {
                startNummern.Add(dataGridView2.SelectedCells[i].OwningRow.Cells[3].Value.ToString());
            }
            List<TriggerTimes> daten = new List<TriggerTimes>();

            foreach (var startnummer in startNummern)
            {
                daten.AddRange(_veranstaltung.TriggerTimesListe.FindAll(x => x.Startnummer.ToString() == startnummer));

            }

            if (checkBox1.Checked)
            {
                daten = daten.FindAll(x => x.Channel.Contains("RT"));
            }

            dataGridView3.DataSource = 1;
            dataGridView3.DataSource = daten;
            dataGridView3.AutoGenerateColumns = true;
            dataGridView3.Columns[3].DefaultCellStyle.Format = @"hh\:mm\:ss\.ffff";
            dataGridView3.Columns[2].DefaultCellStyle.Format = "dd.MM.yyyy hh:mm:ss.ffff";
            for (int i = 0; i < dataGridView3.ColumnCount; i++)
            {
                dataGridView3.AutoResizeColumn(i);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLaufzeitenGridView();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            //UpdateLaufzeitenGridView();
        }
    }

}
