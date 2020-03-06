using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduler.ReadModel.Models
{
    public class User : ReadDbModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Team Team { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
