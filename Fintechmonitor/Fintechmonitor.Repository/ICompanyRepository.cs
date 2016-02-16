using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fintechmonitor.Domain;

namespace Fintechmonitor.Repository
{
    public interface ICompanyRepository
    {
        Company GetById(int companyId);
    }
}
