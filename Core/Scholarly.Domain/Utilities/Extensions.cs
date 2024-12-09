using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scholarly.Domain.Utilities
{
    public static class StringExtensions
    {
        public static string RemoveNotAllowedUrlCharacters(this string input)
        {
            string allowedCharsPattern = @"[^a-zA-Z0-9\-._~:/?#[\]@!$&'()*+,;=]";
            return Regex.Replace(input, allowedCharsPattern, string.Empty);
        }
    }
}
