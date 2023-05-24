using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace back_end.services.company
{
    public class CompanyService : ICompanyService
    {
        private static List<GetCompanyDto> Companys = new List<GetCompanyDto> {
            new GetCompanyDto(),
            new GetCompanyDto { name = "empresa nova" }
        };

        private readonly DataContext _context;
    
        public CompanyService(DataContext context){
            _context = context;
        }
        
        public async Task<ServiceResponse<List<Company>>> AddCompany(Company newCompany)
        {
            var serviceResponse = new ServiceResponse<List<Company>>();
            _context.Company.Add(newCompany); 
            await _context.SaveChangesAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Company>>> GetAllCompanys()
        {
            var serviceResponse = new ServiceResponse<List<Company>>();
            var dbCompanys = await _context.Company.ToListAsync();
            serviceResponse.data = dbCompanys;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Company>> GetCompanyById(int id)
        {
            var serviceResponse = new ServiceResponse<Company>();
            var dbCompany = await _context.Company.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.data = dbCompany;
            return serviceResponse;
        }
    }
}