using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

using webapi_signalr.Interfaces;
using webapi_signalr.Model;
using MongoDB.Bson;

namespace webapi_signalr.Data
{
  public class DBRepository : IDBRepository
  {
    private readonly DBContext _context = null;

    public DBRepository(IOptions<SettingsDB> settings)
    {
      _context = new DBContext(settings);
    }

    public async Task<IEnumerable<Game>> GetAllGames()
    {
      try
      {
        return await _context.Games.Find(_ => true).ToListAsync();
      }
      catch (Exception ex)
      {
        // log or manage the exception
        throw ex;
      }
    }

    public async Task<bool> RemoveAllGames()
    {
      try
      {
        DeleteResult actionResult = await _context.Games.DeleteManyAsync(new BsonDocument());

        return actionResult.IsAcknowledged
            && actionResult.DeletedCount > 0;
      }
      catch (Exception ex)
      {
        // log or manage the exception
        throw ex;
      }
    }

    // MongoDb automatically detects if the index already exists - in this case it just returns the index details
    public async Task<string> CreateIndex()
    {
      try
      {
        return await _context.Games.Indexes
                                   .CreateOneAsync(Builders<Game>
                                                        .IndexKeys
                                                        .Ascending(item => item.Gamecode));
      }
      catch (Exception ex)
      {
        // log or manage the exception
        throw ex;
      }
    }

    public async Task AddGame(Game item)
    {
      try
      {
        await _context.Games.InsertOneAsync(item);
      }
      catch (Exception ex)
      {
        // log or manage the exception
        throw ex;
      }
    }
  }
}