using System.Text.RegularExpressions;

namespace CarSeer.Services
{
    public static class StringExtensions
    {
        public static string SanitizeInput(this string input)
        {
            string inputWithoutSpaces = input.Replace(" ", "");
            string pattern = @"[^a-zA-Z0-9\s]";
            string result = Regex.Replace(inputWithoutSpaces, pattern, "").ToLower();
            return result;
        }
    }
}
