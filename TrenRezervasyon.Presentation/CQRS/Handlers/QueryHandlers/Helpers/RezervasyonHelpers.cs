using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrenRezervasyon.ApplicationCore.Entities.Concrete;
using TrenRezervasyon.Presentation.CQRS.Queries.Request;
using TrenRezervasyon.Presentation.CQRS.Queries.Response;

namespace TrenRezervasyon.Business.Concrete
{
    public static class RezervasyonHelpers
    {
        public static decimal TrenBosKoltukSayisi(Tren tren)
        {
            decimal trenBosKoltukSayisi = 0;
            foreach (var vagon in tren.Vagonlar)
            {
                if (vagon.Kapasite * 0.7 > vagon.DoluKoltukAdet)
                    trenBosKoltukSayisi += (decimal) (vagon.Kapasite * 0.7) - vagon.DoluKoltukAdet;
            }
            return trenBosKoltukSayisi;
        }

        public static decimal VagonBosKoltuk(Vagon vagon)
        {
            return (decimal)((vagon.Kapasite * 0.7) - vagon.DoluKoltukAdet);
        }

        public static CheckReservationQueryResponse CheckReservationIfDifferentWagonIsAvailable(Tren tren, CheckReservationQueryResponse response, decimal kisiSayisi)
        {
            foreach (var vagon in tren.Vagonlar)
            {
                decimal vagonBosKoltukSayisi = RezervasyonHelpers.VagonBosKoltuk(vagon);
                if (kisiSayisi >= vagonBosKoltukSayisi && vagonBosKoltukSayisi > 0)
                {
                    kisiSayisi -= vagonBosKoltukSayisi;
                    response.RezervasyonYapilabilir = true;
                    response.YerlesimAyrintilar.Add(new()
                    {
                        VagonAdi = vagon.Ad,
                        KisiSayisi = vagonBosKoltukSayisi
                    });
                }
                else if (kisiSayisi < vagonBosKoltukSayisi && kisiSayisi > 0)
                {
                    response.RezervasyonYapilabilir = true;
                    response.YerlesimAyrintilar.Add(new()
                    {
                        VagonAdi = vagon.Ad,
                        KisiSayisi = kisiSayisi
                    });
                    return response;
                }
            }
            return response;
        }

        public static CheckReservationQueryResponse CheckReservationIfDiffrenetWagonIsNotAvailable(Tren tren, CheckReservationQueryResponse response, decimal kisiSayisi)
        {
            foreach (var vagon in tren.Vagonlar)
            {
                decimal vagonBosKoltukSayisi = RezervasyonHelpers.VagonBosKoltuk(vagon);
                if (vagonBosKoltukSayisi >= kisiSayisi && kisiSayisi > 0)
                {
                    response.RezervasyonYapilabilir = true;
                    response.YerlesimAyrintilar.Add(new()
                    {
                        VagonAdi = vagon.Ad,
                        KisiSayisi = kisiSayisi
                    });
                    kisiSayisi = 0;
                }
            }
            return response;
        }

    }
}
