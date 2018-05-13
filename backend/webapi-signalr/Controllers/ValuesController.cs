using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi_signalr.Interfaces;
using webapi_signalr.Model;

namespace webapi_signalr.Controllers
{
  [Produces("application/json")]
  [Route("api/[controller]")]
  public class ValuesController : Controller
  {
    private readonly IDBRepository _DBRepository;

    public ValuesController(IDBRepository DBRepository)
    {
      _DBRepository = DBRepository;
    }

    // GET api/values
    [HttpGet]
    public async Task<IEnumerable<Game>> Get()
    {
      return await _DBRepository.GetAllGames();
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "Tim";
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
