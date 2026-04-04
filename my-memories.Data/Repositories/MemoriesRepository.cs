using memories.Data.Context;
using memories.Domain.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace memories.Data.Repositories
{
    public class MemoriesRepository : BaseRepository<memories.Domain.Models.Memory>, IMemoriesRepository
    {
        public MemoriesRepository(IMongoClient client, IOptions<MongoDbSettings> settings)
        : base(client, settings, settings.Value.CollectionName)
        {
        }
    }
}