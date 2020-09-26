using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace todo.dal.Migrations
{
    public partial class AddTenantUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantUser_Tenants_TenantId",
                schema: "dbo",
                table: "TenantUser");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantUser_AspNetUsers_UserId",
                schema: "dbo",
                table: "TenantUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenantUser",
                schema: "dbo",
                table: "TenantUser");

            migrationBuilder.RenameTable(
                name: "TenantUser",
                schema: "dbo",
                newName: "TenantUsers",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_TenantUser_UserId",
                schema: "dbo",
                table: "TenantUsers",
                newName: "IX_TenantUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TenantUser_TenantId",
                schema: "dbo",
                table: "TenantUsers",
                newName: "IX_TenantUsers_TenantId");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId1",
                schema: "dbo",
                table: "TenantUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenantUsers",
                schema: "dbo",
                table: "TenantUsers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TenantUsers_TenantId1",
                schema: "dbo",
                table: "TenantUsers",
                column: "TenantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantUsers_Tenants_TenantId",
                schema: "dbo",
                table: "TenantUsers",
                column: "TenantId",
                principalSchema: "dbo",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TenantUsers_Tenants_TenantId1",
                schema: "dbo",
                table: "TenantUsers",
                column: "TenantId1",
                principalSchema: "dbo",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TenantUsers_AspNetUsers_UserId",
                schema: "dbo",
                table: "TenantUsers",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantUsers_Tenants_TenantId",
                schema: "dbo",
                table: "TenantUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantUsers_Tenants_TenantId1",
                schema: "dbo",
                table: "TenantUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantUsers_AspNetUsers_UserId",
                schema: "dbo",
                table: "TenantUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenantUsers",
                schema: "dbo",
                table: "TenantUsers");

            migrationBuilder.DropIndex(
                name: "IX_TenantUsers_TenantId1",
                schema: "dbo",
                table: "TenantUsers");

            migrationBuilder.DropColumn(
                name: "TenantId1",
                schema: "dbo",
                table: "TenantUsers");

            migrationBuilder.RenameTable(
                name: "TenantUsers",
                schema: "dbo",
                newName: "TenantUser",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_TenantUsers_UserId",
                schema: "dbo",
                table: "TenantUser",
                newName: "IX_TenantUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TenantUsers_TenantId",
                schema: "dbo",
                table: "TenantUser",
                newName: "IX_TenantUser_TenantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenantUser",
                schema: "dbo",
                table: "TenantUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantUser_Tenants_TenantId",
                schema: "dbo",
                table: "TenantUser",
                column: "TenantId",
                principalSchema: "dbo",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TenantUser_AspNetUsers_UserId",
                schema: "dbo",
                table: "TenantUser",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
