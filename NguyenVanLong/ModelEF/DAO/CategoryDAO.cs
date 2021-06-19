using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDAO
    {
        private NguyenVanLongContext db = null;
        public CategoryDAO()
        {
            db = new NguyenVanLongContext();
        }

        public bool Insert(Category entityCat)
        {
            db.Categories.Add(entityCat);
            db.SaveChanges();
            return true;
        }

        public Category Find(string categoryID)
        {
            return db.Categories.Find(categoryID);
        }

        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }

        //public bool Update(Category entityCat)
        //{
        //    try
        //    {
        //        var catID = Find(entityCat.Id_Category);
        //        if (!string.IsNullOrEmpty(entityCat.Name_Category))
        //        {
        //            catID.Name_Category = entityCat.Name_Category;
        //        }
        //        if (entityCat.Id_Category == null)
        //        {
        //            catID.Id_Category = entityCat.Id_Category;
        //        }
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public bool Delete(string Id_Category)
        {
            try
            {
                Category category = db.Categories.Find(Id_Category);
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        //public IEnumerable<Category> ListWhereAll(string searchKey, int page, int pageSize)
        //{
        //    IQueryable<Category> model = db.Categories;
        //    if (!string.IsNullOrEmpty(searchKey))
        //    {
        //        model = model.Where(x => x.Name_Category.Contains(searchKey));
        //    }
        //    return model.OrderBy(x => x.Id_Category);
        //}
    }
}
