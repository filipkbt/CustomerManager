using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Customer_manager.Models
{
    public class DbContextModel : DbContext
    {
        public DbSet<CustomerModel> Customers { get; set; }

        public DbSet<AddressModel> Addresses { get; set; }
    }
}