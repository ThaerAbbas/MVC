using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstPro.Migrations
{
    public partial class AddingIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "117c2fa1-4da2-433c-9676-948a58da3782");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "59519a12-4d7b-4a52-8237-3e032696deff", "8d390283-d984-49d3-b4fc-9272094125f2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59519a12-4d7b-4a52-8237-3e032696deff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d390283-d984-49d3-b4fc-9272094125f2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "56fe1dfe-1538-4ed5-8a47-f22f2dc59b57", "13ca0ae2-8381-40b7-87a2-bb799135d924", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9fecd0a1-9183-4ebe-8536-587f2182958d", "9321c590-6398-4dff-b258-e713c060e759", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "46e8fefb-77d2-4f58-bb64-3d181a09a4cb", 0, 1989, "a36f35e7-9e00-4ff6-b589-66409cacb18c", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEB06XSgr1dQkA3jndoW6opI3Dzuqo8K5tkPvhEGXssdxBuKT8sBtN0BBA6i0UYArLw==", null, false, "ecbf3121-cf93-4e8c-8017-e9adb974e86f", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9fecd0a1-9183-4ebe-8536-587f2182958d", "46e8fefb-77d2-4f58-bb64-3d181a09a4cb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56fe1dfe-1538-4ed5-8a47-f22f2dc59b57");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9fecd0a1-9183-4ebe-8536-587f2182958d", "46e8fefb-77d2-4f58-bb64-3d181a09a4cb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fecd0a1-9183-4ebe-8536-587f2182958d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46e8fefb-77d2-4f58-bb64-3d181a09a4cb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "117c2fa1-4da2-433c-9676-948a58da3782", "aee2b35c-42c7-463e-9e74-e75900e80525", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "59519a12-4d7b-4a52-8237-3e032696deff", "1b661ce7-8f99-4ab9-9309-84211e6bee0e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8d390283-d984-49d3-b4fc-9272094125f2", 0, 1989, "e54d2abe-dc10-4ff7-b78e-533ec2eb3505", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEKTxbpR+zknivMyRXMLTn7ZrKrNLUTz8B6m9hcQbBHhYGQ/vZ3M2D1Tm1yhRgplDHA==", null, false, "506feab4-cf17-4c59-8713-dad27a7d1076", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "59519a12-4d7b-4a52-8237-3e032696deff", "8d390283-d984-49d3-b4fc-9272094125f2" });
        }
    }
}
