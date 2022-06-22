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
        public const string dbcon = @"Data Source=C:\Users\20010844\Desktop\law.db";
        SQLiteConnection conn = new SQLiteConnection(dbcon);
        
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
            try
            {
                int _article = Int32.Parse(article.Text);
                string _articleContent = articleContent.Text;
                int _clause = -1;
                if (clause.Text != "")
                {
                    _clause = Int32.Parse(clause.Text);
                }
                string _clauseContent = clauseContent.Text;
                string _fineAbove = fineAbove.Text;
                string _fineBelow = fineBelow.Text;
                string _point = point.Text;
                string _pointContent = pointContent.Text;


                string query = string.Format("INSERT INTO Law(article, article_content, clause, clause_content, fine_above, fine_below, point, point_content) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}', '{7}')", _article, _articleContent, _clause, _clauseContent, _fineAbove, _fineBelow, _point, _pointContent);
                SQLiteCommand cmd = new SQLiteCommand();
                conn.Open();
                cmd.CommandText = query;
                cmd.Connection = conn;
                adapter.SelectCommand = cmd;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Thêm thành công");
            }
            catch(Exception)
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
                conn.Close();
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = ID.Text;
                int _article = Int32.Parse(article.Text);
                string _articleContent = articleContent.Text;
                int _clause = -1;
                if (clause.Text != "")
                {
                    _clause = Int32.Parse(clause.Text);
                }
                string _clauseContent = clauseContent.Text;
                string _fineAbove = fineAbove.Text;
                string _fineBelow = fineBelow.Text;
                string _point = point.Text;
                string _pointContent = pointContent.Text;s
                string query;

                query = string.Format("UPDATE Law SET article='{0}', articleContent='{1}', clause='{2}', clauseContent='{3}' WHERE id={4}", _article, _articleContent, _clause, _clauseContent, ID);
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = query;
                conn.Open();
                cmd.Connection = conn;
                adapter.SelectCommand = cmd;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Cập nhật thành công");
            }
            catch
            {
                
                MessageBox.Show("Chức năng đang được hoàn thiện!","Lưu ý",MessageBoxButton.OK, MessageBoxImage.Warning);
                conn.Close();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = ID.Text;

                string query = string.Format("DELETE FROM Law WHERE id={0}", id);
                SQLiteCommand cmd = new SQLiteCommand();
                conn.Open();
                cmd.CommandText = query;
                cmd.Connection = conn;
                adapter.SelectCommand = cmd;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Chưa nhập ID","Lưu ý",MessageBoxButton.OK, MessageBoxImage.Warning);
                conn.Close();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM Law";
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            
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
                newT.Text = String.Format("ID:{0} \nĐiều: {1} \nNội dung điều:\n {2} \nKhoản: {3} \nNội dung khoản: {4} \nĐiểm: {5} \nNội dung điểm: {6} \nMức phạt trên: {7} \nMức phạt dưới: {8}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[7], reader[8], reader[5], reader[6]);
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
