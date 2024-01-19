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
    /// Логика взаимодействия для PageAccounting.xaml
    /// </summary>
    public partial class PageAccounting : Page
    {
        public PageAccounting()
        {
            InitializeComponent();
            EmployeeCmb.SelectedValuePath = "ID";
            EmployeeCmb.DisplayMemberPath = "Name";
            EmployeeCmb.ItemsSource = App.context.Employee.ToList();
        }
        private void AccDG_Loaded(object sender, RoutedEventArgs e)
        {
            AccDG.ItemsSource = App.context.Accounting.ToList();
        }
        private void ChoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            //if (string.IsNullOrWhiteSpace(EmployeeCmb.Text))
            //    mes += "Выберите сотрудника";
            if (string.IsNullOrWhiteSpace(ChoiceBeginningDP.Text))
                mes += "Выберите начало даты\n";
            if (string.IsNullOrWhiteSpace(ChoiceEndDP.Text))
                mes += "Выберите конец даты\n";
            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
            Accounting accounting = new Accounting
            {

            };

            var a = (DateTime)ChoiceBeginningDP.SelectedDate;
            var b = (DateTime)ChoiceEndDP.SelectedDate;

            AccDG.ItemsSource = App.context.Accounting.Where(x => x.Datelspol >= a && x.Datelspol <= b).ToList();

            var summa = App.context.Accounting.Where(x => x.Datelspol >= a && x.Datelspol <= b).Select(g => g.Amount).Sum();

            AllSummTb.Text = Convert.ToString(summa);

            var count = App.context.Accounting.Where(x => x.Datelspol >= a && x.Datelspol <= b).Select(g => g.Quantity).Count();

            AllRecTb.Text = Convert.ToString(count);

        }
    }
}
