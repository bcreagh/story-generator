using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryGenerator.Domain
{
    public class GrailWar
    {
        public List<Mage> AliveMages { get; set; }
        public List<Mage> DeadMages { get; set; }
        public List<Mage> MagesWithNoAlliances { get; set; }
        public List<Alliance> Alliances { get; set; }
    }
}
