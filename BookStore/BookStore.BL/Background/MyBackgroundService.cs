using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.Configurations;
using BookStore.Models.Models.Users;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStore.BL.Background
{
   
    public class MyBackgroundService : BackgroundService
    {
        private readonly IOptions<AppSettings> _appsettings;


        public MyBackgroundService(IOptions<AppSettings> appsettings)
        {
            _appsettings = appsettings;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine($"{nameof(MyBackgroundService)}-{DateTime.Now}");
                await Task.Delay(_appsettings.Value.DelayInterval);
             
            }
        }
    }
}
