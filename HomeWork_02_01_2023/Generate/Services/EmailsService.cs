namespace Generate.Services;

public static class EmailsService
{
    private static readonly string[] ends = { "gmail.com", "mail.ru", "icloud.com", "bsu.by", "yandex.ru" };

    public static string GetEmail(string name)
    {
        var nameLower = name.ToLower().Split(' ');

        return $"{nameLower[0]}{nameLower[1]}@{ends[Random.Shared.Next(0, ends.Length - 1)]}";
    }
}