using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
using PagedList;

namespace ModelEF.DAO
{
    public class ProductDAO
    {
        private NguyenVanLongContext db = null;
        public ProductDAO()
        {
            db = new NguyenVanLongContext();
        }


        public bool Insert(Product entityProduct)
        {
            try
            {

                db.Products.Add(entityProduct);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(Product entityProduct)
        {
            try
            {
                var product = Find(entityProduct.ID);
                product.Name = entityProduct.Name;
                product.UnitCost = entityProduct.UnitCost;
                product.Quantity = entityProduct.Quantity;
                product.Image = entityProduct.Image;
                product.Status = entityProduct.Status;
                product.CategoryID = entityProduct.CategoryID;
                product.Description = entityProduct.Description;
    
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Delete(string Id_Product)
        {
            try
            {
                Product product = db.Products.Find(Id_Product);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }


        public Product Find(string Id_Product)
        {
            return db.Products.Find(Id_Product);
        }

        public List<Product> ListAll()
        {
            return db.Products.OrderBy(x => x.Quantity).ThenByDescending(x => x.UnitCost).ToList();
        }

        public IEnumerable<Product> ListWhereAll(string searchKey, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchKey))
            {
                model = model.Where(x => x.Name.Contains(searchKey));
            }
            return model.OrderBy(x => x.Quantity).ThenByDescending(x => x.UnitCost);
        }
    }
}

