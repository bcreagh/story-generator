using StoryGenerator.Domain;

namespace StoryGenerator.Persistance.Abstractions
{
    public interface IMageRepository
    {
        Mage GetMageById(int id);
        void SaveMage(Mage mage);
    }
}
