using System.Web.Mvc;
using Fintechmonitor.Domain;
using Fintechmonitor.Services;
using Fintechmonitor.Web.Models;

namespace Fintechmonitor.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompanyService _companyService;

        public HomeController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [OutputCache(Duration = 1200)]
        public ActionResult Index()
        {
            return View();
        }
    }
}
