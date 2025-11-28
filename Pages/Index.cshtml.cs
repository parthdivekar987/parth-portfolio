using Microsoft.AspNetCore.Mvc.RazorPages;
using Parth_s_Portfolio.Models; // <--- IMPORANT: Import your new folder
using System.Collections.Generic;

namespace Parth_s_Portfolio.Pages
{
    public class IndexModel : PageModel
    {
        // Create a list to hold your projects
        public List<ProjectItem> MyProjects { get; set; } = new List<ProjectItem>();

        public void OnGet()
        {
            // Add data manually here
            MyProjects.Add(new ProjectItem
            {
                Id = 1,
                Title = "My First Website",
                Description = "This is a test project.",
                GitHubUrl = "https://github.com/test"
            });

            MyProjects.Add(new ProjectItem
            {
                Id = 2,
                Title = "Calculator App",
                Description = "A C# calculator.",
                GitHubUrl = "https://github.com/test2"
            });
        }
    }
}