using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Libly.Models;

namespace Libly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<Membership> Memberships { get; set; }
        public Customer Customer { get; set; }
    }
}