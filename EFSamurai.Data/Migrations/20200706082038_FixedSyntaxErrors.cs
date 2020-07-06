using Microsoft.EntityFrameworkCore.Migrations;

namespace EFSamurai.Data.Migrations
{
    public partial class FixedSyntaxErrors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleEvents_BattleLogs_BattleLogId",
                table: "BattleEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_BattleLogs_Battle_BattleId",
                table: "BattleLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_SecretIdentities_Samurais_SamuraiId",
                table: "SecretIdentities");

            migrationBuilder.DropIndex(
                name: "IX_SecretIdentities_SamuraiId",
                table: "SecretIdentities");

            migrationBuilder.DropIndex(
                name: "IX_BattleLogs_BattleId",
                table: "BattleLogs");

            migrationBuilder.AlterColumn<int>(
                name: "SamuraiId",
                table: "SecretIdentities",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BattleId",
                table: "BattleLogs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BattleLogId",
                table: "BattleEvents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecretIdentities_SamuraiId",
                table: "SecretIdentities",
                column: "SamuraiId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BattleLogs_BattleId",
                table: "BattleLogs",
                column: "BattleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleEvents_BattleLogs_BattleLogId",
                table: "BattleEvents",
                column: "BattleLogId",
                principalTable: "BattleLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleLogs_Battle_BattleId",
                table: "BattleLogs",
                column: "BattleId",
                principalTable: "Battle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_BattleEvents_BattleLogs_BattleLogId",
                table: "BattleEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_BattleLogs_Battle_BattleId",
                table: "BattleLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_SecretIdentities_Samurais_SamuraiId",
                table: "SecretIdentities");

            migrationBuilder.DropIndex(
                name: "IX_SecretIdentities_SamuraiId",
                table: "SecretIdentities");

            migrationBuilder.DropIndex(
                name: "IX_BattleLogs_BattleId",
                table: "BattleLogs");

            migrationBuilder.AlterColumn<int>(
                name: "SamuraiId",
                table: "SecretIdentities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BattleId",
                table: "BattleLogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BattleLogId",
                table: "BattleEvents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_SecretIdentities_SamuraiId",
                table: "SecretIdentities",
                column: "SamuraiId",
                unique: true,
                filter: "[SamuraiId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BattleLogs_BattleId",
                table: "BattleLogs",
                column: "BattleId",
                unique: true,
                filter: "[BattleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleEvents_BattleLogs_BattleLogId",
                table: "BattleEvents",
                column: "BattleLogId",
                principalTable: "BattleLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleLogs_Battle_BattleId",
                table: "BattleLogs",
                column: "BattleId",
                principalTable: "Battle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SecretIdentities_Samurais_SamuraiId",
                table: "SecretIdentities",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
