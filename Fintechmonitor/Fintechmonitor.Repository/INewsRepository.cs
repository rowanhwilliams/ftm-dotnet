using Fintechmonitor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintechmonitor.Repository
{
    public interface INewsRepository
    {
        NewsItem GetById(int newsId);
        NewsItem[] GetPaged(int offset, int pageSize);
    }
}
