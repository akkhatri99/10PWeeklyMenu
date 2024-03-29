﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PortfolioServer.Models
{
    /// <summary>
    /// Abstract Entity for all the MongoEntities.
    /// </summary>
    [BsonIgnoreExtraElements(Inherited = true)]
    public abstract class MongoEntity<TKey> : IMongoEntity<TKey>
    {
        /// <summary>
        /// Gets or sets the id for this object (the primary record for an entity).
        /// </summary>
        /// <value>The id for this object (the primary record for an entity).</value>
        [BsonRepresentation(BsonType.ObjectId)]
        public TKey Id { get; set; }
    }

    /// <summary>
    /// Default Abstract Entity for all the MongoEntities.
    /// </summary>
    [BsonIgnoreExtraElements(Inherited = true)]
    public abstract class MongoEntity : IMongoEntity<ObjectId>
    {
        /// <summary>
        /// Gets or sets the id for this object (the primary record for an entity).
        /// </summary>
        /// <value>The id for this object (the primary record for an entity).</value>
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
    }
}
