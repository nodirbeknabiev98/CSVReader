using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using SynelTestProject.Controllers.API;
using SynelTestProject.Models;
using SynelTestProject.DAL.Interfaces;
using Moq;
using System.Web.Http.Results;
using SynelTestProject.DAL.DTOs;
using System.Collections.Generic;
using System.Web.Http;

namespace SynelTestProject.UnitTest.Controllers
{
    [TestClass]
    public class EmployeeAPIControllerTest
    {
        private EmployeeAPIController _empAPIController;
        private EmployeeDto _empDto;
        private Mock<IEmployeeAPI> _empAPIRepo_Mock;


        [TestInitialize]
        public void SetupInitial()
        {
            //Arrange
            _empAPIRepo_Mock = new Mock<IEmployeeAPI>();
            _empAPIController = new EmployeeAPIController(_empAPIRepo_Mock.Object);
            _empDto = new EmployeeDto()
            {
                Id = 2,
                PayrollNumber = "2",
                Forenames = "X",
                Surename = "X",
                Date_of_Birth = DateTime.Now,
                Telephone = "2",
                Mobile = "2",
                Address = "X",
                Address_2 = "X",
                PostCode = "X",
                EMail_Home = "X",
                Start_Date = DateTime.Now
            };
        }

        
        [TestMethod]
        public void GetEmployees_GET_ReturnResult()
        {
            //Act
            List<EmployeeDto> listEmp = new List<EmployeeDto>();
            listEmp.Add(_empDto);
            _empAPIRepo_Mock.Setup(a => a.GetAllEmployees()).Returns(listEmp);

            var response = _empAPIController.GetEmployees();
            var contentResult = response as OkNegotiatedContentResult<List<EmployeeDto>>;

            //Assert 
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(2, contentResult.Content[0].Id);
        }
    }
}
