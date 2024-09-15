namespace Catalog.Api.Common.Extensions;

public static partial class StringExtensions
{
    public static string ToKebabCase(this string input)
    {
        string sanitizedInput = GenerateSanitize().Replace(input, "");

        string kebab = GenerateKebab().Replace(sanitizedInput.Trim(), "-");

        return kebab.ToLower();
    }

    [GeneratedRegex(@"[^a-zA-Z0-9\s-]")]
    private static partial Regex GenerateSanitize();


    [GeneratedRegex(@"\s+")]
    private static partial Regex GenerateKebab();
}
