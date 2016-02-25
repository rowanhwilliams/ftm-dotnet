using Fintechmonitor.Domain;
using Fintechmonitor.Repository;

namespace Fintechmonitor.Services
{
    public class NewsService : INewsService
    {
        private INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public NewsItem[] LatestNews(int offset, int pageSize)
        {
            return _newsRepository.GetPaged(offset, pageSize);
        }

        public NewsItem NewsItem(int newsId)
        {
            return _newsRepository.GetById(newsId);
        }
    }
}
