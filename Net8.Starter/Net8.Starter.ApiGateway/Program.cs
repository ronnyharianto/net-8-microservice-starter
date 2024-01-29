using Ocelot.DependencyInjection;
using Ocelot.Middleware;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers();

		builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
		builder.Services.AddOcelot(builder.Configuration);

		builder.WebHost.UseUrls("http://*:5000");

		var app = builder.Build();

		#region MapControllers()
		//Use this code if there is any endpoint in the service which running gateway using ocelot that need to access by the client
		//app.UseRouting().UseEndpoints(ep =>
		//{
		//	ep.MapControllers();
		//});

		//Use this code if there is none endpoint in the service which running gateway using ocelot that need to access by the client
		app.MapControllers();
		#endregion

		app.UseOcelot().Wait();

		app.Run();
	}
}