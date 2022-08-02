using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace consumerAPI.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class ConsumerController : ControllerBase
   {
      [CapSubscribe("producer.transaction", Group = "group1")]
      public void Consumer(DateTime date)
      {
         Console.WriteLine(date);
      }
   }
}
