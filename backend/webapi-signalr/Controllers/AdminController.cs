using System;
using Microsoft.AspNetCore.Mvc;

using webapi_signalr.Interfaces;
using webapi_signalr.Model;


namespace webapi_signalr.Controllers
{
  [Route("api/[controller]")]
  public class AdminController : Controller
  {
    private readonly IDBRepository _DBRepository;

    public AdminController(IDBRepository DBRepository)
    {
      _DBRepository = DBRepository;
    }

    // Call an initialization - run api/admin/init
    [HttpGet("{setting}")]
    public string Get(string setting)
    {
      if (setting == "init")
      {
        _DBRepository.RemoveAllGames();
        var name = _DBRepository.CreateIndex();

        _DBRepository.AddGame(new Game() { Id = "1", Gamecode = "G1" });
        _DBRepository.AddGame(new Game() { Id = "2", Gamecode = "G2" });

        return "Database horribleCharadesDB was created, and collection 'Game' was filled with 2 sample items";
      }

      return "Unknown";
    }
  }
}