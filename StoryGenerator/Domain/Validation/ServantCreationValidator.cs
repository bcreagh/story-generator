using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryGenerator.Domain.Validation
{
    public class ServantCreationValidator: AbstractValidator<Servant>
    {
        public ServantCreationValidator()
        {
            RuleFor(servant => servant.Strength).InclusiveBetween(0, 100);
            RuleFor(servant => servant.Magic).InclusiveBetween(0, 100);
            RuleFor(servant => servant.FightingAbility).InclusiveBetween(0, 100);
            RuleFor(servant => servant.StrategicAbility).InclusiveBetween(0, 100);
            RuleFor(servant => servant.Name.Length).InclusiveBetween(1, 100);
            RuleFor(servant => servant.ServantClass).NotEqual(Enums.ServantClass.Unknown);
            RuleFor(servant => servant.NoblePhantasm).NotNull();
            RuleFor(servant => servant.NoblePhantasm.Power).InclusiveBetween(0, 100);
            RuleFor(servant => servant.NoblePhantasm.Name.Length).InclusiveBetween(1, 100);
        }
    }
}
