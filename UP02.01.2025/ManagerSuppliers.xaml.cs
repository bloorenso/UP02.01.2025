using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для ManagerSuppliers.xaml
    /// </summary>
    public partial class ManagerSuppliers : Window
    {
        DataSet2 dataSet = new DataSet2();
        SupplierTableAdapter supplier_SupplierAdapter = new SupplierTableAdapter();

        public int IDSup { get; set; }
        public string NameCompany { get; set; }
        public string PersonContact { get; set; }
        public string Phone { get; set; }

        public ManagerSuppliers()
        {
            InitializeComponent();
            supplier_SupplierAdapter.Fill(dataSet.Supplier);
            dataGrid.ItemsSource = dataSet.Supplier.DefaultView;
            dataGrid.SelectedValuePath = "ID_Supplier";
            dataGrid.CanUserAddRows = false;
            dataGrid.CanUserDeleteRows = false;
            dataGrid.SelectionMode = DataGridSelectionMode.Single;

        }
        //public void Table()
        //{
        //    var dateView = from DataRow row in dataSet.Supplier.Rows
        //                   select new
        //                   {
        //                       SupplierID = row.Field<int>("SupplierID"),
        //                       CompanyName = row.Field<string>("CompanyName"),
        //                       ContactPerson = row.Field<string>("ContactPerson"),
        //                       Phone = row.Field<string>("Phone"),
        //                   };
        //    dataGrid.ItemsSource = dateView;
        //    DataRowView selectedRow = dataGrid.SelectedItem as DataRowView;
        //    if (selectedRow != null)
        //    {
        //        IDSup = Convert.ToInt32(selectedRow["SupplierID"].ToString());
        //        NameCompany = Convert.ToString(selectedRow["CompanyName"].ToString());
        //        PersonContact = Convert.ToString(selectedRow["ContactPerson"].ToString());
        //        Phone = Convert.ToString(selectedRow["Phone"].ToString());
            

        private void Suppliers_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Sells_Click(object sender, RoutedEventArgs e)
        {
           ManagerSells manager = new ManagerSells();
           manager.Show();
           Hide();
        }
        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            ManagerReports manager = new ManagerReports();
            manager.Show();
            Hide();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //DataRowView row = dataGrid.SelectedItem as DataRowView;
            //string id1 = row[0].ToString();
            supplier_SupplierAdapter.Insert("","","");
            supplier_SupplierAdapter.Fill(dataSet.Supplier);
           
            //int id2 = int.Parse(id1);
            //int column;
            //do
            //{
            //    id2++;
            //    column = id2;
            //}
            //while (id2!=null);
            //int newId = column;
            //dataGrid.Items.Add(newId);
            //DataRowView row = dataGrid.SelectedItem as DataRowView;

            //string id = row[0].ToString();

            //var grid = (List<SupplierTableAdapter>)dataGrid.ItemsSource;
            ////grid.Add()
            //var newItem = new Supplier
            //{
            //    Suppler = grid.Count > 0 ? grid.Max(item => item.Id)
            //};
            ////var newItem = new int
            ////{
            ////    Id=grid.Count>0? items
            ////}

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }
        private void LoadData(int id, string company, string contact, string phone)
        {

        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow manager = new MainWindow();
            manager.Show();
            Hide();
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;


            string id = row[0].ToString();
            string company = row[1].ToString();
            string sup = row[2].ToString();
            string phone = row[3].ToString();
            EditSupplier editSupplier = new EditSupplier(id, company, sup, phone);
            editSupplier.Owner = this;
            //this.IsEnabled = false;
            editSupplier.ShowDialog();
            //    Window supupdateWindow = new Window();
            //    {
            //        Title = "Редактирование сотрудника";
            //        Width = 300;
            //        Height = 200;
            //        WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //    };

            //    StackPanel stackPanel = new StackPanel();

            //    TextBlock idsup = new TextBlock();
            //    TextBox company1 = new TextBox();
            //    TextBox contact1 = new TextBox();
            //    TextBox phone1 = new TextBox();
            //    Button Cancel = new Button() { Content = "Отменить"};
            //    Button Enter = new Button() {Content ="Подтвердить" };

            //    Enter.Click += (s, args) =>
            //    {
            //        if (company1.Text != "" && contact1.Text != "" && phone1.Text != "")
            //        {
            //            int id = Convert.ToInt32(idsup.Text);
            //            string company1 = NameCompany;
            //            string contact1 = PersonContact;
            //            string phone1 = Phone;
            //            LoadData(id, company1, contact1, phone1);
            //            supupdateWindow.Close();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Пожалуйста введите все данные.");
            //        }
            //    };
            //    Cancel.Click += (s, args) =>
            //    {
            //         supupdateWindow.Close();
            //    };

            //    stackPanel.Children.Add(new TextBlock { Text="Редактировать поставщика" });
            //    stackPanel.Children.Add(idsup);
            //    stackPanel.Children.Add(new TextBlock { Text = "Наименование компании" });
            //    stackPanel.Children.Add(company1);
            //    stackPanel.Children.Add(new TextBlock { Text = "Контактное лицо" });
            //    stackPanel.Children.Add(contact1);
            //    stackPanel.Children.Add(new TextBlock { Text = "Номер телефона" });
            //    stackPanel.Children.Add(phone1);
            //    stackPanel.Children.Add(Cancel);
            //    stackPanel.Children.Add(Enter);


            //    supupdateWindow.Content = stackPanel;
            //    supupdateWindow.ShowDialog();



            //
        }
        private void OpenEdit(string id, string company,string contact,string phone)
        {

        }
        private void DataGridRow_MouseRightButtonClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            if (dataGrid.SelectedItem!=null)
            {
                try
                {
                    int id = Convert.ToInt32(row[0].ToString());
                    supplier_SupplierAdapter.DeleteQuery(id);
                    row.Delete();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
                      //supplier_SupplierAdapter.DeleteQuery((int)dataGrid.SelectedValue);
        }
    }
}