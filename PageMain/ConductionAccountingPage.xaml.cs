using Barbershop.Model;
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

namespace Barbershop.PageMain
{
    /// <summary>
    /// Логика взаимодействия для ConductionAccountingPage.xaml
    /// </summary>
    public partial class ConductionAccountingPage : Page
    {
        public ConductionAccountingPage()
        {
            InitializeComponent();
            EmployeeCmb.SelectedValuePath = "ID";
            EmployeeCmb.DisplayMemberPath = "Name";
            EmployeeCmb.ItemsSource = App.context.Employee.ToList();

            ManufacturerCmb.SelectedValuePath = "ID";
            ManufacturerCmb.DisplayMemberPath = "Name";
            ManufacturerCmb.ItemsSource = App.context.Manufacturer.ToList();

            MaterialCmb.SelectedValuePath = "ID";
            MaterialCmb.DisplayMemberPath = "Name";
            MaterialCmb.ItemsSource = App.context.Material.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(ChoiceDP.Text))
                mes += "Выберите дату\n";
            if (string.IsNullOrWhiteSpace(EmployeeCmb.Text))
                mes += "Выберите сотрудника\n";
            if (string.IsNullOrWhiteSpace(ManufacturerCmb.Text))
                mes += "Выберите производителя\n";
            if (string.IsNullOrWhiteSpace(MaterialCmb.Text))
                mes += "Выберите материал\n";
            if (string.IsNullOrWhiteSpace(CostTb.Text))
                mes += "Введите цену\n";
            if (string.IsNullOrWhiteSpace(AmountTb.Text))
                mes += "Введите количество\n";
            if(mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
            Accounting accounting = new Accounting
            {
                Datelspol = Convert.ToDateTime(ChoiceDP.Text),
                Employee = EmployeeCmb.SelectedItem as Employee,
                Material = MaterialCmb.SelectedItem as Material,
                Price = Convert.ToDecimal(CostTb.Text),
                Quantity = Convert.ToInt32(AmountTb.Text)
            };

            App.context.Accounting.Add(accounting);
            App.context.SaveChanges();
            MessageBox.Show("Учет добавлен!");

            EmployeeCmb.Text = "";
            ManufacturerCmb.Text = "";
            MaterialCmb.Text = "";
            AmountTb.Text = "";
            CostTb.Text = "";
        }

        private void ManufacturerCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedManufacturer = Convert.ToInt32(ManufacturerCmb.SelectedValue);
            MaterialCmb.ItemsSource = App.context.Material.Where(m => m.Manufacturer.ID == selectedManufacturer).ToList();
        }
    }
}