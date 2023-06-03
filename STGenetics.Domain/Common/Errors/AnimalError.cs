using ErrorOr;

namespace STGenetics.Domain.Common.Errors;

public static partial class Errors
{
    public static class AnimalError
    {
        public static Error CreateAnimalFail => Error.Failure(
            code: "Animal.CreateAnimalFail",
            description: "An error ocurred during the creation of the animal.");

        public static Error UpdateAnimalFail => Error.Failure(
            code: "User.UpdateAnimalFail",
            description: "An error ocurred during the updating of the animal.");

        public static Error AnimalNotFound => Error.Failure(
            code: "Animal.AnimalNotFound",
            description: "Animal not found.");
    }
}



