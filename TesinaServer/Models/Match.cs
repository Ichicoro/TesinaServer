using System;
using System.Collections.Generic;

namespace TesinaServer.Models {
    public class Match {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Player> PlayerList { get; set; }

        public Match(string Name, int ID) {
            this.Name = Name;
            this.ID = ID;
            this.PlayerList = new List<Player>();
        }

		public Player getPlayer(int pID) {
			foreach (Player p in PlayerList)
				if (p.ID == pID) return p;
			return null;
		}

		public int DeletePlayer(int pID) {
			foreach (Player p in PlayerList)
				if (p.ID == pID) {
					this.PlayerList.Remove(p);
					return 0;
				}
			return -1;
		}

		public int DeletePlayer(Player pl) {
			foreach (Player p in PlayerList)
				if (p == pl) {
					this.PlayerList.Remove(pl);
					return 0;
				}
			return -1;
		}

        override public string ToString() => "[MatchID: " + this.ID + "; MatchName: " + this.Name + "]";

        public string ToSerializedData() => "";
    }
}
