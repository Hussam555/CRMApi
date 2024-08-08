using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRMApi.Migrations
{
    /// <inheritdoc />
    public partial class CustomerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wohnort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postleitzahl = table.Column<int>(type: "int", nullable: false),
                    EmailAdresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephonenummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Erstellungsdatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Änderungsdatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Interest_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
