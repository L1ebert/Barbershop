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
    /// Логика взаимодействия для PageAddManufacturer.xaml
    /// </summary>
    public partial class PageAddManufacturer : Page
    {
        public PageAddManufacturer()
        {
            InitializeComponent();
        }

        private void AddManufacturerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NameManufacturerTb.Text == "")
            {
                MessageBox.Show("Введите наименование производителя");
            }
            Manufacturer manufacturer = new Manufacturer
            {
                Name = NameManufacturerTb.Text
            };
            App.context.Manufacturer.Add(manufacturer);
            App.context.SaveChanges();
            MessageBox.Show("Производитель добавлен");
            NameManufacturerTb.Text = "";
        }
    }
}
