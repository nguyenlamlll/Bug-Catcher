using BugCatcher.DAL.Abstraction.Repositories;
using BugCatcher.DAL.Models;
using BugCatcher.Service.Abstraction;
using BugCatcher.Service.Implementation;
using BugCatcher.Service.Models.Commands;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace BugCatcher.Service.Tests
{
    public class CompanyServiceTests
    {
        [Fact]
        public void CreateCompany_Fails_WhenUserNotExistInDatabase()
        {
            // Arrange
            CreateCompanyCommand badCommand = new CreateCompanyCommand()
            {
                Name = "Test Company",
                UserId = Guid.NewGuid()
            };

            var mockRepo = new Mock<ICompanyRepository>();
            mockRepo.Setup(repo => repo.CreateCompany(It.IsAny<Company>()));
            mockRepo.Setup(repo => repo.Save());
            var mockCompanyEnrollmentRepo = new Mock<ICompanyEnrollmentRepository>();
            mockCompanyEnrollmentRepo.Setup(enrolRepo => enrolRepo.CreateCompanyEnrollment(It.IsAny<CompanyEnrollment>()))
                .Throws(new DbUpdateException("Not saved", new System.Exception()));
            mockCompanyEnrollmentRepo.Setup(enrolRepo => enrolRepo.Save());

            var service = new CompanyService(mockRepo.Object, mockCompanyEnrollmentRepo.Object);

            // Act & Assert
            Assert.Throws<DbUpdateException>(() => (service as ICompanyService).CreateCompany(badCommand));
        }

        [Fact]
        public void GetCompany_ReturnsSameCompany_WhenGivenExistingCompanyId()
        {
            // Arrange
            Company returnCompany = new Company()
            {
                Id = Guid.NewGuid(),
                Name = "Test Company",
                Products = new List<Product>() { new Product() }
            };
            var mockRepo = new Mock<ICompanyRepository>();
            mockRepo.Setup(repo => repo.GetCompany(It.Is<Guid>(id => id == returnCompany.Id)))
                .Returns(returnCompany);
            var service = new CompanyService(mockRepo.Object, null);

            // Act
            var result = (service as ICompanyService).GetCompany(returnCompany.Id);

            // Assert
            Assert.Equal(returnCompany.Id, result.Id);
        }
    }
}
