using System.Collections.Generic;
using System.Linq;
using Bookmaker.Data;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    public class PlayerService : IPlayerService
    {
        private BookmakerContext context;
        private IInjuryService injuryService;

        public PlayerService()
        {
            this.context = new BookmakerContext();
            this.injuryService = new InjuryService();
        }

        public void AddPlayer(Player player)
        {
            context.Players.Add(player);

            context.SaveChanges();
        }

        public void DeletePlayer(int id)
        {
            Player player = this.GetPlayerById(id);

            player.Delete();

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

        public Player GetPlayerById(int id)
        {
            Player player = context.Players.FirstOrDefault(p => p.Id == id);

            if (player == null || player.IsDeleted)
            {
                throw Exceptions.InvalidId;
            }

            return player;
        }

        public void AddInjury(int playerId, string name)
        {
            Player player = this.GetPlayerById(playerId);

            Injury injury = context.Injuries.FirstOrDefault(i => i.Name == name);

            if (injury == null)
            {
                injuryService.AddInjury(name);
                injury = context.Injuries.FirstOrDefault(i => i.Name == name);
            }

            player.Injuries.Add(injury);

            context.SaveChanges();
        }
    }
}