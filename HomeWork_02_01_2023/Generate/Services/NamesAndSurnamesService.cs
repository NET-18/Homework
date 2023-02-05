namespace Generate.Services;

public class NamesAndSurnamesService
{
    private static readonly string _names =
        "Wade Dave Seth Ivan Riley Gilbert Jorge Dan Brian Roberto Ramon Miles Liam Nathaniel Ethan Lewis" +
        " Milton Claude Joshua Glen Harvey Blake Antonio Connor Julian Aidan Harold Conner Peter Hunter Eli" +
        " Alberto Carlos Shane Marlin Paul Ricardo Hector Alexis Adrian Kingston Douglas Gerald Joey Johnny" +
        " Charlie Scott Martin Troy Tommy Rick Victor Jessie Neil Ted Nick Wiley Morris Clark Stuart" +
        " Orlando Keith Marion Marshall Noel Everett Romeo Sebastian Stefan Robin Clarence Sandy Ernest Samuel" +
        " Benjamin Luka Fred Albert Greyson Terry Cedric Joe Paul George Bruce Christopher Mark Ron Craig" +
        " Philip Jimmy Arthur Jaime Perry Harold Jerry Shawn Walter";

    private readonly string[] names = _names.Split(' ');

    private static readonly string _surnames =
        "Williams Harris Thomas Robinson Walker Scott Nelson Mitchell Morgan Cooper Howard Davis Miller Martin" +
        " Smith Anderson White Perry Clark Richards Wheeler Warburton Stanley Holland Terry Shelton Miles Lucas" +
        " Fletcher Parks Norris Guzman Daniel Newton Potter Francis Erickson Norman Moody Lindsey Gross Sherman" +
        " Simon Jones Brown Garcia Rodriguez Lee Young Hall Allen Lopez Green Gonzalez Baker Adams Perez Campbell" +
        " Shaw Gordon Burns Warren Long Mcdonald Gibson Ellis Fisher Reynolds Jordan Hamilton Ford Graham Griffin Russell" +
        " Foster Butler Simmons Flores Bennett Sanders Hughes Bryant Patterson Matthews Jenkins Watkins Ward Murphy" +
        " Bailey Bell Cox Martinez Evans Rivera Peterson Gomez Murray Tucker Hicks Crawford Mason Rice Black" +
        " Knight Arnold Wagner Mosby Ramirez Coleman Powell Singh Patel Wood Wright Stephens Eriksen Cook Roberts" +
        " Holmes Kennedy Saunders Fisher Hunter Reid Stewart Carter Phillips Spencer Howell Alvarez Little Jacobs" +
        " Foreman Knowles Meadows Richmond Valentine Dudley Woodward Weasley Livingston Sheppard Kimmel Noble Leach Gentry Lara Pace Trujillo Grant";

    private readonly string[] surnames = _surnames.Split(' ');

    public string GetName()
    {
        return $"{names[Random.Shared.Next(0, names.Length - 1)]} {surnames[Random.Shared.Next(0, surnames.Length - 1)]}";
    }
}