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
using System.Data.SqlClient;

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy EdytowanaOsoba.xaml
    /// </summary>
    public partial class EdytowanaOsoba : Window
    {
        private MainWindow MainWindow;
        private DatabaseService DatabaseService;
        private string Mode;
        SqlConnection con = new SqlConnection(@"Data Source = LAPTOP-TG9368EE; Initial Catalog = Baza_Danych; Integrated Security = True");
        public EdytowanaOsoba(MainWindow window, string mode)
        {

            this.MainWindow = window;
            InitializeComponent();

            //pozycja.ItemsSource = Enum.GetValues(typeof(pozycja)).Cast<pozycja>();
            this.DataContext = MainWindow.EdytowanaOsoba;

            this.Mode = mode;
            InitializeComponent();

            this.DatabaseService = new DatabaseService();

        }

        private void ButtonZapisz_Click(object sender, RoutedEventArgs e)
        {

            //this.DatabaseService.createConnection();


            //    this.DatabaseService.executeProcedureModify<Osoba>("procedura", "Update", this.MainWindow.EdytowanaOsoba);



            //this.Close();
            Osoba EdycjaOso = (Osoba)MainWindow.lv_dane.SelectedItem;
            if (EdycjaOso == null)
                return;

            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Table_1 set imie = '" + imie.Text + "',nazwisko='" + nazwisko.Text + "',rodzaj_sportu='" + rodzaj_sportu.Text + "',wiek='" + wiek.Text + "',pozycja='" + pozycja.Text+"' WHERE ID = '"+ EdycjaOso.ID+"' ",con );
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Edytowano pomyślnie");

            }catch(SqlException ex)
            {
                MessageBox.Show("Wystąpił problem z edycją" + ex.Message);
            }
            finally
            {
                con.Close();
                this.Close();
               
            }
        }

        private void Pozycja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
