using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace back_end.services.Suplier
{
    public class SuplierService : ISuplierService
    {
        private static List<suplier> Supliers = new List<suplier> {
            new suplier(),
            new suplier { name = "empresa nova" }
        };

        private readonly DataContext _context;
    
        public SuplierService(DataContext context){
            _context = context;
        }

        public async Task<ServiceResponse<List<suplier>>> AddSuplier(suplier newSuplier)
        {
            var serviceResponse = new ServiceResponse<List<suplier>>();
            _context.suplier.Add(newSuplier);
            await _context.SaveChangesAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<suplier>>> GetAllSupliers()
        {
            var serviceResponse = new ServiceResponse<List<suplier>>();
            var dbSupliers = await _context.suplier.ToListAsync();
            serviceResponse.data = dbSupliers;
            return serviceResponse;
        }

        public async Task<ServiceResponse<suplier>> GetSuplierById(int id)
        {
            var serviceResponse = new ServiceResponse<suplier>();
            var dbSupliers = await _context.suplier.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.data = dbSupliers;
            return serviceResponse;
        }

        public async Task<ServiceResponse<suplier>> UpdateSuplier(suplier newSuplier)
        {
            var serviceResponse = new ServiceResponse<suplier>();

            try
            {
                var suplier =
                    await _context.suplier
                        .FirstOrDefaultAsync(c => c.Id == newSuplier.Id);
                if (suplier is null)
                    throw new Exception($"Character with Id '{newSuplier.Id}' not found.");

                suplier.cnpjCpf = newSuplier.cnpjCpf;
                suplier.rg = newSuplier.rg;
                suplier.dateBirth = newSuplier.dateBirth;
                suplier.email = newSuplier.email;
                suplier.name = newSuplier.name;
                suplier.cep = newSuplier.cep;
                suplier.bairro = newSuplier.bairro;
                suplier.logradouro = newSuplier.logradouro;
                suplier.cidade = newSuplier.cidade;
                suplier.uf = newSuplier.uf;
                suplier.numberHouse = newSuplier.numberHouse;


                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<suplier>>> DeleteSuplier(int id)
        {
            var serviceResponse = new ServiceResponse<List<suplier>>();

            try
            {
                var suplier = await _context.suplier
                    .FirstOrDefaultAsync(c => c.Id == id);
                if (suplier is null)
                    throw new Exception($"Character with Id '{id}' not found.");

                _context.suplier.Remove(suplier);

                await _context.SaveChangesAsync();

                serviceResponse.data =
                    await _context.suplier.ToListAsync();
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