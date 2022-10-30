using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrenRezervasyon.Presentation.CQRS.Queries.Request;
using TrenRezervasyon.Presentation.CQRS.Queries.Response;

namespace TrenRezervasyon.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        IMediator _mediator;
        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/check-reservation")]
        public async Task<IActionResult> CheckReservation([FromBody] CheckReservationQueryRequest requestModel)
        {
            CheckReservationQueryResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }
    }
}
