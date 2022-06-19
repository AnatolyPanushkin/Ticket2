using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Ticket2.Migrations
{
    public partial class RowVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:adminpack", ",,");

            migrationBuilder.CreateTable(
                name: "segments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ticket_number = table.Column<long>(type: "bigint", nullable: false),
                    operation_type = table.Column<string>(type: "text", nullable: false),
                    operration_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    operation_place = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false),
                    patronymic = table.Column<string>(type: "text", nullable: false),
                    doc_type = table.Column<string>(type: "text", nullable: true),
                    doc_number = table.Column<long>(type: "bigint", nullable: false),
                    birthdate = table.Column<DateTime>(type: "date", nullable: false),
                    gender = table.Column<string>(type: "char", nullable: false),
                    passenger_type = table.Column<string>(type: "text", nullable: false),
                    ticket_type = table.Column<int>(type: "integer", nullable: false),
                    airline_code = table.Column<string>(type: "text", nullable: false),
                    flight_num = table.Column<int>(type: "integer", nullable: false),
                    depart_place = table.Column<string>(type: "text", nullable: false),
                    depart_datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    arrive_place = table.Column<string>(type: "text", nullable: false),
                    arrive_datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    pnr_id = table.Column<string>(type: "text", nullable: false),
                    refund = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("segments_pkey", x => new { x.id, x.ticket_number });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "segments");
        }
    }
}
