using TomeOfHolding.DAL;

namespace TomeOfHolding.BLL {
	public class CharacterSheetService {
		private readonly CharacterSheetRepo _characterSheetRepo;

		public CharacterSheetService(CharacterSheetRepo characterSheetRepo) {
			_characterSheetRepo = characterSheetRepo;
		}
	}
}
