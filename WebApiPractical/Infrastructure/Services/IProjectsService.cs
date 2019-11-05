using System.Collections.Generic;
using WebApiPractical.Infrastructure.Entity;

namespace WebApiPractical.Infrastructure.Services
{
    public interface IProjectsService
    {
        List<Projects> GetProjectListByCountryId(int countryId);

        List<Projects> GetProjectList();
    }
}
