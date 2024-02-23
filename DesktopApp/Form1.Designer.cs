namespace DesktopApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            cb_TdC8000_Read = new CheckBox();
            databaseBindingSource1 = new BindingSource(components);
            databaseBindingSource = new BindingSource(components);
            dataGridView1 = new DataGridView();
            textBox4 = new TextBox();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            ladenToolStripMenuItem = new ToolStripMenuItem();
            ladenToolStripMenuItem1 = new ToolStripMenuItem();
            veranstaltungToolStripMenuItem = new ToolStripMenuItem();
            teilnehmerVerwaltenToolStripMenuItem = new ToolStripMenuItem();
            fileSystemWatcher1 = new FileSystemWatcher();
            openFileDialog1 = new OpenFileDialog();
            comboBox1 = new ComboBox();
            cBonlyRaceTimes = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)databaseBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(44, 46);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(398, 23);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(44, 75);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(398, 23);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(44, 104);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(398, 23);
            textBox3.TabIndex = 2;
            // 
            // cb_TdC8000_Read
            // 
            cb_TdC8000_Read.AutoSize = true;
            cb_TdC8000_Read.Location = new Point(471, 77);
            cb_TdC8000_Read.Name = "cb_TdC8000_Read";
            cb_TdC8000_Read.Size = new Size(99, 19);
            cb_TdC8000_Read.TabIndex = 3;
            cb_TdC8000_Read.Text = "TdC8000 Read";
            cb_TdC8000_Read.UseVisualStyleBackColor = true;
            cb_TdC8000_Read.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // databaseBindingSource1
            // 
            databaseBindingSource1.DataSource = typeof(LiteDB_Class.Database);
            // 
            // databaseBindingSource
            // 
            databaseBindingSource.DataSource = typeof(LiteDB_Class.Database);
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(44, 133);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(567, 607);
            dataGridView1.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(44, 746);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 5;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, veranstaltungToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(634, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { ladenToolStripMenuItem, ladenToolStripMenuItem1 });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(46, 20);
            toolStripMenuItem1.Text = "Datei";
            // 
            // ladenToolStripMenuItem
            // 
            ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            ladenToolStripMenuItem.Size = new Size(106, 22);
            ladenToolStripMenuItem.Text = "Neu";
            ladenToolStripMenuItem.Click += ladenToolStripMenuItem_Click;
            // 
            // ladenToolStripMenuItem1
            // 
            ladenToolStripMenuItem1.Name = "ladenToolStripMenuItem1";
            ladenToolStripMenuItem1.Size = new Size(106, 22);
            ladenToolStripMenuItem1.Text = "Laden";
            ladenToolStripMenuItem1.Click += ladenToolStripMenuItem1_Click;
            // 
            // veranstaltungToolStripMenuItem
            // 
            veranstaltungToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { teilnehmerVerwaltenToolStripMenuItem });
            veranstaltungToolStripMenuItem.Name = "veranstaltungToolStripMenuItem";
            veranstaltungToolStripMenuItem.Size = new Size(91, 20);
            veranstaltungToolStripMenuItem.Text = "Veranstaltung";
            veranstaltungToolStripMenuItem.Click += veranstaltungToolStripMenuItem_Click;
            // 
            // teilnehmerVerwaltenToolStripMenuItem
            // 
            teilnehmerVerwaltenToolStripMenuItem.Name = "teilnehmerVerwaltenToolStripMenuItem";
            teilnehmerVerwaltenToolStripMenuItem.Size = new Size(183, 22);
            teilnehmerVerwaltenToolStripMenuItem.Text = "TeilnehmerVerwalten";
            teilnehmerVerwaltenToolStripMenuItem.Click += teilnehmerVerwaltenToolStripMenuItem_Click;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(471, 46);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 7;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // cBonlyRaceTimes
            // 
            cBonlyRaceTimes.AutoSize = true;
            cBonlyRaceTimes.Location = new Point(471, 106);
            cBonlyRaceTimes.Name = "cBonlyRaceTimes";
            cBonlyRaceTimes.Size = new Size(140, 19);
            cBonlyRaceTimes.TabIndex = 8;
            cBonlyRaceTimes.Text = "Show only RaceTimes";
            cBonlyRaceTimes.UseVisualStyleBackColor = true;
            cBonlyRaceTimes.CheckedChanged += cBonlyRaceTimes_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 781);
            Controls.Add(cBonlyRaceTimes);
            Controls.Add(comboBox1);
            Controls.Add(textBox4);
            Controls.Add(dataGridView1);
            Controls.Add(cb_TdC8000_Read);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)databaseBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private CheckBox cb_TdC8000_Read;
        private BindingSource databaseBindingSource1;
        private BindingSource databaseBindingSource;
        private DataGridView dataGridView1;
        private TextBox textBox4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem ladenToolStripMenuItem;
        private ToolStripMenuItem ladenToolStripMenuItem1;
        private FileSystemWatcher fileSystemWatcher1;
        private OpenFileDialog openFileDialog1;
        private ComboBox comboBox1;
        private ToolStripMenuItem veranstaltungToolStripMenuItem;
        private ToolStripMenuItem teilnehmerVerwaltenToolStripMenuItem;
        private CheckBox cBonlyRaceTimes;
    }
}