using Microsoft.EntityFrameworkCore.Infrastructure;
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
    /// Логика взаимодействия для ManagerReports.xaml
    /// </summary>
    public partial class ManagerReports : Window
    {
        DataSet2 dataSet = new DataSet2();
        ProductTableAdapter product_ProductAdapter = new ProductTableAdapter();
        StoreTableAdapter table_StoreAdapter = new StoreTableAdapter();
        Order_TableAdapter order_TableAdapter = new Order_TableAdapter();
        int lowStockThreshold = 10;
        int m,n;
        DateTime startDate;
        DateTime endDate;
        public ManagerReports()
        {
            InitializeComponent();
            product_ProductAdapter.Fill(dataSet.Product);
            table_StoreAdapter.Fill(dataSet.Store);
            order_TableAdapter.Fill(dataSet.Order_);

            dataGrid.ItemsSource = dataSet.Product.DefaultView;
            dataGrid.SelectedValuePath = "ProductID";
            dataGrid.CanUserAddRows = false;
            dataGrid.CanUserDeleteRows = false;
            dataGrid.SelectionMode = DataGridSelectionMode.Single;

            var dateView = from DataRow row in dataSet.Product.Rows
                          select new
                           {
                               ProductID = row.Field<int>("ProductID"),
                               ProductName = row.Field<string>("ProductName"),
                               AuthorID = row.Field<int>("AuthorID"),
                               GenreID = row.Field<int>("GenreID"),
                               UnitPrice = row.Field<decimal>("UnitPrice"),
                               StockQuantity = row.Field<int>("StockQuantity"),
                               ArrivalDate = row.Field<DateTime>("ArrivalDate")
                           };
            dataGrid.ItemsSource = dateView;

            Store.ItemsSource = dataSet.Store.DefaultView;
            Store.DisplayMemberPath = "StoreName";
            Store.SelectedValuePath = "StoreID";
            Store.SelectedIndex = 0;
        }
        private void Suppliers_Click(object sender, RoutedEventArgs e)
        {
            ManagerSuppliers manager = new ManagerSuppliers();
            manager.Show();
            Hide();
        }
        private void Sells_Click(object sender, RoutedEventArgs e)
        {
            ManagerSells manager = new ManagerSells();
            manager.Show();
            Hide();
        }
        private void Reports_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SelectDates_Click(object sender, RoutedEventArgs e)
        {
            // Создаем окно для выбора дат
            Window dateSelectionWindow = new Window
            {
                Title = "Выбор дат",
                Width = 300,
                Height = 200,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            StackPanel stackPanel = new StackPanel();

            DatePicker startDatePicker = new DatePicker();
            DatePicker endDatePicker = new DatePicker();
            Button confirmButton = new Button { Content = "Подтвердить" };

            confirmButton.Click += (s, args) =>
            {
                DateTime? startDate = startDatePicker.SelectedDate;
                DateTime? endDate = endDatePicker.SelectedDate;

                if (startDate.HasValue && endDate.HasValue)
                {
                    SelectedDatesText.Text = $"Начальная дата: {startDate.Value.ToShortDateString()}, Конечная дата: {endDate.Value.ToShortDateString()}";
                    dateSelectionWindow.Close();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите обе даты.");
                }
            };

            stackPanel.Children.Add(new TextBlock { Text = "Выберите начальную дату:" });
            stackPanel.Children.Add(startDatePicker);
            stackPanel.Children.Add(new TextBlock { Text = "Выберите конечную дату:" });
            stackPanel.Children.Add(endDatePicker);
            stackPanel.Children.Add(confirmButton);
      
            dateSelectionWindow.Content = stackPanel;
            dateSelectionWindow.ShowDialog();

            startDate = startDatePicker.SelectedDate.Value;
            endDate = endDatePicker.SelectedDate.Value;
            if (Minus.IsChecked ==true )
            {
                All.IsChecked = true;
                dataGrid.ItemsSource = dataSet.Product.DefaultView;
                dataGrid.SelectedValuePath = "ProductID";
                dataGrid.CanUserAddRows = false;
                dataGrid.CanUserDeleteRows = false;
                dataGrid.SelectionMode = DataGridSelectionMode.Single;


            }
            else
            {
                
                m = 5;
            }
            
                var dateView = from DataRow row in dataSet.Product.Rows
                           where
                           row.Field<DateTime>("ArrivalDate") >= startDate
                           && row.Field<DateTime>("ArrivalDate") <=
                           endDate
                               select new
                               {
                                   ProductID = row.Field<int>("ProductID"),
                                   ProductName = row.Field<string>("ProductName"),
                                   AuthorID = row.Field<int>("AuthorID"),
                                   GenreID = row.Field<int>("GenreID"),
                                   UnitPrice = row.Field<decimal>("UnitPrice"),
                                   StockQuantity = row.Field<int>("StockQuantity"),
                                   ArrivalDate = row.Field<DateTime>("ArrivalDate")
                               };

            dataGrid.ItemsSource = dateView;
            if (n==5)
            {
                var lowStockView = from DataRow row in dataSet.Product.Rows
                                   where
                                   row.Field<int>("StockQuantity") <= lowStockThreshold &&
                                   row.Field<DateTime>("ArrivalDate") >= startDate
                                   && row.Field<DateTime>("ArrivalDate") <=
                                   endDate
                                   select new
                                   {
                                       ProductID = row.Field<int>("ProductID"),
                                       ProductName = row.Field<string>("ProductName"),
                                       AuthorID = row.Field<int>("AuthorID"),
                                       GenreID = row.Field<int>("GenreID"),
                                       UnitPrice = row.Field<decimal>("UnitPrice"),
                                       StockQuantity = row.Field<int>("StockQuantity"),
                                       ArrivalDate = row.Field<DateTime>("ArrivalDate")
                                   };
                dataGrid.ItemsSource = lowStockView;
                Minus.IsChecked = true;
                TxtView.Text = "Товары с низким остатком";
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow manager = new MainWindow();
            manager.Show();
            Hide();
        }
        private void All_Click(object sender, RoutedEventArgs e)
        {
            if (All.IsChecked==true)
            {
                SelectedDatesText.Text = "";
            }

                dataGrid.ItemsSource = dataSet.Product.DefaultView;
                dataGrid.SelectedValuePath = "ProductID";
                dataGrid.CanUserAddRows = false;
                dataGrid.CanUserDeleteRows = false;
                dataGrid.SelectionMode = DataGridSelectionMode.Single;

                SelectedDatesText.Text="";
                m = 0;

            var dateView = from DataRow row in dataSet.Product.Rows
                           select new
                           {
                               ProductID = row.Field<int>("ProductID"),
                               ProductName = row.Field<string>("ProductName"),
                               AuthorID = row.Field<int>("AuthorID"),
                               GenreID = row.Field<int>("GenreID"),
                               UnitPrice = row.Field<decimal>("UnitPrice"),
                               StockQuantity = row.Field<int>("StockQuantity"),
                               ArrivalDate = row.Field<DateTime>("ArrivalDate")
                           };
            dataGrid.ItemsSource = dateView;
        }
        private void Pop_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (m == 5)
            {
                if (Minus.IsChecked == true)
                {
               
                    var lowStockView = from DataRow row in dataSet.Product.Rows
                                       where
                                       row.Field<int>("StockQuantity") <= lowStockThreshold &&
                                       row.Field<DateTime>("ArrivalDate") >= startDate
                                       && row.Field<DateTime>("ArrivalDate") <=
                                       endDate
                                       select new
                                       {
                                           ProductID = row.Field<int>("ProductID"),
                                           ProductName = row.Field<string>("ProductName"),
                                           AuthorID = row.Field<int>("AuthorID"),
                                           GenreID = row.Field<int>("GenreID"),
                                           UnitPrice = row.Field<decimal>("UnitPrice"),
                                           StockQuantity = row.Field<int>("StockQuantity"),
                                           ArrivalDate = row.Field<DateTime>("ArrivalDate")
                                       };
                    dataGrid.ItemsSource = lowStockView;
                    n = 5;
                }
                else
                {

                }
            }
            else
            {



                if (Minus.IsChecked == true)
                {
                    int lowStockThreshold = 10;
                    var lowStockView = from DataRow row in dataSet.Product.Rows
                                       where
                                       row.Field<int>("StockQuantity") <= lowStockThreshold
                                       select new
                                       {
                                           ProductID = row.Field<int>("ProductID"),
                                           ProductName = row.Field<string>("ProductName"),
                                           AuthorID = row.Field<int>("AuthorID"),
                                           GenreID = row.Field<int>("GenreID"),
                                           UnitPrice = row.Field<decimal>("UnitPrice"),
                                           StockQuantity = row.Field<int>("StockQuantity"),
                                           ArrivalDate = row.Field<DateTime>("ArrivalDate")
                                       };
                    dataGrid.ItemsSource = lowStockView;
             
                }
                else
                {

                }
            }
        }
            private void All_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if(radioButton!=null)
            {
                TxtView.Text = "Общая информация";
            }
        }
        private void Pop_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                TxtView.Text = "Популярное";
            }
        }

        private void Store_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



            //var store = from product in dataSet.Product.AsEnumerable()
            //            join order in dataSet.Order_.AsEnumerable()
            //            on product.Field<int>("ProductID") equals order.Field<int>("ProductID")
            //            select new
            //            {
            //                ProductID = product.Field<int>("ProductID"),
            //                ProductName = product.Field<string>("ProductName"),
            //                AuthorID = product.Field<int>("AuthorID"),
            //                GenreID = product.Field<int>("GenreID"),
            //                UnitPrice = product.Field<decimal>("UnitPrice"),
            //                StockQuantity = product.Field<int>("StockQuantity"),
            //                ArrivalDate = product.Field<DateTime>("ArrivalDate")
            //            };


            //dataGrid.ItemsSource = store.ToList();


        }

        private void Minus_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                TxtView.Text = "Товары с низким остатком";
            }
        }
    }

}
