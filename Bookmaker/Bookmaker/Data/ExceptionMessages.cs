using System;

namespace Bookmaker.Data
{
    /*
        The ExceptionMessages class
        Contains all exception messages
    */
    /// <summary>
    /// The <c>ExceptionMessages</c> class.
    /// Contains all exception messages.
    /// </summary>
    public static class ExceptionMessages
    {
        // Exception message for an invalid person name
        /// <summary>
        /// Exception message for an invalid person name.
        /// </summary>
        public static string InvalidPersonName
            => "Invalid name for a person - it must contain only letters and numbers and can't be empty!";

        // Exception message for an invalid age
        /// <summary>
        /// Exception message for an invalid age.
        /// </summary>
        public static string InvalidAge
            => $"The age is invalid, it must be between {Constants.MinAge} and {Constants.MaxAge}!";

        // Exception message for an invalid injury name
        /// <summary>
        /// Exception message for an invalid injury name.
        /// </summary>
        public static string InvalidInjuryName
            => "Invalid name for an injury - it must contain only letters and numbers and can't be empty!";

        // Exception message for an invalid team name
        /// <summary>
        /// Exception message for an invalid team name.
        /// </summary>
        public static string InvalidTeamName
            => "Invalid name for a team - it must contain only letters and numbers and can't be empty!";

        // Exception message for an invalid division
        /// <summary>
        /// Exception message for an invalid division.
        /// </summary>
        public static string InvalidDivision 
            => $"Invalid division - it must be between 1 and {Constants.DivisionsCount}!";

        // Exception message for an invalid budget
        /// <summary>
        /// Exception message for an invalid budget.
        /// </summary>
        public static string InvalidBudget 
            => "The budget amount is invalid - it must be positive!";

        // Exception message for an invalid id
        /// <summary>
        /// Exception message for an invalid id.
        /// </summary>
        public static string InvalidId => "Invalid Id!";

        // Exception message for a player that is not on sale
        /// <summary>
        /// Exception message for a player that is not on sale.
        /// </summary>
        public static string NotOnSalePlayer => "Player is not on sale!";

        // Exception message for a match that is not played yet
        /// <summary>
        /// Exception message for a match that is not played yet.
        /// </summary>
        public static string MatchNotPlayed => "Match is not played yet!";

        // Exception message for a host team that is not capable for a match
        /// <summary>
        /// Exception message for a host team that is not capable for a match.
        /// </summary>
        public static string HostTeamNotCapableForAMatch =>
            $"Host team is not capable for a match - it must have {Constants.MinPlayersCountForAMatch} players or more!";

        // Exception message for a guest team that is not capable for a match
        /// <summary>
        /// Exception message for a guest team that is not capable for a match.
        /// </summary>
        public static string GuestTeamNotCapableForAMatch =>
            $"Guest team is not capable for a match - it must have {Constants.MinPlayersCountForAMatch} players or more!";

        // Exception message for a match that has already been played
        /// <summary>
        /// Exception message for a match that has already been played.
        /// </summary>
        public static string MatchHasAlreadyBeenPlayed => "Match has already been played!";
    }
}