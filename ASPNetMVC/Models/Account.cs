using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPNetMVC.Models
{
    [Table("TB_T_Account")]
    public class Account
    {
        

        [Key][ForeignKey("employee")]
        public int AccountId { get; set; }
        public string Passwords { get; set; }
        public virtual Employee employee { get; set; }

    }
}