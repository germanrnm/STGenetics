using STGenetics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGenetics.Application.Animals.Queries.GetAnimals
{
    public record GetAnimalsQueryResult(List<Animal> Animals);
}
