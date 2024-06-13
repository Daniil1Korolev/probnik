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

namespace Fishing2._0
{
    /// <summary>
    /// Логика взаимодействия для Actives.xaml
    /// </summary>
    public partial class Actives : Window
    {
        public ribalkaEntities db = new ribalkaEntities();
        public Actives()
        {
            InitializeComponent();
            Title = "Активы";
            List_Reload();
        }

        public void List_Reload()
        {
            var OrdersList = db.Active.ToList();
            ListCheck.SelectedValuePath = "ID";
            ListCheck.ItemsSource = OrdersList;
            ListCheck.SelectionMode = SelectionMode.Single;
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("INFO", "Order Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Warning_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Warning", "Orders warn", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Console.WriteLine("Yes");
                    break;
                case MessageBoxResult.No:
                    Console.WriteLine("No");
                    break;
            }
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Active active = new Active
            {
                Number = int.Parse(NumberActive.Text),
                NameActive = NameActive.Text,
                Category = Category.Text,
                Price = int.Parse(Price.Text),
                Count = int.Parse(Count.Text),
                Description = Description.Text,
                DateAdd = DateVilov.SelectedDate.Value
            };
            db.Active.Add(active);
            try
            {
                db.SaveChanges();
            }
            catch
            {

            }
            List_Reload();
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            if (ListCheck.SelectedItem != null)
            {
                Active selectedItem = (Active)ListCheck.SelectedItem;
                NumberActive.Text = selectedItem.Number.ToString();
                NameActive.Text = selectedItem.NameActive;
                Category.Text = selectedItem.Category;
                Price.Text = selectedItem.Price.ToString();
                Count.Text = selectedItem.Count.ToString();
                Description.Text = selectedItem.Description;
                DateVilov.SelectedDate = selectedItem.DateAdd;
                db.SaveChanges();
                List_Reload();
            }
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (ListCheck.SelectedItem != null)
            {
                Active selectedItem = (Active)ListCheck.SelectedItem;
                db.Active.Remove(selectedItem);
                db.SaveChanges();
                List_Reload();
            }
        }
        private void ListCheck_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ListCheck.SelectedItem != null)
            {
                Active selectedItem = (Active)ListCheck.SelectedItem;
                NumberActive.Text = selectedItem.Number.ToString();
                NameActive.Text = selectedItem.NameActive;
                Category.Text = selectedItem.Category;
                Price.Text = selectedItem.Price.ToString();
                Count.Text = selectedItem.Count.ToString();
                Description.Text = selectedItem.Description;
                DateVilov.SelectedDate = selectedItem.DateAdd;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            //vhod.ShowDialog();
            MainWindow.Show();
            this.Close();
        }
    }
}
