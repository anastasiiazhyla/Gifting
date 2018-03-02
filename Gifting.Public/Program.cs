using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NLog;
using NLog.Web;

namespace Gifting.Public
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Logger logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
			try
			{
				logger.Debug("init main"); BuildWebHost(args).Run();
			}
			catch (Exception e)
			{
				//NLog: catch setup errors
				logger.Fatal(e, "Stopped program because of exception");
				throw;
			}
		}

		public static IWebHost BuildWebHost(string[] args)
		{
			return WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.UseNLog()
				.Build();
		}
	}
}
