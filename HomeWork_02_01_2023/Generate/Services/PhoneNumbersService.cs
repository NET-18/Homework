namespace Generate.Services;

public class PhoneNumbersService
{
    private static readonly int[] codes = new[] { 17, 25, 29, 33, 44};

    public string GetRandomNumber()
    {
        var code = codes[Random.Shared.Next(0, 4)];
        var number = Random.Shared.Next(9999999);

        return $"+375({code}){number}";
    }
}