using Fintechmonitor.Domain;
using Fintechmonitor.Repository;

namespace Fintechmonitor.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Company[] Companies(int offset, int pageSize)
        {
            return _companyRepository.GetPaged(offset, pageSize);
        }

        public Company Company(int companyId)
        {
            return _companyRepository.GetById(companyId);
        }
    }
}
