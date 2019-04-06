using System;
using Bookmaker.Data;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    /*
    The InjuryService class
    Contains all methods bound to the injury
*/
    /// <summary>
    /// The <c>InjuuryService</c> class.
    /// Contains all methods bound to the injury.
    /// </summary>
    /// <remarks>
    /// <para>This class can add new injury.</para>
    /// </remarks>
    public class InjuryService : IInjuryService
    {
        private BookmakerContext context;

        // Constructor
        /// <summary>
        /// Initializes a new instance of <c>InjuryService</c> with parameter <paramref name="context"/>.
        /// </summary>
        /// <param name="context">A BookmakerContext.</param>

        //public InjuryService()
        //{
        //    this.context = new BookmakerContext();
        //}

        public InjuryService(BookmakerContext context)
        {
            this.context = context;
        }
        // Adds a result to the DBContext
        /// <summary>
        /// Adds <paramref name="result"/> to the DBContext.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="result">A Result.</param>

        public void AddInjury(string name)
        {
            context.Injuries.Add(new Injury()
            {
                Name = name
            });

            context.SaveChanges();
        }
    }
}