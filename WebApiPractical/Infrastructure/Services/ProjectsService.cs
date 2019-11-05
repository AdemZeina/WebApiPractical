using System.Collections.Generic;
using System.Linq;
using WebApiPractical.Infrastructure.Entity;
using WebApiPractical.Infrastructure.Seeder;

namespace WebApiPractical.Infrastructure.Services
{
    public class ProjectsService: IProjectsService
    {
        public List<Projects> GetProjectListByCountryId(int countryId)
        {
            return DataJsonSeeder.LoadData.Where(x=>x.Country.Id== countryId).OrderByDescending(y=>y.Id).ToList();
        }

        public List<Projects> GetProjectList()
        {
            return DataJsonSeeder.LoadData.OrderByDescending(y => y.Id).ToList();
        }
    }
}
