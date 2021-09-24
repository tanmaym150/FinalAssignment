using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinalAssignment.DAL.Data.Model
{
    public class Facility
    {
        public Facility()
        {
            Assets = new HashSet<Asset>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Facility Type")]
        public string FacilityType { get; set; }
        [InverseProperty("Facility")]
        public virtual ICollection<Asset> Assets { get; set; }


    }
}
