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

        public bool IsOnSale { get; set; }

        public ICollection<Injury> Injuries { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            if (this.IsOnSale)
            {
                sb.AppendLine("Is on sale.");
            }
            else
            {
                sb.AppendLine("Is not on sale.");
            }

            if (this.Injuries.Count > 0)
            {
                sb.AppendLine("Injuries:");
                foreach (var injury in this.Injuries)
                {
                    sb.AppendLine(injury.ToString());
                }
            }

            return sb.ToString();
        }
    }
}