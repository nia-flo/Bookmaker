using Bookmaker.Data;
using Bookmaker.Data.Models;
using Bookmaker.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class PlayerServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddPlayer_Saves_Coach()
        {
            //Arrange
            var playerSet = new Mock<DbSet<Player>>();

            var mockContext = new Mock<BookmakerContext>();
            mockContext.Setup(m => m.Players).Returns(playerSet.Object);

            var playerService = new PlayerService(mockContext.Object);

            //Act
            Player player = new Player()
            {
                Age = 20,
                Name = "Name"
            };
            playerService.AddPlayer(player);

            //Assert
            playerSet.Verify(m => m.Add(It.IsAny<Player>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}