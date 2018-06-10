using Newtonsoft.Json;

namespace TesinaServer.Models {
    public class Player {
        public int ID { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Rotation { get; set; }
        public string Username { get; set; }
        public int MatchID { get; set; }
        public int TeamID { get; set; }


        public Player(string Username, int ID, int MatchID, int TeamID)
        {
            this.ID = ID;
            this.Latitude = 0;
            this.Longitude = 0;
            this.Rotation = 0;
            this.Username = Username;
            this.MatchID = MatchID;
            this.TeamID = TeamID;
        }

        public bool Equals(Player p)
        {
            return (p.ID == this.ID);
        }

        public static bool IsAlly(Player one, Player two)
        {
            if (one == null || two == null) return false;
            return (one.TeamID == two.TeamID);
        }

        public static bool IsEnemy(Player one, Player two)
        {
            if (one == null || two == null) return false;
            return (one.TeamID != two.TeamID);
        }

        public bool EqualsComplete(Player p)
        {
            if (!Equals(p)) return false;// se l'id è diverso, i player sono diversi
            if (Latitude != p.Latitude) return false;
            if (Longitude != p.Longitude) return false;
            if (Rotation != p.Rotation) return false;
            if (!Username.Equals(p.Username)) return false;
            if (MatchID != p.MatchID) return false;
            if (TeamID != p.MatchID) return false;
            return true;
        }


        public void UpdatePosition(Player player)
        {
            Latitude = player.Latitude;
            Longitude = player.Longitude;
            Rotation = player.Rotation;
        }

        public string ToSerializedData() => JsonConvert.SerializeObject(this);
    }
}
