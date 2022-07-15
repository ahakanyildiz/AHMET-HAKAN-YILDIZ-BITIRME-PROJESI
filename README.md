
# AMAÇ VE PROJE DETAYLARI

**PROJENİN AMACI:** IMDB benzeri bir ortamın ihtiyacı olan API.

 Swagger'da token alabilmek için **admin** bilgileri;
**K.Adı:** "Hakan" (Kullanıcı adında büyük, küçük harf duyarlılığı yok)
**Şifre: **"Arvato123"

> ##### Postgre'de dbMovie bir veritabanı oluşturun, oluşan veritabanına sağ tıklayıp restore deyin, açılan pencereden vermiş olduğum sql imajını import edin.
##### Veritabanı bağlantı adresi MovieDbContext'e tanımlandı.Bağlantı adresini kendi serverınıza göre değiştiriniz.

## Kullanılan Teknolojiler

> -  Net 6
- Ef Core
- Web Api
- Postgresql
- Swagger
- Redis

## Multitier architecture

>  Proje 4 katmandan oluşturuldu.Bu katmanlar sırasıyla;

**Movies.Entities:** Bu katmanda oluşturmak istediğim tabloların modellerini, bu tabloların configuration'larını,Dbcontext sınıfını yazdım.Daha sonra EF Core ile migration
ekleyip bu migrationlar aracılığıyla database tarafını da güncelledim.

**Movies.DataAccess:** Bu katmanda öncelikle veritabanından sorgulama yapacak methodlarımı interface'de tanıdım daha sonra repository class'larına implement ettim. Ve hepsinin
amacına göre DBContext'i kullanarak sorguları gerçekleştirdim.JWT methodlarını da bu katmanda yazdım.

**Movies.Business:** Bu katmanda oluşturulan uygulamaların işleyişlerini gösterdim. Tabi bu katmana ilerleyen süreçlerde iş kurallarımı da yazabilirim.

**Movies.Api:** Startup olarak kullandığım bu katman Solution çalıştırıldığında ayağa kalkacak ilk katmandır.Çoğu konfigürasyon burda tanımlandı, bir çok iş buraya yazıldı.
Ve nihayetinde endpointlerimizin himayesi altında olduğu ve requestlere response veren katmanımız bura, bi nevi sunum katmanımız aslında.


## Endpoints

> Totalde User,Genre,Movie,Trendings olmak üzere 4 adet controller yazıldı.

**Movies Controller(9)=>** *GetAllMovies,AddMovie,DeleteMovie,UpdateMovie,GetMovieDetail,GetMovieListByGenreId,GetMovieListByRateFilter,GetMovieListByRelaseDate,Search *

**Genre Controller(5) =>** *GetAllGenre,GetGenreById,AddGenre,UpdateGenre,Delete*

**Trendings Controller(2) =>***ListMostViewed10Movies , ListTopRated10Movies *

**User Controller(1) =>** *Login*

## Authentication(JWT)

> Veritabanında kullanıcı bilgilerinin tutulabilmesi için tblUser adında bir tablo oluşturdum. Daha sonra user datalarında password kısmının MD5 biçimde crypt edilebilmesi için Movies.DataAcces katmanında UserRepository class'ında GetMd5ByPassword adında bir method oluşturdum.Bu method girdiğimiz stringleri MD5 olarak kendi algoritmasına göre şifreliyor.Kullanıcı adımı 'Hakan' şifremi de 'Arvato123' olarak belirledim. Bu methodu ayrı bir console uygulamasında çalıştırıp "Arvato123"'ü MD5 olarak şifreledim. Ve veritabanında MD5 şifreli bir şekilde bilgilerimi kaydettim. Login yaparken api tarafında girdiğiniz şifreyi önce MD5 dönüştürüyor daha sonra veritabanında eşleşmeyi başlatıyor.Eşleşme olursa karşılığında 10 dakika ömrü olan bir token üretiyor ve response ediyor. Token'ı Swagger'ın header bölümündeki Authorize butonuna tıklayıp yapıştırıp logine tıklarsanız admin izni isteyen controller'ların kilidi düşecek ve kullanılabilecek.

## REDİS
> Movies.DataAccess/Redis/RedisHelper.cs class'ına, kullanabileceğim redis methodlarımı yazdım.Bunlar SetList,GetList,SetKey ve GetKey.

***Bu methodları kullandığım endpointler ve sebepleri;***

**1-)MovieController ->** Delete: Her silinen videonun ID'sini,IMDB_ID'sini ve Rate'sini RedisServer'da bir liste içerisinde tuttum, olur da geri almak istediğim 
puanları yüksek filmler olursa IMDB'id sine göre bulabileyim.

**2-)MovieController ->** GetMovieDetail: Son aranan videonun id'sini ve görüntülenme sayısını Redis serverda tuttum.

**3-)UserController ->** Login: Sisteme giriş yapan kullanıcıların Kullanıcı adı ve giriş yaptıkları tarih ve saati loglamak istediğim için bir liste içerisinde
RedisServer'da tuttum.

## Görüntülenme Sayısı-Views(GetMovieDetail)

> Veritabanında Movie'leri tuttuğum tabloda her movie için görüntülenme kayıtlarını tutmak için default değeri "0" olan views sütünu oluşturdum. GetMovieDetail endpoint'i her çağrıldığında id'si girilen videonun görüntülenme sayısı (views değeri) 1'er 1'er artıyor.

**Detay: **Movies.DataAccess/Concrete/MovieRepository.cs









