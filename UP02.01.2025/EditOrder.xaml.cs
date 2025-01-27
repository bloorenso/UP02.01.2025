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
using static Azure.Core.HttpHeader;

namespace UP02._01._2025
{
    /// <summary>
    /// Логика взаимодействия для EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Window
    {
        DataSet2 dataSet = new DataSet2();
        Order_TableAdapter order_TableAdapter = new Order_TableAdapter();
        StoreTableAdapter storeTableAdapter = new StoreTableAdapter();
        PaymentMethodTableAdapter paymentMethodTableAdapter = new PaymentMethodTableAdapter();
        DiscountCardTableAdapter discountCardTableAdapter = new DiscountCardTableAdapter();
        ProductTableAdapter productTableAdapter = new ProductTableAdapter();
        public EditOrder(string orderId, string orderDate, string product, string quantity, string store, string discountCard, string paymentMethod,string totalAmount)
        {
            InitializeComponent();
            order_TableAdapter.Fill(dataSet.Order_);
            productTableAdapter.Fill(dataSet.Product);
            storeTableAdapter.Fill(dataSet.Store);
            paymentMethodTableAdapter.Fill(dataSet.PaymentMethod);
            discountCardTableAdapter.Fill(dataSet.DiscountCard);
            
            IdOrder.Text = orderId;
            OrderDate.Text = orderDate;
            IdProduct.Text = product;
            Quantity.Text = quantity;
            IdStore.Text = store;
            IdCard.Text = discountCard;
            IdMethod.Text = paymentMethod;
            Total.Text = totalAmount;

            NameProduct.ItemsSource = dataSet.Product.DefaultView;
            NameProduct.DisplayMemberPath = "ProductName";
            NameProduct.SelectedValuePath = "ProductID";
            NameProduct.SelectedIndex = Convert.ToInt32(product)-1;

            MethodPay.ItemsSource = dataSet.PaymentMethod.DefaultView;
            MethodPay.DisplayMemberPath = "PaymentMethod";
            MethodPay.SelectedValuePath = "PaymentMethodID";
            MethodPay.SelectedIndex = Convert.ToInt32(paymentMethod) - 1;

            NameStore.ItemsSource = dataSet.Store.DefaultView;
            NameStore.DisplayMemberPath = "StoreName";
            NameStore.SelectedValuePath = "StoreID";
            NameStore.SelectedIndex = Convert.ToInt32(store) - 1;

            DiscountCard.ItemsSource = dataSet.DiscountCard.DefaultView;
            DiscountCard.DisplayMemberPath = "DiscountCardNumber";
            DiscountCard.SelectedValuePath = "DiscountCardID";
            DiscountCard.SelectedIndex = Convert.ToInt32(discountCard) - 1;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(IdOrder.Text);
            string orderDate = OrderDate.Text;
            int product = Convert.ToInt32(IdProduct.Text);
            int quantity = Convert.ToInt32(Quantity.Text);
            int store = Convert.ToInt32(IdStore.Text);
            int discountCard = Convert.ToInt32(IdCard.Text);
            int paymentMethod = Convert.ToInt32(IdMethod.Text);
            decimal totalAmount = Convert.ToDecimal(Total.Text);
           
            order_TableAdapter.UpdateQuery(orderDate, product, quantity,store,discountCard,paymentMethod,totalAmount,id);
            ManagerSells manager = new ManagerSells();
            Owner.Hide();
            Hide();
            manager.Show();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NameProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = NameProduct.SelectedItem as DataRowView;

            string id1 = row[0].ToString();
            IdProduct.Text = id1;
        }

        private void MethodPay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = MethodPay.SelectedItem as DataRowView;

            string id1 = row[0].ToString();
            IdMethod.Text = id1;
        }
        private void NameStore_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = NameStore.SelectedItem as DataRowView;

            string id1 = row[0].ToString();
            IdStore.Text = id1;
        }

        private void DiscountCard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = DiscountCard.SelectedItem as DataRowView;

            string id1 = row[0].ToString();
            IdCard.Text = id1;
        }
    }
}