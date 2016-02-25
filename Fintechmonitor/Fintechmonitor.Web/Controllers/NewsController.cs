using Fintechmonitor.Domain;
using Fintechmonitor.Services;
using Fintechmonitor.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fintechmonitor.Web.Controllers
{
    public class NewsController : Controller
    {
        private INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [OutputCache(Duration = 12000)]
        public ActionResult Latest()
        {
            var latestNews =_newsService.LatestNews(0, 50);

            var viewModel = ToNewsListViewModel(latestNews);

            return View(viewModel);
        }

        [OutputCache(Duration = 12000, VaryByParam = "id")]
        public ActionResult View(int id)
        {
            var newsItem = _newsService.NewsItem(id);

            var viewModel = ToNewsItemViewModel(newsItem);

            return View(viewModel);
        }

        private NewsItemViewModel ToNewsItemViewModel(NewsItem newsItem)
        {
            return new NewsItemViewModel
            {
                Id = newsItem.Id,
                Headline = newsItem.Headline,
                DateTime = newsItem.DateTime,
                Body = newsItem.Body,
                Type = newsItem.Type,
                TypeId = newsItem.TypeId
            };
        }

        private NewsListViewModel ToNewsListViewModel(NewsItem[] newsItems)
        {
            var newsViewModel = new NewsListViewModel();
            newsViewModel.List = newsItems.Select
            (
                x => ToNewsItemViewModel(x)
            )
            .ToArray();

            return newsViewModel;
        }
    }
}