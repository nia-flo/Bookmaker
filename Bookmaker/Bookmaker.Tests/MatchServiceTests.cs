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
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddMatch_Saves_Match()
        {
            //Arrange
            var matchSet = new Mock<DbSet<Match>>();

            var mockContext = new Mock<BookmakerContext>();
            mockContext.Setup(m => m.Matches).Returns(matchSet.Object);

            var matchService = new MatchService(mockContext.Object);

            //Act
            Team host = new Team()
            {
                Id = 1,
                Name = "First",
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

            Team guest = new Team()
            {
                Id = 2,
                Name = "Second",
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

            Match match = new Match()
            {
                HostTeam = host,
                HostId = 1,
                GuestTeam = guest,
                GuestId = 2
            };
            matchService.AddMatch(match);

            //Assert
            matchSet.Verify(m => m.Add(It.IsAny<Match>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}