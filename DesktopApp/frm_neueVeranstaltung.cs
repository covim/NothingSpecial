using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class frm_neueVeranstaltung : Form
    {
        public frm_neueVeranstaltung()
        {
            InitializeComponent();
        }

        public string VeranstaltungsName => textBox1.Text;
        public string VeranstaltungsOrt => textBox2.Text;
        public string DbDateiPfad => textBox3.Text;

        public DialogResult StartDialog()
        {
            textBox1.Text = "TestVeranstaltung";
            textBox2.Text = "TestOrt";
            textBox3.Text = @"C:\temp\Test765.db";

            return ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text)) { return; }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
