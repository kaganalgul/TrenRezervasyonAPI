using TrenRezervasyon.Presentation.CQRS.Queries.Response.HelperClasses;

namespace TrenRezervasyon.Presentation.CQRS.Queries.Response
{
    public class CheckReservationQueryResponse
    {
        public bool RezervasyonYapilabilir { get; set; }
        public ICollection<YerlesimAyrintiResponse> YerlesimAyrintilar { get; set; } = new List<YerlesimAyrintiResponse>();
    }
}
