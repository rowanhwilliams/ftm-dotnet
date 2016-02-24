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
        public string City { get; set; }
        public string AboutUs { get; set; }

        public static CompanyViewModel Empty()
        {
            return new CompanyViewModel();
        }
    }
}
