public class InfoService
{
    private readonly IConfiguration _configuration;

    public InfoService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetMyInfo()
    {
        var personName = _configuration["Person:Name"];
        var personAge = _configuration["Person:Age"];
        var personCountry = _configuration["Person:Country"];
        return $"Person Name: {personName}, Age: {personAge}, Country {personCountry}";
    }
}
