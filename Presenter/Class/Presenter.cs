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
            {"Квартиры", "apartment" },
            {"Договор","contract" },
            {"Клиент","client" },
            {"Выезды патр. экип.","departureofcrew" },
            {"Рапорт","report" },
            {"Командир","comander" },
            {"Документ о задержании","documentofdetention" },
            {"Украденные вещи","stolenitems" },
            {"Города", "city" },
            {"Улицы", "street" },
            {"Выезды на квартиры", "visittoapartment" }
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
            _mainWindow.ChangeButton(ChangeTable);
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
                        //string query = $"INSERT INTO \"test\" ({columns}) VALUES ({parameters})";
                        string query = $"INSERT INTO \"{_lastTable}\" ({columns}) VALUES ({parameters})";

                        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                        {
                            foreach (var entry in columnValues)
                            {
                                var parameter = new NpgsqlParameter("@" + entry.Key, entry.Value ?? (object)DBNull.Value);

                                if (int.TryParse(entry.Value, out int intValue))
                                {
                                    parameter.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                                    parameter.Value = intValue;
                                }
                                else
                                {
                                    parameter.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Text;
                                }

                                command.Parameters.Add(parameter);
                            }

                            int rowsAffected = command.ExecuteNonQuery();
                            MessageBox.Show($"Добавлено записей: {rowsAffected}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка добавления данных: {ex.Message}\nДанные: {string.Join(", ", columnValues)}");
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


        private void ChangeTable(object sender, EventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.show("Изменить");

            if (addWindow._data != null && addWindow._data.Count > 0)
            {
                Dictionary<string, string> columnValues = addWindow._data;

                // Предполагаем, что вы запрашиваете ID записи для изменения
                string idColumnName = "id"; // Название столбца первичного ключа
                if (!columnValues.ContainsKey(idColumnName))
                {
                    MessageBox.Show($"Не указан {idColumnName} для обновления.");
                    return;
                }

                string idValue = columnValues[idColumnName];
                columnValues.Remove(idColumnName); // Убираем ID из списка изменяемых столбцов

                if (columnValues.Count == 0)
                {
                    MessageBox.Show("Нет данных для обновления.");
                    return;
                }

                using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
                {
                    try
                    {
                        connection.Open();

                        // Формирование SQL-запроса для обновления
                        string setClause = string.Join(", ", columnValues.Keys.Select(key => $"\"{key}\" = @{key}"));
                        string query = $"UPDATE \"{_lastTable}\" SET {setClause} WHERE \"{idColumnName}\" = {idValue}";

                        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                        {
                            // Добавляем параметры для каждого столбца
                            foreach (var entry in columnValues)
                            {
                                var parameter = new NpgsqlParameter("@" + entry.Key, entry.Value ?? (object)DBNull.Value);

                                if (int.TryParse(entry.Value, out int intValue))
                                {
                                    parameter.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                                    parameter.Value = intValue;
                                }
                                else
                                {
                                    parameter.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Text;
                                }

                                command.Parameters.Add(parameter);
                            }

                            // Добавляем параметр для ID
                            //command.Parameters.Add(new NpgsqlParameter("@id", idValue)
                            //{
                            //    NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer // Устанавливаем тип Integer для ID
                            //});

                            // Выполняем запрос
                            int rowsAffected = command.ExecuteNonQuery();
                            MessageBox.Show($"Обновлено записей: {rowsAffected}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка обновления данных: {ex.Message}\nДанные: {string.Join(", ", columnValues)}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Данные не были введены.");
            }
        }


        private void FindTable(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;
            AddWindow addWindow = new AddWindow();
            addWindow.show("Найти");
            Dictionary<string, string> columnValues = addWindow._data;

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    // Формируем условие WHERE
                    List<string> conditions = new List<string>();
                    foreach (var entry in columnValues)
                    {
                            conditions.Add($"\"{entry.Key}\" = @{entry.Key}");
                    }
                    string whereClause = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : ""; // Если условия есть, добавляем WHERE

                    // Запрос SQL
                    string query = $"SELECT * FROM \"{_lastTable}\" {whereClause}";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Добавляем параметры к запросу
                        foreach (var entry in columnValues)
                        {
                            var parameter = new NpgsqlParameter("@" + entry.Key, entry.Value ?? (object)DBNull.Value);

                            if (int.TryParse(entry.Value, out int intValue))
                            {
                                parameter.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                                parameter.Value = intValue;
                            }
                            else
                            {
                                parameter.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Text;
                            }

                            command.Parameters.Add(parameter);
                        }

                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        _dataGridView.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка подключения: {ex.Message}");
                }
            }
        }

    }
}
