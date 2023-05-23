using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace back_end.services.company
{
    public class CompanyService : ICompanyService
    {
        private static List<Company> Companys = new List<Company> {
            new Company(),
            new Company { name = "empresa nova" }
        };

        public async Task<ServiceResponse<List<Company>>> AddCompany(Company newCompany)
        {
            var serviceResponse = new ServiceResponse<List<Company>>();
            Companys.Add(newCompany);
            serviceResponse.data = Companys;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Company>>> GetAllCompanys()
        {
            var serviceResponse = new ServiceResponse<List<Company>>();
            serviceResponse.data = Companys;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Company>> GetCompanyById(int id)
        {
            var serviceResponse = new ServiceResponse<Company>();
            var company = Companys.FirstOrDefault(c => c.Id == id);
            serviceResponse.data = company;
            return serviceResponse;
        }
    }
}