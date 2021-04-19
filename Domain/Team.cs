using System.Collections.Generic;

namespace Domain
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string City{ get; set; }
        public List<Player> Players { get; set; }
    }
}