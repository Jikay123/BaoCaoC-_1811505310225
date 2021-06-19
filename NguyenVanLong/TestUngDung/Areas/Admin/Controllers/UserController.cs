using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var user = new UserDAO();

            if (!string.IsNullOrEmpty(searchString))
            {
                var model = user.ListWhereAll(searchString, page, pageSize);
                ViewBag.SearchString = searchString;
                return View(model.ToPagedList(page, pageSize));
            }
            else
            {
                var model = user.ListAll();
                return View(model.ToPagedList(page, pageSize));
            }
        }

       
        [HttpPost]
        public ActionResult Status(string ID)
        {
            
            new UserDAO().Status(ID);
            return RedirectToAction("Index");

        }
       
        [HttpDelete]
        public ActionResult Delete(string ID)
        {
            var dao = new UserDAO();
            var kq = dao.Delete(ID);
            if (kq == true)
            {
                setAlert("Xóa thành công", "success");
            }else
            {
                setAlert("Không thể xóa tài khoản activate", "error");
            }

            return RedirectToAction("Index");
        }

       
    }
}