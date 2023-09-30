using MongoDB.Driver;

namespace GYM_DB.Repositories.Base
{
    public interface IRepository<T>
    {
        T FindOne(FilterDefinition<T> filter);
        List<T> FindAll(FilterDefinition<T> filter = null);
        bool InsertOne(T document);
        bool UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update);
        bool DeleteOne(FilterDefinition<T> filter);
        bool ReplaceOne(FilterDefinition<T> filter, T updatedDocument);

    }
}
