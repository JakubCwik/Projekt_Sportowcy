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
    /// Logika interakcji dla klasy DodawanieWindow.xaml
    /// </summary>
    public partial class DodawanieWindow : Window
    {
        private MainWindow MainWindow;
        public DodawanieWindow(MainWindow window)
        {
            InitializeComponent();
            this.MainWindow = window;

            pozycja.ItemsSource = Enum.GetValues(typeof(pozycja)).Cast<pozycja>();
            this.DataContext = this.MainWindow.EdytowanaOsoba;
            
        }

        private void ButtonZapisz_Click(object sender, RoutedEventArgs e)
        {
            this.MainWindow.dodajDoListy();
            this.Close();
        }

        private void Pozycja_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
