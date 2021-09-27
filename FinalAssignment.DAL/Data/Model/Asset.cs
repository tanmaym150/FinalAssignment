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
        [Required]
        public string Name { get; set; }
        [Required]
        public string  Description { get; set; }
        [Required]
        [Display(Name="Product Type")]
        public int ProductId { get; set; }
        [Required]

        [Display(Name="Facility")]
        public int FacilityId { get; set; }
        [Required]
        public string  Location { get; set; }
        [Required]
        [Display(Name = "Asset Number")]
        
        public string AssetNo { get; set; }
        [Required]
        [Display(Name = "Model Number")]
       
        public string ModelNo { get; set; }
        [Required]
        [Display(Name = "Serial Number")]
        public string SerialNo { get; set; }
        [Required]
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }
        [Required]
        [Display(Name = "Purchase price")]
        public int PurchasePrice { get; set; }
        [Required]
        [Display(Name="EST Service Life (Years)")]
        public int EstServiceLife { get; set; }
        [Required]
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
