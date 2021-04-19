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
using ZooWork.classbd;
using ZooWork.SQL;

namespace ZooWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAdd.xaml
    /// </summary>
    public partial class PageAdd : Page
    {
        public PageAdd()
        {
            InitializeComponent();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            tbNickname.Text = null;
            tbKind.Text = null;
            tbGender.Text = null;
            tbFullName.Text = null;
            tbGender.Text = null;
            tbPost.Text = null;
            tbExperience.Text = null;
            tbStartDate.Text = null;
        }

        private void addbuton_Click(object sender, RoutedEventArgs e)
        {

           
            Animals addAnimals = new Animals();
            Employees addEmployees = new Employees();
            WorkingWithAnimals addWork = new WorkingWithAnimals();


            addAnimals.Nickname = tbNickname.Text;
            addAnimals.Kind = tbKind.Text;
            addAnimals.Gender = tbGender.Text;

            addEmployees.FullName = tbFullName.Text;
            addEmployees.Post = tbPost.Text;
            addEmployees.Experience = tbExperience.Text;

            addWork.idAnimals = addAnimals.ID;
            addWork.idEmployees = addEmployees.ID;


            addWork.StartDate = tbStartDate.SelectedDate;

            dbclass.db.Animals.Add(addAnimals);
            dbclass.db.Employees.Add(addEmployees);
            dbclass.db.WorkingWithAnimals.Add(addWork);


            dbclass.db.SaveChanges();

            MessageBox.Show("Вы добавили данные", "Уведомление");


        }
    }
}
