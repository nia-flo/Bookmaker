using System;
using System.Collections.Generic;
using System.Linq;
using Bookmaker.Data;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    /*
        The MatchService class
        Contains all methods bound to the match
    */
    /// <summary>
    /// The <c>MatchService</c> class.
    /// Contains all methods bound to the match.
    /// </summary>
    public class MatchService : IMatchService
    {
        private BookmakerContext context;
        private IResultService resultService;

        //public MatchService()
        //{
        //    this.context = new BookmakerContext();
        //}

        // Constructor
        /// <summary>
        /// Initializes a new instance of <c>MatchService</c> with parameter <paramref name="context"/>.
        /// </summary>
        /// <param name="context">A BookmakerContext.</param>
        public MatchService(BookmakerContext context)
        {
            this.context = context;
            this.resultService = new ResultService(context);
        }

        // Adds a match to the DBContext
        /// <summary>
        /// Adds <paramref name="match"/> to the DBContext.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="match">A Match.</param>
        public void AddMatch(Match match)
        {
            if (match.HostId == match.GuestId)
            {
                throw new ArgumentException(ExceptionMessages.InvalidId);
            }

            if (!Validations.CanTeamPlayMatch(match.HostTeam))
            {
                throw new ArgumentException(ExceptionMessages.HostTeamNotCapableForAMatch);
            }

            if (!Validations.CanTeamPlayMatch(match.GuestTeam))
            {
                throw new ArgumentException(ExceptionMessages.GuestTeamNotCapableForAMatch);
            }

            context.Matches.Add(match);

            context.SaveChanges();
        }

        // Removes a match
        /// <summary>
        /// Removes a match by <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <remarks>
        /// <para>The match is not deleted from the DBContext, it's property ISDeleted is just made true</para>
        /// </remarks>
        /// <param name="id">An integer.</param>
        public void RemoveMatch(int id)
        {
            Match match = this.GetMatchById(id);

            match.IsDeleted = true;

            context.SaveChanges();
        }

        // Generates a result for a match
        /// <summary>
        /// Generates a result for a match with concrete <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// Nothing
        /// </returns>
        /// <param name="id">An integer.</param>
        public void PlayMatch(int id)
        {
            Match match = this.GetMatchById(id);

            if (match.Result != null)
            {
                throw new ArgumentException(ExceptionMessages.MatchHasAlreadyBeenPlayed);
            }

            Random random = new Random();
            Result result = new Result()
            {
                HostGoals = random.Next(0, Constants.MaxGoalsCount),
                GuestGoals = random.Next(0, Constants.MaxGoalsCount)
            };

            resultService.AddResult(result);

            match.ResultId = result.Id;
            match.Result = result;

            context.SaveChanges();
        }

        // Gets the result for a match
        /// <summary>
        /// Gets the result for a match with concrete <paramref name="id"/>.
        /// </summary>
        /// <returns>
        /// A string with the result
        /// </returns>
        /// <param name="id">An integer.</param>
        public string GetMatchResult(int id)
        {
            Match match = this.GetMatchById(id);

            if (match.Result == null)
            {
                throw new ArgumentException(ExceptionMessages.MatchNotPlayed);
            }

            return match.Result.ToString();
        }

        // Gets all matches
        /// <summary>
        /// Gets all matches.
        /// </summary>
        /// <returns>
        /// A List with all matches
        /// </returns>
        public List<Match> GetAll()
        {
            return context.Matches.Where(m => !m.IsDeleted).ToList();
        }

        // Gets all matches where concrete team is playing
        /// <summary>
        /// Gets all matches where concrete team with <paramref name="teamId"/> is playing. 
        /// </summary>
        /// <returns>
        /// A List with all matches with this concrete team
        /// </returns>
        /// <param name="teamId">An integer.</param>
        public List<Match> GetAllForATeam(int teamId)
        {
            return context.Matches.Where(m => !m.IsDeleted && (m.GuestId == teamId || m.HostId == teamId)).ToList();
        }

        // Gets a match by id
        /// <summary>
        /// Gets a match by id.
        /// </summary>
        /// <returns>
        /// The match with this id
        /// </returns>
        /// <param name="id">An integer.</param>
        public Match GetMatchById(int id)
        {
            Match match = context.Matches.FirstOrDefault(m => m.Id == id);

            if (match == null || match.IsDeleted)
            {
                throw new ArgumentException(ExceptionMessages.InvalidId);
            }

            return match;
        }
    }
}