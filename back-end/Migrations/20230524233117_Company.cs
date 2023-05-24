using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace back_end.Migrations
{
    /// <inheritdoc />
    public partial class Company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numberHouse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "suplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cnpjCpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numberHouse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companysuplier",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    suplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companysuplier", x => new { x.CompanyId, x.suplierId });
                    table.ForeignKey(
                        name: "FK_Companysuplier_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Companysuplier_suplier_suplierId",
                        column: x => x.suplierId,
                        principalTable: "suplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "bairro", "cep", "cidade", "cnpj", "logradouro", "name", "numberHouse", "uf" },
                values: new object[,]
                {
                    { 1, "Bairro A", "12345-678", "Cidade A", "12345678900001", "Rua A", "Empresa A", 123, "UF A" },
                    { 2, "Bairro B", "98765-432", "Cidade B", "98765432100001", "Rua B", "Empresa B", 456, "UF B" },
                    { 3, "Bairro C", "56789-012", "Cidade C", "56789012300001", "Rua C", "Empresa C", 789, "UF C" }
                });

            migrationBuilder.InsertData(
                table: "suplier",
                columns: new[] { "Id", "bairro", "cep", "cidade", "cnpjCpf", "dateBirth", "email", "logradouro", "name", "numberHouse", "rg", "uf" },
                values: new object[,]
                {
                    { 1, "Bairro A", "12345-678", "Cidade A", "12345678900001", null, "test1@test.com", "Rua A", "Empresa A", 123, "0", "UF A" },
                    { 2, "Bairro B", "98765-432", "Cidade B", "11544610516", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "test2@test.com", "Rua B", "Empresa B", 456, "555555555", "UF B" },
                    { 3, "Bairro C", "56789-012", "Cidade C", "56789012300001", null, "test3@test.com", "Rua C", "Empresa C", 789, "0", "UF C" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companysuplier_suplierId",
                table: "Companysuplier",
                column: "suplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companysuplier");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "suplier");
        }
    }
}
