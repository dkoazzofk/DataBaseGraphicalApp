using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.VIew.Interface
{
    public interface IAddWindow
    {
        Dictionary<string, string> _data { get; set; }

        void show(string textButton);
    }
}
