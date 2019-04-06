namespace Bookmaker.Data
{
    /*
        The Constants class
        Contains all constants
    */
    /// <summary>
    /// The <c>Constants</c> class.
    /// Contains all constants.
    /// </summary>
    public static class Constants
    {
        // Minimum age
        /// <summary>
        /// Minimum age.
        /// </summary>
        public static int MinAge => 18;

        // Maximum age
        /// <summary>
        /// Maximum age.
        /// </summary>
        public static int MaxAge => 65;

        // Count of the divisions
        /// <summary>
        /// Count of the divisions.
        /// </summary>
        public static int DivisionsCount => 3;

        // Maximum count of the goals
        /// <summary>
        /// Maximum count of the goals.
        /// </summary>
        public static int MaxGoalsCount => 10;

        // Size of the label
        /// <summary>
        /// Size of the label.
        /// </summary>
        public static int LabelSize => 100;

        // Minimum count of the players that a team must have to play a match
        /// <summary>
        /// Minimum count of the players that a team must have to play a match.
        /// </summary>
        public static int MinPlayersCountForAMatch => 12;
    }
}