using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CASCADINGDROPDOWNLIST.Models
{
    [Table("Country")]
    public class CountryModel
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}