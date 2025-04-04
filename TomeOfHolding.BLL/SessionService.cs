using TomeOfHolding.DAL;

namespace TomeOfHolding.BLL {
	public class SessionService {
		private readonly SessionRepo _sessionRepo;

		public SessionService(SessionRepo sessionRepo) {
			_sessionRepo = sessionRepo;
		}
	}
}
