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
using ZedGraph;

namespace Bill_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bill_Container racuni;
        DBConnect baza = new DBConnect();
        public MainWindow()
        {
            InitializeComponent();
            racuni = new Bill_Container();
            try
            {
                baza.OpenConnection();
                racuni = baza.SelectAll();
                baza.CloseConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            UpdatePrikaz();
            UpdateVrste();
        }

        private void dodajVrstuRacuna_Click(object sender, RoutedEventArgs e)
        {
            baza.OpenConnection();
            try
            {
                baza.InsertRacunTip(dodajVrstuRacunaText.Text);
            }
            catch (Exception ex){
                statusBar.Items.Add(ex.ToString());
                return;
            }
            baza.CloseConnection();
            racuni.Vrste_racuna.Add(dodajVrstuRacunaText.Text);
            UpdateVrste();
            dodajVrstuRacunaText.Clear();
        }
        private void UpdateVrste()
        {
            vrsteRacuna.Items.Clear();
            foreach(string x in racuni.Vrste_racuna)
            {
                vrsteRacuna.Items.Add(x);
            }
        }
         private void UpdatePrikaz()
        {
            prikazRacuna.Items.Clear();
            if(datumA.SelectedDate == null && datumB.SelectedDate == null)
            {
                foreach(Bill x in racuni.Lista_racuna)
                {
                    prikazRacuna.Items.Add(x);
                }
            }
            else if(datumA.SelectedDate == null && datumB.SelectedDate != null)
            {
                foreach (Bill x in racuni.DajRacunePrijeDatuma(datumB.SelectedDate.Value))
                {
                    prikazRacuna.Items.Add(x);
                }
            }
            else if(datumA.SelectedDate != null && datumB.SelectedDate == null)
            {
                foreach (Bill x in racuni.DajRacunePoslijeDatuma(datumA.SelectedDate.Value))
                {
                    prikazRacuna.Items.Add(x);
                }
            }
            else
            {
                foreach (Bill x in racuni.DajRacuneIzmedjuDatuma(datumA.SelectedDate.Value, datumB.SelectedDate.Value))
                {
                    prikazRacuna.Items.Add(x);
                }
            }

        }

        private void dodajVrstuRacunaText_GotFocus(object sender, RoutedEventArgs e)
        {
            dodajVrstuRacunaText.Clear();
        }

        private void vrijednostRacunaText_GotFocus(object sender, RoutedEventArgs e)
        {
            vrijednostRacunaText.Clear();
        }

        private void datum_Initialized(object sender, EventArgs e)
        {
            datum.SelectedDate = DateTime.Now;
        }


        private void obrisiVrstuRacuna_Click(object sender, RoutedEventArgs e)
        {
            
            if (vrsteRacuna.SelectedItem != null)
            {
                foreach (Bill racun in racuni.Lista_racuna)
                {
                    if (racun.Naziv == vrsteRacuna.SelectedItem.ToString())
                    {
                        statusBar.Items.Add("Ne mogu se brisati nazivi racuna koje koriste postojeci racuni!");
                        return;
                    }
                }
                try
                {
                    baza.OpenConnection();
                    baza.DeleteVrstuRacuna(vrsteRacuna.SelectedItem.ToString());
                    baza.CloseConnection();
                }
                catch(Exception ex)
                {
                    statusBar.Items.Add(ex.ToString());
                    return;
                }
                racuni.Vrste_racuna.Remove(vrsteRacuna.SelectedItem.ToString());
                UpdateVrste();
            }
            
        }

        

        private void datumA_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePrikaz();
        }

        private void dodajRacunButton_Click(object sender, RoutedEventArgs e)
        {
            if (vrsteRacuna.SelectedItem == null) statusBar.Items.Add("Odaberite vrstu racuna!");
            else
            {
                statusBar.Items.Clear();
                if (vrijednostRacunaText.Text == null || vrijednostRacunaText.Text == "Cijena") statusBar.Items.Add("Upisite cijenu!");
                else
                {
                    statusBar.Items.Clear();
                    try
                    {
                        baza.OpenConnection();
                        baza.InsertRacun(new Bill(vrsteRacuna.SelectedItem.ToString(), Convert.ToDouble(vrijednostRacunaText.Text), datum.SelectedDate.Value));
                        baza.CloseConnection();
                    }
                    catch(Exception ex)
                    {
                        statusBar.Items.Add(ex.ToString());
                        return;
                    }
                    racuni.Lista_racuna.Add(new Bill(vrsteRacuna.SelectedItem.ToString(), Convert.ToDouble(vrijednostRacunaText.Text), datum.SelectedDate.Value));
                    UpdatePrikaz();

                }
            }
        }

        private void datumB_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
            UpdatePrikaz();
        }

        private void dodajVrstuRacunaText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                baza.OpenConnection();
                try
                {
                    baza.InsertRacunTip(dodajVrstuRacunaText.Text);
                }
                catch (Exception ex)
                {
                    statusBar.Items.Add(ex.ToString());
                    return;
                }
                baza.CloseConnection();
                racuni.Vrste_racuna.Add(dodajVrstuRacunaText.Text);
                UpdateVrste();
                dodajVrstuRacunaText.Clear();
            }
        }

        private void vrijednostRacunaText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (vrsteRacuna.SelectedItem == null) statusBar.Items.Add("Odaberite vrstu racuna!");
                else
                {
                    statusBar.Items.Clear();
                    if (vrijednostRacunaText.Text == null || vrijednostRacunaText.Text == "Cijena") statusBar.Items.Add("Upisite cijenu!");
                    else
                    {
                        statusBar.Items.Clear();
                        try
                        {
                            baza.OpenConnection();
                            baza.InsertRacun(new Bill(vrsteRacuna.SelectedItem.ToString(), Convert.ToDouble(vrijednostRacunaText.Text), datum.SelectedDate.Value));
                            baza.CloseConnection();
                        }
                        catch (Exception ex)
                        {
                            statusBar.Items.Add(ex.ToString());
                            return;
                        }
                        racuni.Lista_racuna.Add(new Bill(vrsteRacuna.SelectedItem.ToString(), Convert.ToDouble(vrijednostRacunaText.Text), datum.SelectedDate.Value));
                        UpdatePrikaz();

                    }
                }
            }
        }

        private void deleteSelectedBtn_Click(object sender, RoutedEventArgs e)
        {
            if (prikazRacuna.SelectedItem != null)
            {
                try
                {
                    baza.OpenConnection();
                    baza.DeleteRacun(prikazRacuna.SelectedItem as Bill);
                    baza.CloseConnection();
                }
                catch(Exception ex)
                {
                    statusBar.Items.Add(ex.ToString());
                    return;
                }
                racuni.Lista_racuna.Remove(prikazRacuna.SelectedItem as Bill);
                UpdatePrikaz();
            }
        }

        private void deleteBufferBtn_Click(object sender, RoutedEventArgs e)
        {
            baza.OpenConnection();
            if(MessageBox.Show("Obrisati iz liste sve?", "Upozorenje!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            foreach(Bill x in prikazRacuna.Items)
            {
                racuni.Lista_racuna.Remove(x);
                baza.DeleteRacun(x);
            }
            baza.CloseConnection();
            UpdatePrikaz();
        }

        private void deleteAllBtn_Click(object sender, RoutedEventArgs e)
        {
           
            if (MessageBox.Show("Obrisati sve podatke?", "Upozorenje!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                racuni.Lista_racuna.Clear();
                baza.OpenConnection();
                baza.DeleteAllRacuni();
                baza.CloseConnection();
                UpdatePrikaz();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                baza.OpenConnection();
                racuni = baza.SelectAll();
                baza.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            UpdatePrikaz();
            UpdateVrste();

        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
