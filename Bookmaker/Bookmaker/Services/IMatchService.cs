using System.Collections.Generic;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    /*
        The IMatchService interface
        Contains all methods bound to the match
    */
    /// <summary>
    /// The <c>IMatchService</c> interface.
    /// Contains all methods bound to the match.
    /// </summary>
    public interface IMatchService
    {
        // Adds a match to the DBContext
        /// <summary>
        /// Adds <paramref name="match"/> to the DBContext.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="match">A Match.</param>
        void AddMatch(Match match);

        // Removes a match
        /// <summary>
        /// Removes a match by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <remarks>
        /// <para>The match is not deleted from the DBContext, it's property ISDeleted is just made true</para>
        /// </remarks>
        /// <param name="id">An integer.</param>
        void RemoveMatch(int id);

        // Generates a result for a match
        /// <summary>
        /// Generates a result for a match with concrete <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="id">An integer.</param>
        void PlayMatch(int id);

        // Gets the result for a match
        /// <summary>
        /// Gets the result for a match with concrete <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// A string with the result
        /// </returns>
        /// <param name="id">An integer.</param>
        string GetMatchResult(int id);

        // Gets all matches
        /// <summary>
        /// Gets all matches.
        /// </summary>
        /// <returns>
        /// A List with all matches
        /// </returns>
        List<Match> GetAll();

        // Gets all matches where concrete team is playing
        /// <summary>
        /// Gets all matches where concrete team with <paramref name="teamId"/> is playing. 
        /// </summary>
        /// <returns>
        /// A List with all matches with this concrete team
        /// </returns>
        /// <param name="teamId">An integer.</param>
        List<Match> GetAllForATeam(int teamId);

        // Gets a match by id
        /// <summary>
        /// Gets a match by id.
        /// </summary>
        /// <returns>
        /// The match with this id
        /// </returns>
        /// <param name="id">An integer.</param>
        Match GetMatchById(int id);
    }
}