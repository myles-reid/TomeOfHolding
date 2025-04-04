using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {
	public class CharacterSheetRepo {
		private readonly TomeOfHoldingContext _context;

		public CharacterSheetRepo(TomeOfHoldingContext context) {
			_context = context;
		}

		public List<CharacterSheet> GetCharacterSheets() {
			return _context.CharacterSheets.ToList();
		}
	}
}
