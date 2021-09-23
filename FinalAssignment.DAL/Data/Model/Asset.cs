using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinalAssignment.DAL.Data.Model
{
   public class Asset
    {
        [Key]
        public int AssetId { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }

        [Display(Name="Product Type")]
        public int ProductId { get; set; }

        [Display(Name="Facility")]
        public int FacilityId { get; set; }

        public string  Location { get; set; }

        public int AssetNo { get; set; }
        public int ModelNo { get; set; }
        public int SerialNo { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int PurchasePrice { get; set; }
        public int EstServiceLife { get; set; }
        public int BER_Maintainance_Cost { get; set; }
        public int MyProperty { get; set; }
        public bool Warranty { get; set; }
        public DateTime? ExpiryDate { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("Asset")]
        public virtual Product Product { get; set; }

        [ForeignKey(nameof(FacilityId))]
        [InverseProperty("Asset")]
        public virtual Facility Facility { get; set; }
        
    }
}
