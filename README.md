 **Otomotiv Sektörüne Üretilen Kablo Ve Kablo Donanımlarının Elektriksel Test Sisteminin Tasarımı**
 <br/>
 **Kurum: TEYDEB 1505 Üniversite-Sanayi İşbirliği Destek Programı - NURSAN AŞ** 
 <br/>
 <br/>
![Alt text](https://i.ibb.co/8gWDkVH/fg.png?raw=true "Title")
<br/>

# **Overview**

Projede araçların elektrik tesisatlarının bir simülasyon programı ile kontrol edilmesi sağlandı. 

Araçtaki elektrik tesisatının şemaları programa entegre edildi. Şemalar üzerinde koordinat, genişlik, uzunluk vb.. bilgileri .gsr formatında saklandı. 

Kontrol butonuna basıldığında ilgili şemayla ilgili dosyaya ulaşarak kablo pinlerinin tek tek kontrolü sağlandı.

# **Technologies**
- C#
- Directory Sınıf (System.IO)
- XML
- OOP
- Design Pattern

## **Soket.cs**

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

## **SoketTestEt.cs**

<b>void btnPinOlustur(int toplamPin)</b>
- .gsr uzantılı dosyadan aldığı pin sayısı kadar buton oluşturmaktadır. Gerekli olan en, boy, name, text event bilgileri yazılmıştır.

<b>private void btnPinClick(Object sender, EventArgs e)</b>
- Oluşturulan butonların kırmızı, yeşil veya beyaz yaparak o an ki varsayılan değerleri girilmektedir. Örneğin yeşil butonsa sağlam, kırmızı ise bozuk ve beyaz ise devre dışı olmaktadır.

<b>public void gsrOku(ListBox listSoketler)</b> 
- Oluşturulan .gsr uzantılı dosyadan koordinat ve pin sayısını okuyarak gerekli işlemlerin yapılmasını sağlar.

<b> public void soketTestEt()</b>
- En son işlemler bittikten sonra gelen değerlerin Raspberry’den geliyormuş gibi değerlendirilerek soketlerdeki pinlerin durumu hakkında bilgi vermektedir

# **Support**

Herhangi bir sorun, geri bildirim veya özellik talebi için omerfaruk56@live.com adresine bir e-posta gönderin, github'da bir Issues oluşturun
<br>
