using Microsoft.Identity.Client;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UP02._01._2025.DataSet2TableAdapters;

namespace UP02._01._2025
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataSet2 dataSet = new DataSet2();
        AccountTableAdapter accountTableAdapter = new AccountTableAdapter();
        Role_TableAdapter role_TableAdapter = new Role_TableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            accountTableAdapter.Fill(dataSet.Account);        
        }
        public void Auth_Click(object sender, RoutedEventArgs e)
        {
            string username = Log.Text;
            string password = Passwd.Text;
            DataTable table = dataSet.Tables["Account"];
            DataRow[] foundRows = table.Select($"Username='{username}' AND Password_ = '{password}'");
            if (foundRows.Length>0)
            {
                string role = foundRows[0]["RoleID"].ToString();
                if(role == "2")
                {
                    ManagerSuppliers managerSuppliers = new ManagerSuppliers();
                    managerSuppliers.Show();
                    this.Close();
                }
                else if(role=="3")
                {
                    SellerGoods sellerGoods = new SellerGoods();
                    sellerGoods.Show();
                    this.Close();
                }
            }
            else if (username=="Почта" || password =="Пароль" )
            {
                MessageBox.Show("Введите имя пользователя и пароль.");
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
         }

    }
}