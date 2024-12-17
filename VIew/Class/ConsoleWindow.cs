using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.VIew.Interface;

namespace test.VIew.Class
{
    public partial class ConsoleWindow : Form, IConsoleWindow
    {
        public ConsoleWindow()
        {
            InitializeComponent();
        }

        public string text => textBoxDocument.Text;

        public DataGridView DataGrid =>  dataGridViewDocument;

        public void SaveButton(EventHandler checkTable)
        {
            saveDocument.Click += checkTable;
        }

        public void SetupButton(EventHandler checkTable)
        {
            seeDocument.Click += checkTable;
        }
    }
}
