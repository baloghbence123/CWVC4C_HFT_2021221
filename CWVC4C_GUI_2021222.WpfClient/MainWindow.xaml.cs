using CWVC4C_GUI_2021222.WpfClient.ViewModels;
using CWVC4C_GUI_2021222.WpfClient.Views;
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

namespace CWVC4C_GUI_2021222.WpfClient
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

        private void HeroesView(object sender, RoutedEventArgs e)
        {
            CV.Content = new HeroView();
        }

        private void ElementView(object sender, RoutedEventArgs e)
        {
            CV.Content = new ElementView();
        }

        private void AbilitiesView(object sender, RoutedEventArgs e)
        {
            CV.Content = new AbilityView();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
