using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class CharacterSheetService {
		private readonly CharacterSheetRepo _characterSheetRepo;

		public CharacterSheetService(CharacterSheetRepo characterSheetRepo) {
			_characterSheetRepo = characterSheetRepo;
		}

		public List<CharacterSheet> GetCharacterSheets() {
			return _characterSheetRepo.GetCharacterSheets();
		}
	}
}
