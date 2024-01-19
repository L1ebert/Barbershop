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
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if(NameEmployeeTb.Text == "")
            {
                mes = "Введите имя сотрудника";
                MessageBox.Show(mes);
                return;
            }
            else
            {
                Employee employee = new Employee
                {
                    Name = NameEmployeeTb.Text
                };
                App.context.Employee.Add(employee);
                App.context.SaveChanges();
                MessageBox.Show("Сотрудник добавлен");

                NameEmployeeTb.Text = "";
            }
        }
    }
}
