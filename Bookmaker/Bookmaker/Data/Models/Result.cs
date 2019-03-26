using System.ComponentModel.DataAnnotations.Schema;
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
            sb.AppendLine("Winner: " + this.GetWinner());

            return sb.ToString().Trim();
        }

        public string GetWinner()
        {
            if (this.HostGoals > this.GuestGoals)
            {
                return "host team";
            }
            else if (this.GuestGoals > this.HostGoals)
            {
                return "guest team";
            }
            else
            {
                return "X";
            }
        }
    }
}