using Customer_manager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Customer_manager.Infrastructure
{
    public static class CustomerManager
    {
        public static IEnumerable<CustomerModel> GetAllCustomers()
        {
            using (DbContextModel db = new DbContextModel())
            {
                try
                {
                    var customers = db.Customers.Include("Address").ToList();
                    return (customers);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static bool AddNewCustomer(CustomerModel customer)
        {
            try
            {
                using (DbContextModel db = new DbContextModel())
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        public static bool DeleteCustomer(int id)
        {
            try
            {
                using (DbContextModel db = new DbContextModel())
                {
                    var customerToRemove = db.Customers.Include("Address").FirstOrDefault(x => x.Id == id);
                    if (customerToRemove != null)
                    {
                        db.Customers.Remove(customerToRemove);
                        db.SaveChanges();
                        return true;
                    }
                    return false;

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        public static bool EditCustomer(CustomerModel customer)
        {
            try
            {
                using (DbContextModel db = new DbContextModel())
                {
                    CustomerModel customerToEdit = db.Customers.Include("Address").FirstOrDefault(x => x.Id == customer.Id);
                    customerToEdit.Name = customer.Name;
                    customerToEdit.Surname = customer.Surname;
                    customerToEdit.TelephoneNumber = customer.TelephoneNumber;
                    customerToEdit.Address.Country = customer.Address.Country;
                    customerToEdit.Address.City = customer.Address.City;
                    customerToEdit.Address.PostalCode = customer.Address.PostalCode;
                    customerToEdit.Address.Street = customer.Address.Street;
                    customerToEdit.Address.HouseNumber = customer.Address.HouseNumber;
                    customerToEdit.Address.FlatNumber = customer.Address.FlatNumber;
                    db.Entry(customerToEdit).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}