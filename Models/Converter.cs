using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Models
{
    public class Converter
    {
        public object Distribution (string typeDate)
        {
            switch (typeDate) {
                case "int":
                    break;
                case "double":
                    break;
                case "string":
                    break;
                case "boolean":
                    break;
                default:
                    return "Ошибка";
            }
            return null;

        }

        public void ConverterInt() { }

        public void ConverterDouble() { }

        public void ConverterString() { }
        
        public void ConverterBoolean() { }
    }
}
