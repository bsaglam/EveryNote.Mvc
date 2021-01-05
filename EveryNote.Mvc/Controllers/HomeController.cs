using EveryNote.BussinessLayer;
using EveryNote.Entities;
using EveryNote.Entities.ErrorManager;
using EveryNote.Entities.ViewModels;
using EveryNote.Mvc.Models.Notifies;
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
            return View(notes.OrderByDescending(x => x.ModifiedOn).ToList());
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var mı kontrolü- 
                UserManager um = new UserManager();
                BussinessLayerResult<Users> result = um.LoginUser(model);
                if (result.Errors.Count > 0)
                {
                    result.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(model);
                }
                Session["user"] = result.Model; // kullanıcı var ise session'a at
                return RedirectToAction("Index"); //yönlendir
            }

            return View(model);
        }

        public ActionResult Register()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {   /*Bu işlerin Bussiness katmana ait orda yapılması gerekir.*/
                //username&email var mı kontrolü
                //yoksa kayıt işlemi
                //activasyon epostası
                /* Bu işler user ile ilgili olduğu için UserManager olşturalım.*/
                UserManager um = new UserManager();
                BussinessLayerResult<Users> blr = um.RegisterUser(model);
                if (blr.Errors.Count > 0)
                {
                    blr.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    ErrorViewModel evm = new ErrorViewModel();
                    foreach (var item in blr.Errors)
                    {
                        evm.Notifies.Add(new ErrorMessage() { ErrorCode = item.ErrorCode,Message=item.Message});
                    }

                    return View("Error", evm);
                }
                return View("Error", model);
            }

            //Eğer modalState hata içeriyorsa return View(model) ile kullanıcıdan gelen aynı model tekrar gönderilir.
            return View(model);

        }

        public ActionResult ActivateUser(Guid id)
        {
            //kullanıcıyı aktifleştirecek işlem BussinessLayerda yapılmalı.
            UserManager um = new UserManager();
            BussinessLayerResult<Users> result=um.ActivateUser(id);
            if (result.Errors.Count>0)
            {
                TempData["errors"]= result.Errors;
                return RedirectToAction("ActivateUsercancel");
            }
            return RedirectToAction("Index");

        }

        public ActionResult ActivateUsercancel()
        {
            List<ErrorMessage> errorList= TempData["errors"] as List<ErrorMessage>;
            return View(errorList);

        }

        public ActionResult RegisterOk()
        {
            return View();

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
        
        public ActionResult ShowProfile()
        {
            if (Session["user"] != null)
            {
                Users user = Session["user"] as Users;
                UserManager um = new UserManager();
                BussinessLayerResult<Users> result = um.ShowProfile(user.Id);
                if (result.Errors.Count > 0)
                {
                    //hata sayfasına yönlendirilecek.
                }
                return View(result.Model);
            }
            return RedirectToAction("Index"); // TODO : Hata sayfasına yöndendirilmeli.
        }
        

      
    }
}