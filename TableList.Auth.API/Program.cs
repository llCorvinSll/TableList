﻿using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

namespace TableList.Auth.API
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
