namespace Bookmaker.Data.Models
{
    public class MatchTeam
    {
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}