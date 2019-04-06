using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Bookmaker.Data.Models
{
    /*
        The Player class
        Contains all data for a player
    */
    /// <summary>
    /// The <c>Player</c> class.
    /// Contains all data for a player.
    /// </summary>
    /// <inheritdoc cref="T:Bookmaker.Data.Models.Person"/>
    public class Player : Person
    {
        // Constructor
        /// <summary>
        /// Initializes a new instance of <c>Player</c>.
        /// </summary>
        public Player()
        {
            Injuries = new List<Injury>();

            this.IsOnSale = true;
        }

        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }

        public bool IsOnSale { get; set; }
        
        public virtual ICollection<Injury> Injuries { get; set; }

        // Converts player to string
        /// <summary>
        /// Converts player to string.
        /// </summary>
        /// <returns>
        /// A string
        /// </returns>
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

        // Sells the player
        /// <summary>
        /// Sells the player.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <remarks>
        /// <para>The property IsOnSale is made true</para>
        /// </remarks>
        public void Sell()
        {
            this.IsOnSale = true;
        }

        // Buys the player
        /// <summary>
        /// Buys the player.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <remarks>
        /// <para>The property IsOnSale is made false</para>
        /// </remarks>
        public void Buy()
        {
            this.IsOnSale = false;
        }

        // Sets teamId and team
        /// <summary>
        /// Sets <paramref name="teamId"/> and <paramref name="team"/>.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="teamId">An integer.</param>
        /// <param name="team">A Team.</param>
        public void SetTeam(int? teamId, Team team)
        {
            this.TeamId = teamId;
            this.Team = team;
        }
    }
}