using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.VIew.Class;
using test.VIew.Interface;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace test.Presenter
{
    public class MainPresenter
    {
        IMainWindow _mainWindow { get; set; }
        DataGridView _dataGridView { get; set; }
        IAddWindow _addwindow { get;set; }
        string _lastTable;

        string _connectionString { get; } = "Host=localhost;Port=5432;Username=postgres;Password=123;Database=Departament Of Security";

        Dictionary<string, string> _dictionary = new Dictionary<string, string> {
            {"Квартиры", "Apartment" },
            {"Договор","Contract" },
            {"Клиент","client" },
            {"Выезды патр. экип.","departureofcrew" },
            {"Рапорт","Report" },
            {"Командир","Comander" },
            {"Документ о задержании","Documentofdetention" },
            {"Украденные вещи","stolenitems" },
        };
        public MainPresenter(IMainWindow mainWindow,IAddWindow addwindow)
        {
            _mainWindow = mainWindow;
            _dataGridView = mainWindow.DataGrid;
            _addwindow = addwindow;
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            _mainWindow.SetupButton(CheckTable);
            _mainWindow.AddButton(AddTable);
            _mainWindow.DeleteButton(DeleteTable);
            _mainWindow.FindButton(FindTable);
        }
        private void CheckTable(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM " + _dictionary[button.Text];
                    _lastTable = _dictionary[button.Text];
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    _dataGridView.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка подключения: {ex.Message}");
                }
            }
        }
       
        private void AddTable(object sender, EventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.show("Добавить");
            if (addWindow._data != null && addWindow._data.Count > 0) 
            {
                Dictionary<string, string> columnValues = addWindow._data;

                using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
                {
                    try
                    {
                        connection.Open();

                        string columns = string.Join(", ", columnValues.Keys);
                        string parameters = string.Join(", ", columnValues.Keys.Select(key => "@" + key));

                        string query = $"INSERT INTO \"{_lastTable}\" ({columns}) VALUES ({parameters})";

                        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                        {
                            foreach (var entry in columnValues)
                            {
                                command.Parameters.AddWithValue("@" + entry.Key, entry.Value ?? (object)DBNull.Value);
                            }

                            int rowsAffected = command.ExecuteNonQuery();
                            MessageBox.Show($"Добавлено записей: {rowsAffected}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка добавления данных: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Данные не были введены.");
            }
        }
        private void DeleteTable(object sender, EventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.show("Удалить");
            Dictionary<string, string> columnValues = addWindow._data;
            string idToDelete = columnValues["id"];
            string deleteQuery = $"DELETE FROM {_lastTable} WHERE id=" + idToDelete;
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", idToDelete);

                        int rowsAffected = command.ExecuteNonQuery();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private void ChangeTable(object sender, EventArgs e) { }
        private void FindTable(object sender, EventArgs e) {
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;
            AddWindow addWindow = new AddWindow();
            addWindow.show("Найти");
            Dictionary<string, string> columnValues = addWindow._data;
            string idToDelete = columnValues["id"];
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM " + _lastTable + " WHERE id=" + idToDelete;
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    _dataGridView.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка подключения: {ex.Message}");
                }
            }
        }
    }
}
