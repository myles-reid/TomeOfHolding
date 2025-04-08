using TomeOfHolding.BLL.Exceptions;
using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class EncounterService {
		private readonly EncounterRepo _encounterRepo;

		public EncounterService(EncounterRepo encounterRepo) {
			_encounterRepo = encounterRepo;
		}

		public async Task<List<Encounter>> GetEncounters() {
			List<Encounter>? encounters = await _encounterRepo.GetEncounters();
			if (encounters == null || encounters.Count == 0) {
				throw new NotFoundException("No encounters found.");
			} else {
				return encounters;
			}
		}

		public async Task<Encounter> GetEncounterById(int id) {
			Encounter? encounter = await _encounterRepo.GetEncounterById(id);
			return encounter ?? throw new NotFoundException("No encounter with that ID found.");
		}

		public async Task<List<Encounter>> GetEncountersBySession(int sessionId) {
			List<Encounter>? encounters = await _encounterRepo.GetEncountersBySession(sessionId);
			if (encounters == null || encounters.Count == 0) {
				throw new NotFoundException("No encounters found for that session.");
			} else {
				return encounters;
			}
		}

		public async Task CreateEncounter(Encounter encounter) {
			// Add validation here, currently unsure how
			await _encounterRepo.CreateEncounter(encounter);
		}


		public async Task DeleteEncounter(int id) {
			Encounter? encounter = await _encounterRepo.GetEncounterById(id) ??
				throw new NotFoundException("No encounter with that ID found.");
			await _encounterRepo.DeleteEncounter(id);
		}

		public async Task UpdateEncounter(Encounter encounter) {
			Encounter? existingEncounter = await _encounterRepo.GetEncounterById(encounter.EncounterId) ??
				throw new NotFoundException("No encounter with that ID found.");
			await _encounterRepo.UpdateEncounter(encounter);
		}
	}
}
