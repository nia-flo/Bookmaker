using System;
using System.Collections.Generic;
using System.Linq;
using Bookmaker.Data;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    /*
    The TeamService class
    Contains all methods bound to the result
*/
    /// <summary>
    /// The <c>TeamService</c> class.
    /// Contains all methods bound to the team.
    /// </summary>
    public class TeamService : ITeamService
    {
        private BookmakerContext context;
        private IPlayerService playerService;
        private ICoachService coachService;

        //public TeamService()
        //{
        //    this.context = new BookmakerContext();
        //    this.playerService = new PlayerService(context);
        //    this.coachService = new CoachService(context);
        //}

        // Constructor
        /// <summary>
        /// Initializes a new instance of <c>TeamService</c> with parameter <paramref name="context"/>.
        /// </summary>
        /// <param name="context">A BookmakerContext.</param>
        public TeamService(BookmakerContext context)
        {
            this.context = context;
            this.playerService = new PlayerService(context);
            this.coachService = new CoachService(context);
        }

        // Adds a team to the DBContext
        /// <summary>
        /// Adds <paramref name="team"/> to the DBContext.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="team">A Team.</param>
        public void AddTeam(Team team)
        {
            context.Teams.Add(team);

            context.SaveChanges();
        }

        // Deletes a team
        /// <summary>
        /// Deletes a team by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <remarks>
        /// <para>The team is not deleted from the DBContext, it's property ISDeleted is just made true</para>
        /// </remarks>
        /// <param name="id">An integer.</param>
        public void DeleteTeam(int id)
        {
            Team team = GetTeamById(id);

            if (team == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidId);
            }
            
            team.Delete();

            context.SaveChanges();
        }

        // Add player to a team
        /// <summary>
        /// Add player to a team.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        public void AddPlayerToATeam(int teamId, int playerId)
        {
            Team team = GetTeamById(teamId);
            Player player = playerService.GetPlayerById(playerId);

            if (!player.IsOnSale)
            {
                throw new ArgumentException(ExceptionMessages.NotOnSalePlayer);
            }

            team.AddPlayer(player);
            player.Buy();
            player.SetTeam(teamId, team);

            context.SaveChanges();
        }

        // Sell player from a team
        /// <summary>
        /// Sell player from a team.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        public void SellPlayer(int teamId, int playerId)
        {
            Team team = GetTeamById(teamId);
            Player player = playerService.GetPlayerById(playerId);

            if (player.TeamId != teamId)
            {
                throw new ArgumentException(ExceptionMessages.InvalidId);
            }

            team.RemovePlayer(player);
            player.Sell();
            player.SetTeam(null, null);

            context.SaveChanges();
        }

        // Add coach from a team
        /// <summary>
        /// Add coach from a team.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        public void AddCoachToATeam(int teamId, int coachId)
        {
            Team team = GetTeamById(teamId);
            Coach coach = coachService.GetCoachById(coachId);

            if (team.Coaches.Contains(coach))
            {
                throw new ArgumentException(ExceptionMessages.InvalidId);
            }

            team.AddCoach(coach);

            context.SaveChanges();
        }

        // Remove coach from a team
        /// <summary>
        /// Remove coach from a team.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        public void RemoveCoachFromATeam(int teamId, int coachId)
        {
            Team team = GetTeamById(teamId);
            Coach coach = coachService.GetCoachById(coachId);

            if (!team.Coaches.Contains(coach))
            {
                throw new ArgumentException(ExceptionMessages.InvalidId);
            }

            team.RemoveCoach(coach);

            context.SaveChanges();
        }

        // Gets all teams.
        /// <summary>
        /// Gets all teams.
        /// </summary>
        /// <returns>
        /// A List with all teams
        /// </returns>
        public List<Team> GetAll()
        {
            return context.Teams.Where(t => !t.IsDeleted).ToList();
        }

        // Gets all teams by division.
        /// <summary>
        /// Gets all teams by division.
        /// </summary>
        /// <returns>
        /// A List with all teams by division
        /// </returns>
        public List<Team> GetAllByDivision(int division)
        {
            return context.Teams.Where(t => !t.IsDeleted && t.Division == division).ToList();
        }

        // Gets all players for a team.
        /// <summary>
        /// Gets all players for a team.
        /// </summary>
        /// <returns>
        /// A List with all players for a team.
        /// </returns>
        public List<Player> GetAllPlayersForATeam(int teamId)
        {
            Team team = GetTeamById(teamId);

            return team.GetPlayers();
        }

        // Gets  team by ID.
        /// <summary>
        /// Gets team by ID.
        /// </summary>
        /// <returns>
        /// A team name.
        /// </returns>
        public Team GetTeamById(int id)
        {
            Team team = context.Teams.FirstOrDefault(t => t.Id == id);

            if (team == null || team.IsDeleted)
            {
                throw new ArgumentException(ExceptionMessages.InvalidId);
            }

            return team;
        }

        // Gets all coaches for a team.
        /// <summary>
        /// Gets all coaches for a team.
        /// </summary>
        /// <returns>
        /// A List with all coaches for a team
        /// </returns>
        public List<Coach> GetAllCoachesForATeam(int teamId)
        {
            Team team = GetTeamById(teamId);

            return team.GetCoaches();
        }
    }
}