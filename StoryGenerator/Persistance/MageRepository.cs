using StoryGenerator.Domain;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryGenerator.Persistance
{
    public class MageRepository
    {
        public Mage GetMageById(int id)
        {

            var mage = new Mage();

            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                mage = session.Load<Mage>($"mages/{id}");
            }
            return mage;
        }

        public void SaveMage(Mage mage)
        {

            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                session.Store(mage);
                session.SaveChanges();
            }

        }
    }
}
