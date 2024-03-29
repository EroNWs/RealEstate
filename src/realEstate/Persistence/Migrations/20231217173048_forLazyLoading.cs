﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class forLazyLoading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 86, 216, 69, 32, 120, 94, 167, 122, 147, 64, 142, 121, 117, 203, 204, 164, 89, 160, 207, 181, 20, 47, 226, 45, 213, 195, 198, 177, 60, 44, 78, 216, 48, 78, 78, 15, 38, 107, 237, 235, 219, 127, 124, 227, 199, 168, 92, 15, 42, 14, 100, 248, 147, 124, 88, 180, 237, 79, 6, 64, 56, 124, 102, 228 }, new byte[] { 162, 135, 129, 186, 86, 152, 106, 24, 12, 170, 18, 230, 174, 248, 49, 211, 193, 234, 24, 94, 21, 44, 7, 125, 189, 204, 64, 212, 118, 194, 232, 233, 120, 156, 27, 167, 190, 141, 121, 122, 94, 251, 80, 59, 11, 222, 107, 88, 79, 91, 65, 146, 53, 69, 198, 110, 23, 185, 9, 74, 155, 8, 204, 12, 252, 23, 28, 102, 84, 45, 87, 146, 16, 118, 47, 233, 6, 119, 95, 119, 170, 118, 99, 126, 183, 240, 26, 209, 14, 70, 212, 65, 34, 67, 118, 157, 121, 237, 17, 133, 122, 58, 163, 104, 31, 20, 239, 57, 171, 163, 79, 162, 253, 250, 70, 249, 35, 240, 74, 154, 99, 86, 13, 230, 231, 68, 109, 71 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 187, 58, 80, 224, 167, 77, 218, 79, 159, 85, 89, 104, 233, 162, 91, 215, 254, 202, 40, 240, 129, 240, 185, 179, 51, 21, 80, 124, 82, 149, 233, 104, 137, 44, 188, 80, 30, 4, 199, 12, 168, 13, 236, 58, 113, 145, 48, 62, 31, 111, 8, 114, 96, 167, 220, 0, 235, 193, 42, 193, 205, 58, 55, 136 }, new byte[] { 75, 183, 68, 63, 71, 115, 122, 215, 115, 81, 21, 162, 159, 98, 133, 131, 100, 130, 199, 146, 90, 248, 50, 236, 164, 174, 104, 221, 39, 37, 110, 31, 251, 228, 240, 193, 176, 125, 105, 175, 19, 111, 152, 130, 95, 23, 61, 1, 140, 243, 203, 12, 90, 63, 90, 47, 70, 14, 150, 226, 56, 173, 34, 178, 175, 109, 66, 152, 230, 156, 30, 77, 151, 54, 92, 181, 124, 23, 248, 196, 169, 191, 15, 123, 249, 243, 190, 60, 161, 165, 194, 187, 120, 11, 38, 47, 232, 225, 23, 102, 128, 62, 194, 156, 80, 78, 61, 128, 208, 140, 4, 146, 19, 238, 211, 32, 143, 40, 211, 48, 160, 243, 17, 219, 156, 213, 143, 5 } });
        }
    }
}
