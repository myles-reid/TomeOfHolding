using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {
	public class SessionRepo {
		private readonly TomeOfHoldingContext _context;

		public SessionRepo(TomeOfHoldingContext context) {
			_context = context;
		}

		public List<Session> GetSessions() {
			return _context.Sessions.ToList();
		}
	}
}
