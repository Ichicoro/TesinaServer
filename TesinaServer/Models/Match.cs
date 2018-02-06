using System;
using System.Collections.Generic;

namespace TesinaServer.Models {
    public class Match {
        public int MatchID { get; set; }
        public string MatchName { get; set; }
        List<Player> PlayerList { get; set; }

        public Match(string MatchName, int id) {
            this.MatchName = MatchName;
            this.MatchID = id;
            this.PlayerList = new List<Player>();
        }

        override public string ToString() {
            return "[MatchID: " + this.MatchID + "; MatchName: " + this.MatchName + "]";
        }
    }
}
