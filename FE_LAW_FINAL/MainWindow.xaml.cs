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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.ComponentModel;

namespace FE_LAW_FINAL {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public const string dbcon = @"Data Source=C:\Users\20010844\source\repos\DataBase\DataBase\testDB.db";
        SQLiteConnection conn = new SQLiteConnection(dbcon);
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter adapter = new SQLiteDataAdapter();
        public bool isLoaded = false;
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }
        public Orientation Orientation { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string _article = article.Text;
            string _articleContent = articleContent.Text;
            string _clause = clause.Text;
            string _clauseContent = clauseContent.Text;
            string _fineAbove = fineAbove.Text;
            string _fineBelow = fineBelow.Text;

            string query = string.Format("INSERT INTO Law(article, article_content, clause, clause_content, fine_above, fine_below) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", _article, _articleContent, _clause, _clauseContent, _fineAbove, _fineBelow);
            conn.Open();
            cmd.CommandText = query;
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Them thanh cong");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string _article = article.Text;
            string _articleContent = articleContent.Text;
            string _clause = clause.Text;
            string _clauseContent = clauseContent.Text;
            string _fineAbove = fineAbove.Text;
            string _fineBelow = fineBelow.Text;
            string query;

            query = string.Format("UPDATE Law SET HoTen='{0}', Lop='{1}', TinhTrang='{2}' WHERE id={3}", _article, _articleContent, _clause, _clauseContent);

            cmd.CommandText = query;
            conn.Open();
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Cap nhat thanh cong");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string id = ID.Text;

            string query = string.Format("DELETE FROM Law WHERE id={0}", id);
            conn.Open();
            cmd.CommandText = query;
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Xoa thanh cong");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM Law";

            conn.Open();
            cmd.CommandText = query;
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            SQLiteDataReader reader = cmd.ExecuteReader();



            listBox.Items.Clear();
            while (reader.Read())
            {
                TextBlock newT = new TextBlock();
                newT.TextWrapping = TextWrapping.WrapWithOverflow;
                newT.MaxWidth = 1450;
                newT.MinWidth = 200;
                newT.Text = String.Format("ID:{0} \nĐiều: {1} \nNội dung điều: {2} \nKhoản: {3} \nNội dung khoản: {4} \nMức phạt trên: {5} \nMức phạt dưới: {6}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
                listBox.Items.Add(newT);
            }
            conn.Close();
        }

        void DataMainWindow_Closing(object sender, CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
