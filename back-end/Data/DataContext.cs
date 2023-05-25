using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company {
                            CompanyId = 1,
                            cnpj =  "12345678900001",
                            name= "Empresa A",
                            cep= "12345-678",
                            bairro= "Bairro A",
                            logradouro= "Rua A",
                            cidade= "Cidade A",
                            uf= "UF A",
                            numberHouse= 123
                        },
                new Company {
                            CompanyId= 2,
                            cnpj= "98765432100001",
                            name= "Empresa B",
                            cep= "98765-432",
                            bairro= "Bairro B",
                            logradouro= "Rua B",
                            cidade= "Cidade B",
                            uf= "UF B",
                            numberHouse= 456

                        },
                new Company {
                            CompanyId= 3,
                            cnpj= "56789012300001",
                            name= "Empresa C",
                            cep= "56789-012",
                            bairro= "Bairro C",
                            logradouro= "Rua C",
                            cidade= "Cidade C",
                            uf= "UF C",
                            numberHouse= 789
                        } 
            );
            modelBuilder.Entity<suplier>().HasData(
                new suplier {
                            suplierId= 1,
                            cnpjCpf= "12345678900001",
                            rg= "0",
                            dateBirth= null,
                            email= "test1@test.com",
                            name= "Empresa A",
                            cep= "12345-678",
                            bairro= "Bairro A",
                            logradouro= "Rua A",
                            cidade= "Cidade A",
                            uf= "UF A",
                            numberHouse= 123
                        },
                new suplier {
                            suplierId= 2,
                            cnpjCpf= "11544610516",
                            rg= "555555555",
                            dateBirth = DateTime.Parse("Jan 1, 1995"),
                            email= "test2@test.com",
                            name= "Empresa B",
                            cep= "98765-432",
                            bairro= "Bairro B",
                            logradouro= "Rua B",
                            cidade= "Cidade B",
                            uf= "UF B",
                            numberHouse= 456

                        },
                new suplier {
                            suplierId= 3,
                            cnpjCpf= "56789012300001",
                            rg= "0",
                            dateBirth= null,
                            email= "test3@test.com",
                            name= "Empresa C",
                            cep= "56789-012",
                            bairro= "Bairro C",
                            logradouro= "Rua C",
                            cidade= "Cidade C",
                            uf= "UF C",
                            numberHouse= 789
                        } 
            );
            modelBuilder.Entity<Companysuplier>()
                .HasKey(bc => new { bc.CompanyId, bc.suplierId });  
            modelBuilder.Entity<Companysuplier>()
                .HasOne(bc => bc.Company)
                .WithMany(b => b.Companysupliers)
                .HasForeignKey(bc => bc.CompanyId);  
            modelBuilder.Entity<Companysuplier>()
                .HasOne(bc => bc.suplier)
                .WithMany(c => c.Companysupliers)
                .HasForeignKey(bc => bc.suplierId);

            modelBuilder.Entity<Companysuplier>().HasData(
                new Companysuplier {
                            suplierId= 1,
                            CompanyId = 1,
                        },
                new Companysuplier {
                            suplierId= 2,
                            CompanyId=1,
                        },
                new Companysuplier {
                            suplierId= 3,
                            CompanyId = 2,
                        } 
            );
        }

        public DbSet<Company> Company => Set<Company>();
        public DbSet<suplier> suplier => Set<suplier>();
        public DbSet<Companysuplier> Companysupliers => Set<Companysuplier>();

    }
}
