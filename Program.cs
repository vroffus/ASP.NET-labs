public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("companyinfo.json", optional: true, reloadOnChange: true);
                config.AddXmlFile("companyinfo.xml", optional: true, reloadOnChange: true);
                config.AddIniFile("companyinfo.ini", optional: true, reloadOnChange: true);
                config.AddJsonFile("myinfo.json", optional: true, reloadOnChange: true);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
