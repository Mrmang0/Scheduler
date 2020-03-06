using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Scheduler.Infrastructure.Settings;
using Scheduler.ReadModel;
using Scheduler.ReadModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Scheduler.Infrastructure
{
    public class MongoDBRepository<TModel> : IRepository<TModel> where TModel : ReadDbModel
    {
        protected MongoClient _mongo;
        protected string _databaseName;
        protected string _collectionName;

        protected IMongoDatabase Database => _mongo.GetDatabase(_databaseName);

        public IMongoCollection<TModel> Collection => Database.GetCollection<TModel>(_collectionName);

        public MongoDBRepository(string connectionString)
        {
            _mongo = new MongoClient(connectionString);
            _databaseName = MongoUrl.Create(connectionString).DatabaseName;
            _collectionName = typeof(TModel).Name;
            if (!BsonClassMap.IsClassMapRegistered(typeof(TModel)))
            {
                BsonClassMap.RegisterClassMap<TModel>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIgnoreExtraElements(true);
                });
            }
        }

        public MongoDBRepository(IOptions<MongoDBSettings> settings)
        {
            _mongo = new MongoClient(settings.Value.ConnectionString);
            _databaseName = MongoUrl.Create(settings.Value.ConnectionString).DatabaseName;
            _collectionName = typeof(TModel).Name;
            if (!BsonClassMap.IsClassMapRegistered(typeof(TModel)))
            {
                BsonClassMap.RegisterClassMap<TModel>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIgnoreExtraElements(true);
                });
            }
        }

        IAggregateFluent<TModel> IRepository<TModel>.Aggregate(params BsonDocument[] operations)
        {
            return this.Collection.Aggregate();
        }

        public long Count(Expression<Func<TModel, bool>> predicate)
        {
            var cursor = predicate == null ? Collection.Find<TModel>(Builders<TModel>.Filter.Empty) : Collection.Find(predicate);
            return cursor.CountDocuments();
        }

        long IRepository<TModel>.CountAll()
        {
            return Count(null); ;
        }

        IEnumerable<TModel> IRepository<TModel>.Find(IQueryable<TModel> query)
        {
            return query.AsEnumerable();
        }

        IEnumerable<TModel> IRepository<TModel>.Find(IQueryable<TModel> query, int skip, int take)
        {
            return query.Skip(skip).Take(take).AsEnumerable();
        }

        public IEnumerable<TModel> Find(Expression<Func<TModel, bool>> predicate)
        {
            return this.Collection.Find(predicate).ToEnumerable();
        }

        IEnumerable<TModel> IRepository<TModel>.FindAll()
        {
            return Find(x => true);
        }

        private IEnumerable<TModel> FindAll(FilterDefinition<TModel> filter, QueryOptions<TModel> options)
        {
            ProjectionDefinition<TModel> projection = null;
            foreach (var field in options.Fields)
            {
                if (projection == null)
                    projection = new ProjectionDefinitionBuilder<TModel>().Include(field);
                else
                    projection = projection.Include(field);
            }

            SortDefinition<TModel> sortDefinition = null;
            var builder = new SortDefinitionBuilder<TModel>();
            if (options.SortAscending != null)
            {
                sortDefinition = builder.Ascending(options.SortAscending);
            }
            if (options.SortDescending != null)
                sortDefinition = builder.Descending(options.SortDescending);

            IFindFluent<TModel, TModel> result = null;
            if (projection == null)
            {
                result = Collection.Find(filter);
            }
            else
            {
                result = Collection.Find(filter).Project<TModel>(projection);            }

            if (options.Skip.HasValue)
                result.Skip(options.Skip.Value);
            if (options.Take.HasValue)
                result.Limit(options.Take);

            if (sortDefinition != null)
                result.Sort(sortDefinition);

            return result.ToEnumerable();
        }

        void IRepository<TModel>.FindAndModify(Expression<Func<TModel, bool>> query, UpdateDefinition<TModel> update)
        {
            FilterDefinition<TModel> filter = new FilterDefinitionBuilder<TModel>().Where(query);

            Collection.UpdateMany(filter, update);
        }


        IQueryable<TModel> IRepository<TModel>.GetAsQueryable()
        {
            return Collection.AsQueryable();
        }

        TModel IRepository<TModel>.GetById(Guid id)
        {
            var builder = Builders<TModel>.Filter;
            var filter = builder.Eq(x => x.Id, id);

            return Collection.FindSync(filter).SingleOrDefault();
        }

        async Task<TModel> IRepository<TModel>.GetByIdAsync(Guid id)
        {
            var builder = Builders<TModel>.Filter;
            var filter = builder.Eq(x => x.Id, id);

            var model = await Collection.FindAsync(filter);
            return model.SingleOrDefault();
        }

        TModel IRepository<TModel>.New()
        {
            TModel instance = Activator.CreateInstance<TModel>();
            instance.Created = DateTime.UtcNow;

            return instance;
        }

        void IRepository<TModel>.Remove(TModel spec)
        {
            if (spec == null)
                return;
            var builder = Builders<TModel>.Filter;
            var filter = builder.Eq(x => x.Id, spec.Id);

            Collection.DeleteOne(filter);
        }

        void IRepository<TModel>.RemoveAll()
        {
            var filter = new BsonDocument();
            this.Collection.DeleteMany(filter);
        }

        void IRepository<TModel>.RemoveAll(Expression<Func<TModel, bool>> predicate)
        {
            Collection.DeleteMany(predicate);
        }

        void IRepository<TModel>.Save(TModel model)
        {
            if (model.Id == Guid.Empty)
            {
                model.Id = Guid.NewGuid();
                model.Created = DateTime.UtcNow;
            }

            model.Updated = DateTime.UtcNow;
            var filter = Builders<TModel>.Filter.Eq(x => x.Id, model.Id);
            Collection.ReplaceOne(filter, model, new ReplaceOptions { IsUpsert = true });
        }
    }
}
