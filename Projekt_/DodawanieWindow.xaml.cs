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
using System.Xml.Serialization;
using System.IO;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;



namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy DodawanieWindow.xaml
    /// </summary>
    public partial class DodawanieWindow : Window
    {
        private MainWindow MainWindow;
        //private DatabaseService DatabaseService;
       // private string Mode;
        SqlConnection con = new SqlConnection(@"Data Source = LAPTOP-TG9368EE; Initial Catalog = Baza_Danych; Integrated Security = True");
        //public DodawanieWindow(MainWindow window, string mode)
        public DodawanieWindow(MainWindow window)
        {
           
           
            this.MainWindow = window;

            //// pozycja.ItemsSource = Enum.GetValues(typeof(pozycja)).Cast<pozycja>();
            //this.DataContext = this.MainWindow.EdytowanaOsoba;

            //this.Mode = mode;
            InitializeComponent();

            //this.DatabaseService = new DatabaseService();
            this.DataContext = this.MainWindow.EdytowanaOsoba;


        }

        //public void LoadGrid()
        //{
        //    SqlCommand cmd = new SqlCommand("SELECT * FROM Table_1", con);
        //    DataTable dt = new DataTable();
        //    con.Open();
        //    SqlDataReader sdr = cmd.ExecuteReader();
        //    dt.Load(sdr);
        //    con.Close();
        //    MainWindow.lv_dane.ItemsSource = dt.DefaultView;
        //}
        private void ButtonZapisz_Click(object sender, RoutedEventArgs e)
        {
            //this.DatabaseService.createConnection();
            this.MainWindow.dodajDoListy();

            SqlCommand cmd = new SqlCommand("INSERT INTO Table_1 VALUES( @imie, @nazwisko, @rodzaj_sportu, @wiek, @pozycja)", con);


           

            try
            {

                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@imie", imie_txt.Text);
                cmd.Parameters.AddWithValue("@nazwisko", nazwisko_txt.Text);
                cmd.Parameters.AddWithValue("@rodzaj_sportu", rodzaj_sportu_txt.Text);
                cmd.Parameters.AddWithValue("@wiek", wiek_txt.Text);
                cmd.Parameters.AddWithValue("@pozycja", pozycja_txt.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //LoadGrid();
                //this.MainWindow.dodajDoListy();
                MessageBox.Show("Dodano pomyślnie");
                this.Close();
               
               // MainWindow.lv_dane.ItemsSource = cmd;


            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }



            //this.Close();
        }

        private void Pozycja_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void pozycja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
