using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Doan.Models;
using Doan.ViewModel;

namespace Doan.Controllers
{
    public class ShoppingCartController : Controller
    {
        DoanDbContext db=new DoanDbContext();
        // GET: ShoppingCart
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart == null|| Session["Cart"]==null)
            {
                cart = new Cart();
                Session["Cart"]=cart;
            }
            return cart;
        }
        //phương thức add
        public ActionResult AddtoCart(int id)
        {
            var pro = db.Products.SingleOrDefault(s => s.Id == id);
            if(pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        //trang giỏ hàng
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "ShoppingCart");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["ID_Product"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity_Shopping(id_pro, quantity);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int _t_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if(cart != null)
            {
                _t_item = cart.Total_Quantity();
            }
            ViewBag.infoCart = _t_item;
            return PartialView("BagCart");
        }
        public ActionResult Shopping_Success()
        {
            return View();
        }
        Login ur = new Login();
        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                Oder _order = new Oder();
                _order.Name = form["CodeCustomer"];
                _order.Careated_At = DateTime.Now;
                _order.Address = form["Address"];
                db.Oders.Add(_order);
                foreach (var item in cart.Items)
                {
                    OderDetail _order_Detail = new OderDetail();
                    _order_Detail.OderId = _order.Id;
                    _order_Detail.ProductId = item._shopping_product.Id;
                    _order_Detail.Price = item._shopping_product.Price;
                    _order_Detail.Number = item._shopping_quantity;
                    db.OderDetails.Add(_order_Detail);
                }
                db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("Shopping_Success", "ShoppingCart");
            }
            catch
            {
                return Content("Lỗi!!! Vui lòng kiểm tra lại");
            }

        }
    }
}