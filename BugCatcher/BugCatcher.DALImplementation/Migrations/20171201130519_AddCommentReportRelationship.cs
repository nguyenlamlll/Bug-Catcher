using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BugCatcher.DAL.Implementation.Migrations
{
    public partial class AddCommentReportRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReportId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReportId",
                table: "Comments",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Reports_ReportId",
                table: "Comments",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Reports_ReportId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ReportId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Comments");
        }
    }
}
