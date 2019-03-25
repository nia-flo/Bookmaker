using System.Collections.Generic;
using System.Linq;
using Bookmaker.Data;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    public class CoachService : ICoachSevice
    {
        private BookmakerContext context;

        public CoachService(BookmakerContext context)
        {
            this.context = context;
        }

        public void AddCoach(Coach coach)
        {
            context.Coaches.Add(coach);

            context.SaveChanges();
        }

        public void DeleteCoach(int id)
        {
            if (context.Coaches.Count(c => c.Id == id) == 0)
            {
                throw Exceptions.InvalidId;
            }

            context.Coaches.First(c => c.Id == id).Delete();

            context.SaveChanges();
        }

        public List<Coach> GetAll()
        {
            return context.Coaches.Where(c => !c.IsDeleted).ToList();
        }

        public Coach GetCoachById(int id)
        {
            return context.Coaches.FirstOrDefault(c => c.Id == id);
        }
    }
}