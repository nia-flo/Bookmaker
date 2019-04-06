using System.Collections.Generic;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    /*
        The IPlayerService interface
        Contains all methods bound to the result
    */
    /// <summary>
    /// The <c>IPlayerService</c> interface.
    /// Contains all methods bound to the player.
    /// </summary>
    public interface IPlayerService
    {
        // Adds a player to the DBContext
        /// <summary>
        /// Adds <paramref name="player"/> to the DBContext.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="player">A Player.</param>
        void AddPlayer(Player player);

        // Deletes a player
        /// <summary>
        /// Deletes a player by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <remarks>
        /// <para>The player is not deleted from the DBContext, it's property ISDeleted is just made true</para>
        /// </remarks>
        /// <param name="id">An integer.</param>
        void DeletePlayer(int id);

        // Gets all players
        /// <summary>
        /// Gets all players.
        /// </summary>
        /// <returns>
        /// A List with all players
        /// </returns>
        List<Player> GetAll();

        // Gets all players that are on sale
        /// <summary>
        /// Gets all players that are on sale.
        /// </summary>
        /// <returns>
        /// A List with all players that are on sale
        /// </returns>
        List<Player> GetAllOnSale();

        // Gets a player by id
        /// <summary>
        /// Gets a player by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// The player with this id
        /// </returns>
        /// <param name="id">An integer.</param>
        Player GetPlayerById(int id);

        // Adds an injury to a player
        /// <summary>
        /// Adds injury <paramref name="name"/> to the player by his <paramref name="playerId"/>.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="playerId">An integer.</param>
        /// <param name="name">A string.</param>
        void AddInjury(int playerId, string name);
    }
}