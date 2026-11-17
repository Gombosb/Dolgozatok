using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
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

        private void Hozzaadas_Click(object sender, RoutedEventArgs e)
        {
            string nev = txtNev.Text.Trim();

            int eletkor;
            int pontszam;

            if (string.IsNullOrWhiteSpace(nev) || string.IsNullOrWhiteSpace(txtEletkor.Text) || string.IsNullOrWhiteSpace(txtPontszam.Text))
            {
                MessageBox.Show("Minden mező kitöltése kötelező!", "Hiányzó adat", MessageBoxButton.OK);
                return;
            }

            eletkor = int.Parse(txtEletkor.Text);
            pontszam = int.Parse(txtPontszam.Text);

            Dolgozatok.Add(new Dolgozat(nev, eletkor, pontszam));

            Dtgrid.Items.Refresh();
        }

        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Title = "Dolgozatok mentése",
                Filter = "Szövegfájl (*.txt)|*.txt",
                DefaultExt = ".txt",
                AddExtension = true,
                FileName = "Mentettdolgozatok.txt"
            };

            if (dialog.ShowDialog() != true)
                return;

            try
            {
                var sorok = new List<string>{"Név; Életkor; Pontszám"};

                foreach (var d in Dolgozatok)
                {
                    sorok.Add($"{d.Nev};{d.Eletkor};{d.Pontszam}");
                }

                File.WriteAllLines(dialog.FileName, sorok, new UTF8Encoding(true));

                MessageBox.Show("A dolgozatok mentése sikerült!", "Mentés", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a mentés során:\n{ex.Message}", "Mentési hiba", MessageBoxButton.OK);
            }
        }

    }
}