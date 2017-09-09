using FluentValidation;
using System;
using System.Linq.Expressions;

namespace StoryGenerator.Domain.Validation
{
    public class MageCreationValidator: AbstractValidator<Mage>
    {
        public MageCreationValidator()
        {
            RuleFor(mage => mage.Strength).InclusiveBetween(0, 100);
            RuleFor(mage => mage.Magic).InclusiveBetween(0, 100);
            RuleFor(mage => mage.FightingAbility).InclusiveBetween(0, 100);
            RuleFor(mage => mage.StrategicAbility).InclusiveBetween(0, 100);
            RuleFor(mage => mage.Violence).InclusiveBetween(0, 100);
            RuleFor(mage => mage.Arogance).InclusiveBetween(0, 100);
            RuleFor(mage => mage.Selfishness).InclusiveBetween(0, 100);
            RuleFor(mage => mage.Honour).InclusiveBetween(0, 100);
            RuleFor(mage => mage.Kindness).InclusiveBetween(0, 100);
            RuleFor(mage => mage.Mercifulness).InclusiveBetween(0, 100);
            RuleFor(mage => mage.Name.Length).LessThan(100);
        }
    }
}
