using System;
namespace TesinaServer.Models {
    public class Player {
		public int ID { get; set; }
        public float Latitude { get; set; }
		public float Longitude { get; set; }
		public float Rotation { get; set; }
        public string Username { get; set; }
		public int MatchID { get; set; }

        public Player(string Username, int ID, int MatchID) {
			this.ID = ID;
            this.Latitude = 0;
            this.Longitude = 0;
            this.Rotation = 0;
            this.Username = Username;
			this.MatchID = MatchID;
        }
    }
}
