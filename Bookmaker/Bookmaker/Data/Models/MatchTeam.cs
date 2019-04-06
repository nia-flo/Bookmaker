namespace Bookmaker.Data.Models
{
    /*
        The MatchTeam class
        A class to represent the mapping table between Match and Team
    */
    /// <summary>
    /// The <c>MatchTeam</c> class.
    /// A class to represent the mapping table between Match and Team.
    /// </summary>
    public class MatchTeam
    {
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}