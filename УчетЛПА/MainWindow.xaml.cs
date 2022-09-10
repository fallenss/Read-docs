using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace УчетЛПА
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ДипломEntities dataEntities = new ДипломEntities();
        public MainWindow()
        {
            InitializeComponent();
            Window_Loaded();
            DataContext = dataEntities;
            ComboTdel.SelectedIndex = 0;
            var CurrentLPA = ДипломEntities.GetContext().ЛПА.ToList();
            LViewLPA.ItemsSource = CurrentLPA;
        }
        private void Window_Loaded()
        {
            

        }




        private void LViewLPA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (LViewLPA.SelectedItem == null) return;
                ЛПА SelectedLPA = LViewLPA.SelectedItem as ЛПА;
                string name = SelectedLPA.Наимемнование;
                info.id_lpa = SelectedLPA.ID;
                try
                {
                    // Запускаем нужный файл
                    string pathToFile = @"C:\Windows\ЛПА\" + name + ".docx";
                    System.Diagnostics.Process.Start(pathToFile);

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
                Ознакомление NewIntroduction = new Ознакомление
                {
                    Дата_время = DateTime.Today,
                    id_сотрудника = info.id_user,
                    id_ЛПА = info.id_lpa
                };
                ДипломEntities.GetContext().Ознакомление.Add(NewIntroduction);
                ДипломEntities.GetContext().SaveChanges();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Критическая ошибка!");
            }
        }

        private void Findless()
        {
            try
            {
                var ResOfSearch = ДипломEntities.GetContext().ЛПА.ToList();

                if (ComboTdel.SelectedIndex > 0)
                {
                    ResOfSearch = ResOfSearch.Where(p => p.id_отдела == ComboTdel.SelectedIndex).ToList();
                }

                ResOfSearch = ResOfSearch.Where(p => p.Наимемнование.ToLower().Contains(Find.Text.ToLower())).ToList();

                LViewLPA.ItemsSource = ResOfSearch;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Критическая ошибка!");
            }
        }

        private void Find_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Find.Text != "Поиск по названию:")
            {
                Findless();
            }
        }

        private void ComboGenre_GotFocus(object sender, RoutedEventArgs e)
        {
            Findless();
        }

        private bool IsToggle;
        private void Find_GotFocus(object sender, RoutedEventArgs e)
        {
   
        }

        private void Find_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            if (!IsToggle)
            {
                Thickness margin = Find.Margin;
                margin.Right += 1300;
                this.Find.BeginAnimation(FrameworkElement.MarginProperty, new ThicknessAnimation(margin, TimeSpan.FromSeconds(0.10)));
                IsToggle = true;
            }
            else
            {
                Thickness margin = Find.Margin;
                margin.Right -= 1300;
                this.Find.BeginAnimation(FrameworkElement.MarginProperty, new ThicknessAnimation(margin, TimeSpan.FromSeconds(0.2)));
                IsToggle = false;
            }
        }

        private void ComboRating_GotFocus(object sender, RoutedEventArgs e)
        {
            Findless();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Вход NewWindow = new Вход();
            NewWindow.Show();
            Close();
        }

        private void Spravka_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Запускаем нужный файл
                string pathToFile = @"C:\Windows\ЛПА\" + "help.chm";

                System.Diagnostics.Process.Start(pathToFile);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Ошибка!");
            }
        }
    }
}
