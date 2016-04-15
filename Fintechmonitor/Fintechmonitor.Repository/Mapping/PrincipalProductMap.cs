using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap.Mapping;
using Fintechmonitor.Domain;

namespace Fintechmonitor.Repository.Mapping
{
    public class PrincipalProductMap : EntityMap<PrincipalProduct>
    {
        public PrincipalProductMap()
        {
            Map(p => p.Id).ToColumn("id_Product");
            Map(p => p.Title).ToColumn("Product_Title");
            Map(p => p.FirstLaunched).ToColumn("First_Launched");
        }
    }
}
