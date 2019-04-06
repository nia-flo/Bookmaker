using System.Collections.Generic;
using Bookmaker.Data;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    /*
        The ResultService class
        Contains all methods bound to the result
    */
    /// <summary>
    /// The <c>ResultService</c> class.
    /// Contains all methods bound to the result.
    /// <list type="bullet">
    /// <item>
    /// <term>AddResult</term>
    /// <description>Add new result operation</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para>This class can add new result.</para>
    /// </remarks>
    public class ResultService : IResultService
    {
        private BookmakerContext context;

        // Constructor
        /// <summary>
        /// Initializes a new instance of <c>ResultService</c> with parameter <paramref name="context"/>.
        /// </summary>
        /// <param name="context">A BookmakerContext.</param>
        public ResultService(BookmakerContext context)
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
        public void AddResult(Result result)
        {
            context.Results.Add(result);

            context.SaveChanges();
        }
    }
}