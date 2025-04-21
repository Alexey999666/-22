using Microsoft.EntityFrameworkCore;
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
             
            //Entry E = new Entry();
            //E.ShowDialog();
            //if (Data.Login == false) Close();
            //if (Data.Right == "Администратор")
            //{
            //    Main.Visibility = Visibility.Visible;
            //}
            //else if (Data.Right == "Менеджер")
            //{
            //    Main.Visibility = Visibility.Visible;
            //    //btnADD.IsEnabled = false;
            //    //btnEdit.IsEnabled = false;
            //    //ZP8.IsEnabled = false;
            //    //btnDelete.IsEnabled = false;

            //}
            //else if (Data.Right == "Зарегестрированный пользователь")
            //{
            //    Main.Visibility = Visibility.Visible;
            //    //btnADD.IsEnabled = false;
            //    //btnEdit.IsEnabled = false;
            //    //ZP1.IsEnabled = true;
            //    //ZP2.IsEnabled = true;
            //    //ZP3.IsEnabled = true;
            //    //ZP4.IsEnabled = true;
            //    //ZP5.IsEnabled = true;
            //    //ZP6.IsEnabled = false;
            //    //ZP7.IsEnabled = false;
            //    //ZP8.IsEnabled = false;
            //    //btnDelete.IsEnabled = false;
            //}
            //else
            //{
            //    Main.Visibility = Visibility.Visible;
            //    //btnADD.IsEnabled = false;
            //    //btnEdit.IsEnabled = false;
            //    //btnFilt1.IsEnabled = false;
            //    //btnFilt2.IsEnabled = false;
            //    //btnFind.IsEnabled = false;
            //    //ZP1.IsEnabled = false;
            //    //ZP2.IsEnabled = false;
            //    //ZP3.IsEnabled = false;
            //    //ZP4.IsEnabled = false;
            //    //ZP5.IsEnabled = false;
            //    //ZP6.IsEnabled = false;
            //    //ZP7.IsEnabled = false;
            //    //ZP8.IsEnabled = false;
            //    //btnDelete.IsEnabled = false;
            //}
            //Main.Title = Main.Title + " " + Data.UserSurname + " " + Data.UserName + " " + Data.UserPatronymic + " (" + Data.Right + ")";

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

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Main.Title = "MainWindow";
        //    Main.Visibility = Visibility.Collapsed;
        //    Window_Initialized(sender, e);



        //}
    }
}