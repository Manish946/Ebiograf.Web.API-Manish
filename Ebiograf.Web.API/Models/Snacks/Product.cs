﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Models.Snacks
{
    public class Product
    {
        [Key] // DataAnnotations used to declare that it is a primary key.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Creating a Auto incremented ID - sql example(Identity(1,1))
        [Column(TypeName = "int")]
        [Required]
        public int ProductID { get; set; }
        [Column(TypeName = "nvarchar(512)")]
        [Required]
        public string Name { get; set; }


        [Column(TypeName = "decimal")]
        [Required]
        public decimal Price { get; set; }

        [Column(TypeName = "nvarchar(512)")]
        [Required]
        public string Description { get; set; }

        // Navigation properties for product.
        public ICollection<OrderSnack> OrderSnacks { get; set; }
    }
}
