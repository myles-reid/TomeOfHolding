using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class EncounterService {
		private readonly EncounterRepo _encounterRepo;

		public EncounterService(EncounterRepo encounterRepo) {
			_encounterRepo = encounterRepo;
		}

		public List<Encounter> GetEncounters() {
			return _encounterRepo.GetEncounters();
		}

		public List<Encounter> GetEncountersBySession(int sessionId) {
			return _encounterRepo.GetEncountersBySession(sessionId);
		}
	}
}
