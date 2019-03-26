using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            if (this.Players.Count == 0)
            {
                sb.AppendLine("None");
                sb.AppendLine();
            }
            else
            {
                foreach (var player in this.Players)
                {
                    sb.AppendLine(player.ToString());
                    sb.AppendLine();
                }
            }

            sb.AppendLine("Coaches:");
            sb.AppendLine();
            if (this.Coaches.Count == 0)
            {
                sb.AppendLine("None");
            }
            else
            {
                foreach (var coach in this.Coaches)
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
    }
}