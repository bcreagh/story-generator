using FluentValidation;
using StoryGenerator.Domain.Validation.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryGenerator.Domain.Validation
{
    public class ServantCreationValidator: AbstractValidator<CreationCandidate<Servant>>
    {
        public ServantCreationValidator()
        {
            RuleFor(cc => cc.Candidate.Strength).InclusiveBetween(0, 100);
            RuleFor(cc => cc.Candidate.Magic).InclusiveBetween(0, 100);
            RuleFor(cc => cc.Candidate.FightingAbility).InclusiveBetween(0, 100);
            RuleFor(cc => cc.Candidate.StrategicAbility).InclusiveBetween(0, 100);
            RuleFor(cc => cc.Candidate.Name.Length).InclusiveBetween(1, 100);
            RuleFor(cc => cc.Candidate.ServantClass).NotEqual(Enums.ServantClass.Unknown);
            RuleFor(cc => cc.Candidate.NoblePhantasm).NotNull();
            RuleFor(cc => cc.Candidate.NoblePhantasm.Power).InclusiveBetween(0, 100);
            RuleFor(cc => cc.Candidate.NoblePhantasm.Name.Length).InclusiveBetween(1, 100);
        }
    }
}
