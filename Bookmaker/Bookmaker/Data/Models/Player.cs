using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Bookmaker.Data.Models
{
    public class Player : Person
    {
        public Player()
        {
            Injuries = new List<Injury>();

            this.IsOnSale = true;
        }

        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }

        public bool IsOnSale { get; set; }
        
        public virtual ICollection<Injury> Injuries { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            if (this.IsOnSale)
            {
                sb.AppendLine("Status: Is on sale");
            }
            else
            {
                sb.AppendLine("Status: Is not on sale");
            }

            sb.AppendLine("Injuries:");
            if (this.Injuries.Count == 0)
            {
                sb.AppendLine("None");
            }
            else
            {
                foreach (var injury in this.Injuries)
                {
                    sb.AppendLine(injury.ToString());
                }
            }

            return sb.ToString().Trim();
        }

        public void Sell()
        {
            this.IsOnSale = true;
        }

        public void Buy()
        {
            this.IsOnSale = false;
        }
    }
}