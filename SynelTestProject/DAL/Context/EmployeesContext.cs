using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using SynelTestProject.Models;

namespace SynelTestProject.DAL.Context
{
    public class EmployeesContext : DbContext
    {
        //Initializing DbContext to work with EF
        public EmployeesContext() : base("DbConn")
        { }
        public DbSet<EmployeeModel> Employees { get; set; }

    }
}