using myHouse.ReadModel.Models;

namespace myHouse.ReadModel
{
    public interface IReadModelRepositoryResolver
    {
        IRepository<TModel> GetRepositoryFor<TModel>() where TModel : ReadDbModel;
    }
}
