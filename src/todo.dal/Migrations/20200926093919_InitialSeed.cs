using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Todo.Dal.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Tenants",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("68b45895-8b2c-4d83-8396-1959b59a21a6"), "Default Tenant" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TodoItems",
                columns: new[] { "Id", "Description", "DoWhat", "Done", "TenantId", "TodoListId", "TotoListId" },
                values: new object[] { new Guid("a9fad21f-0305-410f-a8a1-b9c997cbfa7d"), "Hack all day", "Hack", false, new Guid("68b45895-8b2c-4d83-8396-1959b59a21a6"), new Guid("81df3f6f-4bb8-4195-932e-a091c5019aad"), null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TodoItems",
                columns: new[] { "Id", "Description", "DoWhat", "Done", "TenantId", "TodoListId", "TotoListId" },
                values: new object[] { new Guid("b75cbfd1-2509-4362-beea-c59baa895bae"), "Hack all night", "Hack even more", false, new Guid("68b45895-8b2c-4d83-8396-1959b59a21a6"), new Guid("81df3f6f-4bb8-4195-932e-a091c5019aad"), null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TodoItems",
                columns: new[] { "Id", "Description", "DoWhat", "Done", "TenantId", "TodoListId", "TotoListId" },
                values: new object[] { new Guid("1c16ccb0-a05b-4c0c-af38-4dfbc90076a3"), "Drink coffee all day", "Drink coffee", false, new Guid("68b45895-8b2c-4d83-8396-1959b59a21a6"), new Guid("94260d4d-133f-403e-8b71-0521b87f2215"), null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TodoItems",
                columns: new[] { "Id", "Description", "DoWhat", "Done", "TenantId", "TodoListId", "TotoListId" },
                values: new object[] { new Guid("936a6bef-b102-427c-805a-e06b172dec8c"), "Drink coffee all night", "Drink even more coffee", false, new Guid("68b45895-8b2c-4d83-8396-1959b59a21a6"), new Guid("94260d4d-133f-403e-8b71-0521b87f2215"), null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TodoLists",
                columns: new[] { "Id", "Description", "TenantId", "Title" },
                values: new object[] { new Guid("81df3f6f-4bb8-4195-932e-a091c5019aad"), "First example todo list", new Guid("68b45895-8b2c-4d83-8396-1959b59a21a6"), "TodoList 1" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TodoLists",
                columns: new[] { "Id", "Description", "TenantId", "Title" },
                values: new object[] { new Guid("94260d4d-133f-403e-8b71-0521b87f2215"), "Second example todo list", new Guid("68b45895-8b2c-4d83-8396-1959b59a21a6"), "TodoList 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: new Guid("1c16ccb0-a05b-4c0c-af38-4dfbc90076a3"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: new Guid("936a6bef-b102-427c-805a-e06b172dec8c"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: new Guid("a9fad21f-0305-410f-a8a1-b9c997cbfa7d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: new Guid("b75cbfd1-2509-4362-beea-c59baa895bae"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TodoLists",
                keyColumn: "Id",
                keyValue: new Guid("81df3f6f-4bb8-4195-932e-a091c5019aad"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TodoLists",
                keyColumn: "Id",
                keyValue: new Guid("94260d4d-133f-403e-8b71-0521b87f2215"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("68b45895-8b2c-4d83-8396-1959b59a21a6"));
        }
    }
}
