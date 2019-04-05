using System;
using System.Collections.Generic;
using Bookmaker.Data;
using Bookmaker.Data.Models;
using Bookmaker.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Match = Bookmaker.Data.Models.Match;

namespace Tests
{
    public class MatchServiceTests
    {
        private Mock<DbSet<Match>> matchSet;
        private Mock<BookmakerContext> mockContext;
        private MatchService matchService;
        private Team host;
        private Team guest;

        [SetUp]
        public void Setup()
        {
            matchSet = new Mock<DbSet<Match>>();

            mockContext = new Mock<BookmakerContext>();
            mockContext.Setup(m => m.Matches).Returns(matchSet.Object);

            matchService = new MatchService(mockContext.Object);

            host = new Team()
            {
                Id = 1,
                Name = "Host",
                Division = 1,
                Budget = 1000000,
                Players = new List<Player>
                {
                    new Player(),
                    new Player(),
                    new Player(),
                    new Player(),
                    new Player(),
                    new Player(),
                    new Player(),
                    new Player(),
                    new Player(),
                    new Player(),
                    new Player(),
                    new Player()
                }
            };

            guest = new Team()
            {
                Id = 2,
                Name = "Guest",
                Division = 1,
                Budget = 1000000,
                Players = new List<Player>
                {
                    new Player(),
                    new Player(),
                    new Player(),
                    new Player(),
                    new Player(),
                    new Player(),
                    new Player(),
                    new Player(),
                    new Player(),
                    new Player(),
                    new Player(),
                    new Player()
                }
            };
        }

        [Test]
        public void AddMatch_Saves_Match()
        {
            

            Match match = new Match()
            {
                HostTeam = host,
                HostId = 1,
                GuestTeam = guest,
                GuestId = 2
            };
            matchService.AddMatch(match);

            matchSet.Verify(m => m.Add(It.IsAny<Match>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void AddMatch_Doesnt_Save_Match_When_HostTeam_Doesnt_have_Enough_Players()
        {
            host.Players = new List<Player>();

            Match match = new Match()
            {
                HostTeam = host,
                HostId = 1,
                GuestTeam = guest,
                GuestId = 2
            };

            Assert.Throws<ArgumentException>(() => matchService.AddMatch(match));
        }

        [Test]
        public void AddMatch_Doesnt_Save_Match_When_GuestTeam_Doesnt_have_Enough_Players()
        {
            guest.Players = new List<Player>();

            Match match = new Match()
            {
                HostTeam = host,
                HostId = 1,
                GuestTeam = guest,
                GuestId = 2
            };

            Assert.Throws<ArgumentException>(() => matchService.AddMatch(match));
        }

        [Test]
        public void AddMatch_Doesnt_Save_Match_When_GuestId_And_HostId_Are_Equal()
        {
            Match match = new Match()
            {
                HostTeam = host,
                HostId = 1,
                GuestTeam = host,
                GuestId = 1
            };

            Assert.Throws<ArgumentException>(() => matchService.AddMatch(match));
        }
    }
}