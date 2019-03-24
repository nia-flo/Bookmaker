using System.Collections;
using System.Collections.Generic;
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

        public bool IsDeleted { get; set; }

        public void Delete()
        {
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
                    throw Exceptions.InvalidPersonName;
                }
            }
        }

        public ICollection<Player> Players { get; set; }

        public ICollection<Coach> Coaches { get; set; }

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
                    throw Exceptions.InvalidDivision;
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
                    throw Exceptions.InvalidBudget;
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
            sb.AppendLine("Players:");
            foreach (var player in this.Players)
            {
                sb.AppendLine(player.ToString());
            }

            sb.AppendLine("Coaches:");
            foreach (var coach in this.Coaches)
            {
                sb.AppendLine(coach.ToString());
            }

            return sb.ToString();
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