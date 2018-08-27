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
        [Required(ErrorMessage = "This field is required.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string City { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Street { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string HouseNumber { get; set; }

        public int? FlatNumber { get; set; }
    }
}