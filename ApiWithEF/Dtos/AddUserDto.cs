﻿namespace ApiWithEF.Dtos
{
    public class AddUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
    }
}
