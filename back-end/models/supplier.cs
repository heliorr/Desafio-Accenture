namespace back_end.models
{
    public class suplier {
        public int suplierId { get; set; }
        public string cnpjCpf { get; set; }
        public string rg { get; set; }
        public DateTime? dateBirth { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string logradouro { get; set; }
        public string cidade { get; set; }     
        public string uf { get; set; }
        public int numberHouse { get; set; }
        public ICollection<Companysuplier>? Companysupliers { get; set; }
    }
}