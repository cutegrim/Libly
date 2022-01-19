using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Web;
using Libly.Models;

namespace Libly.ViewModels
{
    public class RandomBookViewModel
    {
        public Book Book { get; set;}
        public List<Customer> Customers { get; set; }

    }
}