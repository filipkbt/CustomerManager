using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Customer_manager.Models
{
    public class AddressModel
    {
        [Key, ForeignKey("CustomerId")]
        public int Id { get; set; }

        public virtual CustomerModel CustomerId { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string HouseNumber { get; set; }

        public int? FlatNumber { get; set; }
    }
}