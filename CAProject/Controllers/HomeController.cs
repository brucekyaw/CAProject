using CAProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CAProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly OnlineshopDBContext db;
        List<Products> productList = new List<Products>();

        public HomeController(OnlineshopDBContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
           /* db.Add(new Products
            {
                ProductName = "Microsoft Home & Student 2021",
                ProductImg = "/img/microsoft-office-student.jpg",
                ProductDescription = "For students and families who want classic Office apps installed on one PC or Mac for use at home or school.",
                ProductPrice = 139,
                ProductRating = 4.5
            });
            db.Add(new Products
            {
                ProductName = "Adobe Acrobat Pro 2020 Mac OS",
                ProductImg = "/img/adobe-acrobat-pro-2020.jpg",
                ProductDescription = "With Adobe Acrobat Pro 2020, you can create, edit, fill, sign, and prepare your PDFs on Windows and Mac.",
                ProductPrice = 142,
                ProductRating = 4.2
            });

            db.Add(new Products
            {
                ProductName = "Kaspersky Total Security 2023",
                ProductImg = "/img/kaspersky-total-security-2023.jpg",
                ProductDescription = "Kaspersky Total Security gives you a smarter way to protect your family’s digital world—on your PC, Mac and mobile devices. Along with award-winning protection for your privacy, money, communications and identity, it includes an easy-to-use password manager and extra security for your family’s precious photos, music and files. You also get powerful tools that do more to help you to keep your children safe—online and beyond. ",
                ProductPrice = 14.99,
                ProductRating = 4.7
            });

            db.Add(new Products
            {
                ProductName = "Adobe Photoshop Elements 2023",
                ProductImg = "/img/adobe-photoshop-elements-2023.jpg",
                ProductDescription = "From simple tweaks and trims to advanced artistic options and effects, it’s never been easier to create beautiful, awe-inspiring photos and videos. With Adobe Sensei Artificial Intelligence, bring motion to your photos and click once to transform your videos with effects inspired by famous works of art. Add depth to photos with peek-through overlays, and showcase your memories with new collage and slideshow templates. Plus, go beyond your desktop with new web and mobile companion apps (English-only beta), and enjoy faster installation and performance plus Apple M1 chip support. Have fun with the easy picture editor and moviemaker for Mac and Windows.",
                ProductPrice = 99.99,
                ProductRating = 4.1
            });

            db.Add(new Products
            {
                ProductName = "VideoStudio Ultimate 2021",
                ProductImg = "/img/videostudio-ultimate-2021.jpg",
                ProductDescription = "Corel VideoStudio Ultimate 2021 makes it fun and easy to produce your best videos yet, with streamlined tools and new creative extras. Explore hundreds of drag-and-drop graphics, titles and transitions, and more than 2,000 visual effects—including exclusive collections from industry leaders. Recreate popular video styles and edit videos for social media in minutes with new Instant Project Templates—even add personality and enhance reactions with brand-new AR Stickers!",
                ProductPrice = 69.69,
                ProductRating = 3.8
            });
            db.SaveChanges();*/

            productList = db.Products.ToList<Products>();
            ViewBag.productList = productList;


            return View();
        }
        [Route("Search/{keyword?}")]
        public IActionResult Search(string keyword) 
        {
            if(productList.Count==0 && string.IsNullOrEmpty(keyword))
            {
                productList = db.Products.ToList<Products>();
            }
            else { 
            productList = db.Products.Where(x =>
            x.ProductDescription.Contains(keyword)).ToList();
            }

            ViewBag.productList = productList;
            ViewBag.keyword = keyword;

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}