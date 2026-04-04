using memories.Data.Context;
using memories.Domain.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace memories.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {

        protected readonly IMongoCollection<T> _collection;

        public BaseRepository(IMongoClient client, IOptions<MongoDbSettings> settings, string collectionName)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<T> GetByIdAsync(string id) =>
            await _collection.Find(FilterId(id)).FirstOrDefaultAsync();

        public async Task CreateAsync(T entity) =>
            await _collection.InsertOneAsync(entity);

        public async Task UpdateAsync(string id, T entity) =>
            await _collection.ReplaceOneAsync(FilterId(id), entity);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(FilterId(id));

        private FilterDefinition<T> FilterId(string id) =>
            Builders<T>.Filter.Eq("Id", id);

    }
}