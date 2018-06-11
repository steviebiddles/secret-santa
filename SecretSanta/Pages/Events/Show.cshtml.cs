using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SecretSanta.Models;

namespace SecretSanta.Pages.Events
{
	public class ShowModel : PageModel
	{
		private readonly SecretSanta.Data.SecretSantaContext db;

		public Event Event { get; set; }

		public ShowModel(SecretSanta.Data.SecretSantaContext context)
		{
			this.db = context;
		}

		[HttpGet("events/{id:int}", Name = "events_show")]
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null) {
				return NotFound();
			}

			Event = await db.Events.SingleOrDefaultAsync(m => m.Id == id);

			if (Event == null) {
				return NotFound();
			}

			return Page();
		}
	}
}
