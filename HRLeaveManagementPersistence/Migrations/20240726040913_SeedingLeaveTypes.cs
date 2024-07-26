using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRLeaveManagementPersistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingLeaveTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "leaveTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DefaultDays", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 7, 26, 5, 9, 12, 395, DateTimeKind.Local).AddTicks(507), 10, "System", new DateTime(2024, 7, 26, 5, 9, 12, 395, DateTimeKind.Local).AddTicks(521), "Vacation" },
                    { 2, "System", new DateTime(2024, 7, 26, 5, 9, 12, 395, DateTimeKind.Local).AddTicks(523), 14, "System", new DateTime(2024, 7, 26, 5, 9, 12, 395, DateTimeKind.Local).AddTicks(523), "Sick" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "leaveTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "leaveTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
