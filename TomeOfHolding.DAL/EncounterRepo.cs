using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {
	public class EncounterRepo {
		private readonly TomeOfHoldingContext _context;

		public EncounterRepo(TomeOfHoldingContext context) {
			_context = context;
		}

		public List<Encounter> GetEncounters() {
			return _context.Encounters.ToList();
		}

		public List<Encounter> GetEncountersBySession(int sessionId) {
			return _context.Encounters.Where(e => e.SessionId == sessionId).ToList();
		}
	}
}
