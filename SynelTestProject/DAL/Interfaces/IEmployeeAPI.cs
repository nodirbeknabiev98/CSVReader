using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SynelTestProject.Models;
using SynelTestProject.DAL.DTOs;

namespace SynelTestProject.DAL.Interfaces
{
    public interface IEmployeeAPI
    {
        List<EmployeeDto> GetAllEmployees();
    }
}
