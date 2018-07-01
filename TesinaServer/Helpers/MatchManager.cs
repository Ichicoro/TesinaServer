using System;
using System.Collections.Generic;
using System.Threading;
using TesinaServer.Models;

namespace TesinaServer.Helpers {
    public static class MatchManager {
	    // ReSharper disable once FieldCanBeMadeReadOnly.Local
	    private static List<Match> Matches = new List<Match>();
	    private static List<(int MatchID, Timer Timer)> Timers = new List<(int MatchID, Timer Timer)>();

	    public static int DeletionTimeout = 6*600 * 1000;

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

        public static int CreateNewMatch() {
            var r = new Random();
            int MatchID;
	        do {
		        MatchID = r.Next();
	        } while (GetMatchByID(MatchID) != null || MatchID == 0 || MatchID > 99999);
            var m = new Match(MatchID);
            Matches.Add(m);
	        var t = new Timer((state) => DeleteMatch(m.ID), null, DeletionTimeout, Timeout.Infinite);
		    
	        Timers.Add((m.ID, t));
	        ResetTimeout(m.ID);
            return MatchID;
        }
	    
	    public static int CreateNewMatch(int MatchID) {
		    if (GetMatchByID(MatchID) != null || MatchID == 0)
			    return 0;
		    var m = new Match(MatchID);		    Matches.Add(m);
		    var t = new Timer((state) => DeleteMatch(m.ID), null, DeletionTimeout, Timeout.Infinite);
		    
		    Timers.Add((m.ID, t));
		    ResetTimeout(m.ID);
		    return MatchID;
	    }

        public static int DeleteMatch(int id) {
            foreach (var match in Matches) {
                if (match.ID == id)
                    Matches.Remove(match);
                    return 0;
            }

	        DeleteTimeout(id);
            return 1;
        }

		public static Player AddPlayer(int MatchID, string Username, int TeamID) {
			var r = new Random();
			var id = r.Next();
			var p = new Player(Username, id, MatchID, TeamID);
			foreach (var match in Matches) {
				if (match.ID == MatchID)
					match.PlayerList.Add(p);
			}
			ResetTimeout(MatchID);
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
					ResetTimeout(m.ID);
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
			ResetTimeout(MatchID);
			return -1;
		}

	    public static int UpdatePlayer(int mid, Player p) {
		    var m = GetMatchByID(mid);
		    Matches.Remove(m);
		    m.UpdatePlayer(p);
		    Matches.Add(m);
		    ResetTimeout(mid);
		    return 0;
	    }

	    public static bool ResetTimeout(int mid) {
		    foreach (var tim in Timers) {
			    if (tim.MatchID != mid) continue;
			    Console.WriteLine($"Resetting Timeout for Match with ID {mid}");
			    tim.Timer.Change(DeletionTimeout, Timeout.Infinite);
			    return true;
		    }

		    return false;
	    }
	    
	    public static bool DeleteTimeout(int mid) {
		    foreach (var tim in Timers) {
			    if (tim.MatchID != mid) continue;
			    Console.WriteLine($"Deleting Timeout for Match with ID {mid}");
			    Timers.Remove(tim);
			    return true;
		    }

		    return false;
	    }

	    public static bool StartMatch(int mid) {
		    var m = GetMatchByID(mid);
		    Matches.Remove(m);
		    m.StartMatch();
		    Matches.Add(m);
		    ResetTimeout(mid);
		    return true;
	    }
	    
	    public static bool StopMatch(int mid) {
		    var m = GetMatchByID(mid);
		    Matches.Remove(m);
		    m.StopMatch();
		    Matches.Add(m);
		    ResetTimeout(mid);
		    return true;
	    }

    }
}
