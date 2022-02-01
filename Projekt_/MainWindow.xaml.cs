using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Xml.Serialization;
using System.IO;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using Projekt_;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Osoba> osobaa { get; }
        public Osoba EdytowanaOsoba { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            //LoadGrid();


            DatabaseService DatabaseService = new DatabaseService();
            DatabaseService.createConnection();
           // osobaa = DatabaseService.executeProcedureSelect<Osoba>("Baza");
            lv_dane.ItemsSource = osobaa;

            string connectionString = "Server= LAPTOP-TG9368EE; Database= Baza_Danych; Integrated Security = SSPI";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("Baza", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);

            //// XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Osoba>));
            ////using (Stream s = File.OpenRead("C:/Users/Kuba/OneDrive/Pulpit/Programowanie 3 JĆ/Projekt_zal/Zapisy/Sportowcy.xml"))
            ////    osobaa = (ObservableCollection<Osoba>) xs.Deserialize(s);


            ////osobaa.Add(new Osoba() { Imie = "Michał", Nazwisko = "Zaradny", RodzajSportu = "Siatkowka", Wiek = "24" });
            osobaa = new ObservableCollection<Osoba>();
            foreach (DataRow row in dataTable.Rows)
            {
                Osoba osoba = new Osoba();
                osoba.ID = (int)row["ID"];
                osoba.Imie = (string)row["imie"];
                osoba.Nazwisko = (string)row["nazwisko"];
                osoba.RodzajSportu = (string)row["Rodzaj_Sportu"];
                osoba.Wiek = (int)row["Wiek"];
                osoba.Pozycja = (string)row["Pozycja"];


                //    //string poz = (string)row["Pozycja"];
                //    //osoba.Pozycja = (pozycja)Enum.Parse(typeof(pozycja), poz, true);




                osobaa.Add(osoba);
            }
            lv_dane.ItemsSource = osobaa;
           

        }
        SqlConnection con = new SqlConnection(@"Data Source = LAPTOP-TG9368EE; Initial Catalog = Baza_Danych; Integrated Security = True");

     
        private void Button_Click_Dodaj(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            EdytowanaOsoba = new Osoba();
            //DodawanieWindow DodawanieWin = new DodawanieWindow(this, button.Name);
            DodawanieWindow DodawanieWin = new DodawanieWindow(this);
            DodawanieWin.Show();


           
        }

        public void dodajDoListy()
        {
            this.osobaa.Add(EdytowanaOsoba);
            
        }

        private void Button_Click_Zapis(object sender, RoutedEventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Osoba>));
            using (Stream s = File.Create("D:/Projekt/Projekt_/Sportowcy.xml"))
                xs.Serialize(s, osobaa);
            MessageBox.Show("Zapisano pomyślnie.");
        }

        private void Button_Click_Edytuj(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            EdytowanaOsoba = (Osoba)lv_dane.SelectedItem;
            if (EdytowanaOsoba == null)
                return;

            EdytowanaOsoba EdytowanieWin = new EdytowanaOsoba(this, button.Name);
            EdytowanieWin.Show();
           
            




        }

        private void Button_Click_Usun(object sender, RoutedEventArgs e)
        {

             Osoba UsuwanieOso = (Osoba)lv_dane.SelectedItem;
             if (UsuwanieOso == null)
                 return;

            
            

            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Table_1 where ID = " + UsuwanieOso.ID , con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Usunięto dane o podanym ID");
                con.Close();
                osobaa.Remove(UsuwanieOso);
               // con.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Nie zostało usunięte"+ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public void removeItemFromOsobaList()
        {
            osobaa.Remove(this.EdytowanaOsoba);
        }

        private void Raport_Click(object sender, RoutedEventArgs e)
        {
            Raport_Okno Okno1 = new Raport_Okno();
            Okno1.ShowDialog();

        }

      

    }
  
}
