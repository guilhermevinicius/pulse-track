using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PulseTrack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSurveyMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_surveys_id",
                table: "surveys");

            migrationBuilder.CreateTable(
                name: "survey_settings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    survey_id = table.Column<Guid>(type: "uuid", nullable: false),
                    accept_answer = table.Column<bool>(type: "boolean", nullable: false),
                    use_date = table.Column<bool>(type: "boolean", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    use_duration = table.Column<bool>(type: "boolean", nullable: false),
                    duration = table.Column<int>(type: "integer", nullable: true),
                    send_notification = table.Column<bool>(type: "boolean", nullable: false),
                    can_edit_answer = table.Column<bool>(type: "boolean", nullable: false),
                    survey_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_survey_settings", x => x.id);
                    table.ForeignKey(
                        name: "fk_survey_settings_surveys_survey_id1",
                        column: x => x.survey_id1,
                        principalTable: "surveys",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_surveys_id",
                table: "surveys",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_survey_settings_id",
                table: "survey_settings",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_survey_settings_survey_id1",
                table: "survey_settings",
                column: "survey_id1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_surveys_survey_settings_id",
                table: "surveys",
                column: "id",
                principalTable: "survey_settings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_surveys_survey_settings_id",
                table: "surveys");

            migrationBuilder.DropTable(
                name: "survey_settings");

            migrationBuilder.DropIndex(
                name: "ix_surveys_id",
                table: "surveys");

            migrationBuilder.CreateIndex(
                name: "ix_surveys_id",
                table: "surveys",
                column: "id");
        }
    }
}
