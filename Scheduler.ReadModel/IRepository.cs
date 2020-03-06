using MongoDB.Bson;
using MongoDB.Driver;
using Scheduler.ReadModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Scheduler.ReadModel
{
    public interface IRepository<TModel> where TModel : ReadDbModel
    {
        TModel New();
        TModel GetById(Guid id);
        Task<TModel> GetByIdAsync(Guid id);
        IQueryable<TModel> GetAsQueryable();
        void Save(TModel model);
        void Remove(TModel spec);
        void RemoveAll();
        void RemoveAll(Expression<Func<TModel, bool>> predicate);
        IEnumerable<TModel> Find(IQueryable<TModel> query);
        IEnumerable<TModel> Find(IQueryable<TModel> query, int skip, int take);
        IEnumerable<TModel> FindAll();
        IAggregateFluent<TModel> Aggregate(params BsonDocument[] operations);
        IEnumerable<TModel> Find(Expression<Func<TModel, bool>> predicate);
        void FindAndModify(Expression<Func<TModel, bool>> query, UpdateDefinition<TModel> update);
        long Count(Expression<Func<TModel, bool>> predicate);
        long CountAll();
    }
}
