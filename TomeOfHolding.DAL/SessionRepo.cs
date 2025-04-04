using Microsoft.EntityFrameworkCore;
using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {
	public class SessionRepo {
		private readonly TomeOfHoldingContext _context;

		public SessionRepo(TomeOfHoldingContext context) {
			_context = context;
		}

		public async Task<List<Session>> GetSessions() {
			return await _context.Sessions.ToListAsync();
		}

		public async Task CreateSession(Session session) {
			_context.Sessions.Add(session);
			await _context.SaveChangesAsync();
		}
	

        public async Task<Session> GetSessionById(int id) {
            return await _context.Sessions.FindAsync(id);
        }

        public async Task DeleteSession(int sessionId) {
            Session session = await _context.Sessions.FindAsync(sessionId);
            if (session != null) {
                _context.Sessions.Remove(session);
                await _context.SaveChangesAsync();
            }
        }
    }
}
