using MediatR;
using TrenRezervasyon.ApplicationCore.Entities.Concrete;
using TrenRezervasyon.Presentation.CQRS.Queries.Response;

namespace TrenRezervasyon.Presentation.CQRS.Queries.Request
{
    public class CheckReservationQueryRequest : IRequest<CheckReservationQueryResponse>
    {
        public Tren Tren { get; set; }
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}
