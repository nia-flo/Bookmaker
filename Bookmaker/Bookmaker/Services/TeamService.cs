using System;
using System.Collections.Generic;
using System.Linq;
using Bookmaker.Data;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    public class TeamService : ITeamService
    {
        private BookmakerContext context;
        private IPlayerService playerService;

        public TeamService()
        {
            this.context = new BookmakerContext();
            this.playerService = new PlayerService(context);
        }

        public TeamService(BookmakerContext context)
        {
            this.context = context;
        }

        public void AddTeam(Team team)
        {
            context.Teams.Add(team);

            context.SaveChanges();
        }

        public void DeleteTeam(int id)
        {
            Team team = GetTeamById(id);

            if (team == null)
            {
                throw new ArgumentException(Exceptions.InvalidId);
            }
            
            team.Delete();

            context.SaveChanges();
        }

        public void AddPlayerToATeam(int teamId, int playerId)
        {
            Team team = GetTeamById(teamId);
            Player player = playerService.GetPlayerById(playerId);

            if (!player.IsOnSale)
            {
                throw new ArgumentException(Exceptions.NotOnSalePlayer);
            }

            team.AddPlayer(player);
            player.Buy();
            player.SetTeam(teamId, team);

            context.SaveChanges();
        }

        public void SellPlayer(int teamId, int playerId)
        {
            Team team = GetTeamById(teamId);
            Player player = playerService.GetPlayerById(playerId);

            if (player.TeamId != teamId)
            {
                throw new ArgumentException(Exceptions.InvalidId);
            }

            team.RemovePlayer(player);
            player.Sell();
            player.SetTeam(null, null);

            context.SaveChanges();
        }

        public List<Team> GetAll()
        {
            return context.Teams.Where(t => !t.IsDeleted).ToList();
        }

        public List<Team> GetAllByDivision(int division)
        {
            return context.Teams.Where(t => !t.IsDeleted && t.Division == division).ToList();
        }

        public List<Player> GetAllPlayersForATeam(int teamId)
        {
            if (context.Teams.Count(t => t.Id == teamId) == 0)
            {
                throw new ArgumentException(Exceptions.InvalidId);
            }

            return context.Teams.First(t => t.Id == teamId).Players.ToList();
        }

        public Team GetTeamById(int id)
        {
            Team team = context.Teams.FirstOrDefault(t => t.Id == id);

            if (team == null || team.IsDeleted)
            {
                throw new ArgumentException(Exceptions.InvalidId);
            }

            return team;
        }
    }
}