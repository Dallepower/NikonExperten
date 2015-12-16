using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace RepoNE
{
    public class ProduktFac : AutoFac<Produkt>
    {
        KategoriFac katFac = new KategoriFac();

        public ProduktListe GetProduktListe(int katID)
        {
            ProduktListe pl = new ProduktListe();
            pl.Kategori = katFac.GetAll();
            pl.Produkter = GetBy("KatID", katID);
            return pl;
        }

    }

}
