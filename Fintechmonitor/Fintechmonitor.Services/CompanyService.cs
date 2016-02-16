using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Company Company(int companyId)
        {
            return _companyRepository.GetById(companyId);
        }
    }
}
