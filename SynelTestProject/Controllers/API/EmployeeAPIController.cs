using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using SynelTestProject.DAL.Interfaces;
using SynelTestProject.DAL.DTOs; // Do not work with Models directly, only with DTOs

namespace SynelTestProject.Controllers.API
{
    public class EmployeeAPIController : ApiController
    {
        private readonly IEmployeeAPI _empAPIRepo = null;

        //Injecting all the necessary Repos
        public EmployeeAPIController(IEmployeeAPI empRepo)
        {
            _empAPIRepo = empRepo;
           
        }
        


        [HttpGet]
        // GET /api/EmployeeAPI
        public IHttpActionResult GetEmployees()
        {
            //Retrieving all the Employees from DB
            List<EmployeeDto> listOfEmployees = _empAPIRepo.GetAllEmployees();

            if (listOfEmployees == null)
            {
                return NotFound();
            }

            return Ok(listOfEmployees);
        }





    }
}
