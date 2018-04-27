﻿using System;
using System.Collections.Generic;

namespace TesinaServer.Models {
    public class Match {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<int> PlayerList { get; set; }

        public Match(string Name, int ID) {
            this.Name = Name;
            this.ID = ID;
            this.PlayerList = new List<int>();
        }

        override public string ToString() => "[MatchID: " + this.ID + "; MatchName: " + this.Name + "]";

        public string ToSerializedData() => "";
    }
}
