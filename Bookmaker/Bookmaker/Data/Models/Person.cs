using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Text;

namespace Bookmaker.Data.Models
{
    /*
        The Person class
        Contains all data for a person
    */
    /// <summary>
    /// The <c>Person</c> class.
    /// Contains all data for a person.
    /// </summary>
    /// <inheritdoc cref="T:Bookmaker.Data.Models.IDeletable"/>
    public abstract class Person : IDeletable
    {
        public int Id { get; set; }

        private string name;
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
                    throw new ArgumentException(ExceptionMessages.InvalidPersonName);
                }
            }
        }

        private int age;
        public int Age
        {
            get => this.age;

            set
            {
                if (Validations.IsAgeValid(value))
                {
                        this.age = value;
                }
                else
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAge);
                }
            }
        }

        public bool IsDeleted { get; set; }

        // Deletes the entry
        /// <summary>
        /// Deletes the entry.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <remarks>
        /// <para>The property IsDeleted is just made true</para>
        /// </remarks>
        /// <inheritdoc cref="M:Bookmaker.Data.Models.IDeletable.Delete"/>
        public void Delete()
        {
            this.IsDeleted = true;
        }

        // Converts person to string
        /// <summary>
        /// Converts person to string.
        /// </summary>
        /// <returns>
        /// A string
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Id: " + this.Id);
            sb.AppendLine("Name: " + this.Name);
            sb.AppendLine("Age: " + this.Age);

            return sb.ToString().Trim();
        }
    }
}