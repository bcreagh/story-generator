using StoryGenerator.Domain.Story;
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

        public GrailWar()
        {
            AliveMages = new List<Mage>();
            DeadMages = new List<Mage>();
            MagesWithNoAlliances = new List<Mage>();
            Alliances = new List<Alliance>();
        }

        public StoryPlot BreakAlliance(Alliance alliance)
        {
            if(Alliances.Count != 0)
            {
                if (Alliances.Remove(alliance))
                {
                    MagesWithNoAlliances.Add(alliance.Mage1);
                    MagesWithNoAlliances.Add(alliance.Mage2);
                    var sp = new StoryPlot();
                    sp.PlotEvents.Add("Alliance is broken");
                    return sp;
                }
                else
                {
                    //if the alliance we want to break does not exist in the list of alliances
                    return null;
                }
            }
            else
            {
                return null;
            } 
        }
    }
}
