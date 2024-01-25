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
    /// Логика взаимодействия для AccountingPeriodPage.xaml
    /// </summary>
    public partial class AccountingPeriodPage : Page
    {
        public AccountingPeriodPage()
        {
            InitializeComponent();
        }
       
            
        

        private void AddAccountingBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
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

            var a = (DateTime)ChoiceBeginningDP.SelectedDate;
            var b = (DateTime)ChoiceEndDP.SelectedDate;

            var qwery = App.context.View_1.
                Where(x => x.Datelspol >= a && x.Datelspol <= b). //
                GroupBy(y => y.Name). //Группируем
                Select(g => new { Сотрудник = g.Key, Сумма = g.Sum(s => s.Summa) }). //Устанавливаем
                OrderBy(n => n.Сотрудник); //Обьявляем

            AccDG.ItemsSource = qwery.ToList();
        }
    }
}
