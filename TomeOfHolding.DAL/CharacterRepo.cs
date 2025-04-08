using Microsoft.EntityFrameworkCore;
using TomeOfHolding.Models;

namespace TomeOfHolding.DAL {
	public class CharacterRepo {
		private readonly TomeOfHoldingContext _context;

		public CharacterRepo(TomeOfHoldingContext context) {
			_context = context;
		}

		public async Task<List<Character>> GetCharacters() {
			return await _context.Characters.ToListAsync();
		}

		public async Task<Character> GetCharacterById(int id) {
			return await _context.Characters.FindAsync(id);
		}

		//public List<Character> GetCharactersByPlayer(int playerId) {
		//	return _context.Characters.Where(c => c.PlayerId == playerId).ToList();
		//}

		public async Task CreateCharacter(Character character) {
			_context.Characters.Add(character);
			await _context.SaveChangesAsync();
		}


		public async Task DeleteCharacter(int id) {
			Character character = await _context.Characters.FindAsync(id);
			if (character != null) {
				_context.Characters.Remove(character);
				await _context.SaveChangesAsync();
			}
		}

		public async Task UpdateCharacter(Character character) {
			_context.Characters.Update(character);
			await _context.SaveChangesAsync();
		}
	}
}
