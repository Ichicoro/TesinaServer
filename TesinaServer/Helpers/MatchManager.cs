using System;
using System.Collections.Generic;
using TesinaServer.Models;

namespace TesinaServer.Helpers {
    public static class MatchManager {
        private static List<Match> Matches = new List<Match>();

        public static List<Match> GetAllMatches() {
            return Matches;
        }

        public static Match GetMatchByID(int id) {
            foreach (var match in Matches) {
                if (match.ID == id)
                    return match;
            }
            return null;
        }

        public static int CreateNewMatch(string MatchName) {
            var r = new Random();
            var MatchID = r.Next();
            while (GetMatchByID(MatchID) != null || MatchID == 0) {
                MatchID = r.Next();
            }
            var m = new Match(MatchName, MatchID);
            Matches.Add(m);
            return MatchID;
        }

        public static int DeleteMatch(int id) {
            foreach (var match in Matches) {
                if (match.ID == id)
                    Matches.Remove(match);
                    return 0;
            }
            return 1;
        }

		public static Player AddPlayer(int MatchID, string Username) {
			var r = new Random();
			var id = r.Next();
			var p = new Player(Username, id, MatchID);
			foreach (var match in Matches) {
				if (match.ID == MatchID)
					match.PlayerList.Add(p);
			}
			return p;
		}

		public static Player GetPlayer(int playerID) {
			foreach (var m in Matches) {
				var p = m.GetPlayer(playerID);
				if (p != null)
					return p;
			}
			return null;
		}

		public static Player GetPlayer(int PlayerID, int MatchID) {
			var m = GetMatchByID(MatchID);
			if (m == null) return null;
			var p = m.GetPlayer(PlayerID);
			return p ?? null;
		}

	    public static List<Player> GetAllPlayers(int mid = -1) {
		    var playerList = new List<Player>();
		    foreach (var m in Matches) {
			    if (m.ID != mid && mid != -1) continue;
			    foreach (var p in m.PlayerList) {
				    playerList.Add(p);
			    }
		    }

		    return playerList;
	    }

		public static int DeletePlayer(int PlayerID) {
			foreach (var m in Matches) {
				var p = m.GetPlayer(PlayerID);
				if (p != null)
					m.DeletePlayer(p);
			}
			return -1;
		}

		public static int DeletePlayer(int MatchID, int PlayerID) {
			foreach (var m in Matches) {
				if (MatchID != m.ID) continue;
				var p = m.GetPlayer(PlayerID);
				if (p != null)
					m.DeletePlayer(p);
			}
			return -1;
		}

	    public static int UpdatePlayer(int mid, Player p) {
		    var m = GetMatchByID(mid);
		    Matches.Remove(m);
		    m.UpdatePlayer(p);
		    Matches.Add(m);
		    return 0;
	    }

    }
}
