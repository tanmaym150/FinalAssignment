using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinalAssignment.DAL.Data.Model
{
  public  class Product
    {
        public Product()
        {
            Assets = new HashSet<Asset>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductType { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<Asset> Assets { get; set; }


    }
}
