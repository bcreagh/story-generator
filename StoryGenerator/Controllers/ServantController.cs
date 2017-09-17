using Microsoft.AspNetCore.Mvc;
using StoryGenerator.Domain;
using StoryGenerator.Domain.Validation;
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
        private IServantRepository ServantRepository;

        public ServantController(IServantRepository servantRepository)
        {
            ServantRepository = servantRepository;
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
            ServantCreationValidator scv = new ServantCreationValidator();
            var validationResults = scv.Validate(servant);

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
