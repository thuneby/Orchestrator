namespace Convert.BusinessLogic.Helpers
{
    public static class TextHelper
    {
        public static int GetInt(string inputText)
        {
            var success = int.TryParse(inputText, out var result);
            return success ? result : 0;
        }

        public static bool IsNumeric(string? codeString)
        {
            return codeString != null && codeString.Trim().Length != 0 && int.TryParse(codeString, out _);
        }
    }
}
