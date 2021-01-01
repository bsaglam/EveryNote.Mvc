using EveryNote.BussinessLayer;
using EveryNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EveryNote.Mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (TempData["notes"] != null)
            {
                return View(TempData["notes"] as List<Notes>);
            }
            NoteManager nm = new NoteManager();
            List<Notes> notes = nm.GetAllNotes();
            return View(notes);
        }
    }
}