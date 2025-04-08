using TomeOfHolding.BLL.Exceptions;
using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class CharacterService {
		private readonly CharacterRepo _characterRepo;

		public CharacterService(CharacterRepo characterRepo) {
			_characterRepo = characterRepo;
		}

		public async Task<List<Character>> GetCharacters() {
			List<Character>? characters = await _characterRepo.GetCharacters();
			if (characters == null || characters.Count == 0) {
				throw new NotFoundException("No characters found.");
			} else {
				return characters;
			}
		}

		public async Task<Character> GetCharacterById(int id) {
			Character? character = await _characterRepo.GetCharacterById(id);
			return character ?? throw new NotFoundException("No character with that ID found.");
		}

		// Add list of characters by player

		public async Task CreateCharacter(Character character) {
			// need proper validation here
			await _characterRepo.CreateCharacter(character);
		}


		public async Task DeleteCharacter(int id) {
			Character? character = await _characterRepo.GetCharacterById(id) ?? 
				throw new NotFoundException("No character with that ID found.");
			await _characterRepo.DeleteCharacter(id);
		}

		public async Task UpdateCharacter(Character character) {
			Character? existingCharacter = await _characterRepo.GetCharacterById(character.CharacterId) ?? 
				throw new NotFoundException("No character with that ID found.");
			await _characterRepo.UpdateCharacter(character);
		}
	}
}
