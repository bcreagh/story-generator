using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StoryGenerator.Domain;
using StoryGenerator.Persistance;
using StoryGenerator.Domain.Validation;
using StoryGenerator.Persistance.Abstractions;

namespace StoryGenerator.Controllers
{
    [Route("api/mages")]
    public class MageController : Controller
    {
        private IMageRepository MageRepository;

        public MageController(IMageRepository mageRepository)
        {
            MageRepository = mageRepository;
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

            MageCreationValidator mcv = new MageCreationValidator();
            var validationResults = mcv.Validate(mage);

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
