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
                if (match.MatchID == id)
                    return match;
            }
            return null;
        }

        public static int CreateNewMatch(string MatchName) {
            Random r = new Random();
            int MatchID = r.Next();
            while (GetMatchByID(MatchID) != null) {
                MatchID = r.Next();
            }
            Match m = new Match(MatchName, MatchID);
            Matches.Add(m);
            return MatchID;
        }
    }
}
