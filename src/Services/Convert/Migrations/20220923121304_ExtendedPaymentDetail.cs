using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Convert.Migrations
{
    public partial class ExtendedPaymentDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerNumber",
                table: "PaymentDetail",
                newName: "PersonName");

            migrationBuilder.AddColumn<DateTime>(
                name: "ContributionRateFromDate",
                table: "PaymentDetail",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerNumberSender",
                table: "PaymentDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustumerNumberRecepient",
                table: "PaymentDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeviationCode",
                table: "PaymentDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeviationEndDate",
                table: "PaymentDetail",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeviationStartDate",
                table: "PaymentDetail",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "PaymentDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "EmployeeSalary",
                table: "PaymentDetail",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EmployeeSalaryStartDate",
                table: "PaymentDetail",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EmployerContribution",
                table: "PaymentDetail",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EmployerContributionRate",
                table: "PaymentDetail",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EmploymentRate",
                table: "PaymentDetail",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EmploymentRateStartDate",
                table: "PaymentDetail",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EmploymentTerminationDate",
                table: "PaymentDetail",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LaborAgreementNumber",
                table: "PaymentDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NormalContribution",
                table: "PaymentDetail",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NormalContributionStartDate",
                table: "PaymentDetail",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalaryTerms",
                table: "PaymentDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SequenceNumber",
                table: "PaymentDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalContributionRate",
                table: "PaymentDetail",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContributionRateFromDate",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "CustomerNumberSender",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "CustumerNumberRecepient",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "DeviationCode",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "DeviationEndDate",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "DeviationStartDate",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "EmployeeSalary",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "EmployeeSalaryStartDate",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "EmployerContribution",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "EmployerContributionRate",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "EmploymentRate",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "EmploymentRateStartDate",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "EmploymentTerminationDate",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "LaborAgreementNumber",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "NormalContribution",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "NormalContributionStartDate",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "SalaryTerms",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "SequenceNumber",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "TotalContributionRate",
                table: "PaymentDetail");

            migrationBuilder.RenameColumn(
                name: "PersonName",
                table: "PaymentDetail",
                newName: "CustomerNumber");
        }
    }
}
