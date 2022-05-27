using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.ComponentModel;

namespace FE_LAW_FINAL {
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window {
        public const string dbcon = @"Data Source=C:\Users\20010844\source\repos\FE_LAW_FINAL\FE_LAW_FINAL\testDB.db";
        SQLiteConnection conn = new SQLiteConnection(dbcon);
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter adapter = new SQLiteDataAdapter();
        public Boolean isLogined = false;
        public bool isLoaded = false;

        public LoginWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String _username = username.Text;
            String _password = password.Password.ToString();
            

            if (_username == "" || _password == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập hoặc mật khẩu!!");
                return;
            }

            string query = "SELECT * FROM User";

            conn.Open();
            cmd.CommandText = query;
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader[1].ToString() == _username && reader[2].ToString() == _password)
                {
                    isLogined = true;
                    break;
                }
            }
            conn.Close();

            if (isLogined)
            {
                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String _username = username.Text;
            String _password = password.Password.ToString();
            string query = string.Format("INSERT INTO User(username, password) VALUES('{0}','{1}')", _username, _password);
            conn.Open();
            cmd.CommandText = query;
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Đăng kí thành công");
        }

        private void showPassword_Checked(object sender, RoutedEventArgs e)
        {
            String _password = password.Password.ToString();
            visiblePassword.Text = _password;
            if (showPassword.IsChecked == true)
            {
                password.Visibility = Visibility.Hidden;
                visiblePassword.Visibility = Visibility.Visible;
            }
            else if (showPassword.IsChecked == false)
            {
                password.Visibility = Visibility.Visible;
                visiblePassword.Visibility = Visibility.Hidden;
            }
        }

        void DataWindow_Closing(object sender, CancelEventArgs e)
        {

            System.Windows.Application.Current.Shutdown();
        }

    }
}
