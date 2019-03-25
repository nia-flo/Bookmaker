﻿using System;
using System.Collections.Generic;
using System.Linq;
using Bookmaker.Data;
using Bookmaker.Data.Models;

namespace Bookmaker.Services
{
    public class TeamService : ITeamService
    {
        private BookmakerContext context;

        public TeamService()
        {
            this.context = new BookmakerContext();
        }

        public void AddTeam(Team team)
        {
            context.Teams.Add(team);

            context.SaveChanges();
        }

        public void DeleteTeam(int id)
        {
            if (context.Teams.Count(t => t.Id == id) == 0)
            {
                throw new ArgumentException(Exceptions.InvalidId);
            }
            
            context.Teams.First(t => t.Id == id).Delete();

            context.SaveChanges();
        }

        public void AddPlayerToATeam(int teamId, int playerId)
        {
            if (context.Teams.Count(t => t.Id == teamId) == 0 || context.Players.Count(p => p.Id == playerId) == 0)
            {
                throw new ArgumentException(Exceptions.InvalidId);
            }

            Player player = context.Players.First(p => p.Id == playerId);

            if (!player.IsOnSale)
            {
                throw new ArgumentException(Exceptions.NotOnSalePlayer);
            }

            context.Teams.First(t => t.Id == teamId).AddPlayer(player);
            context.Players.First(p => p.Id == playerId).Buy();

            context.SaveChanges();
        }

        public void SellPlayer(int teamId, int playerId)
        {
            if (context.Teams.Count(t => t.Id == teamId) == 0 || context.Players.Count(p => p.Id == playerId) == 0)
            {
                throw new ArgumentException(Exceptions.InvalidId);
            }

            Player player = context.Players.First(p => p.Id == playerId);
            context.Teams.First(t => t.Id == teamId).RemovePlayer(player);
            context.Players.First(p => p.Id == playerId).Sell();

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