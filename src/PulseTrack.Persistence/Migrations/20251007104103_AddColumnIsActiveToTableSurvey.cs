﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PulseTrack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnIsActiveToTableSurvey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "surveys",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_active",
                table: "surveys");
        }
    }
}
