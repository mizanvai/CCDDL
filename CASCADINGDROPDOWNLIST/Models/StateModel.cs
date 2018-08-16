using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CASCADINGDROPDOWNLIST.Models
{
    [Table("State")]
    public class StateModel
    {
        [Key]
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string StateName { get; set; }
    }
}