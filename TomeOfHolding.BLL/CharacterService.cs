using TomeOfHolding.DAL;

namespace TomeOfHolding.BLL {
	public class CharacterService {
		private readonly CharacterRepo _characterRepo;

		public CharacterService(CharacterRepo characterRepo) {
			_characterRepo = characterRepo;
		}
	}
}
