using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.services.company
{
    public interface ICompanyService
    {
        Task<ServiceResponse<List<Company>>> GetAllCompanys();

        Task<ServiceResponse<Company>> GetCompanyById(int id);

        Task<ServiceResponse<List<Company>>> AddCompany(Company newCompany);
        
        Task<ServiceResponse<List<Company>>> DeleteCompany(int id);
    }
}