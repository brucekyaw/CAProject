using CAProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Security.Permissions;
using System.Text.Json;

namespace CAProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly OnlineshopDBContext db;
        List<Product> productList = new List<Product>();
        Dictionary<int, int> cartList = new Dictionary<int, int>();


        public HomeController(OnlineshopDBContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            Response.Cookies.Append("SessionCart", JsonSerializer.Serialize(cartList));
            string? sessionId = Request.Cookies["SessionId"];
            string? currentUser = Request.Cookies["currentUsername"];

            ViewBag.currentUser = currentUser;                        
            GenerateProduct();
            return View();
        }
        public IActionResult Search(string keyword) 
        {

            string? currentUser = Request.Cookies["currentUsername"];


            if (productList.Count==0 && string.IsNullOrEmpty(keyword))
            {
               return RedirectToAction("Index","Home");
            }
            else 
            { 
            productList = db.Products.Where(x =>
            x.ProductDescription.Contains(keyword)).ToList();
            ViewBag.productList = productList;
            ViewBag.keyword = keyword;
            ViewBag.currentUser = currentUser;
            return View("Index");                
            }      
        }

        public IActionResult Logout()
        {
            string? currentUser = Request.Cookies["CurrentUsername"];

            User? user = db.Users.FirstOrDefault(x => x.Username == currentUser);
            user.SessionId = null;
            db.SaveChanges();
            Response.Cookies.Delete("SessionId");
            Response.Cookies.Delete("CurrentUsername");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Cart()
        {
            Dictionary<int, int> productList = JsonSerializer.Deserialize<Dictionary<int,int>>(Request.Cookies["SessionCart"]);
            return View("Cart");
        }

        public IActionResult AddToCart(int productId)
        {
            int quantity=0;
            Product? product = db.Products.FirstOrDefault(x=>x.ProductId == productId);

            cartList = JsonSerializer.Deserialize<Dictionary<int, int>>(Request.Cookies["SessionCart"]);

            if (cartList.ContainsKey(productId))
            {
                cartList[productId] += 1;
            }
            else
            {
                cartList.Add(product.ProductId, 1);
            }

            foreach(KeyValuePair<int,int> item in cartList)
            {
                quantity += item.Value;
            }


            Response.Cookies.Append("SessionCart", JsonSerializer.Serialize(cartList));


            return Json(new 
            {   quantity = quantity
            });
        }

        public IActionResult MyPurchase()
        {

            return View("MyPurchase");
        }
        public void GenerateProduct()
        {
            productList = db.Products.ToList<Product>();
            ViewBag.productList = productList;
        }

    }
}