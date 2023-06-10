using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doan.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Careated_At { get; set; }
        public int? Updated_By { get; set; }
        public DateTime? Updated_At { get; set; }
        [NotMapped]
        public List<Category> CatCollection { get; set; }
    }
}