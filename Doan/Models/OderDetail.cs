using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Doan.Models
{
    public class OderDetail
    {
        [Key]
        public int Id { get; set; }
        public int OderId { get; set; }
        public int ProductId { get; set; }
        public int Number { get; set; }
        public double Price { get; set; }
    }
}