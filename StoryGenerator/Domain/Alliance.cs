using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryGenerator.Domain
{
    public class Alliance
    {
        public Mage Mage1 { get; set; }
        public Mage Mage2 { get; set; }

        public Alliance(Mage mage1, Mage mage2)
        {
            Mage1 = mage1;
            Mage2 = mage2;
        }

        public override bool Equals(object obj)
        {
            var testAlliance = obj as Alliance;

            return ((Mage1.Id == testAlliance.Mage1.Id) && (Mage2.Id == testAlliance.Mage2.Id)) ||
                ((Mage1.Id == testAlliance.Mage2.Id) && (Mage2.Id == testAlliance.Mage1.Id));
        }

        public override int GetHashCode()
        {
            return Mage1.Id + Mage2.Id;
        }
    }
}
