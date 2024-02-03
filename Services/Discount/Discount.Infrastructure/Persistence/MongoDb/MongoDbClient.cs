using System.Collections.Concurrent;
using Discount.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Discount.Infrastructure.Persistence.MongoDb;

internal class MongoDbClient : IDatabaseClient
{

    #region Global Fields

    ConcurrentDictionary<string, MongoClient> mongoClients = new ConcurrentDictionary<string, MongoClient>();
    private readonly IConfiguration _configuration;

    #endregion


    #region constroctor

    public MongoDbClient(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    #endregion


    #region Implemented methods

    public async Task<TEntity> GetItemByIdAsync<TEntity>(string id)
    {
        var collection = GetDbCollection<TEntity>();
        var filter = Builders<TEntity>.Filter.Eq("_id", id);
        var item = await collection.FindAsync(filter);
        return item.FirstOrDefault();
    }

    public async Task<TEntity> CreateAsync<TEntity>(TEntity entity)
    {
        var collection = GetDbCollection<TEntity>();
        await collection.InsertOneAsync(entity);
        return entity;
    }

    #endregion


    #region Private method

    private IMongoCollection<TEntity> GetDbCollection<TEntity>()
    {
        var db = GetDatabase();
        var collection = db.GetCollection<TEntity>(typeof(TEntity).Name);
        return collection;
    }

    private IMongoDatabase GetDatabase()
    {
        var client = GetMongoClient();
        var db = client.GetDatabase(_configuration["DatabaseSettings:Name"]);
        return db;
    }

    private MongoClient GetMongoClient()
    {
        if (mongoClients.TryGetValue("MongoDbClient", out var client))
        {
            return client;
        }

        var connectionString = _configuration["DatabaseSettings:connectionString"];
        var mongoClient = new MongoClient(connectionString);
        mongoClients.TryAdd("MongoDbClient", mongoClient);
        return mongoClient;
    }

    #endregion
}
