using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using Bookmaker.Data.Models;

namespace Bookmaker.Data
{
    /*
        The Validations class
        Contains all validations
    */
    /// <summary>
    /// The <c>Validations</c> class.
    /// Contains all validations.
    /// </summary>
    public static class Validations
    {
        // Validates name
        /// <summary>
        /// Validates <paramref name="name"/>.
        /// </summary>
        /// <returns>
        /// True if <paramref name="name"/> is valid, otherwise - false
        /// </returns>
        /// <param name="name">A string.</param>
        public static bool IsNameValid(string name) => name.Trim().Length > 0 && Regex.IsMatch(name, @"^[a-zA-Z ]+$");

        // Validates age
        /// <summary>
        /// Validates <paramref name="age"/>.
        /// </summary>
        /// <returns>
        /// True if <paramref name="age"/> is valid, otherwise - false
        /// </returns>
        /// <param name="age">An integer.</param>
        public static bool IsAgeValid(int age)
        {
            if (age < Constants.MinAge || age > Constants.MaxAge)
            {
                return false;
            }

            return true;
        }

        // Validates division
        /// <summary>
        /// Validates <paramref name="division"/>.
        /// </summary>
        /// <returns>
        /// True if <paramref name="division"/> is valid, otherwise - false
        /// </returns>
        /// <param name="division">An integer.</param>
        public static bool IsDivisionValid(int division) => (division >= 1 && division <= Constants.DivisionsCount);

        // Validates budget
        /// <summary>
        /// Validates <paramref name="budget"/>.
        /// </summary>
        /// <returns>
        /// True if <paramref name="budget"/> is valid, otherwise - false
        /// </returns>
        /// <param name="budget">An integer.</param>
        public static bool IsBudgetValid(decimal budget) => budget > 0;

        // Validates can team play a match
        /// <summary>
        /// Validates can <paramref name="team"/> play a match.
        /// </summary>
        /// <returns>
        /// True if <paramref name="team"/> can play a match, otherwise - false
        /// </returns>
        /// <param name="team">A Team.</param>
        public static bool CanTeamPlayMatch(Team team) => team.PlayersCount >= Constants.MinPlayersCountForAMatch;
    }
}