using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Parth_s_Portfolio.Pages
{
    public class ContactModel : PageModel
    {
        // 1. We create a property to hold the form data
        [BindProperty]
        public ContactInputModel Contact { get; set; } = new ContactInputModel();

        // 2. A message to show the user after they submit
        public string SuccessMessage { get; set; } = string.Empty;

        public void OnGet()
        {
            // Page load logic (empty)
        }

        public IActionResult OnPost()
        {
            // 3. Check if the form is valid (e.g., email is actual email format)
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // 4. Mimic sending an email (In a real app, you would add SMTP code here)
            SuccessMessage = $"Thank you, {Contact.Name}! I have received your message.";

            // Clear the form so they can send another if they want
            ModelState.Clear();
            Contact = new ContactInputModel();

            return Page();
        }

        // 5. This class defines what fields the form has
        public class ContactInputModel
        {
            [Required(ErrorMessage = "Please enter your name")]
            public string Name { get; set; } = string.Empty;

            [Required(ErrorMessage = "Please enter an email address")]
            [EmailAddress(ErrorMessage = "Invalid email format")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "Please enter a message")]
            [MinLength(10, ErrorMessage = "Message must be at least 10 characters")]
            public string Message { get; set; } = string.Empty;
        }
    }
}