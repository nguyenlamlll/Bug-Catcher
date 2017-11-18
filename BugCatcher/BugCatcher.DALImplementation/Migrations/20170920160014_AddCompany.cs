using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BugCatcher.DAL.Implementation.Migrations
{
    public partial class AddCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEnrollment_Company_CompanyId",
                table: "CompanyEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEnrollment_AspNetUsers_UserId",
                table: "CompanyEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Company_CompanyId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyEnrollment",
                table: "CompanyEnrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "CompanyEnrollment",
                newName: "CompanyEnrollments");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyEnrollment_UserId",
                table: "CompanyEnrollments",
                newName: "IX_CompanyEnrollments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyEnrollment_CompanyId",
                table: "CompanyEnrollments",
                newName: "IX_CompanyEnrollments_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyEnrollments",
                table: "CompanyEnrollments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyEnrollments_Companies_CompanyId",
                table: "CompanyEnrollments",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyEnrollments_AspNetUsers_UserId",
                table: "CompanyEnrollments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEnrollments_Companies_CompanyId",
                table: "CompanyEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEnrollments_AspNetUsers_UserId",
                table: "CompanyEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyEnrollments",
                table: "CompanyEnrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "CompanyEnrollments",
                newName: "CompanyEnrollment");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyEnrollments_UserId",
                table: "CompanyEnrollment",
                newName: "IX_CompanyEnrollment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyEnrollments_CompanyId",
                table: "CompanyEnrollment",
                newName: "IX_CompanyEnrollment_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyEnrollment",
                table: "CompanyEnrollment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyEnrollment_Company_CompanyId",
                table: "CompanyEnrollment",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyEnrollment_AspNetUsers_UserId",
                table: "CompanyEnrollment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Company_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
