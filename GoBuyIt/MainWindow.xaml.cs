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
using System.Data;

namespace GoBuyIt
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        SQLiteConnection SQLite_Connection;
        SQLiteCommand  SQLite_Command;
        SQLiteDataReader SQLite_Reader;
        DataTable dt = new DataTable();
        /// <summary>
        /// main
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            SQLite_Connection = new SQLiteConnection(@"Data Source=C:\SQLiteStudio\DB\test1.db");
            SQLite_Connection.Open();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SQLite_Command = SQLite_Connection.CreateCommand();
            SQLite_Command.CommandText = "Select * From TestTable2";
            SQLite_Reader = SQLite_Command.ExecuteReader();
            dt.Load(SQLite_Reader);
            dataGrid.ItemsSource = dt.DefaultView;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SQLite_Command = SQLite_Connection.CreateCommand();
            SQLite_Command.CommandText = "Select * From TestTable2 where 顧客='郭美珍'";
            SQLite_Reader = SQLite_Command.ExecuteReader();
           
            dt.Clear();
            dt.Load(SQLite_Reader);
            dataGrid.ItemsSource = dt.DefaultView;
        }
    }
}
