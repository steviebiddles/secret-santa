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
	public class IndexModel : PageModel
	{
		private readonly SecretSanta.Data.SecretSantaContext db;

		public IList<Event> Events { get; set; }

		public IndexModel(SecretSanta.Data.SecretSantaContext context)
		{
			this.db = context;
		}

		public async Task OnGetAsync()
		{
			Events = await db.Events.ToListAsync();
		}
	}
}
