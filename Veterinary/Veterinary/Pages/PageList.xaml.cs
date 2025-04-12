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
using Veterinary.Database;

namespace Veterinary.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageList.xaml
    /// </summary>
    public partial class PageList : Page
    {
        public PageList()
        {
            InitializeComponent();
            this.DataContext = this;
            listRecept.ItemsSource = ClassDB.connection.Reception.Where(z => z.isDelete == false).ToList();
            var collect = ClassDB.connection.Reception.ToList();
            cmbSort.ItemsSource = collect;
            cmbSort.DisplayMemberPath = "date";
            this.DataContext = this;
        }

        //рабочий поиск по кличке
        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbSearch.Text != null)
            {
                listRecept.ItemsSource = ClassDB.connection.Reception.Where(z => z.Animals.name.Contains(txbSearch.Text)).ToList();
            }
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSort.SelectedIndex != 0)
            {
                //listRecept.ItemsSource = ClassDB.connection.Reception.Where(z => z.date == cmbSort.Text()).ToList(); //не работает
            }
        }

        private void btnAddReception_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.PageAdd());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //var select = (sender as Button).DataContext as Reception;
            //WinEdit win = new WinEdit(select);
            //win.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var scr = (sender as Button).DataContext as Reception;
            scr.isDelete = true;
            ClassDB.connection.SaveChanges();
            listRecept.ItemsSource = ClassDB.connection.Reception.Where(z => z.isDelete == false).ToList();
        }
    }
}
