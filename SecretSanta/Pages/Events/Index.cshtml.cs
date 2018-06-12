using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SecretSanta.Data;
using SecretSanta.Models;

namespace SecretSanta.Pages.Events
{
	public class IndexModel : PageModel
	{
		private readonly SecretSantaContext db;

		public IList<Event> Events { get; set; }

		public IndexModel(SecretSantaContext context)
		{
			this.db = context;
		}

		public async Task<IActionResult> OnGetAsync()
		{
			Events = await this.db.Events.ToListAsync();

			return Page();
		}
	}
}
