using System.Collections.Generic;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    /*
        The ICoachService interface
        Contains all methods bound to the result
    */
    /// <summary>
    /// The <c>ICoachService</c> interface.
    /// Contains all methods bound to the coach.
    /// </summary>
    public interface ICoachService
    {
        // Adds a coach to the DBContext
        /// <summary>
        /// Adds <paramref name="coach"/> to the DBContext.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="coach">A Coach.</param>
        void AddCoach(Coach coach);

        // Deletes a coach
        /// <summary>
        /// Deletes a coach by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <remarks>
        /// <para>The coach is not deleted from the DBContext, it's property ISDeleted is just made true</para>
        /// </remarks>
        /// <param name="id">An integer.</param>
        void DeleteCoach(int id);

        // Gets all coaches
        /// <summary>
        /// Gets all coaches.
        /// </summary>
        /// <returns>
        /// A List with all coaches
        /// </returns>
        List<Coach> GetAll();

        // Gets a coach by id
        /// <summary>
        /// Gets a coach by id.
        /// </summary>
        /// <returns>
        /// The coach with this id
        /// </returns>
        /// <param name="id">An integer.</param>
        Coach GetCoachById(int id);
    }
}