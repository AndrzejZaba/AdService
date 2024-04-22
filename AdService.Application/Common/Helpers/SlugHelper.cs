using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdService.Application.Common.Helpers;

public static class SlugHelper
{
    public static string GenerateSlug(string title, string location, string id)
    {
        // Combine title and location with a hyphen separator
        string combined = $"{title}-{location}".ToLowerInvariant();

        // Normalize combined string to remove diacritics (accents)
        string normalizedString = RemoveDiacritics(combined);

        // Replace all non-alphanumeric characters with hyphen
        string slug = Regex.Replace(normalizedString, @"[^a-z0-9]+", "-");

        // Trim hyphens from the start and end of the slug
        slug = slug.Trim('-');

        // Append the GUID at the end
        slug += $"-{id}";

        return slug;
    }

    private static string RemoveDiacritics(string text)
    {
        var normalizedString = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }
}
