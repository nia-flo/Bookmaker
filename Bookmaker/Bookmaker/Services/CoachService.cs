using System;
using System.Collections.Generic;
using System.Linq;
using Bookmaker.Data;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    public class CoachService : ICoachSevice
    {
        private BookmakerContext context;

        public CoachService()
        {
            this.context = new BookmakerContext();
        }

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
            Coach coach = this.GetCoachById(id);

            coach.Delete();

            context.SaveChanges();
        }

        public List<Coach> GetAll()
        {
            return context.Coaches.Where(c => !c.IsDeleted).ToList();
        }

        public Coach GetCoachById(int id)
        {
            Coach coach = context.Coaches.FirstOrDefault(c => c.Id == id);

            if (coach == null || coach.IsDeleted == true)
            {
                throw new ArgumentException(Exceptions.InvalidId);
            }

            return coach;
        }
    }
}