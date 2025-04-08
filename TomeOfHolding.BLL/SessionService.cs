using TomeOfHolding.BLL.Exceptions;
using TomeOfHolding.DAL;
using TomeOfHolding.Models;

namespace TomeOfHolding.BLL {
	public class SessionService {
		private readonly SessionRepo _sessionRepo;

		public SessionService(SessionRepo sessionRepo) {
			_sessionRepo = sessionRepo;
		}

		public async Task<List<Session>> GetSessions() {
			List<Session>? sessions = await _sessionRepo.GetSessions();
			if (sessions == null || sessions.Count == 0) {
				throw new NotFoundException("No sessions found.");
			} else {
				return sessions;
			}
		}

		public async Task<Session> GetSessionById(int id) {
			Session? session = await _sessionRepo.GetSessionById(id);
			return session ?? throw new NotFoundException("No session with that ID found.");
		}
		public async Task CreateSession(Session session) {
			//add validation here, currently unsure how
			await _sessionRepo.CreateSession(session);
		}

		public async Task DeleteSession(int sessionId) {
			Session? session = await _sessionRepo.GetSessionById(sessionId) ??
				throw new NotFoundException("No session with that ID found.");
			await _sessionRepo.DeleteSession(sessionId);
		}

		public async Task UpdateSession(Session session) {
			Session? existingSession = await _sessionRepo.GetSessionById(session.SessionId) ??
				throw new NotFoundException("No session with that ID found.");
			await _sessionRepo.UpdateSession(session);
		}
	}
}
