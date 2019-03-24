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

        List<Team> GetAll();

        List<Player> GetAllPlayersForATeam(int teamId);
    }
}