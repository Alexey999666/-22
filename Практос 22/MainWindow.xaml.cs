using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Практос_22.ModelsDB;

namespace Практос_22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {

            Entry E = new Entry();
            E.ShowDialog();
            if (Data.Login == false) Close();
            if (Data.Right == "Администратор")
            {
                Main.Visibility = Visibility.Visible;
            }
            else if (Data.Right == "Менеджер")
            {
                Main.Visibility = Visibility.Visible;
                //btnADD.IsEnabled = false;
                //btnEdit.IsEnabled = false;
                //ZP8.IsEnabled = false;
                //btnDelete.IsEnabled = false;

            }
            else if (Data.Right == "Зарегестрированный пользователь")
            {
                Main.Visibility = Visibility.Visible;
                //btnADD.IsEnabled = false;
                //btnEdit.IsEnabled = false;
                //ZP1.IsEnabled = true;
                //ZP2.IsEnabled = true;
                //ZP3.IsEnabled = true;
                //ZP4.IsEnabled = true;
                //ZP5.IsEnabled = true;
                //ZP6.IsEnabled = false;
                //ZP7.IsEnabled = false;
                //ZP8.IsEnabled = false;
                //btnDelete.IsEnabled = false;
            }
            else
            {
                Main.Visibility = Visibility.Visible;
                //btnADD.IsEnabled = false;
                //btnEdit.IsEnabled = false;
                //btnFilt1.IsEnabled = false;
                //btnFilt2.IsEnabled = false;
                //btnFind.IsEnabled = false;
                //ZP1.IsEnabled = false;
                //ZP2.IsEnabled = false;
                //ZP3.IsEnabled = false;
                //ZP4.IsEnabled = false;
                //ZP5.IsEnabled = false;
                //ZP6.IsEnabled = false;
                //ZP7.IsEnabled = false;
                //ZP8.IsEnabled = false;
                //btnDelete.IsEnabled = false;
            }
            Main.Title = Main.Title + " " + Data.UserSurname + " " + Data.UserName + " " + Data.UserPatronymic + " (" + Data.Right + ")";

        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDBInListView();
        }
        void LoadDBInListView()
        {
            using(EditionsCityContext _db =  new EditionsCityContext())
            {
                int selectedIndex = listView.SelectedIndex;
                _db.Editions.Load();
                _db.Organizations.Load();
                listView.ItemsSource = _db.Subscriptions.ToList();
                if(selectedIndex != -1)
                {
                    if (selectedIndex == listView.Items.Count) selectedIndex--;
                    listView.SelectedIndex = selectedIndex;
                    listView.ScrollIntoView(listView.SelectedItem);
                }
                listView.Focus();
            }

        }

        private void btnUserRepost_Click(object sender, RoutedEventArgs e)
        {
            Main.Title = "Подписки на издания";
            Main.Visibility = Visibility.Collapsed;
            Window_Initialized(sender, e);



        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                Flags.FlagEdit = true;
                Data.subscription = (Subscription)listView.SelectedItem;
                TheForm f = new TheForm();
                f.Owner = this;
                f.ShowDialog();
                LoadDBInListView();
            }
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                Flags.FlagView = true;
                Data.subscription = (Subscription)listView.SelectedItem;
                TheForm f = new TheForm();
                f.Owner = this;
                f.ShowDialog();
                LoadDBInListView();
            }
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            tbFind.Clear();
            tbFind.Clear();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Flags.FlagADD = true;
            Data.subscription = null;
            TheForm f = new TheForm();
            f.Owner = this;
            f.ShowDialog();
            LoadDBInListView();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Subscription row = (Subscription)listView.SelectedItem;
                  
                    if (row != null)
                    {
                        using (EditionsCityContext _db = new EditionsCityContext())
                        {
                            _db.Subscriptions.Remove(row);
                            _db.SaveChanges();
                        }
                        LoadDBInListView();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка заполнения");
                }

            }
            else listView.Focus();
        }

        private void tbFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Subscription> listItem = (List<Subscription>)listView.ItemsSource;
            var filtered = listItem.Where(p => p.IndexNavigation.TitleEdition.Contains(tbFind.Text));
            if (filtered.Count() > 0)
            {
                var item = filtered.First();
                listView.SelectedItem = item;
                listView.ScrollIntoView(item);
            }
        }

        private void tbFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbFilter.Text.IsNullOrEmpty() == false)
            {
                using (EditionsCityContext _db = new EditionsCityContext())
                {
                    _db.Editions.Load();
                    _db.Organizations.Load();
                    var filtered = _db.Subscriptions.Where(p => p.CodeNavigation.TitleOrganization.Contains(tbFilter.Text));

                    listView.ItemsSource = filtered.ToList();
                }
            }
            else
            {
                LoadDBInListView();
            }
        }
    }
}