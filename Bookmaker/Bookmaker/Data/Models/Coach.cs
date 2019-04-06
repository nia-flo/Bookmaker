using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookmaker.Data.Models
{
    /*
        The Coach class
        Contains all data for a coach
    */
    /// <summary>
    /// The <c>BookmakerContext</c> class.
    /// Contains all data for a coach.
    /// </summary>
    /// <inheritdoc cref="T:Bookmaker.Data.Models.Person"/>
    public class Coach : Person
    {
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}