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
    //[Authorize]
    public class CountryProjectsController : ControllerBase
    {
        private readonly IProjectsService _projectsService;

        public CountryProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public ActionResult<List<Projects>> GetProjects(requestDto request)
        {
            if (request.CountryId <= 0)
            {
               return _projectsService.GetProjectList();
            }
            return _projectsService.GetProjectListByCountryId(request.CountryId);
        }



    }

    public class requestDto
    {
        public int CountryId { get; set; }
    }
}