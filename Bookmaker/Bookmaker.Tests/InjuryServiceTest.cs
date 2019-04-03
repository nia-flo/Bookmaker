using Bookmaker.Data;
using Bookmaker.Data.Models;
using Bookmaker.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class InjuryServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddInjury_Saves_Injury()
        {
            //Arrange
            var InjurySet = new Mock<DbSet<Injury>>();

            var mockContext = new Mock<BookmakerContext>();
            mockContext.Setup(m => m.Injuries).Returns(InjurySet.Object);

            var injuryService = new InjuryService(mockContext.Object);

            //Act
            Injury injury = new Injury()
            {
                id = 2,
                Name = "Name"
            };
            injuryService.AddInjury(injury);

            //Assert
            InjurySet.Verify(m => m.Add(It.IsAny<Injury>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}