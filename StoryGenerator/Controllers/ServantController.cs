using Microsoft.AspNetCore.Mvc;
using StoryGenerator.Domain;
using StoryGenerator.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryGenerator.Controllers
{
    [Route("api/servants")]
    public class ServantController : Controller
    {
        private ServantRepository ServantRepository;

        public ServantController()
        {
            ServantRepository = new ServantRepository();
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
            ServantRepository.SaveServant(servant);
            return "Servant has been created";
        }
    }
}
