using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using Практос_22.ModelsDB;

namespace Практос_22
{
    /// <summary>
    /// Логика взаимодействия для Entry.xaml
    /// </summary>
    public partial class Entry : Window
    {
        public Entry()
        {
            InitializeComponent();
        }
        DispatcherTimer _timer;
        int _countLogin = 1;
        void GetCaptcha()
        {
            string masChar = "QWERTYUIOPLKJHGFDSAZXCVBNMmnbvcxzasdfghjk" + "lpoiuytrewq1234567890";
            string captcha = "";
            Random rnd = new Random();
            for (int i = 1; i <= 6; i++)
            {
                captcha = captcha + masChar[rnd.Next(0, masChar.Length)];
            }
            grid.Visibility = Visibility.Visible;
            txtCaprcha.Text = captcha;
            tbCaptcha.Text = null;
            txtCaprcha.LayoutTransform = new RotateTransform(rnd.Next(-30, 30));
            line.X1 = 10;
            line.Y1 = rnd.Next(10, 40);
            line.X2 = 280;
            line.Y2 = rnd.Next(10, 40);
            line1.X1 = 50;
            line1.Y1 = rnd.Next(10, 60);
            line1.X2 = 230;
            line1.Y2 = rnd.Next(10, 60);
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            tbLogin.Focus();
            Data.Login = false;
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 10);
            _timer.Tick += new EventHandler(timer_Tick);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            SPenel.IsEnabled = true;
        }
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            using (EditionsCityContext _db = new EditionsCityContext())
            {
                var user = _db.Users.Where(user => user.UserLogin == tbLogin.Text && user.UserPassword == tbPas.Password);
                if (user.Count() == 1 && txtCaprcha.Text == tbCaptcha.Text)
                {
                    Data.Login = true;
                    Data.UserSurname = user.First().UserSurname;
                    Data.UserName = user.First().UserName;
                    Data.UserPatronymic = user.First().UserPatronymic;
                    _db.Roles.Load();
                    Data.Right = user.First().UserRoleNavigation.RoleName;
                    Close();
                }
                else
                {
                    if (user.Count() == 1)
                    {
                        MessageBox.Show("Капча неверная! Повторите ввод.");
                    }
                    else
                    {
                        MessageBox.Show("Логин, пароль неверны! Повторите ввод.");
                    }
                    GetCaptcha();
                    if (_countLogin >= 2)
                    {
                        SPenel.IsEnabled = false;
                        _timer.Start();
                    }
                    _countLogin++;
                    tbLogin.Focus();
                }
            }
        }
        

        private void btnEsc_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            Data.Login = true;
            Data.UserSurname = "Гость";
            Data.UserName = "";
            Data.UserPatronymic = "";
            Data.Right = "Гость";
            Close();
        }
    }
}
