using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {
	public class CharacterRepo {
		private readonly TomeOfHoldingContext _context;

		public CharacterRepo(TomeOfHoldingContext context) {
			_context = context;
		}

		public List<Character> GetCharacters() {
			return _context.Characters.ToList();
		}

		//public List<Character> GetCharactersByPlayer(int playerId) {
		//	return _context.Characters.Where(c => c.PlayerId == playerId).ToList();
		//}
	}
}
