using System;
using Bookmaker.Data;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    public class InjuryService : IInjuryService
    {
        private BookmakerContext context;

        //public InjuryService()
        //{
        //    this.context = new BookmakerContext();
        //}

        public InjuryService(BookmakerContext context)
        {
            this.context = context;
        }

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