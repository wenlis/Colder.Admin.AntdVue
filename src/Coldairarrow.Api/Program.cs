﻿using Coldairarrow.Business.EBook;
using Coldairarrow.Util;
using Colder.Logging.Serilog;
using EFCore.Sharding;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Coldairarrow.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureLoggingDefaults()
                .UseIdHelper()
                .UseCache()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddFxServices();
                    services.AddAutoMapper();
                    services.AddEFCoreSharding(config =>
                    {
                        var dbOptions = hostContext.Configuration.GetSection("Database:BaseDb").Get<DatabaseOptions>();
                        config.UseDatabase(dbOptions.ConnectionString, dbOptions.DatabaseType);

                        var ebookDbOptions = hostContext.Configuration.GetSection("Database:EBookDb").Get<DatabaseOptions>();
                        config.UseDatabase<IEBookDbAccessor>(ebookDbOptions.ConnectionString, ebookDbOptions.DatabaseType);

                    });
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .Build()
                .Run();
        }
    }
}
