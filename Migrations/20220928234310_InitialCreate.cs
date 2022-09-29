using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectricityAccountAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AggregatedDatas",
                columns: table => new
                {
                    PowerGrid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectId = table.Column<int>(type: "int", nullable: false),
                    PowerConsume = table.Column<double>(type: "float", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PowerGenerate = table.Column<double>(type: "float", nullable: false),
                    PowerDifference = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AggregatedDatas");
        }
    }
}
