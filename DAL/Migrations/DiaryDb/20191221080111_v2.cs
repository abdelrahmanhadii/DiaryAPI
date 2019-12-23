using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations.DiaryDb
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Diaries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Diaries",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Diaries");

            migrationBuilder.AlterColumn<string>(
                name: "DueDate",
                table: "Diaries",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
