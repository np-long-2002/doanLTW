using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doan.Models
{
    public class Product
    {
        public Product()
        {
            Image = "~/Content/ProductImg/add.png";
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public int CatId { get; set; }
        public int Type { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Careated_At { get; set; }
        public int? Updated_By { get; set; }
        public DateTime? Updated_At { get; set; }
        public int Status { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpLoad { get; set; }
    }
}