using MongoDB.Bson;
using MongoDB.Driver;
using myHouse.ReadModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace myHouse.ReadModel
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
        TModel FindOne(IQueryable<TModel> query);
        IEnumerable<TModel> Find(IQueryable<TModel> query, int skip, int take);
        IEnumerable<TModel> FindAll();
        IAggregateFluent<TModel> Aggregate(params BsonDocument[] operations);
        int GetTotal(IQueryable<TModel> query);
        IEnumerable<TModel> Find(Expression<Func<TModel, bool>> predicate);
        IEnumerable<TModel> FindGeoIntersects(Expression<Func<TModel, object>> locationField, double lng, double lat);
        IEnumerable<TModel> FindWithinBox(FieldDefinition<TModel> field, double topLeftX, double topLeftY, double bottomRightX, double bottomRightY, Expression<Func<TModel, bool>> predicate);
        IEnumerable<TModel> FindNear(string name, double longitude, double latitude, double maxDistanceMeters, Expression<Func<TModel, bool>> predicate, int? limit);
        IEnumerable<TModel> FindNearGeoJSONObject(string name, double longitude, double latitude, double maxDistanceMeters, Expression<Func<TModel, bool>> predicate, int? limit = null);
        void FindAndModify(Expression<Func<TModel, bool>> query, UpdateDefinition<TModel> update);
        //TModel FindOne(TModel spec);
        long Count(Expression<Func<TModel, bool>> predicate);
        long CountAll();
    }
}
