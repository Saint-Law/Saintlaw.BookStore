using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Saintlaw.BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() 
        {
             ViewBag.Title = "saintlaw";

            return View();
        }
         
        public ViewResult AboutUs()
        {
            return View();
        }
        public ViewResult ContactUs() 
        {
            return View();
        }
    }
}
