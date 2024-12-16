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
    public partial class AddWindow : Form, IAddWindow
    {
        public AddWindow()
        {
            InitializeComponent();
        }
        public Dictionary<string, string> _data { get; set; } = new Dictionary<string, string> { };

        public void show(string textButton)
        {
            button.Text = textButton;
            ShowDialog();
        }

        private void button_Click(object sender, EventArgs e)
        {
            string text = textBox.Text;
            string[] pairs = text.Split(';');
            foreach (string pair in pairs)
            {
                if (string.IsNullOrWhiteSpace(pair)) continue; 

                string[] keyValue = pair.Split('=');
                if (keyValue.Length == 2)
                {
                    string key = keyValue[0].Trim();
                    string value = keyValue[1].Trim();

                    if (!_data.ContainsKey(key))
                        _data[key] = value;
                    else
                        MessageBox.Show($"Ключ \"{key}\" уже существует. Пропускаем.");
                }
                else
                {
                    MessageBox.Show($"Некорректный формат пары: {pair}");
                }
            }
        }
    }
}
