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
    /// Логика взаимодействия для PageAddMaterial.xaml
    /// </summary>
    public partial class PageAddMaterial : Page
    {
        public PageAddMaterial()
        {
            InitializeComponent();
            ManufacturerCmb.SelectedValuePath = "ID";
            ManufacturerCmb.DisplayMemberPath = "Name";
            ManufacturerCmb.ItemsSource = App.context.Manufacturer.ToList();
        }

        private void AddMaterialBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NameMaterialTb.Text == "")
            {
                MessageBox.Show("Введите наименование продукта");
            }
            if (ManufacturerCmb.Text == "")
            {
                MessageBox.Show("Выберите производителя");
            }
            Material addmaterial = new Material
            {
                Name = NameMaterialTb.Text,
                Manufacturer = ManufacturerCmb.SelectedItem as Manufacturer
            };
            App.context.Material.Add(addmaterial);
            App.context.SaveChanges();
            MessageBox.Show("Продукт добавлен");
            NameMaterialTb.Text = "";
            ManufacturerCmb.Text = "";
        }
    }
}
