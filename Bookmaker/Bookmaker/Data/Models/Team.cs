using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Bookmaker.Data.Models
{
    /*
        The Team class
        Contains all data for a team
    */
    /// <summary>
    /// The <c>Team</c> class.
    /// Contains all data for a team.
    /// </summary>
    /// <inheritdoc cref="T:Bookmaker.Data.Models.IDeletable"/>
    public class Team : IDeletable
    {
        public Team()
        {
            Players = new List<Player>();
            Coaches = new List<Coach>();
        }
        
        public virtual ICollection<MatchTeam> MatchTeams { get; set; }

        public bool IsDeleted { get; set; }

        // Deletes the entry
        /// <summary>
        /// Deletes the entry.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <remarks>
        /// <para>The property IsDeleted is just made true</para>
        /// </remarks>
        /// <inheritdoc cref="T:Bookmaker.Data.Models.IDeletable.Delete"/>
        public void Delete()
        {
            foreach (var player in this.Players)
            {
                player.Sell();
            }

            this.IsDeleted = true;
        }
        
        public int Id { get; set; }

        private string name;
        public string Name
        {
            get => this.name;

            set
            {
                if (Validations.IsNameValid(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTeamName);
                }
            }
        }
        
        public virtual ICollection<Player> Players { get; set; }
        
        public virtual ICollection<Coach> Coaches { get; set; }

        private int division;
        public int Division
        {
            get => division;

            set
            {
                if (Validations.IsDivisionValid(value))
                {
                    this.division = value;
                }
                else
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDivision);
                }
            }
        }

        private decimal budget;
        public decimal Budget
        {
            get => this.budget;

            set
            {
                if (Validations.IsBudgetValid(value))
                {
                    this.budget = value;
                }
                else
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudget);
                }
            }
        }

        public int PlayersCount => this.GetPlayers().Count;

        public int CoachesCount => this.GetCoaches().Count;

        // Converts team to string
        /// <summary>
        /// Converts team to string.
        /// </summary>
        /// <returns>
        /// A string
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Id: " + this.Id);
            sb.AppendLine("Name: " + this.Name);
            sb.AppendLine("Division: " + this.Division);
            sb.AppendLine("Budget: " + this.Budget);
            sb.AppendLine();

            sb.AppendLine(this.PlayersCount + " players:");
            sb.AppendLine();
            if (this.PlayersCount == 0)
            {
                sb.AppendLine("None");
                sb.AppendLine();
            }
            else
            {
                foreach (var player in this.GetPlayers())
                {
                    sb.AppendLine(player.ToString());
                    sb.AppendLine();
                }
            }

            sb.AppendLine(this.CoachesCount + " coaches:");
            sb.AppendLine();
            if (this.CoachesCount == 0)
            {
                sb.AppendLine("None");
            }
            else
            {
                foreach (var coach in this.GetCoaches())
                {
                    sb.AppendLine(coach.ToString());
                    sb.AppendLine();
                }
            }

            return sb.ToString().Trim();
        }

        // Adds player to the team
        /// <summary>
        /// Adds <paramref name="player"/> to the team.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="player">A Player.</param>
        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
        }

        // Removes player from the team
        /// <summary>
        /// Removes <paramref name="player"/> from the team.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="player">A Player.</param>
        public void RemovePlayer(Player player)
        {
            this.Players.Remove(player);
        }

        // Adds coach to the team
        /// <summary>
        /// Adds <paramref name="coach"/> to the team.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="coach">A Coach.</param>
        public void AddCoach(Coach coach)
        {
            this.Coaches.Add(coach);
        }

        // Removes coach from the team
        /// <summary>
        /// Removes <paramref name="coach"/> from the team.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="coach">A Coach.</param>
        public void RemoveCoach(Coach coach)
        {
            this.Coaches.Remove(coach);
        }

        // Gets all players
        /// <summary>
        /// Gets all players.
        /// </summary>
        /// <returns>
        /// A List with all players
        /// </returns>
        public List<Player> GetPlayers() => this.Players.Where(p => !p.IsDeleted).ToList();

        // Gets all coaches
        /// <summary>
        /// Gets all coaches.
        /// </summary>
        /// <returns>
        /// A List with all coaches
        /// </returns>
        public List<Coach> GetCoaches() => this.Coaches.Where(c => !c.IsDeleted).ToList();
    }
}