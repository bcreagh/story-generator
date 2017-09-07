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
            var documentStore = new DocumentStore
            {
                Url = "http://localhost:8080",
                DefaultDatabase = "GrailWarDb"
            };

            documentStore.Initialize();

            var mage = new Mage();

            using (var session = documentStore.OpenSession())
            {
                mage = session.Load<Mage>($"mages/{id}");
            }
            return mage;
        }

        public void SaveMage(Mage mage)
        {
            

            var documentStore = new DocumentStore
            {
                Url = "http://localhost:8080",
                DefaultDatabase = "GrailWarDb"
            };

            documentStore.Initialize();

            using (var session = documentStore.OpenSession())
            {
                session.Store(mage);
                session.SaveChanges();
            }

        }
    }
}
