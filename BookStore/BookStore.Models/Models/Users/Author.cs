﻿namespace BookStore.Models.Models.Users
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime BirthDay { get; set; }

        public string Bio { get; set; } = String.Empty;
    }
}
