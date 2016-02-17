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
