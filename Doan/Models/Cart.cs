﻿using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan.Models
{
    public class CartItem
    {
        public Product _shopping_product { get; set; }
        public int _shopping_quantity { get; set; }
    }
    //Giỏ hàng
    public class Cart
    {
        List<CartItem> items=new List<CartItem>();
        public IEnumerable<CartItem> Items
            { get { return items; } }
        public void Add(Product _pro,int _quantity =1)
        {
            var item=items.FirstOrDefault(s=>s._shopping_product.Id==_pro.Id);
            if(item==null)
            {
                items.Add(new CartItem
                {
                    _shopping_product = _pro,
                    _shopping_quantity = _quantity
                });
            }
            else
            {
                item._shopping_quantity += _quantity;
            }
        }
        public void Update_Quantity_Shopping(int id,int _quantity)
        {
            var item = items.FirstOrDefault(s=>s._shopping_product.Id==id);
            if( item!=null)
            {
                item._shopping_quantity= _quantity;
            }
        }
        public double Total_Money()
        {
            var total = items.Sum(s=>s._shopping_product.Price*s._shopping_quantity);
            return (double)total;
        }
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s=>s._shopping_product.Id==id);
        }
        public int Total_Quantity()
        {
            return items.Sum(s => s._shopping_quantity);
        }
        public void ClearCart()
        {
            items.Clear();
        }
    }
}