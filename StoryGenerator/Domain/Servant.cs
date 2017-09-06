using System;
using System.Collections.Generic;
using System.Linq;
using StoryGenerator.Domain.Enums;

namespace StoryGenerator.Domain
{
    public class Servant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ServantClass ServantClass { get; set; }
        public NoblePhantasm NoblePhantasm { get; set; }

        public int Strength { get; set; }
        public int Magic { get; set; }
        public int FightingAbility { get; set; }
        public int StrategicAbility { get; set; }
    }
}
