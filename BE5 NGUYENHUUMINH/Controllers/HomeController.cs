using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BE5_NGUYENHUUMINH.Models;
using BE5_NGUYENHUUMINH.Models.ViewModle;
namespace BE5_NGUYENHUUMINH.Controllers
{
    public class HomeController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();
        public ActionResult Index(string SearchTerm, int? page)
        {
            var model = new HomeProductVM();
            var product = db.Products.AsQueryable();
            if(!string.IsNullOrEmpty(SearchTerm))
            {
                model.SearchTerm = SearchTerm;
                product = product.Where(p =>
                p.ProductName.Contains(SearchTerm) ||
                product.ProductDecription.Contains(SearchTerm) ||
                product.Category.CategoryName.Contains(SearchTerm));
            }
            int pageNumber = page ?? 1;
            int pageSize = 6;
            model.FeaturedProduct = product.OderByDescending(p => p.OderDetails.Sum()).Take(10).ToList();
            model.NewProduct = product.OderBy(p => p.OderDetails.Count());
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // GET: Home/ProductDetails/5
        public ActionResult ProductDetails(int? id, int? quantity, int? page)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product pro = db.Products.Find(id);
            if (pro == null)
            {
                return HttpNotFound();
            }

            // lấy tất cả các sản phẩm cùng danh mục
            var products = db.Products.Where(p => p.CategoryID == pro.CategoryID && p.ProductID != pro.ProductID).AsQueryable();

            ProductDetailsVM model = new ProductDetailsVM();

            // Đoạn code liên quan tới phân trang
            // Lấy số trang hiện tại (mặc định là trang 1 nếu không có giá trị)
            int pageNumber = page ?? 1;
            int pageSize = model.PageSize; // Số sản phẩm mỗi trang
            model.product = pro;
            model.RelatedProducts = products.OrderBy(p => p.ProductID).Take(8).ToPagedList(pageNumber, pageSize);
            model.TopProducts = products.OrderByDescending(p => p.OrderDetails.Count()).Take(8).ToPagedList(pageNumber, pageSize);

            if (quantity.HasValue)
            {
                model.quantity = quantity.Value;
            }

            return View(model);
        }
    }
}