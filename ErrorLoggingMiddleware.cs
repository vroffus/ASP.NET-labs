using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

public class ErrorLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorLoggingMiddleware> _logger;

    public ErrorLoggingMiddleware(RequestDelegate next, ILogger<ErrorLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            LogToFile(ex);
            throw;
        }
    }

    private void LogToFile(Exception ex)
    {
        string logFilePath = "error_log.txt";
        string logMessage = $"[{DateTime.Now}] An error occurred: {ex.Message}";

        try
        {
            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to write to log file.");
        }
    }
}