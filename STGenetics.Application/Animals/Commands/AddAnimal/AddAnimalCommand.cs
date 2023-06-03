﻿using ErrorOr;
using MediatR;
using STGenetics.Domain.Entities;

namespace STGenetics.Application.Animals.Commands.AddAnimal;

public record AddAnimalCommand(string Name,
                               string Breed,
                               DateTime BirthDate,
                               string Sex,
                               decimal Price,
                               string Status) : IRequest<ErrorOr<Animal>>;