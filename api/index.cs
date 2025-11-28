using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Redirect("/Index"));

app.MapFallback(async context =>
{
    var filePath = Path.Combine(builder.Environment.WebRootPath, context.Request.Path.Value!.TrimStart('/') + ".html");
    if (File.Exists(filePath))
    {
        context.Response.ContentType = "text/html";
        await context.Response.SendFileAsync(filePath);
        return;
    }

    // Fallback to index.html for SPA routing
    await context.Response.SendFileAsync(Path.Combine(builder.Environment.WebRootPath, "index.html"));
});

app.Run();