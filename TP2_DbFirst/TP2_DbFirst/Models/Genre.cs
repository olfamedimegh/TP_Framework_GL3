using System;
using System.Collections.Generic;

namespace TP2_DbFirst.Models;

public partial class Genre
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
