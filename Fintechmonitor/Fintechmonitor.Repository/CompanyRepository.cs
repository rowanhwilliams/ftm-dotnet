using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fintechmonitor.Domain;
using Dapper;
using System.Data;

namespace Fintechmonitor.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDbConnection _dbConnection;
        private const string GetByIdTemplate = "select * from {0} where {1} = @id";
        private const string TableName = "Company";
        private const string IdColumnName = "id_Company";

        public CompanyRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Company GetById(int companyId)
        {
            var query = string.Format(GetByIdTemplate, IdColumnName);
            return _dbConnection.Query<Company>(query, new { id = companyId }).Single();
        }
    }
}
