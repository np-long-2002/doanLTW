using Doan.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        DoanDbContext db = new DoanDbContext();
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Products.Where(r=>r.Id==id).FirstOrDefault());
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            Product pro= new Product();
            return View(pro);
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            try
            {
                if (pro.ImageUpLoad != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(pro.ImageUpLoad.FileName);
                    string extension= Path.GetExtension(pro.ImageUpLoad.FileName); 
                    fileName = fileName + extension;
                    pro.Image = "~/Content/ProductImg/" + fileName;
                    pro.Updated_At = DateTime.Now;
                    pro.Careated_At= DateTime.Now;
                    pro.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/ProductImg/"), fileName));
                }
                db.Products.Add(pro);
                db.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.Products.Where(r => r.Id == id).FirstOrDefault());
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Product pro)
        {
            try
            {
                if (pro.ImageUpLoad != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(pro.ImageUpLoad.FileName);
                    string extension = Path.GetExtension(pro.ImageUpLoad.FileName);
                    fileName = fileName + extension;
                    pro.Image = "~/Content/ProductImg/" + fileName;
                    pro.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/ProductImg/"), fileName));
                }
                db.Entry(pro).State=System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Products.Where(r => r.Id == id).FirstOrDefault());
        }

        // POST: Admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product pro)
        {
            try
            {
                pro=db.Products.Where(r => r.Id == id).FirstOrDefault();
                db.Products.Remove(pro);
                db.SaveChanges();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ChoseCat()
        {
            Category cat=new Category();    
            cat.CatCollection=db.Categories.ToList<Category>();
            return PartialView(cat);
        }
    }
}
