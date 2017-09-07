using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StoryGenerator.Domain;
using StoryGenerator.Persistance;

namespace StoryGenerator.Controllers
{
    [Route("api/mages")]
    public class MageController : Controller
    {
        private MageRepository MageRepository;

        public MageController()
        {
            MageRepository = new MageRepository();
        }

        [HttpGet("{id}")]
        public Mage GetMage(int id)
        {
            var mage = MageRepository.GetMageById(id);
            return mage;
        }

        [HttpPost]
        public dynamic SaveMage([FromBody] Mage mage)
        {
            MageRepository.SaveMage(mage);

            return "Mage Created";
        }
    }
}
