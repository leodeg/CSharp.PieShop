﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PieShop.Data.Migrations
{
    public partial class AddOrderTimeToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderPlaced",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderPlaced",
                table: "Orders");
        }
    }
}
