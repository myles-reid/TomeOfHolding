using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class PlayerService {
		private readonly PlayerRepo _playerRepo;

		public PlayerService(PlayerRepo playerRepo) {
			_playerRepo = playerRepo;
		}

		public async Task<List<Player>> GetPlayers() {
			return await _playerRepo.GetPlayers();
		}

		public async Task CreatePlayer(Player player) {
			//add validation here, currently unsure how
			await _playerRepo.CreatePlayer(player);
		}
	}
}
