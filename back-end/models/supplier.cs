namespace back_end.models
{
    public class suplier {
        public int Id { get; set; }
        public int cnpjCpf { get; set; } = 0;
        public int rg { get; set; } = 0;
        public DateTime dateBirth { get; set; }
        public string name { get; set; } = "  ";
        public string email { get; set; } = "  ";
        public int cep { get; set; } = 0;
        public string bairro { get; set; } = "  ";
        public string logradouro { get; set; } = "  ";
        public string cidade { get; set; } = "  ";        
        public string uf { get; set; } = "  ";
        public int numberHouse { get; set; } = 0;
    }
}