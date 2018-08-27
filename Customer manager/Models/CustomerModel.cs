using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Customer_manager.Models
{
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Phone]
        public string TelephoneNumber { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public virtual AddressModel Address { get; set; }
    }
}