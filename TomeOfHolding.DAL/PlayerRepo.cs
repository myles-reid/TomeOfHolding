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

        public async Task<Player> GetPlayerById(int id) {
            return await _context.Players.FindAsync(id);
        }

        public async Task DeletePlayer(int PlayerId) {
            Player player = await _context.Players.FindAsync(PlayerId);
            if (player != null) {
                _context.Players.Remove(player);
                await _context.SaveChangesAsync();
            }
        }
	}
}
