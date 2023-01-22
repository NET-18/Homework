namespace WebApplication3.Services
{
    public class GeneratePersonNameService
    {

        public async Task<Person> GetRandomPersonName()
        {
            int randomNumber = Random.Shared.Next(0, 10);
            var person = new Person();
            person.Name = "";
            person.Gender = "";
            string[] namesWomen =
            {
                "Caroline",
                "Margarite",
                "Victoria",
                "Elisaveta",
                "Shlondra",
                "Potaskuha"
            };
            string[] namesMen =
            {
                "Mike",
                "Tony",
                "Andrew",
                "Gey",
                "Tomy",
                "Nikita"
            };

            if (randomNumber % 2 == 0)
            {
                person.Gender = "Male";
                person.Name = namesMen[Random.Shared.Next(0, namesMen.Length)];
            }
            else
            {
                person.Gender = "Female";
                person.Name = namesWomen[Random.Shared.Next(0, namesWomen.Length)];
            }
            return person;
        }
    }
}
