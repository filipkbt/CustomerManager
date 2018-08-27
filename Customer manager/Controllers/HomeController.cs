using Customer_manager.Infrastructure;
using Customer_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Customer_manager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var countries = CountriesManager.LoadAllCountriesFromFile();
            SelectList countriesList = new SelectList(countries, "Country");

            if ((TempData["Countries"] as SelectList) != null)
            {
                var countriesSelectList = TempData["Countries"] as SelectList;
                var selectedCountries = countriesSelectList.Items;
            }

            TempData["Countries"] = countriesList;

            return View();
        }

        [HttpPost]
        public ActionResult Index(CustomerModel customer)
        {
            var countries = CountriesManager.LoadAllCountriesFromFile();
            SelectList countriesList = new SelectList(countries, "Country");
            if ((TempData["Countries"] as SelectList) != null)
            {
                var countriesSelectList = TempData["Countries"] as SelectList;
                var selectedCountries = countriesSelectList.Items;
            }

            TempData["Countries"] = countriesList;

            if(ModelState.IsValid)
            {
                CustomerManager.AddNewCustomer(customer);
                CustomerModel emptyCustomer = new CustomerModel();
                return View(emptyCustomer);
            }
            return View();
        }

        public ActionResult Customers()
        {
            return View(CustomerManager.GetAllCustomers());
        }

        [HttpPost]
        public ActionResult DeleteCustomer(int id)
        {
            CustomerManager.DeleteCustomer(id);
            return RedirectToAction("Customers");
        }

    }
}
