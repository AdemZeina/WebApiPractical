using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPractical.Infrastructure.Entity;

namespace WebApiPractical.Infrastructure.Services
{
    public interface ICountriesService
    {
        List<Country> GetCountriesList();
    }
}
