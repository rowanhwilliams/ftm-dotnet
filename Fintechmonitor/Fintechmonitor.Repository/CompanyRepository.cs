using System.Linq;
using Fintechmonitor.Domain;
using Dapper;
using System.Data;

namespace Fintechmonitor.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDbConnection _dbConnection;
        private const string GetByIdTemplate = 
            @"select c.*, a.City
            from {0} as c 
            inner join Headquarters_Information as map on c.headquarters_Address = map.id_Headquarters_Information 
            inner join Addresses as a on map.AddressId = a.AddressId
            where c.{1} = @id";*/
        private const string TableName = "Company";
        private const string IdColumnName = "id_Company";

        public CompanyRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Company GetById(int companyId)
        {
            var query = string.Format(GetByIdTemplate, TableName, IdColumnName);
            return _dbConnection.Query<Company>(query, new { id = companyId }).Single();
        }
    }
}
