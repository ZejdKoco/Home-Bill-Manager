using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_Manager
{
    public class Bill
    {

        bool placen;
        private string naziv;
        private double iznos;
        private DateTime datum;

        public string Naziv { get => naziv; set => naziv = value; }
        public double Iznos { get => iznos; set => iznos = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public bool Placen { get => placen; set => placen = value; }

        
        public Bill(string naz, double iz, DateTime dat)
        {
            naziv = naz;
            iznos = iz;
            datum = dat;
        }
        public override string ToString()
        {
            return datum.ToString("dd/MM/yyyy") + ", " + naziv + ", " + iznos.ToString() + " KM";
        }
        public string ToStringIme()
        {
            return naziv + ", " + iznos.ToString() + " KM";
        }
    }
}
