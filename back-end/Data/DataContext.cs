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
            modelBuilder.Entity<Company>()
            .HasMany(x => x.supliers)
            .WithMany(y => y.Companys)
            .UsingEntity(j => j.ToTable("Companysuplier"));

            modelBuilder.Entity<Company>().HasData(
                new Company {
                            Id = 1,
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
                            Id= 2,
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
                            Id= 3,
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
                            Id= 1,
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
                            Id= 2,
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
                            Id= 3,
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
        }

        public DbSet<Company> Company => Set<Company>();
        public DbSet<suplier> suplier => Set<suplier>();

    }
}
