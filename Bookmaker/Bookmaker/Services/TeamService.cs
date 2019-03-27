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
        private ICoachSevice coachSevice;

        public TeamService()
        {
            this.context = new BookmakerContext();
            this.playerService = new PlayerService(context);
            this.coachSevice = new CoachService(context);
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

        public void AddCoachToATeam(int teamId, int coachId)
        {
            Team team = GetTeamById(teamId);
            Coach coach = coachSevice.GetCoachById(coachId);

            if (team.Coaches.Contains(coach))
            {
                throw new ArgumentException(Exceptions.InvalidId);
            }

            team.AddCoach(coach);

            context.SaveChanges();
        }

        public void RemoveCoachFromATeam(int teamId, int coachId)
        {
            Team team = GetTeamById(teamId);
            Coach coach = coachSevice.GetCoachById(coachId);

            if (!team.Coaches.Contains(coach))
            {
                throw new ArgumentException(Exceptions.InvalidId);
            }

            team.RemoveCoach(coach);

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
            Team team = GetTeamById(teamId);

            return team.GetPlayers();
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

        public List<Coach> GetAllCoachesForATeam(int teamId)
        {
            Team team = GetTeamById(teamId);

            return team.GetCoaches();
        }
    }
}