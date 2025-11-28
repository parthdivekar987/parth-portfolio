namespace Parth_s_Portfolio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Production settings
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // This line serves all files from wwwroot (css, images, pdf, etc.)
            app.UseStaticFiles();

            app.UseRouting();

            // This makes Razor Pages + Static Assets work perfectly on Vercel
            app.MapRazorPages()
               .WithStaticAssets();

            app.MapStaticAssets();

            app.Run();
        }
    }
}