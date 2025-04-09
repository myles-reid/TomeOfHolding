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

        public async Task<List<Player>> GetPlayerbyId(List<int> ids) {
            return await _playerRepo.GetPlayerbyId(ids);
        }

        public async Task CreatePlayer(Player player) {
			//add validation here, currently unsure how
			await _playerRepo.CreatePlayer(player);
		}


		public async Task<Player> GetPlayerById(int id) {
			return await _playerRepo.GetPlayerById(id);
		}

		public async Task DeletePlayer(int playerId) {
			await _playerRepo.DeletePlayer(playerId);
		}

		public async Task UpdatePlayer(Player player) {
			await _playerRepo.UpdatePlayer(player);
		}
	}
}
