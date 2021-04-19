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
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public PageMain()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAdd());
        }

        private void btnedit_Click(object sender, RoutedEventArgs e)
        {
            WorkingWithAnimals editrow = (WorkingWithAnimals)MainGrid.SelectedItem;
            if (editrow != null)
            {
                NavigationService.Navigate(new PageEdit(editrow));
            }
        }

        
            private void exitbtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void tbsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainGrid.ItemsSource = dbclass.db.WorkingWithAnimals.Where(item => item.Animals.Kind.Contains(tbsearch.Text) || item.Employees.FullName.Contains(tbsearch.Text)).ToList();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MainGrid.ItemsSource = dbclass.db.WorkingWithAnimals.ToList();
        }

        private void btndelete_Click_1(object sender, RoutedEventArgs e)
        {
            WorkingWithAnimals deleterow = (WorkingWithAnimals)MainGrid.SelectedItem;
            if (MessageBox.Show("Вы точно хотите удалить выбранный элемент?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (deleterow != null)
                {
                    dbclass.db.WorkingWithAnimals.Remove(deleterow);
                    dbclass.db.SaveChanges();
                    Page_Loaded(null, null);
                    MessageBox.Show("Вы удалили данные", "Увдомление");
                }

                else
                {
                    MessageBox.Show("Вы не выбрали элемент для удаления", "Увдомление");

                }
            }
        }


        private void MainGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
