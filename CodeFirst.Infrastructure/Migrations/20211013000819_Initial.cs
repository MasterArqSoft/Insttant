using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirst.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    IdField = table.Column<int>(type: "int", nullable: false, comment: "Identificador del Field")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Codigo del Field"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "Nombre del Field")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.IdField);
                });

            migrationBuilder.CreateTable(
                name: "Flow",
                columns: table => new
                {
                    IdFlow = table.Column<int>(type: "int", nullable: false, comment: "Identificador del Flow")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Codigo del Flow"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "Nombre del Flow")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flow", x => x.IdFlow);
                });

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    IdStep = table.Column<int>(type: "int", nullable: false, comment: "Identificador del Step")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Codigo del Step"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "Nombre del Step")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.IdStep);
                });

            migrationBuilder.CreateTable(
                name: "StepToFlow",
                columns: table => new
                {
                    IdStepToFlow = table.Column<int>(type: "int", nullable: false, comment: "Identificador la StepToFlow")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFlow = table.Column<int>(type: "int", nullable: false, comment: "Identificador del Flow"),
                    IdStep = table.Column<int>(type: "int", nullable: false, comment: "Identificador del step"),
                    IdField = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepToFlow", x => x.IdStepToFlow);
                    table.ForeignKey(
                        name: "FK_StepToFlow_Field",
                        column: x => x.IdField,
                        principalTable: "Field",
                        principalColumn: "IdField",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StepToFlow_Flow",
                        column: x => x.IdFlow,
                        principalTable: "Flow",
                        principalColumn: "IdFlow",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StepToFlow_Step",
                        column: x => x.IdStep,
                        principalTable: "Step",
                        principalColumn: "IdStep",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Field",
                columns: new[] { "IdField", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "F-0001", "Primer nombre" },
                    { 2, "F-0002", "Segundo nombre" },
                    { 3, "F-0003", "Primer apellido" },
                    { 4, "F-0004", "Segundo apellido" },
                    { 5, "F-0005", "Tipo documento" },
                    { 6, "F-0006", "Número de documento" },
                    { 7, "F-0007", "Email" },
                    { 8, "F-0007", "Valor Seguro" }
                });

            migrationBuilder.InsertData(
                table: "Flow",
                columns: new[] { "IdFlow", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "P-0001", "Registrar Usuario" },
                    { 2, "P-0002", "Solicitar poliza de seguro" }
                });

            migrationBuilder.InsertData(
                table: "Step",
                columns: new[] { "IdStep", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "STP-0001", "RegisterUserAsync" },
                    { 2, "STP-0002", "CreateSecureAsync" },
                    { 3, "STP-0003", "SendEmailAsync" },
                    { 4, "STP-0004", "ActiveUserAsync" },
                    { 5, "STP-0005", "ActiveSecureAsync" }
                });

            migrationBuilder.InsertData(
                table: "StepToFlow",
                columns: new[] { "IdStepToFlow", "IdField", "IdFlow", "IdStep" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 15, 6, 2, 4 },
                    { 14, 5, 2, 4 },
                    { 13, 8, 2, 3 },
                    { 12, 6, 2, 3 },
                    { 11, 5, 2, 3 },
                    { 10, 7, 2, 3 },
                    { 16, 5, 2, 5 },
                    { 9, 6, 1, 2 },
                    { 7, 7, 1, 1 },
                    { 6, 6, 1, 1 },
                    { 5, 5, 1, 1 },
                    { 4, 4, 1, 1 },
                    { 3, 3, 1, 1 },
                    { 2, 2, 1, 1 },
                    { 8, 5, 1, 2 },
                    { 17, 6, 2, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StepToFlow_IdField",
                table: "StepToFlow",
                column: "IdField");

            migrationBuilder.CreateIndex(
                name: "IX_StepToFlow_IdFlow",
                table: "StepToFlow",
                column: "IdFlow");

            migrationBuilder.CreateIndex(
                name: "IX_StepToFlow_IdStep",
                table: "StepToFlow",
                column: "IdStep");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StepToFlow");

            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "Flow");

            migrationBuilder.DropTable(
                name: "Step");
        }
    }
}
