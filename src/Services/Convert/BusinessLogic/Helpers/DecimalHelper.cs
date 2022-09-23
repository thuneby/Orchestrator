namespace Convert.BusinessLogic.Helpers
{
    public static class DecimalHelper
    {
        public static decimal GetAmountWithDecimals(string amount) 
        {
            if (string.IsNullOrEmpty(amount))
                return 0M;
            var success = decimal.TryParse(amount, out var result);
            return success ? result / 100 : 0M;
        }

        public static decimal AdjustSign(decimal amount, string sign)
        {
            return sign == "-" || sign == "2" ? -amount : amount;
        }
    }
}
