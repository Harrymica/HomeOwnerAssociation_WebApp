using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomeOwnerAssociation_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commitees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsedCurrency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commitees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HOA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "WorkOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HOAId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardMembers_HOA_HOAId",
                        column: x => x.HOAId,
                        principalTable: "HOA",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HOAId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rule_HOA_HOAId",
                        column: x => x.HOAId,
                        principalTable: "HOA",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankHolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyOwnersId = table.Column<int>(type: "int", nullable: false),
                    FinancialManagementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Budgetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfExpenses = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpensesType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    typeOfBudget = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    FinancialManagementId = table.Column<int>(type: "int", nullable: true),
                    HOAId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budgetings_HOA_HOAId",
                        column: x => x.HOAId,
                        principalTable: "HOA",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeedRestrictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRestricted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Restriction_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    HOAId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeedRestrictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeedRestrictions_HOA_HOAId",
                        column: x => x.HOAId,
                        principalTable: "HOA",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExeptionalBudgetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    typeOfBudget = table.Column<int>(type: "int", nullable: false),
                    typeOfExpences = table.Column<int>(type: "int", nullable: false),
                    ExpensesValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinancialManagementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExeptionalBudgetings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankTransactionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    DateForMonthlyPayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemainingDept = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FinancialManagementId = table.Column<int>(type: "int", nullable: true),
                    HOAId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fees_HOA_HOAId",
                        column: x => x.HOAId,
                        principalTable: "HOA",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FinancialManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Financialreports = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExeptionalBudgetingsId = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialManagement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    propertyId = table.Column<int>(type: "int", nullable: false),
                    Schedules = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReserveFunds = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinancialManagementId = table.Column<int>(type: "int", nullable: true),
                    HOAId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenances_FinancialManagement_FinancialManagementId",
                        column: x => x.FinancialManagementId,
                        principalTable: "FinancialManagement",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Maintenances_HOA_HOAId",
                        column: x => x.HOAId,
                        principalTable: "HOA",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PropertyOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HOAId = table.Column<int>(type: "int", nullable: true),
                    MaintenanceHistoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyOwners_HOA_HOAId",
                        column: x => x.HOAId,
                        principalTable: "HOA",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropertyOwners_Maintenances_MaintenanceHistoryId",
                        column: x => x.MaintenanceHistoryId,
                        principalTable: "Maintenances",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyTypeId = table.Column<int>(type: "int", nullable: true),
                    Units = table.Column<int>(type: "int", nullable: false),
                    propertyOwnerId = table.Column<int>(type: "int", nullable: true),
                    FeesId = table.Column<int>(type: "int", nullable: true),
                    BudgetingId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    AssessmentId = table.Column<int>(type: "int", nullable: false),
                    RestrictionId = table.Column<int>(type: "int", nullable: false),
                    FinancialHistoryId = table.Column<int>(type: "int", nullable: false),
                    HOAId = table.Column<int>(type: "int", nullable: true),
                    MaintenanceHistoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_HOA_HOAId",
                        column: x => x.HOAId,
                        principalTable: "HOA",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Properties_Maintenances_MaintenanceHistoryId",
                        column: x => x.MaintenanceHistoryId,
                        principalTable: "Maintenances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Properties_PropertyOwners_propertyOwnerId",
                        column: x => x.propertyOwnerId,
                        principalTable: "PropertyOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyTypes_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendor_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PropertyTypes",
                columns: new[] { "Id", "MonthlyFee", "UnitType" },
                values: new object[,]
                {
                    { 1, 100.00m, "Small Appartment" },
                    { 2, 540.00m, "Big Appartment" },
                    { 3, 1600.00m, "Garage" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "HouseOwners", "HOUSEOWNERS" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "Unknown", "Unknown", "d183716a-32b1-4ad7-89e3-db4ae7a7d9a0", "Unknown", "Admin007@gmail.com", true, "Emmanuel Chinonso", true, null, "ADMIN007@GMAIL.COM", "ADMIN007@GMAIL.COM", "AQAAAAIAAYagAAAAEG2rB2DQL47BOFpA+ldXgXdWh1HMMA1VvXz1UBr1XtUEuLfIv2OLODDtK3QMGwAPAg==", "Unknown", true, "d44cb38d-96ff-4b61-a226-6df06bc34d38", false, "Admin007@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_PropertyId",
                table: "Assessments",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_FinancialManagementId",
                table: "BankAccounts",
                column: "FinancialManagementId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_PropertyOwnersId",
                table: "BankAccounts",
                column: "PropertyOwnersId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardMembers_HOAId",
                table: "BoardMembers",
                column: "HOAId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgetings_FinancialManagementId",
                table: "Budgetings",
                column: "FinancialManagementId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgetings_HOAId",
                table: "Budgetings",
                column: "HOAId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgetings_PropertyId",
                table: "Budgetings",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_DeedRestrictions_HOAId",
                table: "DeedRestrictions",
                column: "HOAId");

            migrationBuilder.CreateIndex(
                name: "IX_DeedRestrictions_PropertyId",
                table: "DeedRestrictions",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExeptionalBudgetings_FinancialManagementId",
                table: "ExeptionalBudgetings",
                column: "FinancialManagementId");

            migrationBuilder.CreateIndex(
                name: "IX_ExeptionalBudgetings_PropertyId",
                table: "ExeptionalBudgetings",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_FinancialManagementId",
                table: "Fees",
                column: "FinancialManagementId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_HOAId",
                table: "Fees",
                column: "HOAId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_PropertyId",
                table: "Fees",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialManagement_PropertyId",
                table: "FinancialManagement",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_FinancialManagementId",
                table: "Maintenances",
                column: "FinancialManagementId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_HOAId",
                table: "Maintenances",
                column: "HOAId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_HOAId",
                table: "Properties",
                column: "HOAId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_MaintenanceHistoryId",
                table: "Properties",
                column: "MaintenanceHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_propertyOwnerId",
                table: "Properties",
                column: "propertyOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyTypeId",
                table: "Properties",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyOwners_HOAId",
                table: "PropertyOwners",
                column: "HOAId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyOwners_MaintenanceHistoryId",
                table: "PropertyOwners",
                column: "MaintenanceHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Rule_HOAId",
                table: "Rule",
                column: "HOAId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_PropertyId",
                table: "Vendor",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Properties_PropertyId",
                table: "Assessments",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_FinancialManagement_FinancialManagementId",
                table: "BankAccounts",
                column: "FinancialManagementId",
                principalTable: "FinancialManagement",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_PropertyOwners_PropertyOwnersId",
                table: "BankAccounts",
                column: "PropertyOwnersId",
                principalTable: "PropertyOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Budgetings_FinancialManagement_FinancialManagementId",
                table: "Budgetings",
                column: "FinancialManagementId",
                principalTable: "FinancialManagement",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Budgetings_Properties_PropertyId",
                table: "Budgetings",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeedRestrictions_Properties_PropertyId",
                table: "DeedRestrictions",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExeptionalBudgetings_FinancialManagement_FinancialManagementId",
                table: "ExeptionalBudgetings",
                column: "FinancialManagementId",
                principalTable: "FinancialManagement",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExeptionalBudgetings_Properties_PropertyId",
                table: "ExeptionalBudgetings",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_FinancialManagement_FinancialManagementId",
                table: "Fees",
                column: "FinancialManagementId",
                principalTable: "FinancialManagement",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_Properties_PropertyId",
                table: "Fees",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialManagement_Properties_PropertyId",
                table: "FinancialManagement",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialManagement_Properties_PropertyId",
                table: "FinancialManagement");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "BoardMembers");

            migrationBuilder.DropTable(
                name: "Budgetings");

            migrationBuilder.DropTable(
                name: "Commitees");

            migrationBuilder.DropTable(
                name: "DeedRestrictions");

            migrationBuilder.DropTable(
                name: "ExeptionalBudgetings");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Rule");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "WorkOrder");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "PropertyOwners");

            migrationBuilder.DropTable(
                name: "PropertyTypes");

            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DropTable(
                name: "FinancialManagement");

            migrationBuilder.DropTable(
                name: "HOA");
        }
    }
}
