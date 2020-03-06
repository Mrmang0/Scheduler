using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace Scheduler.ReadModel.Models
{
    public class ReadDbModel
    {
        protected ReadDbModel() { }
        protected ReadDbModel(Guid id)
        {
            this.Id = id;
        }

        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        public Guid Id { get; set; }
        [BsonElement]
        public DateTime Created { get; set; }
        [BsonElement]
        public DateTime Updated { get; set; }

        #region Equality
        public bool Equals(ReadDbModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return other.Id.Equals(Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(ReadDbModel)) return false;

            return Equals((ReadDbModel)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Id.GetHashCode();
                result = (result * 123) ^ (Created != DateTime.MinValue ? Created.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(ReadDbModel left, ReadDbModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ReadDbModel left, ReadDbModel right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}
