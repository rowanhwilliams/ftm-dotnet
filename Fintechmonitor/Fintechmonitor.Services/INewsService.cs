using Fintechmonitor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintechmonitor.Services
{
    public interface INewsService
    {
        NewsItem NewsItem(int newsId);
        NewsItem[] LatestNews(int offset, int pageSize);
    }
}
