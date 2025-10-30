using MVC_03.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace MVC_03.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        private DBSportStoreEntities db = new DBSportStoreEntities();

        // GET: Products/ProductList
        public ActionResult ProductList(int? category, int? page, string SearchString, double min = double.MinValue, double max = double.MaxValue)
        {
            var products = new List<Product>
            {
                    new Product { ProductID = 1, NamePro = "Áo thun Polo", Price = 250000, CateID = 1 },
                    new Product { ProductID = 2, NamePro = "Áo khoác Nike", Price = 450000, CateID = 1 },
                    new Product { ProductID = 3, NamePro = "Quần jeans Nam", Price = 350000, CateID = 2 },
                    new Product { ProductID = 4, NamePro = "Giày Bitis Hunter", Price = 750000, CateID = 3 },
                    new Product { ProductID = 5, NamePro = "Áo sơ mi trắng", Price = 280000, CateID = 1 },
                    new Product { ProductID = 6, NamePro = "Quần short kaki", Price = 180000, CateID = 2 },
                    new Product { ProductID = 7, NamePro = "Túi đeo chéo", Price = 220000, CateID = 4 },
                    new Product { ProductID = 8, NamePro = "Mũ lưỡi trai", Price = 120000, CateID = 4 },
                    new Product { ProductID = 9, NamePro = "Váy xòe nữ", Price = 300000, CateID = 5 },
                    new Product { ProductID = 10, NamePro = "Áo hoodie", Price = 500000, CateID = 1 },
            };

            var productsQuery = products.AsQueryable();


            // Lọc theo loại sản phẩm
            if (category != null)
            {
                products = (List<Product>)products.Where(p => p.CateID == category);
            }

            // Lọc theo tên
            if (!string.IsNullOrEmpty(SearchString))
            {
                products = (List<Product>)products.Where(p => p.NamePro.Contains(SearchString));
            }

            // Lọc theo giá
            if (min >= 0 && max > 0)
            {
                products = (List<Product>)products.Where(p => (double)p.Price >= min && (double)p.Price <= max);
            }

            // Phân trang
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            return View(products.OrderBy(p => p.ProductID).ToPagedList(pageNumber, pageSize));
        }

    }
}