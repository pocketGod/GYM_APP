using GYM_MODELS.DB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections;

namespace GYM_DB.Repositories.Base
{
    public class Repository<T> : IRepository<T>
    {
        private readonly IMongoCollection<T> _collection;

        public Repository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public T FindOne(FilterDefinition<T> filter)
        {
            return _collection.Find(filter).FirstOrDefault();
        }

        public List<T> FindAll(FilterDefinition<T> filter = null)
        {
            return filter == null ? _collection.Find(_ => true).ToList() : _collection.Find(filter).ToList();
        }

        public bool InsertOne(T document)
        {
            try
            {
                _collection.InsertOne(document);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            try
            {
                var updateResult = _collection.UpdateOne(filter, update);
                return updateResult.ModifiedCount > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteOne(FilterDefinition<T> filter)
        {
            try
            {
                var deleteResult = _collection.DeleteOne(filter);
                return deleteResult.DeletedCount > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool ReplaceOne(FilterDefinition<T> filter, T updatedDocument)
        {
            try
            {
                var replaceResult = _collection.ReplaceOne(filter, updatedDocument);
                return replaceResult.ModifiedCount > 0;
            }
            catch
            {
                return false;
            }
        }

    }
}
