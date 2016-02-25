using Dapper.FluentMap.Mapping;
using Fintechmonitor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintechmonitor.Repository.Mapping
{
    public class NewsMap : EntityMap<NewsItem>
    {
        public NewsMap()
        {
            Map(p => p.Id).ToColumn("id_News");
            Map(p => p.Headline).ToColumn("Story_Headline");
            Map(p => p.Date).ToColumn("Story_Date");
            Map(p => p.Time).ToColumn("Story_Time");
            Map(p => p.Body).ToColumn("Story_Description");
            Map(p => p.TypeId).ToColumn("id_News_Type");
            Map(p => p.Type).ToColumn("News_Type_Name");
        }
    }
}
