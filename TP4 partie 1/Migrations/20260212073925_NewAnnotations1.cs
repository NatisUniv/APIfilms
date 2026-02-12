using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP4_partie_1.Migrations
{
    /// <inheritdoc />
    public partial class NewAnnotations1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_t_e_film_flm_flm_titre",
                schema: "public",
                table: "t_e_film_flm");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_utilisateur_utl_utl_mail",
                schema: "public",
                table: "t_e_utilisateur_utl",
                newName: "uq_utl_mail");

            migrationBuilder.AlterColumn<string>(
                name: "utl_ville",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "utl_rue",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "utl_pwd",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "varchar(64)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "utl_prenom",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "utl_pays",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "varchar(50)",
                nullable: true,
                defaultValue: "France",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValueSql: "'France'");

            migrationBuilder.AlterColumn<string>(
                name: "utl_nom",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "utl_mail",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "utl_datecreation",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "date",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<string>(
                name: "utl_cp",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "char(5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "flm_titre",
                schema: "public",
                table: "t_e_film_flm",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "flm_genre",
                schema: "public",
                table: "t_e_film_flm",
                type: "varchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "uq_utl_mail",
                schema: "public",
                table: "t_e_utilisateur_utl",
                newName: "IX_t_e_utilisateur_utl_utl_mail");

            migrationBuilder.AlterColumn<string>(
                name: "utl_ville",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "utl_rue",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "utl_pwd",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(64)");

            migrationBuilder.AlterColumn<string>(
                name: "utl_prenom",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "utl_pays",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                defaultValueSql: "'France'",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true,
                oldDefaultValue: "France");

            migrationBuilder.AlterColumn<string>(
                name: "utl_nom",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "utl_mail",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "utl_datecreation",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<string>(
                name: "utl_cp",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "character varying(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "flm_titre",
                schema: "public",
                table: "t_e_film_flm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "flm_genre",
                schema: "public",
                table: "t_e_film_flm",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_film_flm_flm_titre",
                schema: "public",
                table: "t_e_film_flm",
                column: "flm_titre");
        }
    }
}
