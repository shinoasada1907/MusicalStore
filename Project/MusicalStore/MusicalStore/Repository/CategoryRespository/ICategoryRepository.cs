using MusicalStore.Models;

namespace MusicalStore.Repository.CategoryRespository
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetCategorys();
    }
}
