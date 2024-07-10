using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace BookStore.BL.Background
{
    public class MyHostedService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {  
            return Task.CompletedTask; 
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
