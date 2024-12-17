using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.Presenter.Class;
using test.VIew.Class;
using test.VIew.Interface;

namespace test
{
    public partial class MainWindow : Form, IMainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public DataGridView DataGrid => dataGridView1;

        public void SetupButton(EventHandler checkTable)
        {
            apartment.Click += checkTable;
            contract.Click += checkTable;
            client.Click += checkTable;
            departureofcrew.Click += checkTable;
            report.Click += checkTable;
            comander.Click += checkTable;
            documentofdetention.Click += checkTable;
            stolenitems.Click += checkTable;
            city.Click += checkTable;
            street.Click += checkTable;
            visittoapartment.Click += checkTable;
        }
        public void AddButton(EventHandler addTable)
        {
            add.Click += addTable;
        }

        public void DeleteButton(EventHandler deleteTable)
        {
            this.deleteTable.Click += deleteTable;
        }

        public void ChangeButton(EventHandler changeTable)
        {
            change.Click += changeTable;
        }

        public void FindButton(EventHandler findTable)
        {
            find.Click += findTable;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var AboutWindow = new AboutWindow();
            AboutWindow.ShowDialog();
        }

        private void ChangeDarkTheme(object sender, EventArgs e)
        {
            if (this.BackColor == SystemColors.ControlDarkDark)
            {
                MessageBox.Show("У вас уже темная тема.");
            }
            else
            {
                this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.apartment.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.apartment.ForeColor = System.Drawing.SystemColors.ButtonFace;

                this.contract.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.contract.ForeColor = System.Drawing.SystemColors.ButtonFace;

                this.client.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.client.ForeColor = System.Drawing.SystemColors.ButtonFace;

                this.departureofcrew.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.departureofcrew.ForeColor = System.Drawing.SystemColors.ButtonFace;

                this.report.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.report.ForeColor = System.Drawing.SystemColors.ButtonFace;

                this.comander.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.comander.ForeColor = System.Drawing.SystemColors.ButtonFace;

                this.documentofdetention.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.documentofdetention.ForeColor = System.Drawing.SystemColors.ButtonFace;

                this.stolenitems.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.stolenitems.ForeColor = System.Drawing.SystemColors.ButtonFace;

                this.add.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.add.ForeColor = System.Drawing.SystemColors.ButtonFace;

                this.deleteTable.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.deleteTable.ForeColor = System.Drawing.SystemColors.ButtonFace;

                this.change.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.change.ForeColor = System.Drawing.SystemColors.ButtonFace;

                this.find.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.find.ForeColor = System.Drawing.SystemColors.ButtonFace;

                this.city.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.city.ForeColor = System.Drawing.SystemColors.ButtonFace;

                this.street.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.street.ForeColor = System.Drawing.SystemColors.ButtonFace;

                this.visittoapartment.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.visittoapartment.ForeColor = System.Drawing.SystemColors.ButtonFace;

                this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            }
        }

        private void темнаяТемаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChangeDarkTheme(sender, e);
        }
        private void ChangeLightTheme(object sender, EventArgs e)
        {
            if (this.BackColor == SystemColors.ButtonFace)
            {
                MessageBox.Show("У вас уже светлая тема.");
            }
            else
            {
                this.BackColor = System.Drawing.SystemColors.ButtonFace;
                this.apartment.BackColor = System.Drawing.SystemColors.ButtonFace;
                this.apartment.ForeColor = System.Drawing.Color.Black;

                this.contract.BackColor = System.Drawing.SystemColors.ButtonFace;
                this.contract.ForeColor = System.Drawing.Color.Black;

                this.client.BackColor = System.Drawing.SystemColors.ButtonFace;
                this.client.ForeColor = System.Drawing.Color.Black;

                this.departureofcrew.BackColor = System.Drawing.SystemColors.ButtonFace;
                this.departureofcrew.ForeColor = System.Drawing.Color.Black;

                this.report.BackColor = System.Drawing.SystemColors.ButtonFace;
                this.report.ForeColor = System.Drawing.Color.Black;

                this.comander.BackColor = System.Drawing.SystemColors.ButtonFace;
                this.comander.ForeColor = System.Drawing.Color.Black;

                this.documentofdetention.BackColor = System.Drawing.SystemColors.ButtonFace;
                this.documentofdetention.ForeColor = System.Drawing.Color.Black;

                this.stolenitems.BackColor = System.Drawing.SystemColors.ButtonFace;
                this.stolenitems.ForeColor = System.Drawing.Color.Black;

                this.add.BackColor = System.Drawing.SystemColors.ButtonFace;
                this.add.ForeColor = System.Drawing.Color.Black;

                this.deleteTable.BackColor = System.Drawing.SystemColors.ButtonFace;
                this.deleteTable.ForeColor = System.Drawing.Color.Black;

                this.change.BackColor = System.Drawing.SystemColors.ButtonFace;
                this.change.ForeColor = System.Drawing.Color.Black;

                this.find.BackColor = System.Drawing.SystemColors.ButtonFace;
                this.find.ForeColor = System.Drawing.Color.Black;

                this.city.BackColor = System.Drawing.SystemColors.ButtonFace;
                this.city.ForeColor = System.Drawing.Color.Black;

                this.street.BackColor = System.Drawing.SystemColors.ButtonFace;
                this.street.ForeColor = System.Drawing.Color.Black;

                this.visittoapartment.BackColor = System.Drawing.SystemColors.ButtonFace;
                this.visittoapartment.ForeColor = System.Drawing.Color.Black;

                this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            }
        }

        private void светлаяТемаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChangeLightTheme(sender, e);
        }
        public void RegUser()
        {

        }

        private void запросникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsoleWindow ConsoleWindow = new ConsoleWindow();
            DocumentsPresenter documentWindow = new DocumentsPresenter(ConsoleWindow);
            ConsoleWindow.Show();
        }


        //private void ChangeToEnglish(object sender, EventArgs e)
        //{
        //    this.apartment.Text = "Apartment";
        //    this.contract.Text = "Contract";
        //    this.client.Text = "Client";
        //    this.departureofcrew.Text = "Departure of Crew";
        //    this.report.Text = "Report";
        //    this.comander.Text = "Comander";
        //    this.documentofdetention.Text = "Document of detention";
        //    this.stolenitems.Text = "Stolen items";

        //    this.add.Text = "Add";
        //    this.deleteTable.Text = "Delete";
        //    this.change.Text = "Change";
        //    this.find.Text = "Find";
        //}

        //private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ChangeToEnglish(sender, e);
        //}
    }
}
