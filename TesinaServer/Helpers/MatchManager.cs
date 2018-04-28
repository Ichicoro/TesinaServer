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
            foreach (Match match in Matches) {
                if (match.ID == id)
                    return match;
            }
            return null;
        }

        public static int CreateNewMatch(string MatchName) {
            Random r = new Random();
            int MatchID = r.Next();
            while (GetMatchByID(MatchID) != null || MatchID == 0) {
                MatchID = r.Next();
            }
            Match m = new Match(MatchName, MatchID);
            Matches.Add(m);
            return MatchID;
        }

        public static int DeleteMatch(int id) {
            foreach (Match match in Matches) {
                if (match.ID == id)
                    Matches.Remove(match);
                    return 0;
            }
            return 1;
        }

		public static Player AddPlayer(int MatchID, string Username) {
			Random r = new Random();
			int id = r.Next();
			Player p = new Player(Username, id, MatchID);
			foreach (Match match in Matches) {
				if (match.ID == MatchID)
					match.PlayerList.Add(p);
			}
			return p;
		}

		public static Player GetPlayer(int playerID) {
			foreach (Match m in Matches) {
				Player p = m.getPlayer(playerID);
				if (p != null)
					return p;
			}
			return null;
		}

		public static Player GetPlayer(int PlayerID, int MatchID) {
			Match m = GetMatchByID(MatchID);
			if (m != null) {
				Player p = m.getPlayer(PlayerID);
				if (p != null)
					return p;
			}
			return null;
		}

		public static int DeletePlayer(int PlayerID) {
			foreach (Match m in Matches) {
				Player p = m.getPlayer(playerID);
				if (p != null)
					m.DeletePlayer(p);
			}
			return -1;
		}

		public static int DeletePlayer(int PlayerID, int MatchID) {

			return -1;
		}
			

    }
}
