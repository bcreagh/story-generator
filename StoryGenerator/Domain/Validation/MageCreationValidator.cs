using FluentValidation;
using StoryGenerator.Domain.Validation.Candidates;
using System;
using System.Linq.Expressions;

namespace StoryGenerator.Domain.Validation
{
    public class MageCreationValidator: AbstractValidator<CreationCandidate<Mage>>
    {
        public MageCreationValidator()
        {
            RuleFor(cc => cc.Candidate.Strength).InclusiveBetween(0, 100);
            RuleFor(cc => cc.Candidate.Magic).InclusiveBetween(0, 100);
            RuleFor(cc => cc.Candidate.FightingAbility).InclusiveBetween(0, 100);
            RuleFor(cc => cc.Candidate.StrategicAbility).InclusiveBetween(0, 100);
            RuleFor(cc => cc.Candidate.Violence).InclusiveBetween(0, 100);
            RuleFor(cc => cc.Candidate.Arogance).InclusiveBetween(0, 100);
            RuleFor(cc => cc.Candidate.Selfishness).InclusiveBetween(0, 100);
            RuleFor(cc => cc.Candidate.Honour).InclusiveBetween(0, 100);
            RuleFor(cc => cc.Candidate.Kindness).InclusiveBetween(0, 100);
            RuleFor(cc => cc.Candidate.Mercifulness).InclusiveBetween(0, 100);
            RuleFor(cc => cc.Candidate.Name.Length).InclusiveBetween(1, 100);
        }
    }
}
