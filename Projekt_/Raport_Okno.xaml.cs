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
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Microsoft.Reporting;
using Microsoft.ReportingServices;
using Microsoft.Reporting.WinForms;

namespace Projekt_
{
    /// <summary>
    /// Logika interakcji dla klasy Raport_Okno.xaml
    /// </summary>
    public partial class Raport_Okno : Window
    {
        public Raport_Okno()
        {
            InitializeComponent();

            rpt.ServerReport.ReportServerUrl = new Uri("http://laptop-tg9368ee:80/Reports", System.UriKind.Absolute);
            rpt.ServerReport.ReportPath = "C:/Users/Kuba/source/repos/Kuba2210/Projekt_Sportowcy/Report/Report1";
            rpt.RefreshReport();
        }
    }
}
