using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPNetMVC.Models
{
    [Table("TB_M_Division")]
    public class Division
    {
        [Key]
        public int DivisionId { get; set; }
        public string NamaDivisi { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
    
}