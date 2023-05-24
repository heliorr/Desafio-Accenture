using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Dtos.Company
{
    public class AddCompanyDto
    {
        public int cnpj { get; set; } = 0;
        public string name { get; set; } = "  ";
        public int cep { get; set; } = 0;
        public int numberHouse { get; set; } = 0;
    }
}