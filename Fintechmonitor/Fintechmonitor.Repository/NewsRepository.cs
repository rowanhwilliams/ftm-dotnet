using System.Linq;
using Fintechmonitor.Domain;
using System.Data;
using Dapper;

namespace Fintechmonitor.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly IDbConnection _dbConnection;
        private const string GetTemplate =
            @"select n.id_News, n.Story_Headline, n.Story_Date, n.Story_Time, n.Story_Description, n.id_News_Type, t.News_Type_Name
            from {0} as n 
            inner join News_Type as t on n.id_News_Type = t.id_News_Type
            {1}";
        private const string TableName = "News";
        private const string IdColumnName = "id_News";
        private const string WhereIdEquals = "where n.{0} = @id";
        private const string OrderRecent = "order by n.Story_Date desc, n.id_News desc";
        private const string LimitBy = "LIMIT @offset, @rowcount";

        public NewsRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public NewsItem GetById(int newsId)
        {
            var query = string.Format(GetTemplate, TableName, WhereClause());
            return _dbConnection.Query<NewsItem>(query, new { id = newsId }).Single();
        }

        public NewsItem[] GetPaged(int offset, int pageSize)
        {
            var orderByAndLimit = $"{OrderRecent} {LimitBy}";
            var query = string.Format(GetTemplate, TableName, orderByAndLimit);
            var param = new { offset = offset, rowcount = pageSize };
            return _dbConnection.Query<NewsItem>(query, param).ToArray();
        }

        private string WhereClause()
        {
            return string.Format(WhereIdEquals, IdColumnName);
        }
    }
}
