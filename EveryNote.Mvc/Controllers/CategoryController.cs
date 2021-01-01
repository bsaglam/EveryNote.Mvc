using EveryNote.BussinessLayer;
using EveryNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EveryNote.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult CategoryPartial()
        {
            CategoryManager cm = new CategoryManager();

            List<Categories> list = cm.ListCategories();
            return PartialView("_PartialCategories", list);
        }

        //public ActionResult Select(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CategoryManager cm = new CategoryManager();
        //    Categories cat = cm.GetCategoryById(id.Value);

        //    if (cat == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    TempData["notes"] = cat.Notes;
        //    return RedirectToAction("Index","Home");
        //}
    }
}