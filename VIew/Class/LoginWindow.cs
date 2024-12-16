using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using test.Presenter.Class;
using test.VIew.Interface;
using test.Presenter;

namespace test.VIew.Class
{
    public partial class LoginWindow : Form, ILoginWindow
    {
        public MainWindow _mainWindow = new MainWindow();
        ILoginWindow _loginWindow {  get; set; }
        public event EventHandler OpenMainWindow;
        public LoginPresenter loginPresenter;
        public bool isLoggedIn = false;
        public int Flag => loginPresenter.flag;
        public LoginWindow()
        {
            InitializeComponent();
            loginPresenter = new LoginPresenter(this);
        }

        public string userLogin => loginTextBox.Text;

        public string userPassword => passwordTextBox.Text;


        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userLogin) || string.IsNullOrEmpty(userPassword)){
                MessageBox.Show("Введите логин и пароль.");
                return;
            }
            if (loginPresenter.authorization(userLogin, userPassword)){ 
                MessageBox.Show("Успешный вход!");
                this.Hide();
                AddWindow add = new AddWindow();
                MainPresenter presenter = new MainPresenter(_mainWindow, add);
                _mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
                return;
            }


            //loginPresenter.authorization(userLogin, userPassword);
            //if (loginPresenter.flag == 1)
            //{
            //    this.Close();
            //}
        }
    }
}
