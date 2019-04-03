using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookmaker.Data.Models
{
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
                    throw new ArgumentException(Exceptions.InvalidInjuryName);
                }
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}