using NUnit.Framework;
using StoryGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.DomainTests
{
    [TestFixture]
    class GrailWarTests
    {
        private GrailWar gw { get; set; }

        [SetUp]
        protected void SetUp()
        {
            gw = new GrailWar();
        }

        [Test]
        public void BreakAlliance_ShouldReturnNull_WhenNoAlliancesExist()
        {
            Assert.IsNull(gw.BreakAlliance(new Alliance(new Mage(), new Mage())));
        }

        [Test]
        public void BreakAlliance_ShouldReduceNumberOfAlliancesByOne_WhenAlliancesExist()
        {
            var mage1 = new Mage { Id = 1 };
            var mage2 = new Mage { Id = 2 };
            var mage3 = new Mage { Id = 3 };
            var mage4 = new Mage { Id = 4 };

            var alliance1 = new Alliance(mage1, mage2);
            var alliance2 = new Alliance(mage3, mage4);
            gw.Alliances.Add(alliance1);
            gw.Alliances.Add(alliance2);

            var initialCount = gw.Alliances.Count;

            gw.BreakAlliance(alliance2);

            var finalCount = gw.Alliances.Count;

            Assert.IsTrue(finalCount == (initialCount - 1), "The number of alliances was not reduced by one!");
        }

        [Test]
        public void BreakAlliance_ShouldIncreaseNumberOfMagesWithNoAlliancesByTwo_WhenAllianceExists()
        {
            var mage1 = new Mage { Id = 1 };
            var mage2 = new Mage { Id = 2 };
            var mage3 = new Mage { Id = 3 };
            var mage4 = new Mage { Id = 4 };

            var alliance1 = new Alliance(mage1, mage2);
            var alliance2 = new Alliance(mage3, mage4);
            gw.Alliances.Add(alliance1);
            gw.Alliances.Add(alliance2);

            var mage5 = new Mage { Id = 5 };
            var mage6 = new Mage { Id = 6 };
            gw.MagesWithNoAlliances.Add(mage5);
            gw.MagesWithNoAlliances.Add(mage6);



            var initialCount = gw.MagesWithNoAlliances.Count;

            gw.BreakAlliance(alliance2);

            var finalCount = gw.MagesWithNoAlliances.Count;

            Assert.IsTrue(finalCount == (initialCount + 2), "The mages who broke their alliance must be added to the MagesWithNoAlliances list!");
        }



    }
}
