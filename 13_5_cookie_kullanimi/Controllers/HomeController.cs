using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _13_5_cookie_kullanimi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            HttpCookie cookie = new HttpCookie("username", "ssolmaz");

            //cookie.Expires = DateTime.Now.AddDays(1);

            HttpContext.Response.Cookies.Add(cookie);

            return View();

        }

        public ActionResult Index2()
        {
            if (HttpContext.Request.Cookies["username"] != null)  //cookie varsa
            {
                TempData["Username"]= HttpContext.Request.Cookies["username"].Value;
               
            }

            else
            {
                TempData["Username"] = "Cookie tanimlanmamistir.";
            }
            return View();
        }

        public ActionResult Index3()
        {
            if (HttpContext.Request.Cookies["username"] != null)  //cookie varsa
            {
                //HttpContext.Request.Cookies.Remove("username");
                HttpContext.Response.Cookies["username"].Expires = DateTime.Now.AddSeconds(2);   //cookie otomatik silinir.
            }
            return View();
        }
    }
}