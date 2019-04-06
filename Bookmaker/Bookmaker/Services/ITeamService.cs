using System.Collections.Generic;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    /*
    The ITeamService interface
    Contains all methods bound to the result
*/
    /// <summary>
    /// The <c>ITeamService</c> interface.
    /// Contains all methods bound to the team.
    /// </summary>
    public interface ITeamService
    {
        // Adds a team to the DBContext
        /// <summary>
        /// Adds <paramref name="team"/> to the DBContext.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="team">A Team.</param>
        void AddTeam(Team team);

        // Deletes a team
        /// <summary>
        /// Deletes a team by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <remarks>
        /// <para>The team is not deleted from the DBContext, it's property ISDeleted is just made true</para>
        /// </remarks>
        /// <param name="id">An integer.</param>
        void DeleteTeam(int id);

        // Add player to a team
        /// <summary>
        /// Add player to a team.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        void AddPlayerToATeam(int teamId, int playerId);

        // Sell player from a team
        /// <summary>
        /// Sell player from a team.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        void SellPlayer(int teamId, int playerId);

        // Add coach from a team
        /// <summary>
        /// Add coach from a team.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        void AddCoachToATeam(int teamId, int coachId);

        // Remove coach from a team
        /// <summary>
        /// Remove coach from a team.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        void RemoveCoachFromATeam(int teamId, int coachId);

        // Gets all teams
        /// <summary>
        /// Gets all teams.
        /// </summary>
        /// <returns>
        /// A List with all teams
        /// </returns>
        List<Team> GetAll();

        // Gets all teams by division
        /// <summary>
        /// Gets all teams by division.
        /// </summary>
        /// <returns>
        /// A List with all teams by division
        /// </returns>
        List<Team> GetAllByDivision(int division);

        // Gets all players for a team
        /// <summary>
        /// Gets all players for a team.
        /// </summary>
        /// <returns>
        /// A List with all players for a team
        /// </returns>
        List<Player> GetAllPlayersForATeam(int teamId);

        // Gets a team by id
        /// <summary>
        /// Gets a team by id.
        /// </summary>
        /// <returns>
        /// A List with a team name by id
        /// </returns>
        Team GetTeamById(int id);

        // Gets all coaches for a team
        /// <summary>
        /// Gets all coaches for a team.
        /// </summary>
        /// <returns>
        /// A List with all coaches for a team
        /// </returns>
        List<Coach> GetAllCoachesForATeam(int teamId);
    }
}