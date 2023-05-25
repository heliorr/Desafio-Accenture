namespace back_end.models
{
    public class Company {
        public int CompanyId { get; set; }
        public string cnpj { get; set; }
        public string name { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string logradouro { get; set; } 
        public string cidade { get; set; }
        public string uf { get; set; }
        public int numberHouse { get; set; }
        public ICollection<Companysuplier>? Companysupliers { get; set; }
    }
}