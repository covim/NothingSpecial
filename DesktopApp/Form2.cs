using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class Form2 : Form
    {
        private int rowCount = 0;
        private Dictionary<int, TimerRow> timerRows = new Dictionary<int, TimerRow>();

        public Form2()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Add("Nummer", "Nummer");
            dataGridView1.Columns.Add("Zeit", "Zeit (mm:ss.zh)");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rowCount++;
            int rowIndex = dataGridView1.Rows.Add(rowCount.ToString(), "00:00.0");

            TimerRow timerRow = new TimerRow(rowCount, dataGridView1);
            timerRows[rowCount] = timerRow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int rowNumber))
            {
                RemoveRowByNumber(rowNumber);
            }
            else
            {
                MessageBox.Show("Bitte eine gültige Nummer eingeben!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RemoveRowByNumber(int rowNumber)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int currentNumber))
                {
                    if (currentNumber == rowNumber)
                    {
                        // Timer stoppen und entfernen
                        if (timerRows.ContainsKey(rowNumber))
                        {
                            timerRows[rowNumber].Stop();
                            timerRows.Remove(rowNumber);
                        }

                        dataGridView1.Rows.Remove(row);
                        return;
                    }
                }
            }

            MessageBox.Show("Nummer nicht gefunden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    public class TimerRow
    {
        private int rowNumber;
        private int timeValue;
        private System.Windows.Forms.Timer timer;
        private DataGridView gridView;

        public TimerRow(int rowNumber, DataGridView gridView)
        {
            this.rowNumber = rowNumber;
            this.gridView = gridView;
            this.timeValue = 0;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100; // 100ms = 1 Zehntelsekunde
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            timeValue++; // Zehntelsekunden hochzählen
            string formattedTime = FormatTime(timeValue);

            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int currentNumber))
                {
                    if (currentNumber == rowNumber)
                    {
                        row.Cells[1].Value = formattedTime;
                        break;
                    }
                }
            }
        }

        public void Stop()
        {
            timer.Stop();
        }

        private string FormatTime(int totalTenths)
        {
            int minutes = totalTenths / 600;
            int seconds = (totalTenths / 10) % 60;
            int tenths = totalTenths % 10;
            return $"{minutes:D2}:{seconds:D2}.{tenths}";
        }
    }
}
