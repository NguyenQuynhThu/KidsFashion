using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidsFashion.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("Category")]
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}