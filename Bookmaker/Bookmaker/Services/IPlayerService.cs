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

        Player GetPlayerWithId(int id);

        Player GetPlayerById(int id);
    }
}