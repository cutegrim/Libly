using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Libly.Models;

namespace Libly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public bool IsSubscribed { get; set; }
       // [MinMemberAge]
        public DateTime? Birthday { get; set; }

        public MembershipDto Membership { get; set; }
       
        public byte MembershipId { get; set; }
    }
}