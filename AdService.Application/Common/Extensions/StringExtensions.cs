

using System.Net;
using System.Text.RegularExpressions;
using System.Xml;

namespace AdService.Application.Common.Extensions;

public static class StringExtensions
{
    public static string TakeFirstNChar(this string model, int maxLength)
    {
        if (string.IsNullOrEmpty(model))
            return string.Empty;

        if (model.Length <= maxLength)
            return model;

        return model.Substring(0, maxLength - 3) + "...";
    }

    /// <summary>
    /// This function only works for markups like <p> <li> <ul> and <b>
    /// </summary>
    /// <param name="html"></param>
    /// <returns></returns>
    public static string ExtractTextFromHtml(this string html)
    {
        if (string.IsNullOrWhiteSpace(html))
            return string.Empty;

        // Pattern to remove any HTML tags and add a space after the tag
        string htmlTagPattern = "<.*?>";

        // Replace HTML tags with a single space
        var plainText = Regex.Replace(html, htmlTagPattern, " ");

        // Optionally, reduce multiple whitespace characters to a single space
        plainText = Regex.Replace(plainText, "\\s+", " ");

        return plainText;
    }

}
