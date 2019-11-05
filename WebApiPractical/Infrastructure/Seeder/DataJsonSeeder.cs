using System;
using System.Collections.Generic;
using WebApiPractical.Infrastructure.Entity;

namespace WebApiPractical.Infrastructure.Seeder
{
    public static class DataJsonSeeder
    {
        public static List<Country> Countries=new List<Country>()
        {
            new Country(){Id = 0,Name = "Select All",CreateDate = DateTime.Now},
            new Country(){Id = 1,Name = "Turkey",CreateDate = DateTime.Now},
            new Country(){Id = 2,Name = "Germany",CreateDate = DateTime.Now},
            new Country(){Id = 3,Name = "Syria",CreateDate = DateTime.Now},
            new Country(){Id = 4,Name = "Lebanon",CreateDate = DateTime.Now},
            new Country(){Id = 5,Name = "India",CreateDate = DateTime.Now},
            new Country(){Id = 6,Name = "Egypt",CreateDate = DateTime.Now},
        };

        public static List<Customer> Customers = new List<Customer>()
        {
            new Customer(){Id = 1,CustomerName = "Adem",CreateDate = DateTime.Now},
            new Customer(){Id = 2,CustomerName = "Mohamad",CreateDate = DateTime.Now},
            new Customer(){Id = 3,CustomerName = "Ahmad",CreateDate = DateTime.Now},
        };

        public static List<Projects> LoadData=new List<Projects>()
        {
            new Projects(){Id=1,ProjectName = ".Net Web Project",Country = GetCountryById(1),Customer = GetCustomerById(3),CreateDate = DateTime.Now},
            new Projects(){Id=2,ProjectName = "Java Projects",Country = GetCountryById(1),Customer = GetCustomerById(2),CreateDate = DateTime.Now},
            new Projects(){Id=3,ProjectName = "Mobile Projects",Country = GetCountryById(1),Customer = GetCustomerById(1),CreateDate = DateTime.Now},
            new Projects(){Id=4,ProjectName = ".Net Mobile Project",Country = GetCountryById(2),Customer = GetCustomerById(1),CreateDate = DateTime.Now},
            new Projects(){Id=5,ProjectName = "Vini Project",Country = GetCountryById(3),Customer = GetCustomerById(2),CreateDate = DateTime.Now},
            new Projects(){Id=6,ProjectName = "Ericsson Projects",Country = GetCountryById(4),Customer = GetCustomerById(2),CreateDate = DateTime.Now},
            new Projects(){Id=7,ProjectName = "Vitelco Projects",Country = GetCountryById(5),Customer = GetCustomerById(3),CreateDate = DateTime.Now},
            new Projects(){Id=8,ProjectName = "Tibco Project",Country = GetCountryById(6),Customer = GetCustomerById(3),CreateDate = DateTime.Now},
          
        };


        public static Customer GetCustomerById(int id)
        {
            return Customers.Find(x=>x.Id==id);
        }

        public static Country GetCountryById(int id)
        {
            return Countries.Find(x => x.Id == id);
        }
    }
}
