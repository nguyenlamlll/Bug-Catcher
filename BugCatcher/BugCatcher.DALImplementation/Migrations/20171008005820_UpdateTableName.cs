using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BugCatcher.DAL.Implementation.Migrations
{
    public partial class UpdateTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buids_Products_ProductId",
                table: "Buids");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Buids_BuildId",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buids",
                table: "Buids");

            migrationBuilder.RenameTable(
                name: "Buids",
                newName: "Builds");

            migrationBuilder.RenameIndex(
                name: "IX_Buids_ProductId",
                table: "Builds",
                newName: "IX_Builds_ProductId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Builds",
                table: "Builds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Builds_Products_ProductId",
                table: "Builds",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Builds_BuildId",
                table: "Reports",
                column: "BuildId",
                principalTable: "Builds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Builds_Products_ProductId",
                table: "Builds");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Builds_BuildId",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Builds",
                table: "Builds");

            migrationBuilder.RenameTable(
                name: "Builds",
                newName: "Buids");

            migrationBuilder.RenameIndex(
                name: "IX_Builds_ProductId",
                table: "Buids",
                newName: "IX_Buids_ProductId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buids",
                table: "Buids",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Buids_Products_ProductId",
                table: "Buids",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Buids_BuildId",
                table: "Reports",
                column: "BuildId",
                principalTable: "Buids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
