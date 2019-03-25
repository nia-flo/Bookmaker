using System.Text;

namespace Bookmaker.Data.Models
{
    public class Result
    {
        public int Id { get; set; }

        public int HostGoals { get; set; }

        public int GuestGoals { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Host team goals count: " + this.HostGoals);
            sb.AppendLine("Guest team goals count: " + this.GuestGoals);

            return sb.ToString().Trim();
        }
    }
}