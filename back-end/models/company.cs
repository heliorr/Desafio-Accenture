namespace back_end.models
{
    public class Company {
        public int Id { get; set; }
        public int cnpj { get; set; } = 0;
        public string name { get; set; } = "  ";
        public int cep { get; set; } = 0;
        public int numberHouse { get; set; } = 0;
    }
}