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
        [Display(Name = "Asset Number")]
        public string AssetNo { get; set; }
        [Display(Name = "Model Number")]
        public string ModelNo { get; set; }
        [Display(Name = "Serial Number")]
        public string SerialNo { get; set; }
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }
        [Display(Name = "Purchase price")]
        public int PurchasePrice { get; set; }
        [Display(Name="EST Service Life (Years)")]
        public int EstServiceLife { get; set; }
        [Display(Name = "BER Maintainance Cost")]
        public int BER_Maintainance_Cost { get; set; }
       
        public bool Warranty { get; set; }
        [Display(Name = "Expiry Date")]
        public DateTime? ExpiryDate { get; set; }

        

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("Assets")]
        public virtual Product Product { get; set; }

        [ForeignKey(nameof(FacilityId))]
        [InverseProperty("Assets")]
        public virtual Facility Facility { get; set; }
        
    }
}
