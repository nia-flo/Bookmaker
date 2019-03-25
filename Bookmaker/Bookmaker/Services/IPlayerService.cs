using System.Collections.Generic;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    public interface IPlayerService
    {
        void AddPlayer(Player player);

        void DeletePlayer(int id);

        List<Player> GetAll();

        List<Player> GetAllOnSale();

        Player GetPlayerById(int id);

        void AddInjury(int playerId, string name);
    }
}