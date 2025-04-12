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
    /// Логика взаимодействия для PageAuto.xaml
    /// </summary>
    public partial class PageAuto : Page
    {
        public PageAuto()
        {
            InitializeComponent();
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
                var _sel = ClassDB.connection.Doctor.Where(z => z.login == txbLogin.Text && z.password == txbPassword.Text).FirstOrDefault();
                if (_sel != null)
                {
                    NavigationService.Navigate(new Pages.PageList());
                }
                else
                {
                    MessageBox.Show("Пользователь не найденю");
                }
        }
    }
}
