using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using TestUngDung.Common;
using PagedList;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product.

        //[HttpGet]
        //public ActionResult Index()
        //{
        //    var product = new ProductDAO();
        //    var model = product.ListAll();
        //    return View(model);
        //}

        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
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

        [HttpGet]
        public ActionResult Detail()
        {
            var value = Request["Id_Product"];
            var dao = new ProductDAO();
            var kq = dao.Find(value);
            if (kq != null)
                return View(kq);
            return RedirectToAction("Index", "Product");
        }


        [HttpGet]
        public ActionResult Create()
        {
            setViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new ProductDAO();
                    var kq = dao.Insert(product);
                    if (kq == true)
                    {
                        setAlert("Tạo mới sản phẩm thành công", "success");
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        setViewBag();
                        setAlert("Tạo mới sản phẩm  không thành công", "error");
                        return RedirectToAction("Create", "Product");
                    }
                }
                else
                {
                    setViewBag();
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    return View(product);
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
                return View(product);
            }
           
        }

        [HttpGet]
        public ActionResult Edit(string Id_Product)
        {
            setViewBag();
            var value = Request["Id_Product"];
            var dao = new ProductDAO();
            var kq = dao.Find(value);
            if (kq != null)
                return View(kq);
            return View();
        }


        [HttpPost]
        public ActionResult Edit(Product product)
        {

            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();
                if (string.IsNullOrEmpty(product.Name) && string.IsNullOrEmpty(product.UnitCost.ToString()) && string.IsNullOrEmpty(product.Quantity.ToString()))
                {
                    setAlert("Thông tin không được cập nhật trống", "error");
                    return RedirectToAction("Edit", "Product");
                }
                var kq = dao.Update(product);
                if (kq == true)
                {
                    setAlert("Cập nhật sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    setAlert("Cập nhật sản phẩm không thành công", "error");
                    return RedirectToAction("Edit", "Product");
                }
            }
            setViewBag();
            return View();
        }



        [HttpPost]
        public ActionResult Delete(string Id_Product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var value = Request["Id_Product"];

            var kq = new ProductDAO().Delete(Id_Product);
            if(kq == true)
            {
                setAlert("Xóa sản phẩm thành công", "success");
                return View();
            }
            setAlert("Xóa sản phẩm không thành công", "warning");
            return View();
            
        }


        public void setViewBag(long? selectedId = null)
        {
            var dao = new CategoryDAO();
            ViewBag.ID = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
    }
}
