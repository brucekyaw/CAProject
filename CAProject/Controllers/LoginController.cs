using CAProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CAProject.Controllers;

public class LoginController : Controller
{
    private readonly OnlineshopDBContext db;


    public LoginController(OnlineshopDBContext db) 
    {
        this.db = db;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Validate(string username, string password)
    {
        string? sessionId = Request.Cookies["SessionId"];
        string? currentUsername = Request.Cookies["currentUsername"];

        if (sessionId != null) 
        {          
            User? session = db.Users.FirstOrDefault(x => x.SessionId == sessionId);

            if(session != null)
            {
                return RedirectToAction("Index", "Home");
            }
        }
      

       if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) 
       {
            return View("Index");
       }

       User? user = db.Users.FirstOrDefault(x=> x.Username == username && x.Password== password);
        if(user == null) 
        {
            return View("Index");
        }
        Dictionary<int, int> cartList = new Dictionary<int, int>();
        sessionId = new Guid().ToString();
        user.SessionId = sessionId;
        db.SaveChanges();
        currentUsername = user.Username;
        Response.Cookies.Append("SessionId", sessionId);
        Response.Cookies.Append("currentUsername", currentUsername);
        return RedirectToAction("Index", "Home");
    }
}