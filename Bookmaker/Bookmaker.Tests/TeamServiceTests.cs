using Bookmaker.Data;
using Bookmaker.Data.Models;
using Bookmaker.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class TeamServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddTeam_Saves_Team()
        {
            //Arrange
            var teamSet = new Mock<DbSet<Team>>();

            var mockContext = new Mock<BookmakerContext>();
            mockContext.Setup(m => m.Teams).Returns(teamSet.Object);

            var teamService = new TeamService(mockContext.Object);

            //Act
            Team team = new Team()
            {
                Name = "Name",
                Division = 1,
                Budget = 1000000
            };
            teamService.AddTeam(team);

            //Assert
            teamSet.Verify(m => m.Add(It.IsAny<Team>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}