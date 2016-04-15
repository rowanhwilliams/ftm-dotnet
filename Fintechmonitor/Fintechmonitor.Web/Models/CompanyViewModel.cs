using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fintechmonitor.Web.Models
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AboutUs { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string EmployeeSize { get; set; }

        public PrincipalProductViewModel[] PrincipalProducts { get; set; }

        public bool HasPrincipalProducts()
        {
            return PrincipalProducts.Any();
        }

        public static CompanyViewModel Empty()
        {
            return new CompanyViewModel();
        }
    }
}
