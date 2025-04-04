using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class CharacterService {
		private readonly CharacterRepo _characterRepo;

		public CharacterService(CharacterRepo characterRepo) {
			_characterRepo = characterRepo;
		}

		public async Task<List<Character>> GetCharacters() {
			return await _characterRepo.GetCharacters();
		}

		public async Task<Character> GetCharacterById(int id) {
			return await _characterRepo.GetCharacterById(id);
		}

		// Add list of characters by player
	}
}
