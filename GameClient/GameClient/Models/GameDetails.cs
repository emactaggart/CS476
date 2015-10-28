using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Models
{
    class GameDetails
    {
        public Guid id { private set; get; }
        public string type { private set; get; }
        public int playerMin { private set; get; }
        public int playerMax { private set; get; }
        public string description { private set; get; }

        public GameDetails(Guid id, string type, int min, int max, string description)
        {
            this.id = id;
            this.type = type;
            this.playerMin = min;
            this.playerMax = max;
            this.description = description;
        }
    }
}
