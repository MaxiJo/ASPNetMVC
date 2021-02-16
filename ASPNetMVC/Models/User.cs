using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNetMVC.Models
{
    public class User
    {
        public Employee employees { get; set; }
        public Account accounts { get; set; }
    }
}