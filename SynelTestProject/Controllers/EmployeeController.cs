using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.SqlClient;
using System.IO;
using SynelTestProject.Models;

using SynelTestProject.DAL.Interfaces;
using SynelTestProject.DAL.Repositories;
//using System.Globalization;

namespace SynelTestProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _empRepo = null;

        //Injecting all the necessary Repos 
        public EmployeeController(IEmployee empRepo)
        {
           
            _empRepo = empRepo;
        }

        public EmployeeController()
        {
            
        }

        [HttpGet]
        // GET: Employee
        public ActionResult Index(string msgSucc = "empty", string msgErr = "empty")
        {
            TempData["msgSucc"] = msgSucc; 
            TempData["msgErr"] = msgErr;
            return View();
        }

        [HttpGet]
        //GET : Employee/Edit
        public ActionResult Edit(int? Id = null)
        {
            string msgErr = "";
            try
            {
                if (Id != null)
                {
                    //Retrieving the Employee's info using Id
                    EmployeeModel emp = _empRepo.GetEmployee(Id);

                    if (emp == null)
                    {
                        return HttpNotFound();
                    }

                    return View(emp);
                }
                else
                {
                    return HttpNotFound();
                }

            }
            catch(Exception ex)
            {
                TempData["msgErr"] = ex.Message;
                return RedirectToAction("Index", new { msgErr = msgErr });
            }
        }

        
        [HttpPost]
        //POST: Employee/Edit
        public ActionResult Edit(EmployeeModel emp)
        {
            string msgSucc = "";
            string msgErr = "";
            try
            {
                if (emp != null)
                {
                    //Changing the Employee's info
                    emp = _empRepo.EditEmployee(emp);
                    msgSucc = "Employee data was successfully edited";
                    return RedirectToAction("Index", new { msgSucc = msgSucc });
                }
                else
                {
                    return HttpNotFound();
                }
            }
            catch (Exception ex)
            {
                msgErr = ex.Message;
                return RedirectToAction("Index", new { msgErr = msgErr });

            }


        }
        
        [HttpPost]
        //POST: Employee/Upload
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            string msgErr = "";
            string msgSucc = "";
            try
            {
                if (upload != null)
                {
                    //Saving the CSV file data in DB
                    int rowNum = _empRepo.saveCsvInDB(upload.InputStream);
                    msgSucc =  $"{rowNum} rows were successfully proccessed!";
                }
                else
                {
                    msgErr = "The CSV file was not selected. Please select the CSV file.";
                }

                return RedirectToAction("Index", new { msgSucc = msgSucc,msgErr = msgErr});

            }
            catch(Exception ex)
            {
                msgErr = ex.Message;
                return RedirectToAction("Index", new { msgErr = msgErr});
            }
           
        }
    }
}

