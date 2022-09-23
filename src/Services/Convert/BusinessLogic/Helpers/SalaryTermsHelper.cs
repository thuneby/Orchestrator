using Core.DomainModels;

namespace Convert.BusinessLogic.Helpers
{
    public static class SalaryTermsHelper
    {
        public static SalaryTerms GetTerms(string inputString)
        {
            var success = int.TryParse(inputString, out var netsCode);
            if (!success)
                return SalaryTerms.Unknown;
            return netsCode switch
            {
                0 => SalaryTerms.Monthly,
                1 => SalaryTerms.HourlyByMonth,
                2 => SalaryTerms.Biweekly,
                3 => SalaryTerms.Weekly,
                4 => SalaryTerms.Daily,
                5 => SalaryTerms.Quarterly,
                _ => SalaryTerms.Unknown
            };
        }
    }
}
