using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Author { get; set; }
        public string? Class { get; set; }
    }
}
