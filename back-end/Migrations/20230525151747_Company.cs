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
                    CompanyId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "suplier",
                columns: table => new
                {
                    suplierId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_suplier", x => x.suplierId);
                });

            migrationBuilder.CreateTable(
                name: "Companysupliers",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    suplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companysupliers", x => new { x.CompanyId, x.suplierId });
                    table.ForeignKey(
                        name: "FK_Companysupliers_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Companysupliers_suplier_suplierId",
                        column: x => x.suplierId,
                        principalTable: "suplier",
                        principalColumn: "suplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "CompanyId", "bairro", "cep", "cidade", "cnpj", "logradouro", "name", "numberHouse", "uf" },
                values: new object[,]
                {
                    { 1, "Bairro A", "12345-678", "Cidade A", "12345678900001", "Rua A", "Empresa A", 123, "UF A" },
                    { 2, "Bairro B", "98765-432", "Cidade B", "98765432100001", "Rua B", "Empresa B", 456, "UF B" },
                    { 3, "Bairro C", "56789-012", "Cidade C", "56789012300001", "Rua C", "Empresa C", 789, "UF C" }
                });

            migrationBuilder.InsertData(
                table: "suplier",
                columns: new[] { "suplierId", "bairro", "cep", "cidade", "cnpjCpf", "dateBirth", "email", "logradouro", "name", "numberHouse", "rg", "uf" },
                values: new object[,]
                {
                    { 1, "Bairro A", "12345-678", "Cidade A", "12345678900001", null, "test1@test.com", "Rua A", "Empresa A", 123, "0", "UF A" },
                    { 2, "Bairro B", "98765-432", "Cidade B", "11544610516", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "test2@test.com", "Rua B", "Empresa B", 456, "555555555", "UF B" },
                    { 3, "Bairro C", "56789-012", "Cidade C", "56789012300001", null, "test3@test.com", "Rua C", "Empresa C", 789, "0", "UF C" }
                });

            migrationBuilder.InsertData(
                table: "Companysupliers",
                columns: new[] { "CompanyId", "suplierId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companysupliers_suplierId",
                table: "Companysupliers",
                column: "suplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companysupliers");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "suplier");
        }
    }
}
