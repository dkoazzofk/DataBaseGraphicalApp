using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.VIew.Interface
{
    public interface ILoginWindow
    {
        public event EventHandler OpenMainWindow;

        string userLogin { get; }
        string userPassword { get; }
    }
}
