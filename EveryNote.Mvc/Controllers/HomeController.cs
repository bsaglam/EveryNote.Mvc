﻿using EveryNote.BussinessLayer;
using EveryNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EveryNote.Mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //if (TempData["notes"] != null)
            //{
            //    return View(TempData["notes"] as List<Notes>);
            //}
            NoteManager nm = new NoteManager();
            List<Notes> notes = nm.GetAllNotes();
            return View(notes.OrderByDescending(x=>x.ModifiedOn).ToList());
        }

        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryManager cm = new CategoryManager();
            Categories cat = cm.GetCategoryById(id.Value);

            if (cat == null)
            {
                return HttpNotFound();
            }
             
            return View("Index", cat.Notes);
        }
        

        public ActionResult MostLiked()
        {
            NoteManager nm = new NoteManager();
           
            return RedirectToAction("Index", nm.GetAllNotes().OrderByDescending(x => x.LikeCounts).ToList());
        }

        public ActionResult About()
        {
            

            return View();
        }

    }
}