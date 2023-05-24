namespace back_end.models
{
    public class Company {
        public int Id { get; set; }
        public int cnpj { get; set; } = 0;
        public string name { get; set; } = "  ";
        public int cep { get; set; } = 0;
        public string bairro { get; set; } = "  ";
        public string logradouro { get; set; } = "  ";
        public string cidade { get; set; } = "  ";        
        public string uf { get; set; } = "  ";
        public int numberHouse { get; set; } = 0;
    }
}