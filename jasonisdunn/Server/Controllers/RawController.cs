using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dashboard.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace dashboard.Server.Controllers
{
    [ApiController]
    public class RawController : ControllerBase
    {


        [Route("[controller]/index/{language:int=1}")]
        [HttpGet]
        public Raw GetIndex(int? language)
        {
            var connectionstring = "Data Source = tcp:s23.winhost.com; User ID = DB_146837_jasonisdunn_user; Password = RJ2cc7a#z; Connect Timeout = 600; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"; ;
            var optionsBuilder = new DbContextOptionsBuilder<TestDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);
            Raw raw = new Raw();
            if (language == 0)
                language = 1;

            try
            {
                using (var context = new TestDbContext(optionsBuilder.Options))
                {
                 raw = context.Raw.Single(raw => raw._id == language);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return raw;

            //    _location = "-West-soutern_zone- & -West-northern_zone-",

         }
    }
}
