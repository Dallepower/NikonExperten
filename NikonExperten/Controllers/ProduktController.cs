using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoNE;

namespace NikonExperten.Controllers
{
    public class ProduktController : Controller
    {
        ProduktFac prodFac = new ProduktFac();

        // GET: Produkt
        public ActionResult Produkter()
        {
            return View();
        }

        public ActionResult KategoriVisning(int id=1)
        {
            return View(prodFac.GetProduktListe(id));
        }

    }
}