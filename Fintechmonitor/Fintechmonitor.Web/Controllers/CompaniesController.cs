using Fintechmonitor.Domain;
using Fintechmonitor.Services;
using Fintechmonitor.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace Fintechmonitor.Web.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [OutputCache(Duration = 1200)]
        public ActionResult Index()
        {
            var companies =_companyService.Companies(0, 100);
            var viewModel = ToCompaniesListViewModel(companies);

            return View(viewModel);
        }

        //[OutputCache(Duration = 12000, VaryByParam = "id")]
        public ActionResult View(int? id)
        {
            if (!id.HasValue) return View(CompanyViewModel.Empty());

            var company = _companyService.Company(id.Value);

            return View(ToCompanyViewModel(company));
        }

        private CompanyViewModel ToCompanyViewModel(Company company)
        {
            return new CompanyViewModel
            {
                Id = company.Id,
                Name = company.Name,
                AboutUs = company.AboutUs,
                City = company.City,
                Country = company.Country,
                EmployeeSize = company.EmployeeSize,
                PrincipalProducts = company.PrincipalProducts.Select(ToPrincipalProductViewModel).ToArray()
            };
        }

        private PrincipalProductViewModel ToPrincipalProductViewModel(PrincipalProduct principalProduct)
        {
            return new PrincipalProductViewModel
            {
                Id = principalProduct.Id,
                Title = principalProduct.Title,
                FirstLaunched = principalProduct.FirstLaunched
            };
        }

        private CompaniesListViewModel ToCompaniesListViewModel(Company[] companies)
        {
            var companiesViewModel = new CompaniesListViewModel();
            companiesViewModel.List = companies.Select
            (
                x => ToCompanyViewModel(x)
            )
            .ToArray();

            return companiesViewModel;
        }
    }
}
