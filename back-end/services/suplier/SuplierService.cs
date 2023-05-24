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

        public async Task<ServiceResponse<suplier>> GetSuplierByCnpjCpf(int cnpjCpf)
        {
            var serviceResponse = new ServiceResponse<suplier>();
            var dbSupliers = await _context.suplier.FirstOrDefaultAsync(c => c.cnpjCpf == cnpjCpf);
            serviceResponse.data = dbSupliers;
            return serviceResponse;
        }
    }
}