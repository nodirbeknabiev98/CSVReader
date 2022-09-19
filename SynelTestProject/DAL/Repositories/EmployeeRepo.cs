using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.IO;

using SynelTestProject.Models;
using SynelTestProject.DAL.Context;
using SynelTestProject.DAL.Interfaces;
using System.Data.Entity;

namespace SynelTestProject.DAL.Repositories
{
    public class EmployeeRepo : IDisposable, IEmployee
    {
       //DbContext derived class 
       private EmployeesContext _context = null;

        public EmployeeRepo()
        {
            _context = new EmployeesContext();
        }

        //Once we are done with DbContext(EmployeeContext), we need to dispose it
        //Current class must implement IDisposable interface to use this feauture
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public EmployeeModel GetEmployee(int? id)
        {
            //Retrieving the Employee data from DB using id
            EmployeeModel emp = _context.Employees.Where(e => e.Id == id).FirstOrDefault();

            return emp;
        }

        public int saveCsvInDB(Stream inputStream)
        {
            int rowNum = 0; // proccessed row counter for displaying the message later

            //Proccessing the input stream - adding to DB
            using (StreamReader reader = new StreamReader(inputStream))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    //Should skip line number 0, as it is the 'header' line in our CSV file.
                    if (rowNum != 0)
                    {
                        //Mapping all data from CSV to database columns
                        EmployeeModel employee = new EmployeeModel();

                        employee.PayrollNumber = values[0];
                        employee.Forenames = values[1];
                        employee.Surename = values[2];
                        employee.Date_of_Birth = DateTime.ParseExact(values[3], "dd/MM/yyyy", null);
                        employee.Telephone = values[4];
                        employee.Mobile = values[5];
                        employee.Address = values[6];
                        employee.Address_2 = values[7];
                        employee.PostCode = values[8];
                        employee.EMail_Home = values[9];
                        employee.Start_Date = DateTime.ParseExact(values[10], "dd/MM/yyyy", null);

                        _context.Employees.Add(employee);
                    }
                    rowNum++;
                }
                _context.SaveChanges();
            }

            rowNum--; 
            return rowNum;

        }

        public EmployeeModel EditEmployee(EmployeeModel emp)
        {
            
            _context.Employees.Attach(emp); // repopulating a context with an entity(EmployeeModel) that is known to already exist in the database
            _context.Entry(emp).State = EntityState.Modified;  //Changing "Unchanged" state of EmployeeModel to "Modified"
            _context.SaveChanges(); 
            return emp;
        }


    }
}



/*
 //string fileName = System.IO.Path.GetFileName(upload.FileName);
 //upload.SaveAs(Server.MapPath("~/Files/" + fileName));
 
 */