using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy EdytowanaOsoba.xaml
    /// </summary>
    public partial class EdytowanaOsoba : Window
    {
        private MainWindow MainWindow;
        public EdytowanaOsoba(MainWindow window)
        {

            this.MainWindow = window;
            InitializeComponent();

            pozycja.ItemsSource = Enum.GetValues(typeof(pozycja)).Cast<pozycja>();
            this.DataContext = MainWindow.EdytowanaOsoba;

        }

        private void ButtonZapisz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
