# Northwind.Api
- MVC Projesi açıldı.
- Northwind kullanıldı.
-------------------------------------------
- Client üzerinden egzersiz yapılmak için açılmış bir proje.
- Verilen web servisde crud işlemleri hazır bir api üzerinden??

# Project 1 - Northwind.Api
- Aşağıdaki paketler install edildi.
  - Newtonsoft.Json
- [Northwind api json'larına ulaşmak için](https://northwind.vercel.app/)
- **Controller Folder**
  - CategoryControler
- **Models Folder**
- **NOT:** Elimizdeki json dosyasını APi sonucunu convert ederek classımıza o propertyleri yazıyoruz.
  - Category
  - WebApiClient
  - ApiUrl
 - **Views Folder**
  Her zaman olduğu gibi controller içindeki methodlar için view oluştur.
  
  - **NOT:** SweetAlert için  Manage Client Side de Libman.json dosyası açılacak o kısıma yaz. Sonra Layout içine script olarak link eklendi ki çalışabilsin.
  
  - NOT: Bir tane generic bir APi yazıldi(WebApiClient) generiz olduğu için tüm controllerla ile iletişim haline geçebilecek. Apide yazdığımız crud işlemler ile Controllerlar arasında bağlantı kuruldu. Bu sayade her controller içinde yaptığımız crud işlemleri WebApiClient üzerinden yönlendirildi.

