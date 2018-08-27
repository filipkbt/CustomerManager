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
                ViewBag.AlertSuccess = true;
                ModelState.Clear();
                return View();
            }
            ViewBag.AlertSuccess = false;
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

        public ActionResult EditCustomer(int id)
        {
            using (DbContextModel db = new DbContextModel())
            {
                try
                {
                    var customer = db.Customers.Include("Address").Where(x => x.Id == id).FirstOrDefault();

                    var countries = CountriesManager.LoadAllCountriesFromFile();
                    SelectList countriesList = new SelectList(countries, "Country");
                    if ((TempData["Countries"] as SelectList) != null)
                    {
                        var countriesSelectList = TempData["Countries"] as SelectList;
                        var selectedCountries = countriesSelectList.Items;
                    }

                    TempData["Countries"] = countriesList;

                    return View("EditCustomer", customer);
                }
                catch(Exception)
                {
                    return RedirectToAction("Customers");
                }
            }
        }

        [HttpPost]
        public ActionResult EditCustomer(CustomerModel customer)
        {
            using (DbContextModel db = new DbContextModel())
            {
                try
                {
                    CustomerManager.EditCustomer(customer);
                    TempData["AlertSuccess"] = "Yes";

                    return RedirectToAction("Customers");
                }
                catch (Exception)
                {
                    ViewBag.AlertSuccess = false;

                    return View("EditCustomer",customer);
                }
            }
        }

    }
}
