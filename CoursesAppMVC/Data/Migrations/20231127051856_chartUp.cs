﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesAppMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class chartUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoursSpent",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "RecordedDate",
                table: "Modules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "HoursSpent",
                table: "Modules",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "RecordedDate",
                table: "Modules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
