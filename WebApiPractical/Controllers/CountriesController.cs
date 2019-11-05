using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiPractical.Infrastructure.Entity;
using WebApiPractical.Infrastructure.Services;

namespace WebApiPractical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {

        private readonly ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        // GET api/values
        [HttpGet]
        public List<Country> Get()
        {
            return _countriesService.GetCountriesList();
        }
    }
}