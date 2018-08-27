using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Customer_manager.Infrastructure
{
    public static class CountriesManager
    {
        private const string _countriesFilePath = @"/Content/Countries.txt";

        public static IEnumerable<string> LoadAllCountriesFromFile()
        {
            try
            {
                var _countriesProjectFilePath = HttpContext.Current.Server.MapPath(_countriesFilePath);
                using (StreamReader sr = new StreamReader(_countriesProjectFilePath, Encoding.Default, true))
                {
                    string line;
                    List<string> countries = new List<string>();
                    while ((line = sr.ReadLine()) != null)
                    {
                        countries.Add(line);
                    }
                    return countries;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}