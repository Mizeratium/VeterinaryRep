using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Linq;
using Veterinary.Database;

namespace Veterinary.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAdd.xaml
    /// </summary>
    public partial class PageAdd : Page
    {
        Reception reception = new Reception();
        public PageAdd()
        {
            InitializeComponent();
            //комбобокс с именами врачей
            var doctors = ClassDB.connection.Doctor.ToList();
            cmbDoctor.ItemsSource = doctors;
            cmbDoctor.DisplayMemberPath = "FIO";
            //комбобокс с именами животных
            var animals = ClassDB.connection.Animals.ToList();
            cmbAnimal.ItemsSource = animals;
            cmbAnimal.DisplayMemberPath = "name";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cmbAnimal.SelectedItem != null && cmbDoctor.Text != null && txbDate.Text != "")
            {
                var _selAnimal = cmbAnimal.SelectedItem as Animals;
                var _selDoctor = cmbDoctor.SelectedItem as Doctor;
                reception.doctor_id = _selDoctor.ID;
                reception.animal_id = _selAnimal.ID;
                reception.date = Convert.ToDateTime(txbDate.Text);
                reception.isDelete = false;
                ClassDB.connection.Reception.Add(reception);
                ClassDB.connection.SaveChanges();
                MessageBox.Show("Запись прошла успешно");
                NavigationService.Navigate(new Pages.PageList());
            }
            else
            {
                MessageBox.Show("Студент не добавлен");
            }
        }
    }
}
