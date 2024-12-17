using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test.VIew.Interface
{
    public interface IConsoleWindow
    {
        String text { get; }
        DataGridView DataGrid { get; }

        void SetupButton(EventHandler checkTable);
        void SaveButton(EventHandler checkTable);
    }
}
