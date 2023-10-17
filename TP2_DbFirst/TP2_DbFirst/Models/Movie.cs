using System;
using System.Collections.Generic;

namespace TP2_DbFirst.Models;

public partial class Movie
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Guid GenreId { get; set; }

    public virtual Genre Genre { get; set; } = null!;
}
