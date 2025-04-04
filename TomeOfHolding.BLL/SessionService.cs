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

		public async Task<Session> GetSessionById(int id) {
			return await _sessionRepo.GetSessionById(id);
		}
		public async Task CreateSession(Session session) {
			//add validation here, currently unsure how
			await _sessionRepo.CreateSession(session);
		}

        public async Task DeleteSession(int sessionId) {
            await _sessionRepo.DeleteSession(sessionId);
        }

        public async Task UpdateSession(Session session) {
            await _sessionRepo.UpdateSession(session);
        }
    }
}
