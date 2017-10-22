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

        public void KillMage(Mage mage)
        {
            if (AliveMages.Contains(mage))
            {
                AliveMages.Remove(mage);
                DeadMages.Add(mage);
            }
            else
            {
                throw new ArgumentException("The mage could not be killed because it was not found in the list of alive mages");
            }
        }

        public StoryPlot FormAlliance(Alliance alliance)
        {
            if (alliance.Mage1 == null || alliance.Mage2 == null)
            {
                throw new ArgumentException("An alliance's mages cannot be null");
            }

            if (MagesWithNoAlliances.Contains(alliance.Mage1) && MagesWithNoAlliances.Contains(alliance.Mage2))
            {
                MagesWithNoAlliances.Remove(alliance.Mage1);
                MagesWithNoAlliances.Remove(alliance.Mage2);
                Alliances.Add(alliance);

                return new StoryPlot($"{alliance.Mage1.Name} and {alliance.Mage2.Name} have formed an alliance");
            }
            else
            {
                throw new ArgumentException("Mages must be in the list of MagesWithNoAlliance to form an alliance");
            }
        }
    }
}
