﻿namespace PatrickGodWebApiTutorial.Entities
{
    public class SuperHero
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string FirstName { get; set; } = string.Empty;
        public required string LastName { get; set; } = string.Empty;
        public required string Place { get; set; } = string.Empty;

    }
}