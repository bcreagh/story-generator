﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryGenerator.Domain.Story
{
    public class StoryPlot
    {
        public List<string> PlotEvents { get; set; }

        public StoryPlot()
        {
            PlotEvents = new List<string>();
        }

        public void Add(StoryPlot newPlotEvents)
        {
            PlotEvents = PlotEvents.Concat(newPlotEvents.PlotEvents).ToList();
        }
    }
}
