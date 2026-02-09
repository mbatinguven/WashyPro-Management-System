washyPro - Akıllı Çamaşırhane Yönetim ve Otomasyon Sistemi
WashyPro, araç yıkama ve çamaşırhane gibi hizmet odaklı işletmelerin randevu, personel ve bakiye süreçlerini dijitalleştirmek için geliştirilmiş uçtan uca bir otomasyon sistemidir. Proje, C# Windows Forms arayüzü ile SQL Server veritabanı mimarisini birleştirerek kurumsal bir çözüm sunar.

-Teknik Özellikler ve Yetkinlikler-
Gelişmiş Randevu Sistemi: Haftalık periyotlarla sınırlandırılmış, çakışmaları önleyen ve kaynak (makine) müsaitliğine göre çalışan akıllı takvim yapısı.

Bakiye ve Finansal Mantık: Randevu ekleme (50 TL) ve iptal işlemlerinde (30 TL iade) otomatik bakiye güncelleyen finansal algoritmalar.

Kullanıcı Yetkilendirme: Müşteri ve Yönetici (Admin) rollerine göre farklılaştırılmış erişim seviyeleri ve güvenli giriş paneli.

Veri Doğrulama: Üye kayıt aşamasında Regex (Düzenli İfadeler) ile e-posta ve girdi kontrolü.

-Veritabanı Mimarisi (SQL Server)-
Projenin kalbinde yer alan gelişmiş veritabanı özellikleri:

Stored Procedures: Veri güvenliğini artırmak ve kod tekrarını önlemek için kullanılan saklı yordamlar (Örn: sp_YeniRezervasyonEkle).

Views: Karmaşık tabloları birleştirerek kullanıcı ve işlem bazlı detaylı raporlama sunan görünümler (Örn: vw_RezervasyonDetay).

Triggers: Rezervasyon yapıldığında bakiyeyi otomatik düşüren veya makine durum değişikliklerini loglayan tetikleyiciler.

-Proje İçeriği-
/src: C# Windows Forms kaynak kodları ve uygulama mantığı.

/database: SQL scriptleri (.sql) ve veritabanı yedekleri (.bak).

/docs: Proje gereksinimlerini ve ER diyagramlarını içeren kapsamlı rapor.

-Kullanılan Teknolojiler-
Dil: C# (.NET 6.0)

Veritabanı: Microsoft SQL Server

Kütüphaneler: System.Data.SqlClient


--NOT--
Bu proje üzerinde kafa yorduğum projelerden birisidir.
