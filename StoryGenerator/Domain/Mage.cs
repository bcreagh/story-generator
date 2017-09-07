
using StoryGenerator.Domain.Enums;

namespace StoryGenerator.Domain
{
    public class Mage
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Raven.Imports.Newtonsoft.Json.JsonIgnore]
        public ServantClass ServantClass { get; set; }
        [Raven.Imports.Newtonsoft.Json.JsonIgnore]
        public Servant Servant { get; set; }

        public int Strength { get; set; }
        public int Magic { get; set; }
        public int FightingAbility { get; set; }
        public int StrategicAbility { get; set; }

        public int Violence { get; set; }
        public int Arogance { get; set; }
        public int Selfishness { get; set; }

        public int Honour { get; set; }
        public int Kindness { get; set; }
        public int Mercifulness { get; set; }
    }
}
