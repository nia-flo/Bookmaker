using Bookmaker.Data;
using Bookmaker.Data.Models;
using Bookmaker.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class ResultServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddResult_Saves_Result()
        {
            var resultSet = new Mock<DbSet<Result>>();

            var mockContext = new Mock<BookmakerContext>();
            mockContext.Setup(m => m.Results).Returns(resultSet.Object);

            var resultService = new ResultService(mockContext.Object);
            resultService.AddResult(new Result());
            resultSet.Verify(m => m.Add(It.IsAny<Result>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }
    }
}