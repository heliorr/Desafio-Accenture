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
            var query = _context.Company
            .Include(r => r.Companysupliers)
            .ThenInclude(r => r.suplier);
            var dbCompanys = await query.ToListAsync();
            serviceResponse.data = dbCompanys;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Company>> GetCompanyById(int CompanyId)
        {
            var serviceResponse = new ServiceResponse<Company>();
            var dbCompany = await _context.Company.FirstOrDefaultAsync(c => c.CompanyId == CompanyId);
            serviceResponse.data = dbCompany;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Company>> UpdateCompany(Company newCompany)
        {
            var serviceResponse = new ServiceResponse<Company>();

            try
            {
                var company =
                    await _context.Company
                        .FirstOrDefaultAsync(c => c.CompanyId == newCompany.CompanyId);
                if (company is null)
                    throw new Exception($"Character with Id '{newCompany.CompanyId}' not found.");

                company.cnpj = newCompany.cnpj;
                company.name = newCompany.name;
                company.cep = newCompany.cep;
                company.bairro = newCompany.bairro;
                company.logradouro = newCompany.logradouro;
                company.cidade = newCompany.cidade;
                company.uf = newCompany.uf;
                company.numberHouse = newCompany.numberHouse;


                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Company>>> DeleteCompany(int CompanyId)
        {
            var serviceResponse = new ServiceResponse<List<Company>>();

            try
            {
                var company = await _context.Company
                    .FirstOrDefaultAsync(c => c.CompanyId == CompanyId);
                if (company is null)
                    throw new Exception($"Character with Id '{CompanyId}' not found.");

                _context.Company.Remove(company);

                await _context.SaveChangesAsync();

                serviceResponse.data =
                    await _context.Company.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
        
    }
}