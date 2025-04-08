using TomeOfHolding.BLL.Exceptions;
using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class PlayerService {
		private readonly PlayerRepo _playerRepo;

		public PlayerService(PlayerRepo playerRepo) {
			_playerRepo = playerRepo;
		}

		public async Task<List<Player>> GetPlayers() {
			List<Player>? players = await _playerRepo.GetPlayers();
			if (players == null || players.Count == 0) {
				throw new NotFoundException("No players found.");
			} else {
				return players;
			}
		}

		public async Task CreatePlayer(Player player) {
			//add validation here, currently unsure how
			await _playerRepo.CreatePlayer(player);
		}


		public async Task<Player> GetPlayerById(int id) {
			Player? player = await _playerRepo.GetPlayerById(id);
			return player ?? throw new NotFoundException("No player with that ID found.");
		}

		public async Task DeletePlayer(int playerId) {
			Player player = await _playerRepo.GetPlayerById(playerId) ??
				throw new NotFoundException("No player with that ID found.");
			await _playerRepo.DeletePlayer(playerId);
		}

		public async Task UpdatePlayer(Player player) {
			Player existingPlayer = await _playerRepo.GetPlayerById(player.PlayerId) ??
				throw new NotFoundException("No player with that ID found.");
			await _playerRepo.UpdatePlayer(player);
		}
	}
}
