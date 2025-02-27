﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Scholarly.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Users_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Introduction = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: -1, nullable: false),
                    Selector = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Articles_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEducations",
                columns: table => new
                {
                    UserEducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FieldOfStudy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Level = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InstituteName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEducations", x => x.UserEducationId);
                    table.ForeignKey(
                        name: "FK_UserEducations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWorkExperiences",
                columns: table => new
                {
                    UserWorkExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SkillsUsed = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkExperiences", x => x.UserWorkExperienceId);
                    table.ForeignKey(
                        name: "FK_UserWorkExperiences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleImages",
                columns: table => new
                {
                    ArticleImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Selector = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", maxLength: -1, nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleImages", x => x.ArticleImageId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_ArticleImages_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleModifiedByUserMap",
                columns: table => new
                {
                    ArticleModifiedByUserMapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleModifiedByUserMap", x => x.ArticleModifiedByUserMapId);
                    table.ForeignKey(
                        name: "FK_ArticleModifiedByUserMap_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId");
                    table.ForeignKey(
                        name: "FK_ArticleModifiedByUserMap_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "GenderName" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DOB", "DateCreated", "DateModified", "Email", "FirstName", "GenderId", "LastName", "Password", "PhoneNumber", "UserName" },
                values: new object[] { 1, new DateTime(1996, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gurwindersingh@gmail.com", "Gurwinder", 1, "Singh", "admin@admin", "1234567890", "gurwindersingh" });

            migrationBuilder.InsertData(
                table: "UserEducations",
                columns: new[] { "UserEducationId", "DateCreated", "DateModified", "Description", "EducationName", "EndDt", "FieldOfStudy", "InstituteName", "IsActive", "Level", "StartDt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A brief dive in various cloud technologies and their implementation", "Cloud Data Management", new DateTime(2024, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Information Technology", "Conestoga College, Kitchener", false, "Post Graduate Diploma", new DateTime(2023, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A brief study and hand-on experience on computer technologies", "Computer Science and Engineering", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Information Technology", "Rayat Institute of Engineering and Information Technology, Railmajra", false, "Bachelor's of Technology", new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "UserWorkExperiences",
                columns: new[] { "UserWorkExperienceId", "CompanyName", "DateCreated", "DateModified", "Description", "EndDt", "IsActive", "IsCurrent", "Position", "SkillsUsed", "StartDt", "UserId" },
                values: new object[] { 1, "Ace Cooling Solutions", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gained a working experience on latest technologies such as Azure DevOps, Angular, MediatR etc", new DateTime(2024, 12, 8, 0, 8, 37, 245, DateTimeKind.Utc).AddTicks(6110), false, true, "Software Developer", "Azure DevOps, Angular, MediatR, Inversion of Control (IOC), Onion Architecture etc", new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "UserWorkExperiences",
                columns: new[] { "UserWorkExperienceId", "CompanyName", "DateCreated", "DateModified", "Description", "EndDt", "IsActive", "Position", "SkillsUsed", "StartDt", "UserId" },
                values: new object[,]
                {
                    { 2, "Vertex Infosoft Solutions Pvt. Ltd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Worked on a multi-tier application within a team of 5 developers.", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Software Developer", "Angular, Inversion of Control (IOC), JQuery, TypeScript, ASP.NET CORE etc", new DateTime(2017, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "Vertex Infosoft Solutions Pvt. Ltd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gained a working experience of Entity Framework and client handling practices.", new DateTime(2027, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Software Developer", "AngularJS, Entity Framework, ASP.NET MVC etc", new DateTime(2015, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleImages_ArticleId",
                table: "ArticleImages",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleImages_Selector",
                table: "ArticleImages",
                column: "Selector",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleModifiedByUserMap_ArticleId",
                table: "ArticleModifiedByUserMap",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleModifiedByUserMap_ModifiedByUserId",
                table: "ArticleModifiedByUserMap",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CreatedByUserId",
                table: "Articles",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Selector",
                table: "Articles",
                column: "Selector",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_UserEducations_UserId",
                table: "UserEducations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                table: "Users",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkExperiences_UserId",
                table: "UserWorkExperiences",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleImages");

            migrationBuilder.DropTable(
                name: "ArticleModifiedByUserMap");

            migrationBuilder.DropTable(
                name: "UserEducations");

            migrationBuilder.DropTable(
                name: "UserWorkExperiences");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
