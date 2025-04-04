using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class CharacterService {
		private readonly CharacterRepo _characterRepo;

		public CharacterService(CharacterRepo characterRepo) {
			_characterRepo = characterRepo;
		}

		public List<Character> GetCharacters() {
			return _characterRepo.GetCharacters();
		}
	}
}
