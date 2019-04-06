using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    /*
    The IInjuryService class
    Contains all methods related to the return of injury .
*/
    /// <summary>
    /// The <c>IInjuryService</c> class.
    /// Contains all methods bound to the injury.
    /// </summary>


    public interface IInjuryService
    {

        /// <returns>
        /// Nothing
        /// </returns>
        void AddInjury(string name);
    }
}