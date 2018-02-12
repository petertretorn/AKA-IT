using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FormManager.Data.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Forms_FormId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_FormId",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "Member");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Forms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Forms_MemberId",
                table: "Forms",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Member_MemberId",
                table: "Forms",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Member_MemberId",
                table: "Forms");

            migrationBuilder.DropIndex(
                name: "IX_Forms_MemberId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Forms");

            migrationBuilder.AddColumn<int>(
                name: "FormId",
                table: "Member",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Member_FormId",
                table: "Member",
                column: "FormId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Forms_FormId",
                table: "Member",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
