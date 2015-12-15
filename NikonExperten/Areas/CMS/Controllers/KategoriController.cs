﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoNE;
using RepoNE.Models.BaseModels;
namespace NikonExperten.Areas.CMS.Controllers
{
    public class KategoriController : Controller
    {
        private KategoriFac katFac = new KategoriFac();
        // GET: CMS/Kategori
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NyKategori()
        {
            return View();
        }

        public ActionResult AddKat(Kategori kat)
        {
            if (ModelState.IsValid)
            {
                katFac.Insert(kat);
                ViewBag.MSG = "Kategorien er oprettet!";
            }
            else
            {
                ViewBag.MSG = "Udfyld alle felter!!!";
            }
            return View("NyKategori");
            
        }

        public ActionResult Edit()
        {
            return View(katFac.GetAll());
        }

        public ActionResult EditForm(int id)
        {
            return View(katFac.Get(id));
        }

        [HttpPost]
        public ActionResult EditResult(Kategori kat)
        {
            if (ModelState.IsValid)
            {
                katFac.Update(kat);
            }

            return RedirectToAction("Edit");
        }

        public ActionResult Delete(int id)
        {
            katFac.Delete(id);
            return RedirectToAction("Edit");
        }

    }
}