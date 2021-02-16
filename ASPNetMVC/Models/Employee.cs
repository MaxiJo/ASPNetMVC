using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNetMVC.Models
{
    [Table("TB_M_Employee")]
    public class Employee
    {
        [Key]
        public int employeeId { get; set; }
        public string Nama { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "DateTime2")]
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int divisionId { get; set; }
        public Division Divisions { get; set; }
        public virtual Account account { get; set; }
    }
}