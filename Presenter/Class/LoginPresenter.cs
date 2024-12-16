using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.VIew.Interface;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace test.Presenter.Class
{
    public class LoginPresenter
    {
        public int flag = 0;
        ILoginWindow _loginWindow;

        public LoginPresenter(ILoginWindow loginWindow)
        {
            _loginWindow = loginWindow;
            _loginWindow.OpenMainWindow += OpenMainWindow;
        }
        public void OpenMainWindow(object argc, EventArgs e)
        {
            string login = _loginWindow.userLogin;
            string password = _loginWindow.userPassword;
            MainWindow mainWindow = new MainWindow();

            mainWindow.ShowDialog();
        }

        //public void authorization(string username, string password)
        //{
        //    if (username == "admin" && password == "zxc")
        //    {
        //        flag = 1;
        //        MessageBox.Show("Добро пожаловать!");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Неправильные данные.");
        //    }
        //}
        public bool authorization(string login, string password)
        {
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123;Database=Departament Of Security";
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(1) FROM users WHERE login = @login AND password = @password";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        return count == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return false;
            }
        }
    }
}