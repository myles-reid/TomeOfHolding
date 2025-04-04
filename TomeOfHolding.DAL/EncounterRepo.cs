using Microsoft.EntityFrameworkCore;
using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {
	public class EncounterRepo {
		private readonly TomeOfHoldingContext _context;

		public EncounterRepo(TomeOfHoldingContext context) {
			_context = context;
		}

		public async Task<List<Encounter>> GetEncounters() {
			return await _context.Encounters.ToListAsync();
		}

		public async Task<List<Encounter>> GetEncountersBySession(int sessionId) {
			return await _context.Encounters.Where(e => e.SessionId == sessionId).ToListAsync();
		}

		public async Task CreateEncounter(Encounter encounter) {
			_context.Encounters.Add(encounter);
			await _context.SaveChangesAsync();
		}
	}
}
