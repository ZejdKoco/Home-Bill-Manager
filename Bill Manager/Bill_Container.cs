using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_Manager
{
    public class Bill_Container
    {
        List<Bill> lista_racuna = new List<Bill>();
        List<string> vrste_racuna = new List<string>();

        public List<Bill> Lista_racuna { get => lista_racuna; set => lista_racuna = value; }
        public List<string> Vrste_racuna { get => vrste_racuna; set => vrste_racuna = value; }

        public List<Bill> DajNeplaceneRacune()
        {
            List<Bill> izlaz = new List<Bill>();
            foreach(Bill x in lista_racuna)
            {
                if (x.Placen == false) izlaz.Add(x);
            }
            return izlaz;
        }
        public List<Bill> DajPlaceneRacune()
        {
            List<Bill> izlaz = new List<Bill>();
            foreach (Bill x in lista_racuna)
            {
                if (x.Placen == true) izlaz.Add(x);
            }
            return izlaz;
        }
        public List<Bill> DajRacunePrijeDatuma(DateTime datum)
        {
            List<Bill> izlaz = new List<Bill>();
            foreach (Bill x in lista_racuna)
            {
                if (x.Datum <= datum) izlaz.Add(x);
            }
            return izlaz;
        }
        public List<Bill> DajRacunePoslijeDatuma(DateTime datum)
        {
            List<Bill> izlaz = new List<Bill>();
            foreach (Bill x in lista_racuna)
            {
                if (x.Datum >= datum) izlaz.Add(x);
            }
            return izlaz;
        }
        public List<Bill> DajRacuneIzmedjuDatuma(DateTime datum1, DateTime datum2)
        {
            List<Bill> izlaz = new List<Bill>();
            foreach (Bill x in lista_racuna)
            {
                if (x.Datum >= datum1 && x.Datum <= datum2) izlaz.Add(x);
            }
            return izlaz;
        }
    }
}
