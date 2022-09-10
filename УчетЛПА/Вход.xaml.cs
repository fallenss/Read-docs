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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace УчетЛПА
{
    

    /// <summary>
    /// Логика взаимодействия для Вход.xaml
    /// </summary>
    public partial class Вход : Window
    {

        public Вход()
        {
            InitializeComponent();
            ComboTdel.SelectedIndex = 0;
        }

        private void nic_TextChanged(object sender, TextChangedEventArgs e)
        {

        }




        private void pas_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        private void vhod_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bool temp = false;
                if (nic.Text == "" | pas.Password == "")
                {
                    vhod.ToolTip = "Заполните поля логин и пароль";
                }
                else
                {
                    bool res = false;


                    foreach (var item in ДипломEntities.GetContext().Сотрудники) //Берёт все строки из таблицы Пользователи
                    {
                        if (item.Никнейм == nic.Text & item.Пароль == pas.Password) // Ищет совпадения с текстбоксом и строкой в бд
                        {
                            res = true;
                        }

                        if (res == true) //Если оба совпадают открывает основную форму (Info это статик класс для передачи инфы между формами, необязателен)
                        {
                            temp = true;
                            MainWindow mainWindow = new MainWindow();
                            info.id_user = item.ID;
                            mainWindow.Show();
                            Close();
                            break;
                        }
                    }
                    if (temp == false)
                    {
                        foreach (var item in ДипломEntities.GetContext().Администраторы) //Берёт все строки из таблицы Пользователи
                        {
                            if (item.Никнейм == nic.Text & item.Пароль == pas.Password) // Ищет совпадения с текстбоксом и строкой в бд
                            {
                                res = true;
                            }

                            if (res == true) //Если оба совпадают открывает основную форму (Info это статик класс для передачи инфы между формами, необязателен)
                            {
                                temp = true;
                                MainWindow mainWindow = new MainWindow();
                                info.id_user = item.ID;
                                mainWindow.Show();
                                Close();
                                break;
                            }
                        }
                    }

                    if (temp != true) //Проверка на фальшифку
                    {
                        MessageBox.Show("Никнейм или пароль неверные, повторите попытку.", "Ошибка!");
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Критическая ошибка!");
            }
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mail.Visibility = Visibility.Visible;
                ComboTdel.Visibility = Visibility.Visible;
                if (nic.Text == "" | pas.Password == "" | ComboTdel.SelectedIndex == 0)
                {
                    reg.ToolTip = "Заполните логин, пароль и Email. Также выберите отдел.";
                }
                else
                {
                    bool res = true;

                    Сотрудники newbie = new Сотрудники // Создаёт новый объект таблицы бд Пользователи
                    {
                        Никнейм = nic.Text,
                        Пароль = pas.Password,
                        id_отдела = ComboTdel.SelectedIndex,
                        Почта = mail.Text,
                    };
                    foreach (var item in ДипломEntities.GetContext().Сотрудники)
                    {
                        if (item.Никнейм == nic.Text)
                        {
                            res = false;
                        }

                        if (res == false)
                        {
                            MessageBox.Show("Никнейм занят, выбирай другой", "Ошибка!");
                            break;
                        }
                    }
                    if (res == true)
                    {
                        ДипломEntities.GetContext().Сотрудники.Add(newbie); //Добавляет новую строку в таблицу Пользователи
                        ДипломEntities.GetContext().SaveChanges(); //Оно и ясно
                        MessageBox.Show("Регистрация успешно завершена, авторизуйся.", "Успешно!");
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Критическая ошибка!");
            }
        }

        private void pas_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AdminLog_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bool temp = false;
                if (nic.Text == "" | pas.Password == "")
                {
                    AdminLog.ToolTip = "Заполните поля Логин и Пароль.";
                }
                else
                {
                    bool res = false;

                    foreach (var item in ДипломEntities.GetContext().Администраторы) //Берёт все строки из таблицы Пользователи
                    {
                        if (item.Никнейм == nic.Text & item.Пароль == pas.Password) // Ищет совпадения с текстбоксом и строкой в бд
                        {
                            res = true;
                        }

                        if (res == true) //Если оба совпадают открывает основную форму (Info это статик класс для передачи инфы между формами, необязателен)
                        {
                            temp = true;
                            info.id_user = item.ID;
                            AdminPanel adminpanel = new AdminPanel();
                            adminpanel.Show();
                            Close();
                            break;
                        }
                    }
                }
                if (temp != true) //Проверка на фальшифку
                {
                    MessageBox.Show("Никнейм или пароль администратора неверные, повтори попытку.", "Ошибка!");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Критическая ошибка!");
            }
        }
    }
}
