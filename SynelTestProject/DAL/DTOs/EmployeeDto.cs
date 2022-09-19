using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SynelTestProject.DAL.DTOs
{
    //External systems can retrieve only this DTO, not domain object(EmployeeModel)
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string PayrollNumber { get; set; }
        public string Forenames { get; set; }

        public string Surename { get; set; }
        public DateTime? Date_of_Birth { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Address_2 { get; set; }
        public string PostCode { get; set; }
        public string EMail_Home { get; set; }
        public DateTime? Start_Date { get; set; }
    }
}