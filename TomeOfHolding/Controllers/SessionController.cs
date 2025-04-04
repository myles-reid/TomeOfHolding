using Microsoft.AspNetCore.Mvc;
using TomeOfHolding.BLL;

namespace TomeOfHolding.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class SessionController : ControllerBase {
		private readonly SessionService _sessionService;

		public SessionController(SessionService sessionService) {
			_sessionService = sessionService;
		}
	}
}
