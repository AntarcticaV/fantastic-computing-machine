using _21._106_Beliy_authorization.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace _21._106_Beliy_authorization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonAuthorization_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new Entities()) 
                {
                    // загрузка данных из таблицы ролей
                    db.Role.Load(); 

                    // выбираем строку пользователя по его имени
                    var selectUsers = db.User.Where(o => o.Name == textBoxName.Text).FirstOrDefault();

                    // проверка на то что пользователь найден и пароль совпадает с хранящимся в базе
                    if (selectUsers != null && selectUsers.Password == passwordBox.Password)
                    {
                        // вывод информации об успешной авторизации и роль пользователя
                        textBlockInfo.Text = "Авторизация прошла успешно, ваша роль: " + selectUsers.Role.Neme.ToString();
                    }
                    else
                    {
                        // вывод информации об неудачной авторизации
                        textBlockInfo.Text = "Авторизация прошла неудачна, неверный логин или пароль";
                    }
                }
            }
            catch
            {
                // вывод информации что произошла ошибка
                textBlockInfo.Text = "Произошла неопределённая ошибка";
            }
        }
    }
}
