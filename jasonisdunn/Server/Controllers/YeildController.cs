using dashboard.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace dashboard.Server.Controllers
{
    [ApiController]
    public class YeildController : ControllerBase
    {
        [Route("[controller]/index")]
        [HttpGet]
        public IEnumerable<Yeild> GetIndex()
        {
            return Enumerable.Range(1, 10).Select(index => new Yeild
            {
                _worker = 0,
                _value = "",
                _datetime = ""
            }).ToArray();

        }

        //[Route("[controller]")]
        //[HttpGet]
        //public IEnumerable<Miner> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 10).Select(index => new Miner
        //    {
        //        _worker = (index),
        //        _name = $"jid_00{rng.Next(1, 99999).ToString("D5")}",
        //        _total = 678943,
        //        _payload = 1,
        //        _rank = 33
        //    }).ToArray();
        //}
    }
}

