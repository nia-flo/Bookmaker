using System;
using System.Collections.Generic;
using System.Linq;
using Bookmaker.Data;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    /*
        The ResultService class
        Contains all methods bound to the result
    */
    /// <summary>
    /// The <c>PlayerService</c> class.
    /// Contains all methods bound to the player.
    /// </summary>
    public class PlayerService : IPlayerService
    {
        private BookmakerContext context;
        private IInjuryService injuryService;

        //public PlayerService()
        //{
        //    this.context = new BookmakerContext();
        //    this.injuryService = new InjuryService();
        //}

        // Constructor
        /// <summary>
        /// Initializes a new instance of <c>PlayerService</c> with parameter <paramref name="context"/>.
        /// </summary>
        /// <param name="context">A BookmakerContext.</param>
        public PlayerService(BookmakerContext context)
        {
            this.context = context;
            this.injuryService = new InjuryService(context);
        }

        // Adds a player to the DBContext
        /// <summary>
        /// Adds <paramref name="player"/> to the DBContext.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="player">A Player.</param>
        public void AddPlayer(Player player)
        {
            context.Players.Add(player);

            context.SaveChanges();
        }

        // Deletes a player
        /// <summary>
        /// Deletes a player by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="id">A Player.</param>
        /// <remarks>
        /// <para>The player is not deleted from the DBContext, it's property ISDeleted is just made true</para>
        /// </remarks>
        /// <param name="id">An integer.</param>
        public void DeletePlayer(int id)
        {
            Player player = this.GetPlayerById(id);

            player.Delete();

            context.SaveChanges();
        }

        // Gets all players
        /// <summary>
        /// Gets all players.
        /// </summary>
        /// <returns>
        /// A List with all players
        /// </returns>
        public List<Player> GetAll()
        {
            return context.Players.Where(p => !p.IsDeleted).ToList();
        }

        // Gets all players that are on sale
        /// <summary>
        /// Gets all players that are on sale.
        /// </summary>
        /// <returns>
        /// A List with all players that are on sale
        /// </returns>
        public List<Player> GetAllOnSale()
        {
            return context.Players.Where(p => !p.IsDeleted && p.IsOnSale).ToList();
        }

        // Gets a player by id
        /// <summary>
        /// Gets a player by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// The player with this id
        /// </returns>
        /// <param name="id">An integer.</param>
        public Player GetPlayerById(int id)
        {
            Player player = context.Players.FirstOrDefault(p => p.Id == id);

            if (player == null || player.IsDeleted)
            {
                throw new ArgumentException(ExceptionMessages.InvalidId);
            }

            return player;
        }

        // Adds an injury to a player
        /// <summary>
        /// Adds injury <paramref name="name"/> to the player by his <paramref name="playerId"/>.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="playerId">An integer.</param>
        /// <param name="name">A string.</param>
        public void AddInjury(int id, string injuryName)
        {
            Player player = this.GetPlayerById(id);

            Injury injury = context.Injuries.FirstOrDefault(i => i.Name == injuryName);
            
            if (injury == null)
            {
                injuryService.AddInjury(injuryName);
                injury = context.Injuries.FirstOrDefault(i => i.Name == injuryName);
            }

            player.Injuries.Add(injury);

            context.SaveChanges();
        }
    }
}