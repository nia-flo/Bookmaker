using System.Text;

namespace Bookmaker.Data.Models
{
    public class Match : IDeletable
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public void Delete()
        {
            this.IsDeleted = true;
        }

        public Team HostTeam { get; set; }

        public Team GuestTeam { get; set; }

        public Result Result { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Host team: " + this.HostTeam.Name);
            sb.AppendLine("Guest team: " + this.GuestTeam.Name);

            if (this.Result != null)
            {
                sb.AppendLine("Result:");
                sb.AppendLine(this.Result.ToString());
            }
            else
            {
                sb.AppendLine("There isn't any result yet.");
            }

            return sb.ToString();
        }
    }
}