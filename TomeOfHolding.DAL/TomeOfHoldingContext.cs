using Microsoft.EntityFrameworkCore;

namespace TomeOfHolding.DAL {
	public class TomeOfHoldingContext : DbContext {

		public TomeOfHoldingContext(DbContextOptions<TomeOfHoldingContext> options) : base(options) {
		}
	}
}
