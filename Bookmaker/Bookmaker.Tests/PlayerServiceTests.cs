using System;
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
        private Mock<DbSet<Player>> playerSet;
        private Mock<BookmakerContext> mockContext;
        private PlayerService playerService;

        [SetUp]
        public void Setup()
        {
            playerSet = new Mock<DbSet<Player>>();

            mockContext = new Mock<BookmakerContext>();
            mockContext.Setup(m => m.Players).Returns(playerSet.Object);

            playerService = new PlayerService(mockContext.Object);
        }

        [Test]
        public void AddPlayer_Saves_Player()
        {
            Player player = new Player()
            {
                Age = 20,
                Name = "Name"
            };
            playerService.AddPlayer(player);
            
            playerSet.Verify(m => m.Add(It.IsAny<Player>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void AddPlayer_Doesnt_Save_Player_With_Age_Less_Than_18()
        {
            Player player = new Player();

            Assert.Throws<ArgumentException>(() => player.Age = 15);
        }

        [Test]
        public void AddPlayer_Doesnt_Save_Player_With_Age_More_Than_65()
        {
            Player player = new Player();

            Assert.Throws<ArgumentException>(() => player.Age = 70);
        }

        [Test]
        public void AddPlayer_Doesnt_Save_Player_With_Invalid_Name()
        {
            Player player = new Player();

            Assert.Throws<ArgumentException>(() => player.Name = "@#$");
        }
    }
}