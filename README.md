 **Otomotiv Sektörüne Üretilen Kablo Ve Kablo Donanımlarının Elektriksel Test Sisteminin Tasarımı**
 <br/>
 **Kurum: TEYDEB 1505 Üniversite-Sanayi İşbirliği Destek Programı - NURSAN AŞ** 
 <br/>
 <br/>
![Alt text](https://i.ibb.co/8gWDkVH/fg.png?raw=true "Title")
<br/>
## **Özet**

Projede araçların elektrik tesisatlarının bir simülasyon programı ile kontrol edilmesi sağlandı. 

Araçtaki elektrik tesisatının şemaları programa entegre edildi. Şemalar üzerinde koordinat, genişlik, uzunluk vb.. bilgileri .gsr formatında saklandı. 

Kontrol butonuna basıldığında ilgili şemayla ilgili dosyaya ulaşarak kablo pinlerinin tek tek kontrolü sağlandı.

**Araçların tesisatları şu şekildedir;**

**Tampon Tesisatı:** Ön ve arka tampon tesisatları, otomotiv teknolojisi ilerleyip park
sistemleri standart bir hale gelmeye başladıktan sonra arka tampon üzerinde yer alan
sensor, kamera gibi cihazların işlevlerini yerine getirmesini sağlamak üzere görev alan
elektrik kablo demetleridir.
<br/>
**HIS Tesisatı:** Araçta bulunan ısıtma soğutma ve havalandırma sistemlerini besler ve
kontrol eder. Genellikle HIS ünitesi üzerinde araca monte edilir.
<br/>
**Kapı Tesisatı:** Aracın tasarımına göre sayısı değişmekle birlikte arka tesisat üzerinden
kapılara bağlı cihazların (cam açma, dış ayna, kapı lambası, vb) işlevlerini yerine
getirmesini sağlayan tesisatlardır. Standart bir binek araçta sürücü kapı tesisatı, yolcu kapı
tesisatı ve 2 adet arka kapı tesisatı vardır.
<br/>
**Arka Tesisat / Gövde Tesisatı:** Araç dizayn konseptine göre “Arka Tesisat” veya “Gövde
Tesisatı” olarak adlandırılabilen ve araçtaki diğer cihazların (yakıt tankı, hava yastığı, arka
stop lambaları, vb) fonksiyonlarını sağlamak üzere direkt veya endirekt rol üstlenen büyük
kablo demetlerindendir.
<br/>
**Ana Tesisat / Kokpit Tesisatı:** Araç dizayn konseptine göre “Kokpit Tesisatı”, “IP
Tesisatı”, “Torpido Tesisatı” veya “Ana Tesisat” olarak adlandırılabilen ve aracın kontrol
mekanizmasının yer aldığı Kokpit üzerindeki cihazların (gösterge, klima, hava yastığı,
audio ve navigasyon gibi) işlevlerini yerine getirmesini sağlayan elektrik kablo demetidir.

<b>public Soket(string _soketResmi, Form _frm, string _soketAdi)</b>
- Constructor ile soketin resmini nerede oluşturulacağını ve soket ad bilgilerini alarak soketi oluşturduk.
<b>public void soketOlustur()</b>
- Soketin en boy bilgilerinin verildiği, soketin adı oluşturulduğu, Lokasyon bilgilerinin verildiği, soket yolunun alındığı, Mouse clilck, Mouse down, Mouse up, Mouse move olaylarının oluşturulduğu metot yazıldı.
<b>private void pictSoket_MouseClick(object sender, MouseEventArgs e)</b>
- Soketin oluştulmasını Mouse click eventi ile sağladık. Soketin Lokasyon,en ve boy bilgilerini alarak bize soket (picturebox) oluşturmaktadır.
<b>private void pictSoket_MouseMove(object sender, MouseEventArgs e)</b> 
- Soketin çizim işlemini Mouse move eventi ile gerçekleştirdik. Mouse hareket ettikçe imlecin hareketine bağlı olarak kare oluşturmaktadır.
<b>private void pictSoket_MouseUp(object sender, MouseEventArgs e)</b>
- Mouse sol tıklamadan parmağımızı kaldırdığımızda bu olay tetiklenmektedir. Pinleri
kaydeder, genişlik ve uzunluk bilgilerini sıfırlar ve karecizim durumunu false yapar.
<b>private void pictSoket_MouseDown(object sender, MouseEventArgs e)</b>
- Mouse sol tıklama yapıldığı an itibariyle imlecin koordinatlarını kare çizime aktarmayı sağlayan eventtir.
<b>private Pen BozukPin()</b>
- bozukPin() metodu bize kırmızı renk değerini ve çizgi kalınlığını pen sınıfı olarak geri döndürür.
<b>private Pen SaglamPin()</b> 
- saglamPin() metodu bize yeşil renk değerini ve çizgi kalınlığını pen sınıfı olarak geri döndürür.
<b>private void soketTemizle()</b>
- Ana ekrandaki tüm soketleri temizler.
<b>public void soketResmiEkle(ListBox listSoketler)</b>
- Openfiledialog sınıfı ile jpeg dosyalarını filtreleyerek soketleri projeye eklemeyi sağlar.
<b>public void soketleriListele(ListBox listSoketler)</b>
- Eklenen soketierin listbox’ta görünmesini sağlar.
<b>public void gsrSaveSoket()</b>
- Soketkerin Lokasyon, genişlik,uzunluk, renk ve şekil bilgilerini .gsr uzantılı dosyaya kaydeder.
<b>public override string ToString()</b> 
- ToString Metodunu override ederek Lokasyon, genişlik,uzunluk, renk ve şekil bilgilerini yazdırdık.
