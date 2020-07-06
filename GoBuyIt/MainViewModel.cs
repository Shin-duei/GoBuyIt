using GoBuyIt.BasicFunction;
using GoBuyIt.Model;
using GoBuyIt.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GoBuyIt
{
    public class MainViewModel : ViewModelBase
	{
		public MainViewModel()
		{

		}
		//載入的訂單
		private List<BaseTitle> loadOrderViewList = new List<BaseTitle>();
		//輸入的顧客姓名
		private string customerName;
		//是否為會員
		private bool membership;


		private ObservableCollection<OrderView> orderViewList = new ObservableCollection<OrderView>();
		public ObservableCollection<OrderView> OrderViewList
		{
			get { return orderViewList; }
			set { orderViewList = value; OnPropertyChanged(); }
		}

		SQLiteConnection SQLite_Connection;
		SQLiteCommand SQLite_Command;
		SQLiteDataReader SQLite_Reader;

		string DataBasePath = Path.Combine(PathFunction.GetExecuteLevelPath(System.Environment.CurrentDirectory, 2), @"DataBase\GoBuyIt.db");
		DataTable dt = new DataTable();

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (SQLite_Connection.State == ConnectionState.Closed)
				SQLite_Connection.Open();

			SQLite_Command = SQLite_Connection.CreateCommand();
			SQLite_Command.CommandText = "Select * From GoBuyItMember";
			SQLite_Reader = SQLite_Command.ExecuteReader();
			dt.Load(SQLite_Reader);
			// dataGrid.ItemsSource = dt.DefaultView;

		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			SQLite_Command = SQLite_Connection.CreateCommand();
			SQLite_Command.CommandText = "Select * From TestTable2 where 顧客='郭美珍'";
			SQLite_Reader = SQLite_Command.ExecuteReader();

			dt.Clear();
			dt.Load(SQLite_Reader);
			// dataGrid.ItemsSource = dt.DefaultView;
		}
		/// <summary>
		/// 建立資料庫按鈕
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonCreateDataBase(object sender, RoutedEventArgs e)
		{
			if (!File.Exists(DataBasePath))
				SQLite_Connection = CreateDataBase(DataBasePath);
		}
		/// <summary>
		/// 建立資料庫
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private SQLiteConnection CreateDataBase(string dataBasePath)
		{
			string CreateDataBasePath = string.Format("Data Source=" + $"{ dataBasePath}" + ";Version=3;New=True;Compress=True;");
			if (!File.Exists(dataBasePath))
			{
				var _SQLite_Connection = new SQLiteConnection(CreateDataBasePath);

				if (_SQLite_Connection.State == ConnectionState.Open)
					_SQLite_Connection.Close();

				_SQLite_Connection.Open();

				return _SQLite_Connection;
			}
			return SQLite_Connection;
		}

		/// <summary>
		/// 建立資料表按鈕
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonCreateDataTable(object sender, RoutedEventArgs e)
		{
			string ComdCreateTableTitle = @"CREATE TABLE GoBuyItMember (
	  主鍵										    INT,
			廠商編號									    STRING,
			廠商名稱									    STRING,
			訂單編號                                      STRING,     
			建立日期                                      STRING,
	  訂單狀態                                      STRING,
	  顧客                                          STRING,
	  會員										      STRING,
			名稱                                          STRING,
	  產品SKU                                       STRING,
	  產品                                          STRING,
	  產品數量                                      INT,
	  [數量(單品/組合/任選)]            		      INT,
	  單價                                          DOUBLE,
	  小計                                          DOUBLE,
	  [訂單金額(不含金/物流手續費)] 				     DOUBLE,
	  訂單金流手續費                                DOUBLE,
	  訂單運費                                      DOUBLE,
	  總計金額                                      DOUBLE,
	  金流                                          STRING,
	  金流狀態                                      STRING,
	  金流備註                                      STRING,
	  物流                                          STRING,
	  物流狀態                                      STRING,
	  物流備註                                      STRING,
	  電話國碼                                      STRING,
	  顧客電話                                      STRING,
	  顧客性別                                      STRING,
	  顧客信箱                                      STRING,
	  運送地址                                      STRING,
	  方便收貨時間                                  STRING,
	  運送超商                                      STRING,
	  [超商寄貨編號(拋單後取得)]   				     STRING,
	  超商代號                                      STRING,
	  顧客備註                                      STRING,
	  商家備註                                      STRING,
	  物流追蹤                                      STRING,
	  發票                                          STRING,
	  IP                                            STRING,
	  FB名稱                                        STRING,
	  標籤                                          STRING,
	  信用卡末四碼                                  STRING,
	  託運單號                                      STRING,
	  匯款末五碼                                    STRING,
	  匯款時間                                      STRING,
	  顧客留言                                      STRING
	   );";
			if (File.Exists(DataBasePath))
			{
				//開啟連線
				if (SQLite_Connection.State == ConnectionState.Closed)
					SQLite_Connection.Open();
				//先確認資料表存在
				string cmdCheckTable = "SELECT COUNT(*) FROM sqlite_master where type='table' and name='GoBuyItMember'";
				SQLite_Command = new SQLiteCommand(cmdCheckTable, SQLite_Connection);
				//如果不存在就建立
				if (Convert.ToInt32(SQLite_Command.ExecuteScalar()) == 0)
					CreateDataTable(DataBasePath, ComdCreateTableTitle);
			}

		}
		/// <summary>
		/// 建立資料表
		/// </summary>
		/// <param name="database"></param>
		/// <param name="CreateTableString"></param>
		private void CreateDataTable(string database, string CreateTableString)
		{
			SQLite_Command = new SQLiteCommand(CreateTableString, SQLite_Connection);
			SQLiteTransaction mySqlTransaction = SQLite_Connection.BeginTransaction();
			try
			{
				SQLite_Command.Transaction = mySqlTransaction;
				SQLite_Command.ExecuteNonQuery();
				mySqlTransaction.Commit();
			}
			catch (Exception ex)
			{
				mySqlTransaction.Rollback();
				throw (ex);
			}
			if (SQLite_Connection.State == ConnectionState.Open)
				SQLite_Connection.Close();
		}

		public ICommand ExecuteClickCommand
		{
			get { return new DelegateCommand(ImportOderClick, CanCommand); }
		}

		private void ImportOderClick()
		{
			//string OrderListPath = @"Order/order_2020_05_16_09_52_57.csv";
			// string MemberListPath = @"MemberList/方氏果乾會員.csv";
			string OrderListPath = @"D:\C#\DummyFile\order_2020_05_16_09_52_57.csv";
			string MemberListPath = @"D:\C#\DummyFile\mm.csv";
			FileProcessing.CsvTrans2Json<BaseTitle>(OrderListPath, out loadOrderViewList);
			FileProcessing.CsvTrans2Json<MemberListTitle>(MemberListPath, out List<MemberListTitle> MemberList);

			OrderViewList.Clear();

			loadOrderViewList.ForEach(Order =>
			{
				MemberList.ForEach(s =>
				{
					if (Order.CustomerName == s.RealName && Order.CustomerEmail == s.Email)
						Order.Membership = "V";
				});
				Order.OwnerName = "方氏果乾";
				Order.OwnerNumber = "F00001";
			});

			//篩選統計欄位
			loadOrderViewList.ForEach(s =>
			{
				bool IsValidOrderNumber = true;

				s.OrderNumber.ToList().ForEach(ch => {
					if (!char.IsDigit(ch) && !char.IsLetter(ch))//是否为数字//是否为字母
						IsValidOrderNumber = false;
				});
				if(IsValidOrderNumber)
					OrderViewList.Add(new OrderView(s));
			});
		}


		public ICommand SearchClickCommand
		{
			get { return new DelegateCommand(SearchClick, CanCommand); }
		}

		private void SearchClick()
		{
			OrderViewList.Clear();

			if (this.membership)
			{
				loadOrderViewList.ForEach(s =>
				{
					//if(s.CustomerName==this.customerName)
					if (s.Membership == "V")
						OrderViewList.Add(new OrderView(s));
				}
				);
			}
			else
				loadOrderViewList.ForEach(s => { OrderViewList.Add(new OrderView(s)); });
		
		}

		public ICommand ExportPDFClickCommand
		{
			get { return new DelegateCommand(ExportPDFClick, CanCommand); }
		}

		/// <summary>
		/// 輸出PDF
		/// </summary>
		private void ExportPDFClick()
		{
			Dictionary<string, List<OrderView>> IndividualList = new Dictionary<string, List<OrderView>>();
			
			OrderViewList.ToList().ForEach(s => {
				
				if (IndividualList.ContainsKey(s.OrderNumber))
					IndividualList[s.OrderNumber].Add(s);
				else
					IndividualList.Add(s.OrderNumber, new List<OrderView>() {s});
			});

			PDFTool.ExportIndividualList(IndividualList,false);

			//PDFTool.ExportListPDF(new List<OrderView>(OrderViewList.ToList()), @"D:\C#\20200706.pdf");
			//OrderViewList;
		}
		public ICommand TextChangedEvent
		{
			get { return new RelayCommand(TextChanged, RelayCommand.CanExecuteMethod); }
		}
		private void TextChanged(object parameter)
		{
			TextBox tb = parameter as TextBox;
			this.customerName = tb.Text;
		}

		public ICommand CheckBoxEvent
		{
			get { return new RelayCommand(CheckBoxChanged, RelayCommand.CanExecuteMethod); }
		}
		private void CheckBoxChanged(object parameter)
		{
			CheckBox cb = parameter as CheckBox;
			if (cb.IsChecked == true)
				this.membership = true;
			else
				this.membership = false;

		}
		private bool CanCommand()
		{
			return true;
		}
	}
}
