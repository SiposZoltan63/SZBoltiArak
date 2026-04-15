using System;
using System.Collections.Generic;
using System.IO;
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

namespace EvVegiArakWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            deleteButton1.IsEnabled = false;
        }
        List<Arak> arak = new List<Arak>();
        public void LoadData()
        {
            string[] beolvas = File.ReadAllLines("TermekekArai.txt");

            for (int i = 1; i < beolvas.Length; i++)
            {
                Arak ar = new Arak(beolvas[i]);
                arak.Add(ar);
            }
            dataGrid1.ItemsSource = arak;
        }



        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            deleteButton1.IsEnabled = true;
        }

        private void deleteButton1_Click(object sender, RoutedEventArgs e)
        {
            
            var aru = dataGrid1.SelectedItem as Arak;
            arak.Remove(aru);
            dataGrid1.ItemsSource = null;
            dataGrid1.ItemsSource = arak;
        }
    }

    class Arak
    {
        public int Kod { get; set; }
        public string Megnevezes { get; set; }
        public string Szeptember { get; set; }
        public string Oktober { get; set; }
        public string November { get; set; }
        public string December { get; set; }
        public Arak(string sor) 
        {
            string[] adatok = sor.Split(';');

            Kod = int.Parse(adatok[0]);
            Megnevezes = adatok[1];
            Szeptember = adatok[2];
            Oktober = adatok[3];
            November = adatok[4];
            December = adatok[5];
        }
    }
}
