﻿namespace ApiWithEF.Dtos
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime SelectTime { get; set; }
    }
}
