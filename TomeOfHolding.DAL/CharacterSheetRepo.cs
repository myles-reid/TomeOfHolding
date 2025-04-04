using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {
	public class CharacterSheetRepo {
		private readonly TomeOfHoldingContext _context;

		public CharacterSheetRepo(TomeOfHoldingContext context) {
			_context = context;
		}

		public async Task<CharacterSheet> GetCharacterSheet(int characterId) {
			return await _context.CharacterSheets.FindAsync(characterId);
		}
	}
}
