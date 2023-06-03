using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGenetics.Domain.Entities;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Breed { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string Sex { get; set; } = null!;
    public decimal Price { get; set; }
    public string Status { get; set; } = null!;
}
