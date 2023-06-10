using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Doan.Models
{
    public class Oder
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? Careated_At { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
    }
}