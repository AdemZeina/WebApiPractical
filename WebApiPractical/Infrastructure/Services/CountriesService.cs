using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPractical.Infrastructure.Entity;
using WebApiPractical.Infrastructure.Seeder;

namespace WebApiPractical.Infrastructure.Services
{
    public class CountriesService:ICountriesService
    {
        public List<Country> GetCountriesList()
        {
            return DataJsonSeeder.Countries.ToList();
        }
    }
}
