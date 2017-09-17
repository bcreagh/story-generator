using StoryGenerator.Domain;

namespace StoryGenerator.Persistance.Abstractions
{
    public interface IServantRepository
    {
        Servant GetServantById(int id);
        void SaveServant(Servant servant);
    }
}
