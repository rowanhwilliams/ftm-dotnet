using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap;

namespace Fintechmonitor.Repository.Mapping
{
    public class DapperBootstrapper
    {
        public void Run()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new CompanyMap());
            });
        }
    }
}
