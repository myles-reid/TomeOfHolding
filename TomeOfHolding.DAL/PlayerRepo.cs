using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {
	public class PlayerRepo {
		private readonly TomeOfHoldingContext _context;

		public PlayerRepo(TomeOfHoldingContext context) {
			_context = context;
		}

		public List<Player> GetPlayers() {
			return _context.Players.ToList();
		}
	}
}
