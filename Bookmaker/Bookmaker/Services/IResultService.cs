using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    /*
        The ResultService interface
        Contains all methods bound to the result
    */
    /// <summary>
    /// The <c>IResultService</c> interface.
    /// Contains all methods bound to the result.
    /// </summary>
    public interface IResultService
    {
        // Adds a result to the DBContext
        /// <summary>
        /// Adds <paramref name="result"/> to the DBContext.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="result">A Result.</param>
        void AddResult(Result result);
    }
}