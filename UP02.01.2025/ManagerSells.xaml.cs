using System;
using System.Collections.Generic;
using System.Data;
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
using UP02._01._2025.DataSet2TableAdapters;

namespace UP02._01._2025
{
    /// <summary>
    /// Логика взаимодействия для ManagerSells.xaml
    /// </summary>
    public partial class ManagerSells : Window
    {
        DataSet2 dataSet = new DataSet2();
        Order_TableAdapter order_TableAdapter = new Order_TableAdapter();
        ProductTableAdapter productTableAdapter = new ProductTableAdapter();
        StoreTableAdapter storeTableAdapter = new StoreTableAdapter();
        DiscountCardTableAdapter discountCardTableAdapter = new DiscountCardTableAdapter();
        PaymentMethodTableAdapter paymentMethodTableAdapter = new PaymentMethodTableAdapter();

        public ManagerSells()
        {
            InitializeComponent();
            order_TableAdapter.Fill(dataSet.Order_);
            productTableAdapter.Fill(dataSet.Product);
            storeTableAdapter.Fill(dataSet.Store);
            discountCardTableAdapter.Fill(dataSet.DiscountCard);
            paymentMethodTableAdapter.Fill(dataSet.PaymentMethod);

//            var dateView = from order in dataSet.Order_.AsEnumerable()
//                           join product in dataSet.Product.AsEnumerable()
//                           on order.Field<int>("OrderID") equals product.Field<int>("ProductID")
//                           join store in dataSet.Store.AsEnumerable()
//on order.Field<int>("OrderID") equals store.Field<int>("StoreID")
//                           join card in dataSet.DiscountCard.AsEnumerable()
//                           on order.Field<int>("OrderID") equals card.Field<int>("DiscountCardID")
//                           join method in dataSet.PaymentMethod.AsEnumerable()
//on order.Field<int>("OrderID") equals method.Field<int>("PaymentMethodID")

//                           select new
//                           {
//                               OrderID = order.Field<int>("OrderID"),
//                               OrderDate = order.Field<DateTime>("OrderDate"),
//                               ProductID = order.Field<int>("ProductID"),
//                               ProductName = product.Field<string>("ProductName"),
//                               Quantity = order.Field<int>("Quantity"),
//                               StoreID = order.Field<int>("StoreID"),
//                               StoreName = store.Field<string>("StoreName"),
//                               DiscountCardID = order.Field<int>("DiscountCardID"),
//                               DiscountCardNumber = card.Field<string>("DiscountCardNumber"),
//                               DiscountRate = card.Field<decimal>("DiscountRate"),
//                               PaymentMethod = order.Field<int>("PaymentMethodID"),
//                               TotalAmount = order.Field<decimal>("TotalAmount")
//                           };

            //DataRelation relation = new DataRelation("Order_ProductDetails", dataSet.Tables["Order_"].Columns["OrderID"],
            //    dataSet.Tables["Product"].Columns["ProductID"]);
            //dataSet.Relations.Add(relation);
            //dataSet.Merge(dataSet.Order_,dataSet.Product);


            //dataGrid.ItemsSource = dateView;

            dataGrid.ItemsSource = dataSet.Order_.DefaultView;
            dataGrid.SelectedValuePath = "ID_Order";
            dataGrid.CanUserAddRows = false;
            dataGrid.CanUserDeleteRows = false;

            dataGrid.SelectionMode = DataGridSelectionMode.Single;

            
            
        }
        private void Suppliers_Click(object sender, RoutedEventArgs e)
        {
            ManagerSuppliers manager = new ManagerSuppliers();
            manager.Show();
            Hide();
        }
        private void Sells_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            ManagerReports manager = new ManagerReports();
            manager.Show();
            Hide();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            order_TableAdapter.Insert(DateTime.Today, 1,0,1,1,1,0);
            order_TableAdapter.Fill(dataSet.Order_);

           

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow manager = new MainWindow();
            manager.Show();
            Hide();
        }
        private void DataGridRow_MouseRightButtonClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            if (dataGrid.SelectedItem != null)
            {
                try
                {
                    int id = Convert.ToInt32(row[0].ToString());
                    order_TableAdapter.DeleteQuery(id);
                    row.Delete();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            //supplier_SupplierAdapter.DeleteQuery((int)dataGrid.SelectedValue);
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("RowClick");
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            

            string orderId = row[1].ToString();
            string orderDate = row[1].ToString();
            string product = row[2].ToString();
            string quantity = row[3].ToString();
            string store = row[4].ToString();
            string discountCard = row[5].ToString();
            string paymentMethod = row[6].ToString();
            string totalAmount = row[7].ToString();
            EditOrder editOrder = new EditOrder(orderId, orderDate, product, quantity, store, discountCard, paymentMethod, totalAmount);
            editOrder.Owner = this;
            //this.IsEnabled = false;
            editOrder.ShowDialog();
        }
    }
}
