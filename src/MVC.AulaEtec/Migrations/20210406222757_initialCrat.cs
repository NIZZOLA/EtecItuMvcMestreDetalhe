using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.AulaEtec.Migrations
{
    public partial class initialCrat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClienteModel",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFantasia = table.Column<string>(maxLength: 100, nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 100, nullable: false),
                    Apelido = table.Column<string>(maxLength: 100, nullable: true),
                    Cnpj = table.Column<string>(maxLength: 18, nullable: true),
                    IE = table.Column<string>(maxLength: 18, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Observacoes = table.Column<string>(maxLength: 500, nullable: true),
                    LogoAddress = table.Column<string>(maxLength: 250, nullable: true),
                    CodigoExterno = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteModel", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "ClienteEnderecoModel",
                columns: table => new
                {
                    ClienteEnderecoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(nullable: false),
                    Rua = table.Column<string>(maxLength: 100, nullable: true),
                    Numero = table.Column<string>(maxLength: 10, nullable: true),
                    Bairro = table.Column<string>(maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(maxLength: 10, nullable: true),
                    Referencia = table.Column<string>(maxLength: 50, nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Padrao = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteEnderecoModel", x => x.ClienteEnderecoId);
                    table.ForeignKey(
                        name: "FK_ClienteEnderecoModel_ClienteModel_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClienteModel",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteEnderecoModel_ClienteId",
                table: "ClienteEnderecoModel",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteEnderecoModel");

            migrationBuilder.DropTable(
                name: "ClienteModel");
        }
    }
}
