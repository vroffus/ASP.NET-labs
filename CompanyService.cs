public class CompanyService
{
    private readonly IConfiguration _configuration;

    public CompanyService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetCompanyWithMostEmployees()
    {
        var companies = _configuration.GetSection("Companies").GetChildren();
        var companyWithMostEmployees = companies.OrderByDescending(c => int.Parse(c["Employees"])).First();
        return companyWithMostEmployees.Key;
    }
}
