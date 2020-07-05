using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFSamurai.Data.Migrations
{
    public partial class SamuraiBattle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Quote_QuoteId",
                table: "Samurais");

            migrationBuilder.DropForeignKey(
                name: "FK_SecretIdentity_Samurais_SamuraiId",
                table: "SecretIdentity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecretIdentity",
                table: "SecretIdentity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quote",
                table: "Quote");

            migrationBuilder.RenameTable(
                name: "SecretIdentity",
                newName: "SecretIdentities");

            migrationBuilder.RenameTable(
                name: "Quote",
                newName: "Quotes");

            migrationBuilder.RenameIndex(
                name: "IX_SecretIdentity_SamuraiId",
                table: "SecretIdentities",
                newName: "IX_SecretIdentities_SamuraiId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecretIdentities",
                table: "SecretIdentities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quotes",
                table: "Quotes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Battle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsBrutal = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SamuraiBattles",
                columns: table => new
                {
                    SamuraiId = table.Column<int>(nullable: false),
                    BattleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SamuraiBattles", x => new { x.SamuraiId, x.BattleId });
                    table.ForeignKey(
                        name: "FK_SamuraiBattles_Battle_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SamuraiBattles_Samurais_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SamuraiBattles_BattleId",
                table: "SamuraiBattles",
                column: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Quotes_QuoteId",
                table: "Samurais",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SecretIdentities_Samurais_SamuraiId",
                table: "SecretIdentities",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Quotes_QuoteId",
                table: "Samurais");

            migrationBuilder.DropForeignKey(
                name: "FK_SecretIdentities_Samurais_SamuraiId",
                table: "SecretIdentities");

            migrationBuilder.DropTable(
                name: "SamuraiBattles");

            migrationBuilder.DropTable(
                name: "Battle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecretIdentities",
                table: "SecretIdentities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quotes",
                table: "Quotes");

            migrationBuilder.RenameTable(
                name: "SecretIdentities",
                newName: "SecretIdentity");

            migrationBuilder.RenameTable(
                name: "Quotes",
                newName: "Quote");

            migrationBuilder.RenameIndex(
                name: "IX_SecretIdentities_SamuraiId",
                table: "SecretIdentity",
                newName: "IX_SecretIdentity_SamuraiId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecretIdentity",
                table: "SecretIdentity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quote",
                table: "Quote",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Quote_QuoteId",
                table: "Samurais",
                column: "QuoteId",
                principalTable: "Quote",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SecretIdentity_Samurais_SamuraiId",
                table: "SecretIdentity",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
