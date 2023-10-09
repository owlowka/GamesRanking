namespace GamesRanking.DataAccess.CsvReader.Extensions;

public static class EntityFieldExtensions
{
    public static double? FieldToDouble(this string? field)
    {
        if (String.IsNullOrEmpty(field))
        {
            return null;
        }
        else
        {
            return double.Parse(field);
        }
    }

    public static int? FieldToInt(this string? field)
    {
        if (String.IsNullOrEmpty(field))
        {
            return null;
        }
        else
        {
            return int.Parse(field);
        }
    }

    public static string? FieldToString(this string? field)
    {
        if (String.IsNullOrEmpty(field))
        {
            return null;
        }
        else
        {
            return field;
        }
    }

    public static string[]? FieldToStringArray(this string? field)
    {
        if (String.IsNullOrEmpty(field))
        {
            return null;
        }
        else
        {
            string[]? fieldArray;
            return fieldArray = FieldToString(field)?.Trim().Split(',');
        }
    }
}