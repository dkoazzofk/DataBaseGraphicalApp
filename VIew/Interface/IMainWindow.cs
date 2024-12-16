using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test.VIew.Interface
{
    public interface IMainWindow
    {
        DataGridView DataGrid { get; }

        void SetupButton(EventHandler checkTable);
        
        void AddButton(EventHandler addTable);
        void DeleteButton(EventHandler deleteTable);
        void ChangeButton(EventHandler deleteTable);
        void FindButton(EventHandler deleteTable);

    }
}
