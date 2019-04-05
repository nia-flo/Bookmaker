using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Bookmaker.Services;

namespace Bookmaker.Data.Models
{
    public class Match : IDeletable
    {
        private ITeamService teamService;

        public int Id { get; set; }

        public virtual ICollection<MatchTeam> MatchTeams { get; set; }

        public bool IsDeleted { get; set; }

        public void Delete()
        {
            this.IsDeleted = true;
        }

        public int HostId { get; set; }
        
        public virtual Team HostTeam { get; set; }

        public int GuestId { get; set; }

        public virtual Team GuestTeam { get; set; }

        public int? ResultId { get; set; }
        public virtual Result Result { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Id: " + this.Id);
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

            return sb.ToString().Trim();
        }
    }
}