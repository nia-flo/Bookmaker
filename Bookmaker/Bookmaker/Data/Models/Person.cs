using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Text;

namespace Bookmaker.Data.Models
{
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
                    throw new ArgumentException(Exceptions.InvalidPersonName);
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
                    throw new ArgumentException(Exceptions.InvalidAge);
                }
            }
        }

        public bool IsDeleted { get; set; }

        public void Delete()
        {
            this.IsDeleted = true;
        }

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