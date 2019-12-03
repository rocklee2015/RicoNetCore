using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace S04.EFCodeCodeFirstSqlServer.Migrations
{
    public partial class DeleteFiled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "CreateOn",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "ModifyBy",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "ModifyOn",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "Parent",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Menu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "Menu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateOn",
                table: "Menu",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Menu",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Menu",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyBy",
                table: "Menu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyOn",
                table: "Menu",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Parent",
                table: "Menu",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Menu",
                nullable: true);
        }
    }
}
