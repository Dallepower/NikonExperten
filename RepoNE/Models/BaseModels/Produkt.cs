using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoNE
{
    public class Produkt
    {
        public int ID { get; set; }

        public string Navn { get; set; }

        public string Varenummer { get; set; }

        public int Pris { get; set; }

        public int Tilbudspris { get; set; }

        public string Leveringstid { get; set; }

        public string Lagerantal { get; set; }

        public string Billede { get; set; }

        public string Producent { get; set; }

        public string Beskrivelse { get; set; }

        public int KatID { get; set; }

    }
}
