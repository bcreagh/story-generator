using StoryGenerator.Domain.Story;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryGenerator.Domain.WarEvents
{
    public abstract class WarEvent
    {
        public abstract StoryPlot PlayEvent();
    }
}
