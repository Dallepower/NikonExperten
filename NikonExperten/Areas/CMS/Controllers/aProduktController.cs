using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoNE;
using System.IO;
using RepoNE.Models.ViewModels;
namespace NikonExperten.Areas.CMS.Controllers
{
    public class aProduktController : Controller
    {
        Uploader u = new Uploader();
        KategoriFac kf = new KategoriFac();
        ProduktFac pf = new ProduktFac();
        
        public ActionResult Add()
        {
            return View(kf.GetAll());
        }

        public ActionResult AddResult(Produkt prod, HttpPostedFileBase fil)
        {
            if (fil != null)
            {
                string path = Request.PhysicalApplicationPath + "/Content/images/";
                prod.Billede = Path.GetFileName(u.UploadImage(fil, path, 300, true));
            }
            else
            {
                prod.Billede = "PaaVej.jpg";
            }
            pf.Insert(prod);
            ViewBag.MSG = "Produktet er oprettet!";
            return View("Add", kf.GetAll());
        }

        public ActionResult Edit()
        {
            EditProduct ep = new EditProduct();
            ep.Kategorier = kf.GetAll();
            return View(ep);
        }

        public ActionResult EditList(int KatID)
        {
            EditProduct ep = new EditProduct();
            ProduktListe pl = new ProduktListe();
            ep.Kategorier = kf.GetAll();
            pl.Produkter = pf.GetBy("KatID", KatID);
            pl.Kategori = kf.Get(KatID);
            ep.Produktliste = pl; 

            return View("Edit", ep);
        }
    }
}