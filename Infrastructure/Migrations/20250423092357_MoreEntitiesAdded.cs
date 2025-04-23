using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoreEntitiesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveSubscription",
                schema: "mainApp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartingDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndingDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    SubscriptionType = table.Column<string>(type: "text", nullable: false),
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveSubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveSubscription_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "mainApp",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                schema: "mainApp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                },
                comment: "Represents the type of programs an organazation can have to provide some services, eg: a gym could provide a Functional or a Crossfit program");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveSubscription_PersonId",
                schema: "mainApp",
                table: "ActiveSubscription",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveSubscription",
                schema: "mainApp");

            migrationBuilder.DropTable(
                name: "Programs",
                schema: "mainApp");
        }
    }
}
