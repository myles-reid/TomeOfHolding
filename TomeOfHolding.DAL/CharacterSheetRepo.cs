﻿using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {
	public class CharacterSheetRepo {
		private readonly TomeOfHoldingContext _context;

		public CharacterSheetRepo(TomeOfHoldingContext context) {
			_context = context;
		}

		public async Task<CharacterSheet> GetCharacterSheet(int characterId) {
			return await _context.CharacterSheets.FindAsync(characterId);
		}

		public async Task CreateCharacterSheet(CharacterSheet characterSheet) {
			_context.CharacterSheets.Add(characterSheet);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteCharacterSheet(int characterId) {
			CharacterSheet characterSheet = await _context.CharacterSheets.FindAsync(characterId);
			if (characterSheet != null) {
				_context.CharacterSheets.Remove(characterSheet);
				await _context.SaveChangesAsync();
			}
		}

		public async Task UpdateCharacterSheet(CharacterSheet characterSheet) {
			_context.CharacterSheets.Update(characterSheet);
			await _context.SaveChangesAsync();
		}
	}
}
