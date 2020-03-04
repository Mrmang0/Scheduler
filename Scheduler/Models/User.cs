using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduler.Web.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Team Team { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
