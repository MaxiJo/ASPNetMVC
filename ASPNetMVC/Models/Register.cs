using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPNetMVC.Models
{
    public class Register
    {
        public Account accounts { get; set; }
        public Division divisions { get; set; }
        public Employee employees { get; set; }

        public string Nama { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "DateTime2")]
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int divisionId { get; set; }
        public string Passwords { get; set; }
    }
}