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
            if (ModelState.IsValid)
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
                    return View(model);
                }
                //return RedirectToAction("RegisterOk");
                //RegisterOK sayfasına yönlendirmek yerine artık standart olan success sayfamıza yönlendirebiliriz.
                SuccessViewModel svm = new SuccessViewModel();
                return View("Success", svm);
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
                //TempData["errors"]= result.Errors; //ActivateUserCancel action'ı içinde kullanılıyordu.
                //return RedirectToAction("ActivateUsercancel");
                //bunun yerine de Hata ekranına yönlendirip hatayı standart hata ekranında göstermeliyiz.
                ErrorViewModel evm = new ErrorViewModel()
                {
                    Notifies = result.Errors
                };
               
                return View("Error", evm);
            }
            return RedirectToAction("Index");

        }

        public ActionResult ActivateUsercancel()
        {
            List<ErrorMessage> errorList= TempData["errors"] as List<ErrorMessage>;
            return View(errorList);

        }

        
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
        
        public ActionResult ShowProfile()
        {
            Users user = Session["user"] as Users;
            UserManager um = new UserManager();
            BussinessLayerResult<Users> result = um.ShowProfile(user.Id);
            if (result.Errors.Count > 0)
            {
                ErrorViewModel evm = new ErrorViewModel()
                {
                    Notifies = result.Errors
                };
                return View("Error", evm);
            }
            return View(result.Model);
        }


        public ActionResult EditUser()
        {
            //Bu sayfa açılırken Session'da olan kullanıcının verileri ile açılacak.
            //Session'dan veriyi al
            Users user = new Users();
            user = Session["user"] as Users;
            //BL'da Kullanıcı verilerini getir.
            BussinessLayerResult<Users> result = new BussinessLayerResult<Users>();
            UserManager um = new UserManager();
            result=um.GetUserById(user.Id);

            if (result.Errors.Count>0)
            {
                ErrorViewModel notifyList = new ErrorViewModel()
                {
                    Notifies = result.Errors,
                    RedirectingUri="/Home/EditUser"
                };
               

                return View("Error",notifyList);
            }

            EditUserViewModel model = new EditUserViewModel()
            {   Id=result.Model.Id,
                FirstName = result.Model.FirstName,
                EMail = result.Model.EMail,
                ImageFilePath= result.Model.ImageFilePath,
                LastName = result.Model.LastName,
                Password = result.Model.Password,
                UserName=result.Model.UserName
            };
            
            return View(model);
        }

        [HttpPost]
        public ActionResult EditUser(EditUserViewModel model, HttpPostedFileBase UserImageName)
        {
            //gelen image 'ın tipi kontrol edilecek,
            //gelen image göre filename oluşturulacak
            //server'a kaydedilecek. //kaydetme sırasında hata olursa burdan hata döndür.
            // TODO : (aslında en güzeli bu işin BL'da yapılması.)
            //server'a kayıttan sonra BL'dan Update metodu çağrılmalı.
            BussinessLayerResult<Users> result = new BussinessLayerResult<Users>();
            UserManager um = new UserManager();
            result = um.UpdateUser(model);
            if (result.Errors.Count>0)
            {
                ErrorViewModel notifyList = new ErrorViewModel()
                {
                    Notifies = result.Errors,
                    RedirectingUri="/Home/EditProfile"
                };

                return View("Error",notifyList);
            }
            //Hata varsa hata ekranına gönderilmeli
            //hata yoksa ShowProfile sayfasına yönelendirilmeli
            //Session değer güncellenmelidir.
            Session["user"] = result.Model;
             
            return RedirectToAction("ShowProfile");
        }





    }
}