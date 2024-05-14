using System.Globalization;

namespace Log4U.Core.Utils
{
    public static class DateTimeValidator
    {
        private static readonly ISet<string> formats = new HashSet<string>
        {
            "M/d/yyyy h:mm:ss tt"
        };
        public static bool ValidateDateTime(string dateTime)
        {
            foreach (var format in formats)
            {
                if (DateTime.TryParseExact(dateTime, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    return true;
                }

            }
            return false;
        }
        public static void AddFormat(string format) => formats.Add(format);
    }
}
