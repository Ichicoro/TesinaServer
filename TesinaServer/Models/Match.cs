using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;

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

		public Player GetPlayer(int pID) {
			foreach (var p in PlayerList)
				if (p.ID == pID) return p;
			return null;
		}

		public int DeletePlayer(int pID) {
			foreach (var p in PlayerList)
				if (p.ID == pID) {
					PlayerList.Remove(p);
					return 0;
				}
			return -1;
		}

		public int DeletePlayer(Player pl) {
			foreach (var p in PlayerList)
				if (p.Equals(pl)) {
					PlayerList.Remove(pl);
					return 0;
				}
			return -1;
		}

	    public int UpdatePlayer(Player p) {
		    foreach (var pl in PlayerList) {
			    if (pl.ID != p.ID) continue;
			    PlayerList.Remove(pl);
			    PlayerList.Add(p);
		    }
		    return 0;
	    }

        public override string ToString() => "[MatchID: " + this.ID + "; MatchName: " + this.Name + "]";

        public string ToSerializedData() => JsonConvert.SerializeObject(this);
    }
}
