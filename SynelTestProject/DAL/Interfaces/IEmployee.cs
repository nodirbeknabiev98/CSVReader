using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using SynelTestProject.Models;

namespace SynelTestProject.DAL.Interfaces
{
    public interface IEmployee
    {

        EmployeeModel GetEmployee(int? id);
        int saveCsvInDB(Stream inputStream);

        EmployeeModel EditEmployee(EmployeeModel emp);
    }
}
