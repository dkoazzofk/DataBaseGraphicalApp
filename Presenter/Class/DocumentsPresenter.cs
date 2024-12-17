using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.VIew.Interface;

namespace test.Presenter.Class
{
    public class DocumentsPresenter
    {
        IConsoleWindow _consoleWindow { get; set; }

        DataTable _dataTable { get; set; }

        string _filePath { get; set; } = "C:\\Users\\zotov\\source\\repos\\test\\test\\files\\document.txt";
        string _connectionString { get; } = "Host=localhost;Port=5432;Username=postgres;Password=123;Database=Departament Of Security";
        public DocumentsPresenter(IConsoleWindow consoleWindow) {
            _consoleWindow = consoleWindow;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _consoleWindow.SetupButton(CheckTable);
            _consoleWindow.SaveButton(SaveToTxt);
        }
        private void CheckTable(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string query = _consoleWindow.text;
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    _dataTable = dataTable;
                    adapter.Fill(dataTable);
                    _consoleWindow.DataGrid.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка подключения: {ex.Message}");
                }
            }
        }

        public void SaveToTxt(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    // Запись заголовков столбцов
                    for (int i = 0; i < _dataTable.Columns.Count; i++)
                    {
                        writer.Write(_dataTable.Columns[i]);
                        if (i < _dataTable.Columns.Count - 1)
                            writer.Write("\t"); // Разделитель между столбцами (табуляция)
                    }
                    writer.WriteLine();

                    // Запись строк данных
                    foreach (DataRow row in _dataTable.Rows)
                    {
                        for (int i = 0; i < _dataTable.Columns.Count; i++)
                        {
                            writer.Write(row[i]);
                            if (i < _dataTable.Columns.Count - 1)
                                writer.Write("\t");
                        }
                        writer.WriteLine();
                    }
                }
                Console.WriteLine($"Данные успешно сохранены в файл: {_filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения в файл: {ex.Message}");
            }
        }
    }
}
