using System.Collections.Generic;
using System.Linq;
using Bookmaker.Data;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    public class PlayerService : IPlayerService
    {
        private BookmakerContext context;

        public PlayerService(BookmakerContext context)
        {
            this.context = context;
        }

        public void AddPlayer(Player player)
        {
            context.Players.Add(player);

            context.SaveChanges();
        }

        public void DeletePlayer(int id)
        {
            if (context.Players.Count(p => p.Id == id) == 0)
            {
                throw Exceptions.InvalidId;
            }

            context.Players.First(p => p.Id == id).Delete();

            context.SaveChanges();
        }

        public List<Player> GetAll()
        {
            return context.Players.Where(p => !p.IsDeleted).ToList();
        }

        public List<Player> GetAllOnSale()
        {
            return context.Players.Where(p => !p.IsDeleted && p.IsOnSale).ToList();
        }

        public Player GetPlayerWithId(int id)
        {
            Player player = context.Players.FirstOrDefault(p => p.Id == id);

            if (player == null)
            {
                throw Exceptions.InvalidId;
            }

            return player;
        }
    }
}