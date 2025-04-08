using TomeOfHolding.BLL.Exceptions;
using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class CharacterSheetService {
		private readonly CharacterSheetRepo _characterSheetRepo;

		public CharacterSheetService(CharacterSheetRepo characterSheetRepo) {
			_characterSheetRepo = characterSheetRepo;
		}

		public async Task<CharacterSheet> GetCharacterSheet(int characterId) {
			CharacterSheet? sheet = await _characterSheetRepo.GetCharacterSheet(characterId);
			return sheet ?? throw new NotFoundException("No Character Sheet for that character");
		}

		public async Task CreateCharacterSheet(CharacterSheet characterSheet) {
			// add validation
			await _characterSheetRepo.CreateCharacterSheet(characterSheet);
		}


		public async Task DeleteCharacterSheet(int characterId) {
			CharacterSheet? cs = await _characterSheetRepo.GetCharacterSheet(characterId) ??
				throw new NotFoundException("No character Sheet with that character");
			await _characterSheetRepo.DeleteCharacterSheet(characterId);
		}

		public async Task UpdateCharacterSheet(CharacterSheet characterSheet) {
			CharacterSheet? cs = await _characterSheetRepo.GetCharacterSheet(characterSheet.CharacterId) ??
				throw new NotFoundException("No character Sheet with that character");
			await _characterSheetRepo.UpdateCharacterSheet(characterSheet);
		}
	}
}
