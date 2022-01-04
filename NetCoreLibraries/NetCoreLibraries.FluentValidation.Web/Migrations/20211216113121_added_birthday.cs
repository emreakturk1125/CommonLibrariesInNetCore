using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreLibraries.FluentValidation.Web.Migrations
{
    public partial class added_birthday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Customers");
        }
    }
}
