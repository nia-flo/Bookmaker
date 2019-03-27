using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Bookmaker.Data.Models
{
    public class Team : IDeletable
    {
        public Team()
        {
            Players = new List<Player>();
            Coaches = new List<Coach>();
        }
        
        public virtual ICollection<MatchTeam> MatchTeams { get; set; }

        public bool IsDeleted { get; set; }

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
                    throw new ArgumentException(Exceptions.InvalidPersonName);
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
                    throw new ArgumentException(Exceptions.InvalidDivision);
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
                    throw new ArgumentException(Exceptions.InvalidBudget);
                }
            }
        }

        public int PlayersCount => this.GetPlayers().Count;

        public int CoachesCount => this.GetCoaches().Count;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Id: " + this.Id);
            sb.AppendLine("Name: " + this.Name);
            sb.AppendLine("Division: " + this.Division);
            sb.AppendLine("Budget: " + this.Budget);
            sb.AppendLine();

            sb.AppendLine("Players:");
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

            sb.AppendLine("Coaches:");
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

        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            this.Players.Remove(player);
        }

        public void AddCoach(Coach coach)
        {
            this.Coaches.Add(coach);
        }

        public void RemoveCoach(Coach coach)
        {
            this.Coaches.Remove(coach);
        }

        public List<Player> GetPlayers() => this.Players.Where(p => !p.IsDeleted).ToList();

        public List<Coach> GetCoaches() => this.Coaches.Where(c => !c.IsDeleted).ToList();
    }
}