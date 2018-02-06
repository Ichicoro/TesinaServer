using System;
namespace TesinaServer.Models {
    public class Player {
        double Latitude { get; set; }
        double Longitude { get; set; }
        double Rotation { get; set; }
        string Username { get; set; }
        string UUID { get; set; }

        public Player(string Username, string UUID) {
            this.Latitude = 0;
            this.Longitude = 0;
            this.Rotation = 0;
            this.Username = Username;
            this.UUID = UUID;
        }
    }
}
