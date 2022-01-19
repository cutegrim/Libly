using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public bool IsSubscribed { get; set; }
        [MinMemberAge]
        public DateTime? Birthday { get; set; }
        public Membership Membership { get; set; }
        [Required]
        public byte MembershipId { get; set; }
    }
}