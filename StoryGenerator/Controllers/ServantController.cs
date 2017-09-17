using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StoryGenerator.Domain;
using StoryGenerator.Domain.Validation;
using StoryGenerator.Domain.Validation.Candidates;
using StoryGenerator.Persistance;
using StoryGenerator.Persistance.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryGenerator.Controllers
{
    [Route("api/servants")]
    public class ServantController : Controller
    {
        private readonly IServantRepository ServantRepository;
        private readonly AbstractValidator<CreationCandidate<Servant>> ServantCreationValidator;

        public ServantController(
            IServantRepository servantRepository, 
            AbstractValidator<CreationCandidate<Servant>> servantCreationValidator)
        {
            ServantRepository = servantRepository;
            ServantCreationValidator = servantCreationValidator;
        }

        [HttpGet("{id}")]
        public dynamic GetServantById(int id)
        {
            var servant = ServantRepository.GetServantById(id);
            if(servant != null)
            {
                return servant;
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public dynamic SaveServant([FromBody] Servant servant)
        {

            var cc = new CreationCandidate<Servant>(servant);
            var validationResults = ServantCreationValidator.Validate(cc);

            if (validationResults.IsValid)
            {
                ServantRepository.SaveServant(servant);
                return "Servant has been created";
            }
            else
            {
                return validationResults.Errors;
            }
            
        }
    }
}
