namespace back_end.models
{
    public class Companysuplier{
        public int CompanyId { get; set; }
        public int suplierId { get; set; }

        public Company Company { get; set; }
        public suplier suplier { get; set; }
    }
}