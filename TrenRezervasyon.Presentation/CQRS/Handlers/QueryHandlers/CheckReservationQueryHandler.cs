using MediatR;
using TrenRezervasyon.ApplicationCore.Entities.Concrete;
using TrenRezervasyon.Business.Concrete;
using TrenRezervasyon.Presentation.CQRS.Queries.Request;
using TrenRezervasyon.Presentation.CQRS.Queries.Response;

namespace TrenRezervasyon.Presentation.CQRS.Handlers.QueryHandlers
{
    public class CheckReservationQueryHandler : IRequestHandler<CheckReservationQueryRequest, CheckReservationQueryResponse>
    {
        public async Task<CheckReservationQueryResponse> Handle(CheckReservationQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                CheckReservationQueryResponse response = new();
                Tren tren = request.Tren;
                decimal kisiSayisi = request.RezervasyonYapilacakKisiSayisi;             
                decimal trenBosKoltukSayisi = RezervasyonHelpers.TrenBosKoltukSayisi(request.Tren);

                if (tren == null || request.RezervasyonYapilacakKisiSayisi > trenBosKoltukSayisi)
                {
                    return response;
                }

                if (request.KisilerFarkliVagonlaraYerlestirilebilir && kisiSayisi <= trenBosKoltukSayisi)
                {
                    return RezervasyonHelpers.CheckReservationIfDifferentWagonIsAvailable(tren, response, kisiSayisi);
                }
                else
                {
                    return RezervasyonHelpers.CheckReservationIfDiffrenetWagonIsNotAvailable(tren, response, kisiSayisi);
                }
            }
            catch (Exception)
            {           
                throw;
            }
        }
        
    }
}


