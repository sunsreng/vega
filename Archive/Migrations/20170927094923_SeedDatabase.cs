using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MAKES (Name) VALUES('MAKE1')");
            migrationBuilder.Sql("INSERT INTO MAKES (Name) VALUES('MAKE2')");
            migrationBuilder.Sql("INSERT INTO MAKES (Name) VALUES('MAKE3')");

            migrationBuilder.Sql("INSERT INTO MODELS (Name, MakeID) VALUES('MAKE1-MODELA', (SELECT ID FROM MAKES WHERE NAME='MAKE1'))");
            migrationBuilder.Sql("INSERT INTO MODELS (Name, MakeID) VALUES('MAKE1-MODELB', (SELECT ID FROM MAKES WHERE NAME='MAKE1'))");
            migrationBuilder.Sql("INSERT INTO MODELS (Name, MakeID) VALUES('MAKE1-MODELC', (SELECT ID FROM MAKES WHERE NAME='MAKE1'))");

            migrationBuilder.Sql("INSERT INTO MODELS (Name, MakeID) VALUES('MAKE1-MODELA', (SELECT ID FROM MAKES WHERE NAME='MAKE2'))");
            migrationBuilder.Sql("INSERT INTO MODELS (Name, MakeID) VALUES('MAKE1-MODELB', (SELECT ID FROM MAKES WHERE NAME='MAKE2'))");
            migrationBuilder.Sql("INSERT INTO MODELS (Name, MakeID) VALUES('MAKE1-MODELC', (SELECT ID FROM MAKES WHERE NAME='MAKE2'))");

            migrationBuilder.Sql("INSERT INTO MODELS (Name, MakeID) VALUES('MAKE1-MODELA', (SELECT ID FROM MAKES WHERE NAME='MAKE3'))");
            migrationBuilder.Sql("INSERT INTO MODELS (Name, MakeID) VALUES('MAKE1-MODELB', (SELECT ID FROM MAKES WHERE NAME='MAKE3'))");
            migrationBuilder.Sql("INSERT INTO MODELS (Name, MakeID) VALUES('MAKE1-MODELC', (SELECT ID FROM MAKES WHERE NAME='MAKE3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes WHERE NAME IN ('MAKE1','MAKE2','MAKE3')");
        }
    }
}
