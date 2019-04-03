using Bookmaker.Data;
using Bookmaker.Data.Models;
using Bookmaker.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class CoachServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddCoach_Saves_Coach()
        {
            //Arrange
            var coachSet = new Mock<DbSet<Coach>>();

            var mockContext = new Mock<BookmakerContext>();
            mockContext.Setup(m => m.Coaches).Returns(coachSet.Object);

            var coachService = new CoachService(mockContext.Object);

            //Act
            Coach coach = new Coach()
            {
                Age = 20,
                Name = "Name"
            };
            coachService.AddCoach(coach);

            //Assert
            coachSet.Verify(m => m.Add(It.IsAny<Coach>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}