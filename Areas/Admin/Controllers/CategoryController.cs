using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doan.Models;
using System.Data;
using System.IO;

namespace Doan.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        DoanDbContext db = new DoanDbContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Categories.Where(r => r.Id==id).FirstOrDefault());
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        public ActionResult Create(Category cat)
        {
            try
            {
                // TODO: Add insert logic here
                db.Categories.Add(cat);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int id )
        {
            return View(db.Categories.Where(r => r.Id == id).FirstOrDefault());
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category cat)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(cat).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Categories.Where(r => r.Id == id).FirstOrDefault());
        }

        // POST: Admin/Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category cat)
        {
            try
            {
                cat = db.Categories.Where(r => r.Id == id).FirstOrDefault();
                db.Categories.Remove(cat);
                db.SaveChanges();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
