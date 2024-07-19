using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PARK_CONTACT_TYPE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ACTIVE = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValue: "N")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FINSERT = table.Column<DateTime>(type: "datetime", nullable: false),
                    USERNAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    FUPDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    USERNAMEUPDATE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CODE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARK_CONTACT_TYPE", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PARK_DOCUMENT_TYPE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CUSTOMER_TYPE = table.Column<int>(type: "int", nullable: false),
                    ACTIVE = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValue: "N")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FINSERT = table.Column<DateTime>(type: "datetime", nullable: false),
                    USERNAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    FUPDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    USERNAMEUPDATE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CODE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARK_DOCUMENT_TYPE", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PARK_GENDER",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ACTIVE = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValue: "N")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FINSERT = table.Column<DateTime>(type: "datetime", nullable: false),
                    USERNAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    FUPDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    USERNAMEUPDATE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CODE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARK_GENDER", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PARK_CUSTOMER",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DOCUMENT_NUMBER = table.Column<int>(type: "int", nullable: false),
                    DOCUMENT_TYPE_ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    COMUNITY_ID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    INVOICE_TYPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ACTIVE = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValue: "N")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FINSERT = table.Column<DateTime>(type: "datetime", nullable: false),
                    USERNAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    FUPDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    USERNAMEUPDATE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CODE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARK_CUSTOMER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PARK_CUSTOMER_PARK_DOCUMENT_TYPE_DOCUMENT_TYPE_ID",
                        column: x => x.DOCUMENT_TYPE_ID,
                        principalTable: "PARK_DOCUMENT_TYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PARK_COMPANY",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    COMPANY_NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CURRENT_NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARK_COMPANY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PARK_COMPANY_PARK_CUSTOMER_ID",
                        column: x => x.ID,
                        principalTable: "PARK_CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PARK_CUSTOMER_ADDRESS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CONTACT_TYPE_ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    STREETNAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STREETNUMBER = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FLOOR = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEPT = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CITY = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    POSTALCODE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    COUNTRY = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LNG = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LAT = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADDRESS_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    CUSTOMER_ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ACTIVE = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValue: "N")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FINSERT = table.Column<DateTime>(type: "datetime", nullable: false),
                    USERNAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    FUPDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    USERNAMEUPDATE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CODE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARK_CUSTOMER_ADDRESS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PARK_CUSTOMER_ADDRESS_PARK_CONTACT_TYPE_CONTACT_TYPE_ID",
                        column: x => x.CONTACT_TYPE_ID,
                        principalTable: "PARK_CONTACT_TYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PARK_CUSTOMER_ADDRESS_PARK_CUSTOMER_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "PARK_CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PARK_CUSTOMER_MAIL",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CUSTOMER_ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CONTACT_TYPE_ID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    EMAIL = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PREFERRED = table.Column<int>(type: "int", nullable: false),
                    ACTIVE = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValue: "N")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FINSERT = table.Column<DateTime>(type: "datetime", nullable: false),
                    USERNAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    FUPDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    USERNAMEUPDATE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CODE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARK_CUSTOMER_MAIL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PARK_CUSTOMER_MAIL_PARK_CONTACT_TYPE_CONTACT_TYPE_ID",
                        column: x => x.CONTACT_TYPE_ID,
                        principalTable: "PARK_CONTACT_TYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PARK_CUSTOMER_MAIL_PARK_CUSTOMER_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "PARK_CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PARK_CUSTOMER_PHONE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CUSTOMER_ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CONTACT_TYPE_ID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PHONE_NUMBER = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ACTIVE = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValue: "N")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FINSERT = table.Column<DateTime>(type: "datetime", nullable: false),
                    USERNAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    FUPDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    USERNAMEUPDATE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CODE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARK_CUSTOMER_PHONE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PARK_CUSTOMER_PHONE_PARK_CONTACT_TYPE_CONTACT_TYPE_ID",
                        column: x => x.CONTACT_TYPE_ID,
                        principalTable: "PARK_CONTACT_TYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PARK_CUSTOMER_PHONE_PARK_CUSTOMER_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "PARK_CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PARK_CUSTOMERPHOTO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CUSTOMER_ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IMAGE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ACTIVE = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValue: "N")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FINSERT = table.Column<DateTime>(type: "datetime", nullable: false),
                    USERNAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    FUPDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    USERNAMEUPDATE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CODE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARK_CUSTOMERPHOTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PARK_CUSTOMERPHOTO_PARK_CUSTOMER_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "PARK_CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PARK_PERSON",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LASTNAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GENDER_ID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    BIRTHDAY = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARK_PERSON", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PARK_PERSON_PARK_CUSTOMER_ID",
                        column: x => x.ID,
                        principalTable: "PARK_CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PARK_PERSON_PARK_GENDER_GENDER_ID",
                        column: x => x.GENDER_ID,
                        principalTable: "PARK_GENDER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PARK_COMPANY_PERSON_CONTACT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CUSTOMER_ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PERSON_ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PREFERRED = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ACTIVE = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValue: "N")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FINSERT = table.Column<DateTime>(type: "datetime", nullable: false),
                    USERNAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VERSION = table.Column<int>(type: "int", nullable: false),
                    FUPDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    USERNAMEUPDATE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CODE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARK_COMPANY_PERSON_CONTACT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PARK_COMPANY_PERSON_CONTACT_PARK_CUSTOMER_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "PARK_CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PARK_COMPANY_PERSON_CONTACT_PARK_PERSON_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "PARK_PERSON",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PARK_COMPANY_PERSON_CONTACT_CUSTOMER_ID",
                table: "PARK_COMPANY_PERSON_CONTACT",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PARK_COMPANY_PERSON_CONTACT_PERSON_ID",
                table: "PARK_COMPANY_PERSON_CONTACT",
                column: "PERSON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PARK_CUSTOMER_DOCUMENT_TYPE_ID",
                table: "PARK_CUSTOMER",
                column: "DOCUMENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PARK_CUSTOMER_ADDRESS_CONTACT_TYPE_ID",
                table: "PARK_CUSTOMER_ADDRESS",
                column: "CONTACT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PARK_CUSTOMER_ADDRESS_CUSTOMER_ID",
                table: "PARK_CUSTOMER_ADDRESS",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PARK_CUSTOMER_MAIL_CONTACT_TYPE_ID",
                table: "PARK_CUSTOMER_MAIL",
                column: "CONTACT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PARK_CUSTOMER_MAIL_CUSTOMER_ID",
                table: "PARK_CUSTOMER_MAIL",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PARK_CUSTOMER_PHONE_CONTACT_TYPE_ID",
                table: "PARK_CUSTOMER_PHONE",
                column: "CONTACT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PARK_CUSTOMER_PHONE_CUSTOMER_ID",
                table: "PARK_CUSTOMER_PHONE",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PARK_CUSTOMERPHOTO_CUSTOMER_ID",
                table: "PARK_CUSTOMERPHOTO",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PARK_PERSON_GENDER_ID",
                table: "PARK_PERSON",
                column: "GENDER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PARK_COMPANY");

            migrationBuilder.DropTable(
                name: "PARK_COMPANY_PERSON_CONTACT");

            migrationBuilder.DropTable(
                name: "PARK_CUSTOMER_ADDRESS");

            migrationBuilder.DropTable(
                name: "PARK_CUSTOMER_MAIL");

            migrationBuilder.DropTable(
                name: "PARK_CUSTOMER_PHONE");

            migrationBuilder.DropTable(
                name: "PARK_CUSTOMERPHOTO");

            migrationBuilder.DropTable(
                name: "PARK_PERSON");

            migrationBuilder.DropTable(
                name: "PARK_CONTACT_TYPE");

            migrationBuilder.DropTable(
                name: "PARK_CUSTOMER");

            migrationBuilder.DropTable(
                name: "PARK_GENDER");

            migrationBuilder.DropTable(
                name: "PARK_DOCUMENT_TYPE");
        }
    }
}
