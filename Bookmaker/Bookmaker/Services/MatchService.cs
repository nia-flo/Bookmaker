using System;
using System.Collections.Generic;
using System.Linq;
using Bookmaker.Data;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    public class MatchService : IMatchService
    {
        private BookmakerContext context;

        public MatchService()
        {
            this.context = new BookmakerContext();
        }

        public void AddMatch(Match match)
        {
            if (match.HostId== match.GuestId)
            {
                throw new ArgumentException(Exceptions.InvalidId);
            }

            //if (match.HostTeam.Players.Count < Constants.MinPlayersCountForAMatch)
            //{
            //    throw new ArgumentException(Exceptions.NotEnoughPlayersHostTeam);
            //}

            //if (match.GuestTeam.Players.Count < Constants.MinPlayersCountForAMatch)
            //{
            //    throw new ArgumentException(Exceptions.NotEnoughPlayersGuestTeam);
            //}

            context.Matches.Add(match);

            context.SaveChanges();
        }

        public void RemoveMatch(int id)
        {
            Match match = this.GetMatchById(id);

            context.Matches.Remove(match);

            context.SaveChanges();
        }

        public void PlayMatch(int id)
        {
            Match match = this.GetMatchById(id);

            Random random = new Random();
            Result result = new Result();
            result.HostGoals = random.Next(0, Constants.MaxGoalsCount);
            result.GuestGoals = random.Next(0, Constants.MaxGoalsCount);

            match.Result = result;

            context.SaveChanges();
        }

        public string GetMatchResult(int id)
        {
            Match match = this.GetMatchById(id);

            if (match.Result == null)
            {
                throw new ArgumentException(Exceptions.MatchNotPlayed);
            }

            return match.Result.ToString();
        }

        public List<Match> GetAll()
        {
            return context.Matches.Where(m => !m.IsDeleted).ToList();
        }

        public List<Match> GetAllForATeam(int teamId)
        {
            return context.Matches.Where(m => !m.IsDeleted && (m.GuestTeam.Id == teamId || m.HostTeam.Id == teamId)).ToList();
        }

        public Match GetMatchById(int id)
        {
            Match match = context.Matches.FirstOrDefault(m => m.Id == id);

            if (match == null || match.IsDeleted)
            {
                throw new ArgumentException(Exceptions.InvalidId);
            }

            return match;
        }
    }
}