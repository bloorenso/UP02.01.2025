using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для EditSupplier.xaml
    /// </summary>
    public partial class EditSupplier : Window
    {
        DataSet2 dataSet = new DataSet2();
        SupplierTableAdapter supplierTableAdapter = new SupplierTableAdapter();
        public EditSupplier(string id, string company, string sup, string phone)
        {
            InitializeComponent();
            IdSup.Text = Convert.ToString(id);
            NameCompany.Text = company;
            NameSup.Text = sup;
            PhoneSup.Text = phone;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {

            //ManagerSuppliers manager = new ManagerSuppliers();
            ////manager.IsEnabled = true;
            Close();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(IdSup.Text);
            string company = NameCompany.Text;
            string sup = NameSup.Text;
            string phone = PhoneSup.Text;
            supplierTableAdapter.UpdateQuery(company, sup, phone,id);
            ManagerSuppliers manager = new ManagerSuppliers();
            Owner.Hide();
            Hide();
            manager.Show();
         }
           }
}
