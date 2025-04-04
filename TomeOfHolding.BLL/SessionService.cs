using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class SessionService {
		private readonly SessionRepo _sessionRepo;

		public SessionService(SessionRepo sessionRepo) {
			_sessionRepo = sessionRepo;
		}

		public List<Session> GetSessions() {
			return _sessionRepo.GetSessions();
		}
	}
}
