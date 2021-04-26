using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalApplication.API.Migrations
{
    public partial class EditedVacancyMOdel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PortalFormDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TetInstitution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassOfDegree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearofExperience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentEmployer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessionalCertificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhyRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelevantSkills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalFormDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacancy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VacancyUniqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacancyUniqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobDescriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VacancyModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descriptions_Vacancy_VacancyModelId",
                        column: x => x.VacancyModelId,
                        principalTable: "Vacancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacancyUniqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobRequirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VacancyModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requirements_Vacancy_VacancyModelId",
                        column: x => x.VacancyModelId,
                        principalTable: "Vacancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_VacancyModelId",
                table: "Descriptions",
                column: "VacancyModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_VacancyModelId",
                table: "Requirements",
                column: "VacancyModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DropTable(
                name: "PortalFormDatas");

            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "Vacancy");
        }
    }
}
