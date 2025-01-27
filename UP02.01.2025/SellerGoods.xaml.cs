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
    /// Логика взаимодействия для SellerGoods.xaml
    /// </summary>
    public partial class SellerGoods : Window
    {
        public SellerGoods()
        {
            InitializeComponent();
        }
        private void Goods_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            SellerOrders admin = new SellerOrders();
            admin.Show();
            Hide();
        }
        private void Cards_Click(object sender, RoutedEventArgs e)
        {
            SellerCards admin = new SellerCards();
            admin.Show();
            Hide();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow admin = new MainWindow();
            admin.Show();
            Hide();
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
