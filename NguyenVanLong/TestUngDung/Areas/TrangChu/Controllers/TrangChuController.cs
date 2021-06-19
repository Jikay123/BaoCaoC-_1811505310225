using ModelEF.DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.TrangChu.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: Admin/TrangChu
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 8)
        {
            var product = new ProductDAO();

            if (!string.IsNullOrEmpty(searchString))
            {
                var model = product.ListWhereAll(searchString, page, pageSize);
                ViewBag.SearchString = searchString;
                return View(model.ToPagedList(page, pageSize));
            }
            else
            {
                var model = product.ListAll();
                return View(model.ToPagedList(page, pageSize));
            }
        }
    }
}