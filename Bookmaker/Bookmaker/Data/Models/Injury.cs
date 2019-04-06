using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookmaker.Data.Models
{
    /*
        The Injury class
        Contains all data for an injury
    */
    /// <summary>
    /// The <c>Injury</c> class.
    /// Contains all data for an injury.
    /// </summary>
    public class Injury
    {
        public int Id { get; set; }

        private string name;
        public int id;

        public string Name
        {
            get => this.name;

            set
            {
                if (Validations.IsNameValid(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException(ExceptionMessages.InvalidInjuryName);
                }
            }
        }

        // Converts injury to string
        /// <summary>
        /// Converts injury to string.
        /// </summary>
        /// <returns>
        /// A string
        /// </returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}