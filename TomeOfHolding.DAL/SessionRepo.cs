﻿using Microsoft.EntityFrameworkCore;
using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {
	public class SessionRepo {
		private readonly TomeOfHoldingContext _context;

		public SessionRepo(TomeOfHoldingContext context) {
			_context = context;
		}

		public async Task<List<Session>> GetSessions() {
			return await _context.Sessions.ToListAsync();
		}
	}
}
