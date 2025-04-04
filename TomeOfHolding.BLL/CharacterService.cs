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

		public async Task CreateCharacter(Character character) {
			await _characterRepo.CreateCharacter(character);
		}

		public async Task DeleteCharacter(int id) {
			await _characterRepo.DeleteCharacter(id);
		}

		public async Task UpdateCharacter(Character character) {
			await _characterRepo.UpdateCharacter(character);
		}
	}
}
