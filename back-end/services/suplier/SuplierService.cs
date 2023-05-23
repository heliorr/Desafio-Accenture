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

        public async Task<ServiceResponse<List<suplier>>> AddSuplier(suplier newSuplier)
        {
            var serviceResponse = new ServiceResponse<List<suplier>>();
            Supliers.Add(newSuplier);
            serviceResponse.data = Supliers;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<suplier>>> GetAllSupliers()
        {
            var serviceResponse = new ServiceResponse<List<suplier>>();
            serviceResponse.data = Supliers;
            return serviceResponse;
        }

        public async Task<ServiceResponse<suplier>> GetSuplierById(int id)
        {
            var serviceResponse = new ServiceResponse<suplier>();
            var suplier = Supliers.FirstOrDefault(c => c.Id == id);
            serviceResponse.data = suplier;
            return serviceResponse;
        }

        public async Task<ServiceResponse<suplier>> GetSuplierByCnpjCpf(int cnpjCpf)
        {
            var serviceResponse = new ServiceResponse<suplier>();
            var suplier = Supliers.FirstOrDefault(c => c.cnpjCpf == cnpjCpf);
            serviceResponse.data = suplier;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<suplier>>> GetSuplierByName(string name)
        {
            var serviceResponse = new ServiceResponse<List<suplier>>();
            var suplier = Supliers.FirstOrDefault(c => c.name.Contains(name));
            serviceResponse.data = suplier;
            return serviceResponse;
        }
    }
}