using System;

namespace Bookmaker.Data
{
    public static class Exceptions
    {
        public static ArgumentException InvalidPersonName
            => new ArgumentException("Invalid name for a person - it must contain only letters!");

        public static ArgumentException InvalidAge
            => new ArgumentException($"The age is invalid, it must be between {Constants.MinAge} and {Constants.MaxAge}!");

        public static ArgumentException InvalidInjuryName
            => new ArgumentException("Invalid name for an injury - it must contain only letters!");

        public static ArgumentException InvalidDivision 
            => new ArgumentException($"Invalid division - it must be between 1 and {Constants.DivisionsCount}!");

        public static ArgumentException InvalidBudget 
            => new ArgumentException("The budget amount is invalid - it must be positive!");

        public static ArgumentException InvalidId => new ArgumentException("Invalid Id!");

        public static ArgumentException NotOnSalePlayer => new ArgumentException("Player is not on sale!");

        public static ArgumentException MatchNotPlayed => new ArgumentException("Match is not played yet!");
    }
}