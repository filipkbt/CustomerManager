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

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
        [Required]
        public virtual AddressModel Address { get; set; }
    }
}