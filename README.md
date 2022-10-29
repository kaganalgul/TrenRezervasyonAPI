# TrenRezervasyonAPI

- Database işlemleri yapılmıştır ancak QueryHandler class'ında kullanılmamaktadır. İstenirse veri database'den kontrol edilebilir.
- Integration Testleri Postman üzerinden yapılmıştır.
- Request:
```javascript
{
    "Tren":
    {   "Id":"1",
        "Ad":"Başkent Ekspres",
        "Vagonlar":
        [
            {"Ad":"Vagon 1", "Kapasite":100, "DoluKoltukAdet":68},
            {"Ad":"Vagon 2", "Kapasite":90, "DoluKoltukAdet":50},
            {"Ad":"Vagon 3", "Kapasite":80, "DoluKoltukAdet":80}
        ]
    },
    "RezervasyonYapilacakKisiSayisi":3,
    "KisilerFarkliVagonlaraYerlestirilebilir":true
}
```
formatında atılarak test edilebilir.

- Yapının, istenilen request-response'a uygun olması açısından property'ler Türkçe olarak kullanılmıştır.

- Database kullanılarak test edilecekse, yukarıdaki verilen Tren ve Vagon table ları aynı column isimlerine sahip olacak şekilde oluşturulmuştur. Yukarıdaki istek veri,
migration eklenip update edildiğinde aynı verilerle database'e 'Seed' olarak oluşturulur.
