using Microsoft.Extensions.Options;
using MongoDB.Driver;
using webapi_signalr.Model;


namespace webapi_signalr.Data
{
  public class DBContext
  {
    private readonly IMongoDatabase _database = null;

    public DBContext(IOptions<SettingsDB> settings)
    {
      var client = new MongoClient(settings.Value.ConnectionString);
      if (client != null)
        _database = client.GetDatabase(settings.Value.Database);
    }

    public IMongoCollection<Game> Games
    {
      get
      {
        return _database.GetCollection<Game>("Game");
      }
    }
  }
}