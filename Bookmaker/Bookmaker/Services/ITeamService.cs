using System.Collections.Generic;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    public interface ITeamService
    {
        void AddTeam(Team team);

        void DeleteTeam(int id);

        void AddPlayerToATeam(int teamId, int playerId);

        void SellPlayer(int teamId, int playerId);

        void AddCoachToATeam(int teamId, int coachId);

        void RemoveCoachFromATeam(int teamId, int coachId);

        List<Team> GetAll();

        List<Team> GetAllByDivision(int division);

        List<Player> GetAllPlayersForATeam(int teamId);

        Team GetTeamById(int id);

        List<Coach> GetAllCoachesForATeam(int teamId);
    }
}