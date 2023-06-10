using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doan.Models;

namespace Doan.Controllers
{
    public class ProductController : Controller
    {
        DoanDbContext db = new DoanDbContext();
        // GET: Product
        public ActionResult Index(string search="")
        {
            ViewBag.Search = search;
            return View(db.Products.Where(r=>r.Name.Contains(search)).ToList());
        }
        public ActionResult Detail(int id)
        {
            return View(db.Products.Where(r => r.Id == id).FirstOrDefault());
        }
    }
}