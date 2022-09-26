using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enki.Migrations
{
    public partial class AddingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobFunction",
                table: "Users",
                newName: "Order");

            migrationBuilder.CreateTable(
                name: "Shrines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShrineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConstructionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shrines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pilgrimages",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ShrineId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilgrimages", x => new { x.UserId, x.ShrineId });
                    table.ForeignKey(
                        name: "FK_Pilgrimages_Shrines_ShrineId",
                        column: x => x.ShrineId,
                        principalTable: "Shrines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pilgrimages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Shrines",
                columns: new[] { "Id", "ConstructionDate", "DeityName", "ShrineName" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poseidon", "Ruin of Atlantis" },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Odin", "Valhalla" },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jesus", "Nazareth" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Order", "Password", "RegisteredOn", "Surname" },
                values: new object[,]
                {
                    { 1L, "max.mcmann@mail.com", "Max", "Attorney", "password", new DateTime(2022, 9, 26, 4, 15, 39, 846, DateTimeKind.Local).AddTicks(4461), "McMann" },
                    { 2L, "s.armstrong@mail.com", "S.", "Senator", "Nanomachines", new DateTime(2022, 9, 26, 4, 15, 39, 846, DateTimeKind.Local).AddTicks(4492), "Armstrong" },
                    { 3L, "claire.redfield@mail.com", "Jill", "S.T.A.R.S", "password", new DateTime(2022, 9, 26, 4, 15, 39, 846, DateTimeKind.Local).AddTicks(4495), "Valentine" },
                    { 4L, "gura.gawr@mail.com", "Gura", "Shark Idol", "shaaark", new DateTime(2022, 9, 26, 4, 15, 39, 846, DateTimeKind.Local).AddTicks(4497), "Gawr" }
                });

            migrationBuilder.InsertData(
                table: "Pilgrimages",
                columns: new[] { "ShrineId", "UserId" },
                values: new object[,]
                {
                    { 2L, 1L },
                    { 2L, 2L },
                    { 3L, 2L },
                    { 1L, 3L },
                    { 1L, 4L },
                    { 2L, 4L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pilgrimages_ShrineId",
                table: "Pilgrimages",
                column: "ShrineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pilgrimages");

            migrationBuilder.DropTable(
                name: "Shrines");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Users",
                newName: "JobFunction");
        }
    }
}
