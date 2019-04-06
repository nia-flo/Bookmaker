using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    /*
        The IInjuryService interface
        Contains all methods bound to the injury
    */
    /// <summary>
    /// The <c>IInjuryService</c> interface.
    /// Contains all methods bound to the injury.
    /// </summary>
    public interface IInjuryService
    {

        // Adds a injury to the DBContext
        /// <summary>
        /// Adds a new injury by <paramref name="name"/> to the DBContext.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="name">A string.</param>
        void AddInjury(string name);
    }
}