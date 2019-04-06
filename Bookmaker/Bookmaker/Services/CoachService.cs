using System;
using System.Collections.Generic;
using System.Linq;
using Bookmaker.Data;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    /*
        The CoachService class
        Contains all methods bound to the result
    */
    /// <summary>
    /// The <c>CoachService</c> class.
    /// Contains all methods bound to the coach.
    /// </summary>
    public class CoachService : ICoachService
    {
        private BookmakerContext context;

        //public CoachService()
        //{
        //    this.context = new BookmakerContext();
        //}

        // Constructor
        /// <summary>
        /// Initializes a new instance of <c>CoachService</c> with parameter <paramref name="context"/>.
        /// </summary>
        /// <param name="context">A BookmakerContext.</param>
        public CoachService(BookmakerContext context)
        {
            this.context = context;
        }

        // Adds a coach to the DBContext
        /// <summary>
        /// Adds <paramref name="coach"/> to the DBContext.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="coach">A Coach.</param>
        public void AddCoach(Coach coach)
        {
            context.Coaches.Add(coach);

            context.SaveChanges();
        }

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
        public void DeleteCoach(int id)
        {
            Coach coach = this.GetCoachById(id);

            coach.Delete();

            context.SaveChanges();
        }

        // Gets all coaches
        /// <summary>
        /// Gets all coaches.
        /// </summary>
        /// <returns>
        /// A List with all coaches
        /// </returns>
        public List<Coach> GetAll()
        {
            return context.Coaches.Where(c => !c.IsDeleted).ToList();
        }

        // Gets a coach by id
        /// <summary>
        /// Gets a coach by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// The coach with this id
        /// </returns>
        /// <param name="id">An integer.</param>
        public Coach GetCoachById(int id)
        {
            Coach coach = context.Coaches.FirstOrDefault(c => c.Id == id);

            if (coach == null || coach.IsDeleted == true)
            {
                throw new ArgumentException(ExceptionMessages.InvalidId);
            }

            return coach;
        }
    }
}