using System;

namespace Bookmaker.Data
{
    public static class Exceptions
    {
        public static string InvalidPersonName
            => "Invalid name for a person - it must contain only letters!";

        public static string InvalidAge
            => $"The age is invalid, it must be between {Constants.MinAge} and {Constants.MaxAge}!";

        public static string InvalidInjuryName
            => "Invalid name for an injury - it must contain only letters!";

        public static string InvalidDivision 
            => $"Invalid division - it must be between 1 and {Constants.DivisionsCount}!";

        public static string InvalidBudget 
            => "The budget amount is invalid - it must be positive!";

        public static string InvalidId => "Invalid Id!";

        public static string NotOnSalePlayer => "Player is not on sale!";

        public static string MatchNotPlayed => "Match is not played yet!";

        public static string NotEnoughPlayersHostTeam =>
            $"Host team does not have enough players to participate in a match! They must be at least {Constants.MinPlayersCountForAMatch}";

        public static string NotEnoughPlayersGuestTeam =>
            "Guest team does not have enough players to participate in a match! They must be at least {Constants.MinPlayersCountForAMatch}";
    }
}