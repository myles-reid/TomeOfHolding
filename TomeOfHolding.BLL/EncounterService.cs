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

		public async Task<Encounter> GetEncounterById(int id) {
			return await _encounterRepo.GetEncounterById(id);
		}

		public async Task<List<Encounter>> GetEncountersBySession(int sessionId) {
			return await _encounterRepo.GetEncountersBySession(sessionId);
		}

		public async Task CreateEncounter(Encounter encounter) {
			// Add validation here, currently unsure how
			await _encounterRepo.CreateEncounter(encounter);
		}


		public async Task DeleteEncounter(int id) {
			await _encounterRepo.DeleteEncounter(id);
		}

		public async Task UpdateEncounter(Encounter encounter) {
			await _encounterRepo.UpdateEncounter(encounter);
		}
	}
}
