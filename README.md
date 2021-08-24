# TutorLBE2021
![image](https://user-images.githubusercontent.com/58657135/130463087-3488f01c-ef9f-4dc5-8f07-8241392327f2.png)
## Pengertian Game Engine
Unity adalah cross-platform game engine dimana Unity adalah berfungsi sebagai aplikasi "editor" untuk pengembangan game (Semacam halnya Photoshop adalah aplikasi editor untuk manipulasi gambar).

Dalam Unity, dikenal namanya "Unity Project". Unity project secara umunya dibedakan menjadi 2 yaitu Project 3D dan 2D. Dalam modul ini kita akan lebih lanjut membahas membuat game dalam Unity Project 2D.

## A. Setting Up Project
1. Buka Unity Hub yang telah di download.

![image](https://user-images.githubusercontent.com/58657135/130462847-8c00778e-76f6-47c2-b77a-67b45d181488.png)

2. Pilih New pada pojok kanan atas untuk membuat Project baru.

3. Pilih Template 2D untuk membuat game 2D dan isi **Project Name** untuk Nama Project Game yang ingin dibuat dan **Location** untuk lokasi project yang akan ditempatkan.

## B. Setting Up Scene
1. Pada tampilan awal terdapat panel `Hierarchy`, `SceneView`, `Gameiew`, `Inspector` dsb yang nanti akan dijelaskan sambil jalannya tutorial.
![image](https://user-images.githubusercontent.com/58657135/130573050-388c3642-9535-4312-a185-bbaed2f1b9b4.png)

2. Pertama ubah background color dari camera menjadi hitam (Select camera lalu ubah background color dari inspector)
![image](https://user-images.githubusercontent.com/58657135/130573289-a2fca422-5229-44f0-aeed-f2eacb31eced.png)

3. Lalu buat GameObject ball (dengan klik kanan pada `Hierarchy` dan mengikuti seperti di gambar)
![image](https://user-images.githubusercontent.com/58657135/130574002-dee3ea20-141e-4428-8b81-eb5711259cfb.png)
- `Hierarchy` atau `Hierarchy Window` mengandung dan menampilkan semua GameObject yang berhubungan dalam Scene yang sedang dikerjakan. GameObject seperti camera, lighting ,model 3D, dsb yang digunakan dalam Scene pasti akan tertampil dalam Hierarchy.

4. Lalu kita akan tambahkan Component RigidBody2D pada GameObject Ball
![image](https://user-images.githubusercontent.com/58657135/130574322-02b52e8c-9386-464a-97e0-d6752925c9b3.png)
- `Rigidbody2D` disini berfungsi untuk menerapkan hukum fisika pada GameObject yang kita pasang dan bisa memodifikasi value propertie seperti mass, drag, gravity, dsb pada object tersebut

5. Kita set gravity scale pada ball ke 0 (agar bola tidak jatuh),set angular drag ke 0.05, dan Freeze Z rotation
![image](https://user-images.githubusercontent.com/58657135/130575201-38ad82ce-e633-4e7e-9732-947ed9e61750.png)

6. Agar tampilan ball tidak terlalu besar, kita bisa mengecilkan scale dari ball menjadi seperti berikut (ubah dari Transform properties):
![image](https://user-images.githubusercontent.com/58657135/130575520-8a7b4d2a-fc96-4de1-910e-6f8e5d71528f.png)

7. Tambahkan Component BoxCollider2D pada GameObject Ball
![image](https://user-images.githubusercontent.com/58657135/130583278-922e9eca-88ba-4a5f-ba83-67ccdbe802f8.png)

- `BoxCollider2D` adalah Component yang berfungsi untuk menetapkan batas bagaimana sebuah objek 2D dapat "bertabrakan"/Berinteraksi dengan objek lain (terdapat collider dengan bentuk shape yang lain)






  
