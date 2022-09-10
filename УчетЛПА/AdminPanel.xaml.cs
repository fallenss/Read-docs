using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        

        public AdminPanel()
        {
            InitializeComponent();
            Gridetsky.ItemsSource = ДипломEntities.GetContext().ЛПА.ToList();
            a1.ItemsSource = ДипломEntities.GetContext().Отдел.ToList();
            var allResp = ДипломEntities.GetContext().ЛПА.ToList();
            allResp.Insert(0, new ЛПА
            {
                Наимемнование = "Выбор ЛПА"
            });
            ComboSelect.ItemsSource = allResp;
            //TransfersTeq.eID = name.ID;
            ComboSelect.SelectedIndex = 0;

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var NewLPA = Gridetsky.SelectedItems.Cast<ЛПА>().ToList();
                ДипломEntities.GetContext().ЛПА.AddRange(NewLPA);
                ДипломEntities.GetContext().SaveChanges();
                Gridetsky.ItemsSource = ДипломEntities.GetContext().ЛПА.ToList();
                string pathToFile = @"C:\Windows\ЛПА\";
                OpenFileDialog fileDialog = new OpenFileDialog()
                {
                    Filter = "Docx Files|*.docx|All Files|*.*",
                    CheckFileExists = false,
                    CheckPathExists = true,
                    Multiselect = false, 
                    Title = "Выберите ЛПА"
                };
                //fileDialog.ShowDialog();
                if (fileDialog.ShowDialog() == true)
                {
                    string filename = fileDialog.FileName;
                    File.Copy(filename, pathToFile + fileDialog.SafeFileName, true);
                    MessageBox.Show("ЛПА успешно добавлен!", "Успех!");
                }


            }
            catch (Exception exp)
            {
                System.Windows.MessageBox.Show(exp.Message, "Критическая ошибка!");
            }
        }



        private void red_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //var EditLPA = ДипломEntities.GetContext().ЛПА.ToList();

                //int id = 0;
                //int selectedColumn1 = 0;
                //var selectedCell1 = Gridetsky.SelectedCells[selectedColumn1];
                //var cellContent1 = selectedCell1.Column.GetCellContent(selectedCell1.Item);
                //if (cellContent1 is TextBlock)
                //{
                //    id = Convert.ToInt32((cellContent1 as TextBlock).Text);
                //}
                //string oname = "";
                //foreach (var abobus in ДипломEntities.GetContext().ЛПА)
                //{
                //    if (abobus.ID == id)
                //    {
                //        oname = abobus.Наимемнование;
                //    }
                //}
                //string nname = "";

                //var a = Gridetsky.SelectedItems.Cast<ЛПА>().ToList();
               
                //int selectedColumn = 1;
                //var selectedCell = Gridetsky.SelectedCells[selectedColumn];
                //var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);
                //if (cellContent is TextBlock)
                //{
                //    nname = (cellContent as TextBlock).Text;
                //}

                //string opathToFile = @"C:\Windows\ЛПА\" + oname + ".docx";
                //string npathToFile = @"C:\Windows\ЛПА\" + nname + ".docx";
                //File.Copy(oname, nname, true);
                //File.Delete(oname);
                Gridetsky.SelectedItems.Cast<ЛПА>().ToList();
                ДипломEntities.GetContext().SaveChanges();
                Gridetsky.ItemsSource = ДипломEntities.GetContext().ЛПА.ToList();
                MessageBox.Show("ЛПА отредактирован!", "Успех!");
            }
            catch (Exception exp)
            {
                System.Windows.MessageBox.Show(exp.Message, "Критическая ошибка!");
            }
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string NameOfDelFile = "";
                var DelLPA = Gridetsky.SelectedItems.Cast<ЛПА>().ToList();
                int selectedColumn = 1;
                var selectedCell = Gridetsky.SelectedCells[selectedColumn];
                var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);
                if (cellContent is TextBlock)
                {
                    NameOfDelFile = (cellContent as TextBlock).Text;
                }
                string pathToFile = @"C:\Windows\ЛПА\" + NameOfDelFile + ".docx";
                File.Delete(pathToFile);
                ДипломEntities.GetContext().ЛПА.RemoveRange(DelLPA);
                ДипломEntities.GetContext().SaveChanges();
                Gridetsky.ItemsSource = ДипломEntities.GetContext().ЛПА.ToList();
                MessageBox.Show("ЛПА удалён!", "Успех!");

            }
            catch (Exception exp)
            {
                System.Windows.MessageBox.Show(exp.Message, "Критическая ошибка!");
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Вход NewWindow = new Вход();
            NewWindow.Show();
            Close();
        }

        private void rep_user_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //List<ЛПА> data = ДипломEntities.GetContext().ЛПА.ToList();
                List<Сотрудники> date = new List<Сотрудники>();
                List<Сотрудники> date2 = new List<Сотрудники>();
                foreach (var item in ДипломEntities.GetContext().ЛПА.ToList())
                {
                    foreach (var item2 in ДипломEntities.GetContext().Сотрудники)
                    {
                        if (item.id_отдела == item2.id_отдела)
                        {
                            date.Add(item2);
                        }
                    }


                    date2.AddRange(date);
                    date.Clear();
                }

                byte[] reportExcel = new Class1().Generate(date2);
                File.WriteAllBytes(desktopPath + @"\LPAReport.xlsx", reportExcel);
                System.Diagnostics.Process.Start(desktopPath + @"\LPAReport.xlsx");
            }
            
            catch (Exception exp)
            {
                System.Windows.MessageBox.Show(exp.Message, "Критическая ошибка!");

            }

        }
            
        private readonly string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        private void rep_introd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ComboSelect.SelectedIndex == 0)
                {
                    System.Windows.MessageBox.Show("Выберите ЛПА в выпадающем списке выше.", "Ошибка!");
                }
                else
                {
                    Byte[] CurrentLPA = new Class1().DEGenerate(ComboSelect.SelectedItem as ЛПА);
                    File.WriteAllBytes(desktopPath + @"\Oznakomlenie.xlsx", CurrentLPA);
                    System.Diagnostics.Process.Start(desktopPath + @"\Oznakomlenie.xlsx");
                }
            }
            catch (Exception exp)
            {
                System.Windows.MessageBox.Show(exp.Message,"Критическая ошибка!");
            }
        }

        private void Gridetsky_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ЛПА UpdateLPA = Gridetsky.SelectedItems.Cast<ЛПА>().FirstOrDefault();
                if (UpdateLPA != null)
                {
                    UpdateLPA.Дата_обновления = DateTime.Today;
                    UpdateLPA.Срок_контроля = UpdateLPA.Дата_обновления.AddDays(30);
                    ДипломEntities.GetContext().SaveChanges();
                    Gridetsky.ItemsSource = ДипломEntities.GetContext().ЛПА.ToList();
                    int kol = 0;
                    foreach (var Worker in ДипломEntities.GetContext().Сотрудники)
                    {
                        if (Worker.id_отдела == UpdateLPA.id_отдела)
                        {
                            try
                            {
                                // отправитель - устанавливаем адрес и отображаемое в письме имя
                                MailAddress from = new MailAddress("uchetlpa@gmail.com", "Учёт ЛПА");
                                // кому отправляем
                                MailAddress to = new MailAddress(Worker.Почта);
                                // создаем объект сообщения
                                MailMessage m = new MailMessage(from, to);
                                // тема письма
                                m.Subject = "Обновление ЛПА";
                                // текст письма
                                m.Body = $"<h2>Здравствуйте, только что был обновлен ЛПА \"{UpdateLPA.Наимемнование}\". <br>Убедительная просьба ознакомится с новвоведениями до истечения срока контроля: {UpdateLPA.Срок_контроля.ToString("d")}. <br><br>Внимание, сообщение отправлено автоматически, на него не нужно отвечать.</h2>";
                                // письмо представляет код html
                                m.IsBodyHtml = true;
                                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                                // логин и пароль
                                smtp.Credentials = new NetworkCredential("uchetlpa@gmail.com", "3434253333333356454");
                                smtp.EnableSsl = true;
                                smtp.Send(m);
                                kol++;
                            }
                            catch (Exception exp)
                            {
                                System.Windows.MessageBox.Show(exp.Message, "Критическая ошибка!");
                            }
                        }
                    }
                    System.Windows.MessageBox.Show($"Обновление ЛПА успешно завершено, оповещения высланы. ({kol})", "Успешно!");
                }
                else
                {
                    System.Windows.MessageBox.Show($"Выберите ЛПА, который следует обновить.", "Ошибка!");
                }

            }
            catch (Exception exp)
            {
                System.Windows.MessageBox.Show(exp.Message, "Критическая ошибка!");
            }
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
                System.Windows.MessageBox.Show(exp.Message, "Ошибка!");
            }
        }

        private void rep_otdel_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                    Byte[] AllLPA = new Class1().DEDEGenerate();
                    File.WriteAllBytes(desktopPath + @"\Otdel.xlsx", AllLPA);
                    System.Diagnostics.Process.Start(desktopPath + @"\Otdel.xlsx");
                
            }
            catch (Exception exp)
            {
                System.Windows.MessageBox.Show(exp.Message, "Критическая ошибка!");
            }
        }

        private void Gridetsky_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }


    }
}
