using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class EncounterService {
		private readonly EncounterRepo _encounterRepo;

		public EncounterService(EncounterRepo encounterRepo) {
			_encounterRepo = encounterRepo;
		}

		public async Task<List<Encounter>> GetEncounters() {
			return await _encounterRepo.GetEncounters();
		}

		public async Task<List<Encounter>> GetEncountersBySession(int sessionId) {
			return await _encounterRepo.GetEncountersBySession(sessionId);
		}
	}
}
