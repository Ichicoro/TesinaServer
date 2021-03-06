﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace TesinaServer.Models {
    public class Match {
        public int ID { get; set; }
        public List<Player> PlayerList { get; set; }

        public Match(int ID) {
            this.ID = ID;
            this.PlayerList = new List<Player>();
        }

		public Player GetPlayer(int pID) {
			foreach (var p in PlayerList.ToArray())
				if (p.ID == pID) return p;
			return null;
		}

		public int DeletePlayer(int pID) {
			foreach (var p in PlayerList.ToArray())
				if (p.ID == pID) {
					PlayerList.Remove(p);
					return 0;
				}
			return -1;
		}

		public int DeletePlayer(Player pl) {
			foreach (var p in PlayerList.ToArray())
				if (p.Equals(pl)) {
					PlayerList.Remove(pl);
					return 0;
				}
			return -1;
		}

	    public int UpdatePlayer(Player p) {
		    foreach (var pl in PlayerList.ToArray()) {
			    if (pl.ID != p.ID) continue;
			    PlayerList.Remove(pl);
			    if (p.State == -2)
					p.State = pl.State;
			    PlayerList.Add(p);
		    }
		    return 0;
	    }
	    
	    public int StartMatch() {
		    foreach (var pl in PlayerList.ToArray()) {
			    PlayerList.Remove(pl);
			    pl.State = 0;
			    PlayerList.Add(pl);
		    }
		    return 0;
	    }
	    
	    public int StopMatch() {
		    foreach (var pl in PlayerList.ToArray()) {
			    PlayerList.Remove(pl);
			    pl.State = -1;
			    PlayerList.Add(pl);
		    }
		    return 0;
	    }

        public override string ToString() => "[MatchID: " + this.ID + "]";

        public string ToSerializedData() => JsonConvert.SerializeObject(this);
    }
}
