using System;
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
        private Mock<DbSet<Coach>> coachSet;
        private Mock<BookmakerContext> mockContext;
        private CoachService coachService;

        [SetUp]
        public void Setup()
        {
            coachSet = new Mock<DbSet<Coach>>();

            mockContext = new Mock<BookmakerContext>();
            mockContext.Setup(m => m.Coaches).Returns(coachSet.Object);

            coachService = new CoachService(mockContext.Object);
        }

        [Test]
        public void AddCoach_Saves_Coach()
        {
            Coach coach = new Coach()
            {
                Age = 20,
                Name = "Name"
            };

            coachService.AddCoach(coach);
            
            coachSet.Verify(m => m.Add(It.IsAny<Coach>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void AddCoach_Doesnt_Save_Coach_With_Age_Less_Than_18()
        {
            Coach coach = new Coach();

            Assert.Throws<ArgumentException>(() => coach.Age = 15);
        }

        [Test]
        public void AddCoach_Doesnt_Save_Coach_With_Age_More_Than_65()
        {
            Coach coach = new Coach();

            Assert.Throws<ArgumentException>(() => coach.Age = 70);
        }

        [Test]
        public void AddCoach_Doesnt_Save_Coach_With_Invalid_Name()
        {
            Coach coach = new Coach();

            Assert.Throws<ArgumentException>(() => coach.Name = "@#$");
        }
    }
}