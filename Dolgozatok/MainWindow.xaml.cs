using System.Collections.ObjectModel;
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

namespace Dolgozatok
{
    public class Dolgozat
    {
        public string Nev { get; set; }
        public int Eletkor { get; set; }
        public int Pontszam { get; set; }

        public Dolgozat(string nev, int eletkor, int pontszam)
        {
            Nev = nev;
            Eletkor = eletkor;
            Pontszam = pontszam;
        }
    }

    public partial class MainWindow : Window
    {
        public List<Dolgozat> Dolgozatok { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Dolgozatok = new List<Dolgozat>
            {
                new Dolgozat("Kiss Péter", 16, 87),
                new Dolgozat("Nagy Anna", 17, 92),
                new Dolgozat("Szabó Tamás", 16, 78),
                new Dolgozat("Tóth Éva", 18, 95),
                new Dolgozat("Varga Bence", 17, 81),
                new Dolgozat("Horváth Zsolt", 16, 65),
                new Dolgozat("Molnár Réka", 18, 89),
                new Dolgozat("Lakatos Dániel", 17, 72)
            };

            DataContext = this;
        }
    }
}