using NUnit.Framework;
using StoryGenerator.Domain.Story;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.DomainTests.Story
{
    [TestFixture]
    class StoryPlotTests
    {
        [Test]
        public void Add_ShouldConcatenateTwoMessageListInTheCorrectOrder()
        {
            string[] storyEvents = { "Story Started", "Heros are summoned", "Saber wins the grail", "Story Ended" };

            var storyPlot = new StoryPlot();
            storyPlot.PlotEvents.Add(storyEvents[0]);
            storyPlot.PlotEvents.Add(storyEvents[1]);

            var newStoryEvents = new StoryPlot();
            newStoryEvents.PlotEvents.Add(storyEvents[2]);
            newStoryEvents.PlotEvents.Add(storyEvents[3]);

            storyPlot.Add(newStoryEvents);

            for (int i = 0; i < storyPlot.PlotEvents.Count; i++)
            {
                Assert.AreEqual(storyPlot.PlotEvents[i], storyEvents[i]);
            }

        }
    }
}
