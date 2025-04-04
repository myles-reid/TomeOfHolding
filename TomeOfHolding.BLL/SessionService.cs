using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class SessionService {
		private readonly SessionRepo _sessionRepo;

		public SessionService(SessionRepo sessionRepo) {
			_sessionRepo = sessionRepo;
		}

		public async Task<List<Session>> GetSessions() {
			return await _sessionRepo.GetSessions();
		}
	}
}
