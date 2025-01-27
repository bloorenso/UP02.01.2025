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

namespace UP02._01._2025
{
    /// <summary>
    /// Логика взаимодействия для SellerOrders.xaml
    /// </summary>
    public partial class SellerOrders : Window
    {
        public SellerOrders()
        {
            InitializeComponent();
        }
        private void Goods_Click(object sender, RoutedEventArgs e)
        {
            SellerGoods admin = new SellerGoods();
            admin.Show();
            Hide();
        }
        private void Orders_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Cards_Click(object sender, RoutedEventArgs e)
        {
            SellerCards admin = new SellerCards();
            admin.Show();
            Hide();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow admin = new MainWindow();
            admin.Show();
            Hide();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
