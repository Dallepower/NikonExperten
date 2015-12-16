using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoNE;
using System.IO;

namespace NikonExperten.Areas.CMS.Controllers
{
    public class aProduktController : Controller
    {
        Uploader u = new Uploader();
        KategoriFac kf = new KategoriFac();
        private ProduktFac pf = new ProduktFac();
        // GET: CMS/aProdukt
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
    }
}