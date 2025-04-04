using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class PlayerService {
		private readonly PlayerRepo _playerRepo;

		public PlayerService(PlayerRepo playerRepo) {
			_playerRepo = playerRepo;
		}

		public List<Player> GetPlayers() {
			return _playerRepo.GetPlayers();
		}
	}
}
