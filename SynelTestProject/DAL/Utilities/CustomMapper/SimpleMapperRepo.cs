using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SynelTestProject.DAL.DTOs;
using SynelTestProject.Models;

namespace SynelTestProject.DAL.Utilities.CustomMapper
{
    public class SimpleMapperRepo : ISimpleMapper
    {
        public SimpleMapperRepo()
        {

        }

        //Responsible for creating the EmployeeDto from EmployeeModel
        public EmployeeDto CreateEmpDto(EmployeeModel empM)
        {
            EmployeeDto empD = new EmployeeDto() {
                Id = empM.Id,
                PayrollNumber = empM.PayrollNumber,
                Forenames = empM.Forenames,
                Surename = empM.Surename,
                Date_of_Birth = empM.Date_of_Birth,
                Telephone = empM.Telephone,
                Mobile = empM.Mobile,
                Address = empM.Address,
                Address_2 = empM.Address_2,
                PostCode = empM.PostCode,
                EMail_Home = empM.EMail_Home,
                Start_Date = empM.Start_Date
            };
            return empD;
        }



    }
}