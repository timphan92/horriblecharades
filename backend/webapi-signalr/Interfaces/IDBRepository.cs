using System.Collections.Generic;
using System.Threading.Tasks;
using webapi_signalr.Model;

namespace webapi_signalr.Interfaces
{
  public interface IDBRepository
  {
    Task<IEnumerable<Game>> GetAllGames();
    Task<bool> RemoveAllGames(); //caution used for dev setup
    Task<string> CreateIndex(); // create a sample index 
    Task AddGame(Game item);   // add new game document
  }
}