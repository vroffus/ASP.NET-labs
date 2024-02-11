public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<CompanyService>();
        services.AddSingleton<InfoService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CompanyService companyService, InfoService infoService)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.Run(async (context) =>
        {
            var companyWithMostEmployees = companyService.GetCompanyWithMostEmployees();
            var myInfo = infoService.GetMyInfo();
            await context.Response.WriteAsync($"Company with most employees: {companyWithMostEmployees}\n" +
                $"My info {myInfo}");
        });
    }
}
