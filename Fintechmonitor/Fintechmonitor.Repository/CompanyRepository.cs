using System.Linq;
using Fintechmonitor.Domain;
using Dapper;
using System.Data;
using System;

namespace Fintechmonitor.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDbConnection _dbConnection;
        private const string GetTemplate =
            @"select c.id_Company, c.Company_Full_Name, c.Company_Full_Name, Company_About_Us, a.City, ctry.Country, employee.Employee_Size
            from {0} as c 
            inner join Headquarters_Information as map on c.headquarters_Address = map.id_Headquarters_Information 
            inner join Addresses as a on map.AddressId = a.AddressId
            inner join Country as ctry on a.id_Country = ctry.id_Country
            inner join Employee_Size as employee on c.id_Employee_size = employee.id_Employee_size
            {1}";
        private const string TableName = "Company";
        private const string IdColumnName = "id_Company";
        private const string WhereIdEquals = "where c.{0} = @id";
        private const string LimitBy = "LIMIT @offset, @rowcount";

        private const string PrincipalProductsSql =
            @"select id_Product, Product_Title, First_Launched from Product where id_Owner_Company = @id";

        public CompanyRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Company GetById(int companyId)
        {
            var baseCompanyQuery = string.Format(GetTemplate, TableName, WhereClause());
            var companyAndProducts = string.Concat(baseCompanyQuery, ";", PrincipalProductsSql, ";");
            var reader = _dbConnection.QueryMultiple(companyAndProducts, new { id = companyId });

            var company = reader.Read<Company>().Single();
            company.PrincipalProducts = reader.Read<PrincipalProduct>().ToArray();

            return company;
        }

        public Company[] GetPaged(int offset, int pageSize)
        {
            var query = string.Format(GetTemplate, TableName, LimitBy);
            var param = new { offset = offset, rowcount = pageSize };
            return _dbConnection.Query<Company>(query, param).ToArray();
        }

        private string WhereClause()
        {
            return string.Format(WhereIdEquals, IdColumnName);
        }
    }
}
