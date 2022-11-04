using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetC_Assessment___Coding_exercise.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    FirstName = table.Column<string>(type: "ntext", nullable: true),
                    LastNme = table.Column<string>(type: "ntext", nullable: true),
                    DriverLicense = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Brand = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Vin = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    year = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Owner_Id = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.id);
                    table.ForeignKey(
                        name: "Owner_Id",
                        column: x => x.Owner_Id,
                        principalTable: "Vehicles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    Vehicle_Id = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.id);
                    table.ForeignKey(
                        name: "Vehicle_Id",
                        column: x => x.Vehicle_Id,
                        principalTable: "Vehicles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_Vehicle_Id",
                table: "Claims",
                column: "Vehicle_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Owner_Id",
                table: "Vehicles",
                column: "Owner_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
