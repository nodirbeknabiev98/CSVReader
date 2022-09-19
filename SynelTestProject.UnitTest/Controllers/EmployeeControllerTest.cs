using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using SynelTestProject;
using SynelTestProject.Controllers;
using System.Web.Mvc;
using SynelTestProject.Models;

using Moq;
using SynelTestProject.DAL.Interfaces;
using System.Web;
using System.IO;

namespace SynelTestProject.UnitTest.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {

        private EmployeeController _empController;
        private EmployeeModel _empModel;
        private Mock<IEmployee> _empRepo_Mock;
       

        [TestInitialize]
        public void SetupInitial()
        {
            //Arrange
            _empRepo_Mock = new Mock<IEmployee>();
            _empController = new EmployeeController(_empRepo_Mock.Object);
            _empModel = new EmployeeModel()
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


        /* Index method testing - START */

        [TestMethod]
        public void Index_GET_ViewResult_NotNull()
        {
            //Act
            ViewResult result = _empController.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index_GET_TempData_SuccErrMsg()
        {
            //Arrange
            string expected1 = "This is the success message";
            string expected2 = "empty";
            //Act
            ViewResult result = _empController.Index("This is the success message") as ViewResult;
            //Assert
            Assert.AreEqual(expected1,result.TempData["msgSucc"]);
            Assert.AreEqual(expected2, result.TempData["msgErr"]);
        }

        /* Index method testing - END */


        /*Edit method testing - START*/

        [TestMethod]
        public void Edit_GET_ViewResult_WhenParamIsNull()
        {
            //Arrange
            int? id = null;
            //Act
            ViewResult result = _empController.Edit(id) as ViewResult;
            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Edit_GET_ViewResult_WhenParamIsNotNull()
        {
            //Arrange
           _empRepo_Mock.Setup(a => a.GetEmployee(2)).Returns(_empModel);
            //Act
            ViewResult result = _empController.Edit(2) as ViewResult;
            //Assert
            Assert.AreEqual<EmployeeModel>(_empModel, (EmployeeModel)result.Model);
        }

        [TestMethod]
        public void Edit_POST_ViewResult_WhenParamIsNull()
        {
            //Arrange 
            EmployeeModel emp = null;
            //Act
            ViewResult result = _empController.Edit(emp) as ViewResult;
            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Edit_POST_ViewResult_WhenParamIsNotNull()
        {
            //Arrange 
            _empRepo_Mock.Setup(a => a.EditEmployee(_empModel)).Returns(_empModel);
            //Act
            ViewResult result = _empController.Edit(_empModel) as ViewResult;
            //Assert
            Assert.IsNull(result);
        }



        /*Edit method testing - END*/



        /*Upload method testing - START*/

        [TestMethod]
        public void Upload_POST_WhenParamIsNull()
        {
            //Act
            ViewResult result = _empController.Upload(null) as ViewResult;
            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Upload_POST_WhenParamIsNotNull()
        {
            //Arrange 
            int rowsNum = 2;
            var httpPFB_Mock = new Mock<HttpPostedFileBase>();
            _empRepo_Mock.Setup(a => a.saveCsvInDB(httpPFB_Mock.Object.InputStream)).Returns(rowsNum);
            //Act
            ViewResult result = _empController.Upload(httpPFB_Mock.Object) as ViewResult;
            //Assert
            Assert.IsNull(result);
        }


        /*Upload method testing - END*/

    }
}
