using System;
using System.Collections.Generic;

namespace TeamAPI.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public List<User> TeamMembers { get; set; }
    }
}
