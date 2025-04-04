using Microsoft.EntityFrameworkCore;
using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {
	public class PlayerRepo {
		private readonly TomeOfHoldingContext _context;

		public PlayerRepo(TomeOfHoldingContext context) {
			_context = context;
		}

		public async Task<List<Player>> GetPlayers() {
			return await _context.Players.ToListAsync();
		}
	}
}
