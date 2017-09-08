using StoryGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryGenerator.Persistance
{
    public class ServantRepository
    {
        public Servant GetServantById(int id)
        {

            var servant = new Servant();

            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                servant = session.Load<Servant>($"servants/{id}");
            }
            return servant;
        }

        public void SaveServant(Servant servant)
        {

            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                session.Store(servant);
                session.SaveChanges();
            }

        }
    }
}
