using MVC_03.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_03.Controllers
{
    public class CategoriesController : Controller
    {
        private DBSportStoreEntities db = new DBSportStoreEntities();

        [ChildActionOnly]
        public PartialViewResult CategoryPartial()
        {
            var cateList = db.Categories.ToList();
            return PartialView(cateList);
        }
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }
    }
}