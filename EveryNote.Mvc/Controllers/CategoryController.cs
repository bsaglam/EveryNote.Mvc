using EveryNote.BussinessLayer;
using EveryNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return PartialView("_PartialCategories",list);
        }
    }
}