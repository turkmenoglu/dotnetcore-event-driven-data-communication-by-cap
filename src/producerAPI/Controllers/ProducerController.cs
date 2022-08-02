using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using producerAPI.Models;

namespace producerAPI.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class ProducerController : ControllerBase
   {
      private readonly ICapPublisher _capPublisher;
      public ProducerController(ICapPublisher capPublisher)
      {
         _capPublisher = capPublisher;
      }
      public async Task<IActionResult> ProducerTransaction()
      {
         using ExampleContext context = new ExampleContext();
         using var transaction = context.Database.BeginTransaction(_capPublisher, autoCommit: true);
         var date = DateTime.Now;
         await _capPublisher.PublishAsync<DateTime>("producer.transaction", date);
         return Ok(date);
      }
   }
}
