using Bookmaker.Data;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    public class InjuryService : IInjuryService
    {
        private BookmakerContext context;

        public InjuryService(BookmakerContext context)
        {
            this.context = context;
        }

        public void AddInjury(Injury injury)
        {
            context.Injuries.Add(injury);

            context.SaveChanges();
        }
    }
}