﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoNE
{
    public class ProduktListe
    {
        public List<Kategori> KategoriList { get; set; }
        public Kategori Kategori { get; set; }
        public List<Produkt> Produkter { get; set; }
    }
}
