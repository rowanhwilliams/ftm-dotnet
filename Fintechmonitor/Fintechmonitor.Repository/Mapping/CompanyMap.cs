using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fintechmonitor.Domain;
using Dapper.FluentMap.Mapping;

namespace Fintechmonitor.Repository.Mapping
{
    public class CompanyMap : EntityMap<Company>
    {
        public CompanyMap()
        {
            Map(p => p.Id).ToColumn("id_Company");
            Map(p => p.Name).ToColumn("Company_Full_Name");
            Map(p => p.AboutUs).ToColumn("Company_About_Us");
        }
    }
}

