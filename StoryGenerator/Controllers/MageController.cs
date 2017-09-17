using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StoryGenerator.Domain;
using StoryGenerator.Persistance;
using StoryGenerator.Domain.Validation;
using StoryGenerator.Persistance.Abstractions;
using StoryGenerator.Domain.Validation.Candidates;
using FluentValidation;

namespace StoryGenerator.Controllers
{
    [Route("api/mages")]
    public class MageController : Controller
    {
        private readonly IMageRepository MageRepository;
        private readonly AbstractValidator<CreationCandidate<Mage>> MageCreationValidator;

        public MageController(
            IMageRepository mageRepository, 
            AbstractValidator<CreationCandidate<Mage>> mageCreationValidator)
        {
            MageRepository = mageRepository;
            MageCreationValidator = mageCreationValidator;
        }

        [HttpGet("{id}")]
        public dynamic GetMage(int id)
        {
            var mage = MageRepository.GetMageById(id);
            if (mage != null)
            {
                return mage;
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public dynamic SaveMage([FromBody] Mage mage)
        {

            var cc = new CreationCandidate<Mage>(mage);
            var validationResults = MageCreationValidator.Validate(cc);

            if (validationResults.IsValid)
            {
                MageRepository.SaveMage(mage);
                return "Mage has been created";
            }
            else
            {
                return validationResults.Errors;
            }
        }
    }
}
