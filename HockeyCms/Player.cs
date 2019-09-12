using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyCms
{
    class Player
    {
        public enum Position{
            None,
            Goalie,
            Defence,
            Forward
        }
        public string Name { get; set; }
        public Position PlayerPosition { get; set; }
        public int JerseyNumber { get; set; }

        public int Scores { get; set; }
        public int Assists { get; set; }

        public Player(string name, Position position, int jerseyNumber)
        {
            Name = name;
            PlayerPosition = position;
            JerseyNumber = jerseyNumber;
        }
    }
}
