using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Customer_manager;
using Customer_manager.Controllers;
using NUnit.Framework;
using Customer_manager.Infrastructure;
using Customer_manager.Models;

namespace Customer_manager.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        private HomeController _homeController;

        public HomeControllerTest()
        {
            _homeController = new HomeController();
        }

        [Test]
        public void GetAllCustomers()
        {
            Assert.NotNull(CustomerManager.GetAllCustomers());
        }

        [Test]
        public void AddNewCustomerShouldReturnTrue()
        {
            CustomerModel customer = new CustomerModel
            {
                Address = new AddressModel(),
                Name = "Filip",
                Surname = "Kubat",
                TelephoneNumber = "511300400"
            };
            customer.Address.Country = "Poland";
            customer.Address.City = "Katowice";
            customer.Address.PostalCode = "42-600";
            customer.Address.Street = "Rynek";
            customer.Address.HouseNumber = "24";
            Assert.IsTrue(CustomerManager.AddNewCustomer(customer));
            CustomerManager.DeleteCustomer(customer.Id);
        }

        [Test]
        public void AddNewCustomerShouldReturnFalse()
        {
            CustomerModel customer = new CustomerModel
            {
                Address = new AddressModel()
            };
            Assert.AreEqual(CustomerManager.AddNewCustomer(customer), false);
        }

        [Test]
        public void EditCustomerShouldReturnTrue()
        {
            CustomerModel customer = new CustomerModel
            {
                Address = new AddressModel(),
                Name = "Filip",
                Surname = "Kubat",
                TelephoneNumber = "511300400"
            };
            customer.Address.Country = "Poland";
            customer.Address.City = "Katowice";
            customer.Address.PostalCode = "42-600";
            customer.Address.Street = "Rynek";
            customer.Address.HouseNumber = "24";
            CustomerManager.AddNewCustomer(customer);
            Assert.IsTrue(CustomerManager.EditCustomer(customer));
            CustomerManager.DeleteCustomer(customer.Id);
        }

        [Test]
        public void DeleteCustomerShouldReturnTrue()
        {
            CustomerModel customer = new CustomerModel
            {
                Address = new AddressModel(),
                Name = "Filip",
                Surname = "Kubat",
                TelephoneNumber = "511300400"
            };
            customer.Address.Country = "Poland";
            customer.Address.City = "Katowice";
            customer.Address.PostalCode = "42-600";
            customer.Address.Street = "Rynek";
            customer.Address.HouseNumber = "24";
            CustomerManager.AddNewCustomer(customer);
            Assert.IsTrue(CustomerManager.DeleteCustomer(customer.Id));
            CustomerManager.DeleteCustomer(customer.Id);
        }

        [Test]
        public void DeleteCustomerShouldReturnFalse()
        {
            CustomerModel customer = new CustomerModel
            {
                Address = new AddressModel(),
                Name = "Filip",
                Surname = "Kubat",
                TelephoneNumber = "511300400"
            };
            customer.Address.Country = "Poland";
            customer.Address.City = "Katowice";
            customer.Address.PostalCode = "42-600";
            customer.Address.Street = "Rynek";
            customer.Address.HouseNumber = "24";
            Assert.AreEqual(CustomerManager.DeleteCustomer(customer.Id),false);
        }


    }
}
