using System.Collections.Generic;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    public interface IMatchService
    {
        void AddMatch(Match match);

        void RemoveMatch(int id);

        void PlayMatch(int id);

        string GetMatchResult(int id);

        List<Match> GetAll();

        List<Match> GetAllForATeam(int teamId);
    }
}