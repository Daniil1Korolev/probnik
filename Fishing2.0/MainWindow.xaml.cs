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

namespace Fishing2._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ribalkaEntities db = new ribalkaEntities();
        public MainWindow()
        {
            InitializeComponent();
            Data_Reload();
        }
        public void Data_Reload()
        {
            var FishList = db.Active.ToList();
            DataFish.SelectedValuePath = "ID";
            DataFish.ItemsSource = FishList;
            DataFish.SelectionMode = DataGridSelectionMode.Single;
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var FishList = db.Active.Where(a => a.NameFish.Contains(Search.Text) || a.Category.Contains(Search.Text)).ToList();
            DataFish.SelectedValuePath = "ID";
            DataFish.ItemsSource = FishList;
            DataFish.SelectionMode = DataGridSelectionMode.Single;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Actives Actives = new Actives();
            //vhod.ShowDialog();
            Actives.Show();
            this.Close();
        }
    }
}
