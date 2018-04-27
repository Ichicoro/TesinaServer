using System;
using System.Collections.Generic;
using TesinaServer.Models;

namespace TesinaServer.Helpers {
	public static class PlayerManager {
        private static List<Player> Players = new List<Player>();

		public static List<Player> GetAllPlayers() {
			return Players;
		}

		public static Player GetPlayerByID(int id) {
			foreach (Player Player in Players) {
				if (Player.ID == id)
					return Player;
			}
			return null;
		}

		public static int CreateNewPlayer(string PlayerName, int MatchID) {
			Random r = new Random();
			int PlayerID = r.Next();
			while (GetPlayerByID(PlayerID) != null || PlayerID == 0) {
				PlayerID = r.Next();
			}
			Player m = new Player(PlayerName, PlayerID, MatchID);
			Players.Add(m);
			return PlayerID;
		}

		public static int DeletePlayer(int id) {
			foreach (Player Player in Players) {
				if (Player.ID == id)
					Players.Remove(Player);
				return 0;
			}
			return 1;
		}
	}
}
