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
    /// Логика взаимодействия для PageEdit.xaml
    /// </summary>
    public partial class PageEdit : Page
    {

        private WorkingWithAnimals editmain;
        public PageEdit()
        {
            InitializeComponent();
        }


        public PageEdit (WorkingWithAnimals editmain)
        {

            InitializeComponent();

            this.editmain = editmain;


           tbNickname.Text = editmain.Animals.Nickname;
           tbKind.Text = editmain.Animals.Kind;
           tbGender.Text = editmain.Animals.Gender;



            tbFullName.Text = editmain.Employees.FullName;
            tbPost.Text = editmain.Employees.Post;
            tbExperience.Text = editmain.Employees.Experience;


            tbStartDate.SelectedDate = (DateTime) editmain.StartDate;


        }


        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


        private void deletebutton_Click_1(object sender, RoutedEventArgs e)
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

        private void editbutton_Click(object sender, RoutedEventArgs e)
        {
            WorkingWithAnimals Save = dbclass.db.WorkingWithAnimals.FirstOrDefault(item => item.ID == editmain.ID);

            Save.Animals.Nickname = tbNickname.Text;
            Save.Animals.Kind = tbKind.Text;
            Save.Animals.Gender = tbGender.Text;

            Save.Employees.FullName = tbFullName.Text;
            Save.Employees.Post = tbPost.Text;
            Save.Employees.Experience = tbExperience.Text;

            Save.StartDate = tbStartDate.SelectedDate;



            dbclass.db.SaveChanges();

            MessageBox.Show("Вы изменили данные", "Уведомление");

            NavigationService.GoBack();

        }
    }
}
