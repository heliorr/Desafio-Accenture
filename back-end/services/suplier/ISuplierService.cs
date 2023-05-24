using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.services.Suplier
{
    public interface ISuplierService
    {
        Task<ServiceResponse<List<suplier>>> GetAllSupliers();

        Task<ServiceResponse<suplier>> GetSuplierById(int id);

        Task<ServiceResponse<List<suplier>>> AddSuplier(suplier newSuplier);
    }
}