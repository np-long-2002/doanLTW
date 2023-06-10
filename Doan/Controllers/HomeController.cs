using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doan.Models;

namespace Doan.Controllers
{
    public class HomeController : Controller
    {
        DoanDbContext db = new DoanDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
    }
}