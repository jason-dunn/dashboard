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
    public class MinerController : ControllerBase
    {
        [Route("[controller]/index")]
        [HttpGet]
        public IEnumerable<Miner> GetIndex()
        {
            return Enumerable.Range(1, 10).Select(index => new Miner
            {
                _worker = 0,
                _rank = 0,
                _name = "",
                _total = 0,
                _payload = 0
               
            }).ToArray();

        }

        [Route("[controller]")]
        [HttpGet]
        public IEnumerable<Miner> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new Miner
            {     
                _worker = (index),
                _name = $"jid_00{rng.Next(1, 99999).ToString("D5")}",
                _total = 678943,
                _payload = 1,
                _rank = 33
        }).ToArray();
        }
    }
}

