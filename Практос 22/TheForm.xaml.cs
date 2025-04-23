using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
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
using Практос_22.ModelsDB;

namespace Практос_22
{
    /// <summary>
    /// Логика взаимодействия для TheForm.xaml
    /// </summary>
    public partial class TheForm : Window
    {
        public TheForm()
        {
            InitializeComponent();
        }
        EditionsCityContext _db = new EditionsCityContext();
        Subscription _subscription;
        Edition _edition;
        OpenFileDialog open = new OpenFileDialog();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbEdition.ItemsSource = _db.Editions.ToList();
            cbEdition.DisplayMemberPath = "TitleEdition";
            cbOrganization.ItemsSource = _db.Organizations.ToList();
            cbOrganization.DisplayMemberPath = "TitleOrganization";

            if(Flags.FlagADD == true)
            {
                TheFormBlank.Title = "Добавить запись";
                btnFormAdd.Content = "Добавить";
                btnFormAdd.Visibility = Visibility.Visible;
                _subscription = new Subscription();
                _subscription.SubscriptionDate = DateTime.Now;
                Flags.FlagADD = false;
            }
            else if (Flags.FlagEdit == true)
            {
                TheFormBlank.Title = "Изменить запись";
                btnFormAdd.Content = "Изменить";
                btnFormAdd.Visibility = Visibility.Visible;
                _subscription = _db.Subscriptions.Find(Data.subscription.SubscriptionNumber);
                if (!string.IsNullOrEmpty(_subscription.IndexNavigation?.Photo))
                {
                    var photoPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "image", _subscription.IndexNavigation.Photo);
                    if (File.Exists(photoPath))
                    {
                        imgPhoto.Source = new BitmapImage(new Uri(photoPath));
                    }
                }
                Flags.FlagEdit = false;

            }
            else
            {
                TheFormBlank.Title = "Посмотреть запись";
                _subscription = _db.Subscriptions.Find(Data.subscription.SubscriptionNumber);
                if (!string.IsNullOrEmpty(_subscription.IndexNavigation?.Photo))
                {
                    var photoPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "image", _subscription.IndexNavigation.Photo);
                    if (File.Exists(photoPath))
                    {
                        imgPhoto.Source = new BitmapImage(new Uri(photoPath));
                    }
                }
                btnFormAdd.Visibility = Visibility.Collapsed;
                Flags.FlagView = false;
            }
            TheFormBlank.DataContext = _subscription;
        }

        private void btnFormAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            ////if (!int.TryParse(tbNumber.Text, out int N) || N <= 0)
            ////    errors.AppendLine("Ошибка в номере");
            //if (dpDate.SelectedDate == null || dpDate.SelectedDate.Value == default(DateTime))
            //    errors.AppendLine("Заполните корректную дату");
            //else if (dpDate.SelectedDate.Value > DateTime.Now)
            //    errors.AppendLine("Дата не может быть в будущем");
            //if (string.IsNullOrWhiteSpace(cbNumber.Text))
            //    errors.AppendLine("Заполните заказ");
            //if (string.IsNullOrWhiteSpace(cbKod.Text))
            //    errors.AppendLine("Заполните услугу");
            //tbCoust.Text = tbCoust.Text.Replace(".", ",");
            //if (!double.TryParse(tbCoust.Text, out double D) || D <= 0)
            //    errors.AppendLine("Ошибка в цене");
            //if (string.IsNullOrWhiteSpace(cbFormBuy.Text))
            //    errors.AppendLine("Заполните форму оплаты");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString()); return;
            }
            try
            {
                if (open.SafeFileName.Length != 0)
                {
                    string newNamePhoto = Directory.GetCurrentDirectory + "\\image\\" + open.SafeFileName;
                    File.Copy(open.FileName, newNamePhoto, true);
                    _edition.Photo = open.SafeFileName;
                }
            }
            catch { }
            try
            {
                if (Data.subscription == null)
                {
                    _db.Subscriptions.Add(_subscription);
                    _db.SaveChanges();
                }
                else
                {
                    _db.Entry(_subscription).State = EntityState.Modified;
                    _db.SaveChanges();
                }
                MessageBox.Show("Информация сохранена");
                this.Close();
            }
            catch (Exception ex)
            {
                _db.Subscriptions.Remove(_subscription);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            open.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png";
            open.Title = "Выберите фото клиента";
            if (open.ShowDialog() == true) 
            {
                BitmapImage imgagePhoto = new BitmapImage(new Uri(open.FileName));
                imgPhoto.Source = imgagePhoto;
            }
        }
    }
}
