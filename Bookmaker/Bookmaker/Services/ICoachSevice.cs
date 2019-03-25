using System.Collections.Generic;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    public interface ICoachSevice
    {
        void AddCoach(Coach coach);

        void DeleteCoach(int id);

        List<Coach> GetAll();

        Coach GetCoachById(int id);
    }
}