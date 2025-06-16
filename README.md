# Blog Platformu Web API

Bu proje, kullanıcıların güvenli bir şekilde kayıt olup giriş yapabildiği, rol tabanlı yetkilendirme ile yetkilendirildiği ve JWT (JSON Web Token) ile güvenli oturum yönetimi sağlayan kapsamlı bir blog platformu API'sidir. Proje, modern yazılım geliştirme prensipleri ve ölçeklenebilir bir yapı sunmak üzere N-Tier mimarisiyle tasarlanmıştır.

## Öne Çıkan Özellikler

* **Kullanıcı Kayıt ve Giriş (Register/Login):** ASP.NET Core Identity ile güvenli şifre hashleme ve kullanıcı yönetimi.
* **JWT ile Güvenli API Erişimi:** Token tabanlı kimlik doğrulama ile her isteğin güvenliğini sağlama.
* **Rol Yönetimi ve Yetkilendirme:** Kullanıcı rolleri (örneğin, Admin, Yazar, Okuyucu) aracılığıyla yetki bazlı erişim kontrolü.
* **Veri Taşıma ve Doğrulama:** DTO (Data Transfer Object) kullanımı ile verilerin temiz ve güvenli bir şekilde taşınması, FluentValidation ile gelen verilerin detaylı doğrulanması.
* **N-Tier Mimari:** Sunum, İş, Veri Erişim katmanlarına ayrılmış yapı sayesinde kolay bakım, yüksek ölçeklenebilirlik ve sürdürülebilirlik.

## Kullanılan Teknolojiler

* **ASP.NET Core Web API**
* **ASP.NET Core Identity**
* **JWT Authentication**
* **N-Tier Architecture**
* **DTOs**
* **FluentValidation**

Proje, temel authentication işlemlerinden gelişmiş yetkilendirme mekanizmalarına kadar modern bir web API'sinin tüm gereksinimlerini karşılamaktadır.


