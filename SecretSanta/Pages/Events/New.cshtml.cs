﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecretSanta.Models;

namespace SecretSanta.Pages.Events
{
    public class NewModel : PageModel
    {
        private readonly SecretSanta.Data.SecretSantaContext db;
        
        [BindProperty]
        public string Name { get; set; }
        
        public NewModel(SecretSanta.Data.SecretSantaContext context)
        {
            this.db = context;
        }
        
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var Event = new Event
            {
                Name = Request.Form["name"]
            };
            
            this.db.Events.Add(Event);
            await this.db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}