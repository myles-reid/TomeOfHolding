﻿using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class CharacterSheetService {
		private readonly CharacterSheetRepo _characterSheetRepo;

		public CharacterSheetService(CharacterSheetRepo characterSheetRepo) {
			_characterSheetRepo = characterSheetRepo;
		}

		public async Task<CharacterSheet> GetCharacterSheet(int characterId) {
			return await _characterSheetRepo.GetCharacterSheet(characterId);
		}

		public async Task CreateCharacterSheet(CharacterSheet characterSheet) {
			await _characterSheetRepo.CreateCharacterSheet(characterSheet);
		}


		public async Task DeleteCharacterSheet(int characterId) {
			await _characterSheetRepo.DeleteCharacterSheet(characterId);
		}

		public async Task UpdateCharacterSheet(CharacterSheet characterSheet) {
			await _characterSheetRepo.UpdateCharacterSheet(characterSheet);
		}
	}
}
