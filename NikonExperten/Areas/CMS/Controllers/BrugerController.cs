using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Web.Security;
using RepoNE;

namespace NikonExperten.Areas.CMS.Controllers
{
    public class BrugerController : Controller
    {
        BrugerFac bf = new BrugerFac();
        // GET: CMS/Bruger
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string Navn, string Adgangskode)
        {
            Bruger bruger = bf.Login(Navn.Trim(), Crypto.Hash(Adgangskode.Trim()));

            if (bruger.ID > 0)
            {
                FormsAuthentication.SetAuthCookie(bruger.ID.ToString(), false);

                Session["UserID"] = bruger.ID;
                Session["Level"] = bruger.Level;
                Session.Timeout = 120;
                return Redirect("/CMS/Bruger/Secret/");
            }
            else
            {
                ViewBag.MSG = "Brugeren blev ikke fundet!!!";
                return View("Index");
            }
        }

        [Authorize]
        public ActionResult Secret()
        {
            return View();
        }

    }
}