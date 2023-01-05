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

            //var nextId = _col.Query().ToList()[0].TeilnehmerListe.ToList().Count + 1;
            //Teilnehmer neuerTeilnehmer = new Teilnehmer { Id = nextId, Jahrgang = 1983 + nextId, Startnummer = nextId, TeilnehmerName = "Matthias" };
            //_veranstaltung.TeilnehmerListe.Add(neuerTeilnehmer);
            //_col.Update(_veranstaltung);

            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                dataGridView2.AutoResizeColumn(i);
            }

            dataGridView2.DataSource = _veranstaltung.TeilnehmerListe;
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.AllowUserToAddRows = true;
            dataGridView2.AllowUserToDeleteRows = true;
            dataGridView2.AllowUserToOrderColumns = true;
            dataGridView2.VirtualMode = true;
            dataGridView2.MultiSelect = false;



            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                dataGridView2.AutoResizeColumn(i);
            }
            dataGridView2.Refresh();
            dataGridView2.Update();
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
            //dataGridView2.DataSource = 1;
            var nix = dataGridView2.SelectedCells[0].OwningRow.Cells[0].Value.ToString();
            var daten = _veranstaltung.TeilnehmerListe.Find(x => x.Id.ToString() == dataGridView2.SelectedCells[0].OwningRow.Cells[0].Value.ToString()).TeilnehmerRaceTimes;

            List<string> datenAsString = new List<string>();

            foreach (var data in daten)
            {
                datenAsString.Add(data.ToString(@"hh\:mm\:ss\.ffff",System.Globalization.CultureInfo.InvariantCulture));
                
            }

            listBox1.DataSource = daten;


        }
    }

}
