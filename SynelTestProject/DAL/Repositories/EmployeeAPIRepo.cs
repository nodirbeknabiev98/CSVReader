using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SynelTestProject.DAL.Context;
using SynelTestProject.DAL.Interfaces;
using SynelTestProject.Models;
using SynelTestProject.DAL.DTOs;
using SynelTestProject.DAL.Utilities.CustomMapper;


namespace SynelTestProject.DAL.Repositories
{
    public class EmployeeAPIRepo: IDisposable,IEmployeeAPI
    {
        //DbContext derived class 
        private EmployeesContext _context = null;  

        private readonly ISimpleMapper _mapper = null; 

        //Injecting all necessary repos
        public EmployeeAPIRepo(ISimpleMapper mapper)
        {
            _context = new EmployeesContext();
            _mapper = mapper;
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


        public List<EmployeeDto> GetAllEmployees()
        {
            //Retrieving all employees from DB
            List<EmployeeModel> list_EmployeeModel = _context.Employees.ToList();
            List<EmployeeDto> list_EmployeeDto = new List<EmployeeDto>();

            //Creating EmployeeDto List by mapping each EmployeeModel in list_EmployeeModel to each EmployeeDto
            foreach (EmployeeModel empM in list_EmployeeModel)
            {
                 list_EmployeeDto.Add(_mapper.CreateEmpDto(empM));
            }

            //Never return domain object(EmployeeModel) to external system
            return list_EmployeeDto;
        }
      

    }
}
