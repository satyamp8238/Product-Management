﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategory.Domain.Model
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        [Required] public string Name { get; set; }
        public string? Description { get; set; }
        //public ICollection<Product> Products { get; set; }
    }

}
