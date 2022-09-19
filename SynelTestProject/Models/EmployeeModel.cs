using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;


namespace SynelTestProject.Models
{

    public class EmployeeModel
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Payroll Number")]
        public string PayrollNumber { get; set; }

        [Display(Name = "Forename")]
        public string Forenames { get; set; }

        public string Surename { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Date_of_Birth { get; set; }

        
        public string Telephone { get; set; }
        public string Mobile { get; set; }

       
        public string Address { get; set; }

        [Display(Name = "2nd Address")]
        public string Address_2 { get; set; }

        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        [Display(Name = "Home E-mail")]
        public string EMail_Home { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? Start_Date { get; set; }
    }
}