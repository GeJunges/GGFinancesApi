﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancesApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Budget = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpensesDate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExpenseId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensesDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpensesDate_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpensesDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExpenseDateId = table.Column<Guid>(nullable: false),
                    DetailId = table.Column<Guid>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    Paid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpensesDetails_Details_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpensesDetails_ExpensesDate_ExpenseDateId",
                        column: x => x.ExpenseDateId,
                        principalTable: "ExpensesDate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_Name",
                table: "Details",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_Name_Budget",
                table: "Expenses",
                columns: new[] { "Name", "Budget" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpensesDate_ExpenseId_Date",
                table: "ExpensesDate",
                columns: new[] { "ExpenseId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpensesDetails_DetailId",
                table: "ExpensesDetails",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpensesDetails_ExpenseDateId_DetailId",
                table: "ExpensesDetails",
                columns: new[] { "ExpenseDateId", "DetailId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpensesDetails");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "ExpensesDate");

            migrationBuilder.DropTable(
                name: "Expenses");
        }
    }
}
