using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enki.Migrations
{
    public partial class SecureBoot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "RegisteredOn" },
                values: new object[] { "6niXyt4vhoOWhG6N/Rje0e4wGrGndK0eSbahkJdu7kk=", new DateTime(2022, 9, 26, 4, 59, 25, 450, DateTimeKind.Local).AddTicks(8861) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "RegisteredOn" },
                values: new object[] { "svbCoMlwN1Uv4JbSj4B7OzI2T/euRF+zJAnIRhP2gWI=", new DateTime(2022, 9, 26, 4, 59, 25, 457, DateTimeKind.Local).AddTicks(7791) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "RegisteredOn" },
                values: new object[] { "6niXyt4vhoOWhG6N/Rje0e4wGrGndK0eSbahkJdu7kk=", new DateTime(2022, 9, 26, 4, 59, 25, 464, DateTimeKind.Local).AddTicks(7153) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Order", "Password", "RegisteredOn" },
                values: new object[] { "Shark Girl Idol", "m2BvrMF5k4zIxPCduBv2IWQO+EPwcQOkyxC9VjpJ1HE=", new DateTime(2022, 9, 26, 4, 59, 25, 471, DateTimeKind.Local).AddTicks(5379) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "RegisteredOn" },
                values: new object[] { "password", new DateTime(2022, 9, 26, 4, 15, 39, 846, DateTimeKind.Local).AddTicks(4461) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "RegisteredOn" },
                values: new object[] { "Nanomachines", new DateTime(2022, 9, 26, 4, 15, 39, 846, DateTimeKind.Local).AddTicks(4492) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "RegisteredOn" },
                values: new object[] { "password", new DateTime(2022, 9, 26, 4, 15, 39, 846, DateTimeKind.Local).AddTicks(4495) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Order", "Password", "RegisteredOn" },
                values: new object[] { "Shark Idol", "shaaark", new DateTime(2022, 9, 26, 4, 15, 39, 846, DateTimeKind.Local).AddTicks(4497) });
        }
    }
}
