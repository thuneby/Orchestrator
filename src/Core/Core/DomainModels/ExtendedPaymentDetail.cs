using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.DomainModels
{
    public class ExtendedPaymentDetail: PaymentDetail
    {
        public string LaborAgreementNumber { get; set; }
        public string PersonName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? EmploymentTerminationDate { get; set; }
        public SalaryTerms SalaryTerms { get; set; }
        public decimal? TotalContributionRate { get; set; }

        public decimal? EmployerContributionRate { get; set; }

        [DataType(DataType.Currency)]
        public decimal? EmployerContribution { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? ContributionRateFromDate { get; set; }

        public decimal? NormalContribution { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? NormalContributionStartDate { get; set; }


        [Column(TypeName = "Date")]
        public DateTime? DeviationStartDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? DeviationEndDate { get; set; }

        [Display(Name = "Afvigelseskode")]
        public DeviationCode? DeviationCode { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? EmployeeSalaryStartDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal? EmployeeSalary { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? EmploymentRateStartDate { get; set; }

        public decimal? EmploymentRate { get; set; }

    }
}
