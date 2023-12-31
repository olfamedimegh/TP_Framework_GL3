﻿using System.ComponentModel.DataAnnotations;

namespace TP3.Models
{
    public class Genre
    {
        public Guid Id { get; set; }

        [ConcurrencyCheck]
        public string? Name { get; set; }

        public List<Movie>? Movies { get; set; }
    }
}
